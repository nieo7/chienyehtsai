using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Manager_BannerCategory_Edit : BasePage
{
    BannerCategoryBLL bcBLL = new BannerCategoryBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            Bind();
        }
    }
    private void InitPage()
    {
        phtitle.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCategory", "phtitle"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCategory", "phshow"));
    }
    protected void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) > 0)
            {
                BannerCategoryInfo info = bcBLL.GetDataById(id);
                txtTitle.Text = info.bc_title;
                rbShow.SelectedValue = info.bc_show.ToString();
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BannerCategoryInfo info = bcBLL.GetDataById(id);
        info.bc_title = txtTitle.Text;
        info.bc_show = bool.Parse(rbShow.SelectedValue);
        if (bcBLL.Update(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30014"));
        }
    }
}