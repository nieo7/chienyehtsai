using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Web.UI.HtmlControls;

public partial class Manager_GBCategory_Add : BasePage
{
    GBcategoryBLL gbcBLL = new GBcategoryBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();        
    }
    private void InitPage()
    {        
        phtitle.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBCategory", "phtitle"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBCategory", "phshow"));
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        GBCategoryInfo info = new GBCategoryInfo();
        info.gbc_title = txtName.Text;
        info.gbc_show = bool.Parse(rbShow.SelectedValue);
        if (gbcBLL.Insert(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30009"));
        }
    }
}