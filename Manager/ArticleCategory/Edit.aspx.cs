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

public partial class Manager_ArticleCategory_Edit : BasePage
{
    ArticleCategoryBLL acBLL = new ArticleCategoryBLL(lid);
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            //Check_Power(1, 32, true);
            BindCategory();
            Bind();
        }
    }
    private void InitPage()
    {
        phfather.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phfather"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phname"));
        phtype.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phtype"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (acBLL.SearchHierarchyDownVail(Tools.TryParseMethod(ddlCategory.SelectedValue), id, int.Parse(UserInfoConfig.GetUserConfig("HierarchyArticleCategory"))))
        {
            ArticleCategoryInfo info = acBLL.getAllById(id);
            info.ac_name = txtName.Text;
            info.ac_type = txtType.Text;
            info.ac_fatherId = Tools.TryParseMethod(ddlCategory.SelectedValue);
            if (acBLL.Update(info) > 0)
            {
                Response.Redirect("List.aspx?header=修改訊息完成!", true);
            }
            else
            {
                ShowMessage("更新失敗: 更新類別不可為自身、不可為自身以下的子類別");
            }
        }
        else
        {
            ShowMessage("轉換類別超越階層限制數");
        }    
    }
    public void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) != 0)
            {
                ArticleCategoryInfo info = acBLL.getAllById(id);
                ddlCategory.SelectedValue = info.ac_fatherId.ToString();
                if (info.ac_fatherId == 0)
                {
                    ddlCategory.Enabled = false;
                }
                txtName.Text = info.ac_name;
                txtType.Text = info.ac_type;
            }
        }
    }
    protected void BindCategory()
    {
        ddlCategory.DataSource = acBLL.GetallSortData(0);
        ddlCategory.DataTextField = "ac_name";
        ddlCategory.DataValueField = "ac_id";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("==設定成主類別==", "0"));
    }
}
