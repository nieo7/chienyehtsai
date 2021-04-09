using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Web.UI.HtmlControls;

public partial class Manager_GBMessage_Add : BasePage
{
    GBcategoryBLL gbcBLL = new GBcategoryBLL();
    GBmessageBLL gbBLL = new GBmessageBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            InsertDropDown();
        }
    }
    private void InitPage()
    {
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phcategory"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phname"));
        phmail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phmail"));
        phtitle.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phtitle"));
        phshowmail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phshowmail"));
        phcontent.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phcontent"));        
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phshow"));
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        GBmessageInfo info = new GBmessageInfo();
        info.gbc_Id = int.Parse(ddlCategory.SelectedValue);
        info.gb_name = txtName.Text;
        info.gb_mail = txtMail.Text;
        info.gb_show_mail = bool.Parse(ChkVisible.Checked.ToString());
        info.gb_ip = Tools.GetIpAddress();
        info.gb_title = txtTitle.Text;
        info.gb_content = Ckeditorl1.Text;
        info.gb_createdate = DateTime.Now;
        info.gb_editdate = DateTime.Now;
        info.gb_show = bool.Parse(rbShow.SelectedValue);
        if (gbBLL.Insert(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30009"));
        }
    }
    public void InsertDropDown()
    {
        ddlCategory.DataSource = gbcBLL.GetData();
        ddlCategory.DataTextField = "gbc_title";
        ddlCategory.DataValueField = "gbc_id";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("==請選擇類別==", "0"));
    }
}