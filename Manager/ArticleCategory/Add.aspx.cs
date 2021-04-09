using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using BLL;
using Model;

public partial class Manager_ArticleCategory_Add : BasePage
{
    ArticleCategoryBLL acBLL = new ArticleCategoryBLL(lid);
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            //檢查權限
            //Check_Power(1, 2, true);             
            BindCategory();
        }        
    }
    private void InitPage()
    {
        phfather.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phfather"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phname"));
        phtype.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phtype"));        
    }
    protected void BindCategory()
    {
        ddlCategory.DataSource = acBLL.GetallSortData(0);
        ddlCategory.DataTextField = "ac_name";
        ddlCategory.DataValueField = "ac_id";        
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("==新增主類別==", "0"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {        
        if (ddlCategory.SelectedValue != "0")
        {
            if (acBLL.SearchHierarchyUpVail(int.Parse(ddlCategory.SelectedValue), int.Parse(UserInfoConfig.GetUserConfig("HierarchyArticleCategory"))))
            {
                InsertData();
            }
            else
            {
                ShowMessage("新增超越限制階層");
            }
        }
        else
        {
            InsertData();
        }
    }
    protected void InsertData()
    {
        ArticleCategoryInfo info = new ArticleCategoryInfo();
        info.ac_fatherId = int.Parse(ddlCategory.SelectedValue);
        info.ac_name = txtName.Text;
        info.ac_type = txtType.Text;
        info.l_id = lid;
        if (acBLL.Insert(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30009"));
        }
    }
}

