using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Manager_GBCategory_Edit : BasePage
{
    GBcategoryBLL gbcBLL = new GBcategoryBLL();
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
        phtitle.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBCategory", "phtitle"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBCategory", "phshow"));
    }
    protected void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) > 0)
            {
                GBCategoryInfo info = gbcBLL.GetDataById(id);
                txtName.Text = info.gbc_title;
                rbShow.SelectedValue = info.gbc_show.ToString();
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        GBCategoryInfo info = gbcBLL.GetDataById(id);
        info.gbc_title = txtName.Text;
        info.gbc_show = bool.Parse(rbShow.SelectedValue);
        if (gbcBLL.Update(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30014"));
        }
    }
}