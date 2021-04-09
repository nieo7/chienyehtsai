using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Manager_BannerLocation_Add :BasePage
{
    BannerLocationBLL blBLL = new BannerLocationBLL();    
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {            
            InsertDropdown();
        }
    }
    protected void InitPage()
    {
        phfather.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerLocation", "phfather"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerLocation", "phname"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerLocation", "phshow"));        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedValue != "0")
        {
            //動態載入階層值            
            if (blBLL.SearchHierarchyUpVail(Tools.TryParseMethod(ddlCategory.SelectedValue), int.Parse(UserInfoConfig.GetUserConfig("HierarchyProductCategory"))))
            {
                InsertData();
            }
            else
            {
                ShowMessage("超過可新增階層最大值");
            }
        }
        else
        {
            InsertData();
        }
    }
    protected void InsertData()
    {
        BannerLocationInfo info = new BannerLocationInfo();
        info.bl_father_id = Tools.TryParseMethod(ddlCategory.SelectedValue);
        info.bl_title = txtName.Text;
        info.bl_show = bool.Parse(rbShow.SelectedValue);
        if (blBLL.Insert(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30009"));
        }
    }
    protected void InsertDropdown()
    {
        ddlCategory.DataSource = blBLL.GetallSortData(0);
        ddlCategory.DataTextField = "bl_title";
        ddlCategory.DataValueField = "bl_id";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("==新增廣告頁面==", "0"));
    }
}