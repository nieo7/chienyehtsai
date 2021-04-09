using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class Manager_BannerCategory_Add : BasePage
{
    BannerCategoryBLL bcBLL = new BannerCategoryBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
    }
    private void InitPage()
    {
        phtitle.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCategory", "phtitle"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCategory", "phshow"));            
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BannerCategoryInfo info = new BannerCategoryInfo();
        info.bc_title = txtTitle.Text;
        info.bc_show = bool.Parse(rbShow.SelectedValue);
        if (bcBLL.Insert(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30009"));
        }
    }
}