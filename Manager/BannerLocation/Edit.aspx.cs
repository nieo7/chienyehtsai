using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Manager_BannerLocation_Edit : BasePage
{
    BannerLocationBLL blBLL = new BannerLocationBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            InsertDropdown();
            Bind();
        }
    }
    protected void InitPage()
    {
        phfather.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerLocation", "phfather"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerLocation", "phname"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerLocation", "phshow"));        
    }
    protected void InsertDropdown()
    {
        ddlCategory.DataSource = blBLL.GetallSortData(0);
        ddlCategory.DataTextField = "bl_title";
        ddlCategory.DataValueField = "bl_id";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("==新增廣告頁面==", "0"));
    }
    protected void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) != 0)
            {
                BannerLocationInfo info = blBLL.GetDataById(id);
                ddlCategory.SelectedValue = info.bl_father_id.ToString();
                txtName.Text = info.bl_title;
                rbShow.SelectedValue = info.bl_show.ToString();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedValue != "0")
        {
            if (blBLL.SearchHierarchyDownVail(Tools.TryParseMethod(ddlCategory.SelectedValue),id,int.Parse(UserInfoConfig.GetUserConfig("HierarchyBannerLocation"))))
            {
                InsertData();
            }
            else
            {
                ShowMessage("轉換類別超越階層限制數");
            }
        }
        else
        {
            InsertData();
        }
    }
    protected void InsertData()
    {
        BannerLocationInfo info = blBLL.GetDataById(id);
        info.bl_title = txtName.Text;
        info.bl_father_id = Tools.TryParseMethod(ddlCategory.SelectedValue);
        info.bl_show = bool.Parse(rbShow.SelectedValue);
        if (blBLL.Update(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30014"));
            return;
        }
        ShowMessage("更新失敗: 更新類別不可為自身、不可為自身以下的子類別");
    }
}