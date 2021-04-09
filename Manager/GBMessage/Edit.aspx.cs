using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;


public partial class Manager_GBMessage_Edit : BasePage
{
    GBcategoryBLL gbcBLL = new GBcategoryBLL();
    GBmessageBLL gbBLL = new GBmessageBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            InsertDropDown();
            Bind();
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
        phcreatedate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phcreatedate"));
        pheditdate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "pheditdate"));
    }
    protected void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) > 0)
            {
                GBmessageInfo info = gbBLL.GetDataById(id);
                ddlCategory.SelectedValue = info.gbc_Id.ToString();
                txtName.Text = info.gb_name;
                txtMail.Text = info.gb_mail;
                ChkVisible.Checked = info.gb_show_mail;
                txtTitle.Text = info.gb_title;
                Ckeditorl1.Text = info.gb_content;
                txtCreatedate.Text = info.gb_createdate.ToShortDateString();
                txtEditdate.Text = info.gb_editdate.ToShortDateString();
            }
        }
    }
    protected void InsertDropDown()
    {
        ddlCategory.DataSource = gbcBLL.GetData();
        ddlCategory.DataTextField = "gbc_title";
        ddlCategory.DataValueField = "gbc_id";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("==請選擇類別==", "0"));
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        GBmessageInfo info = gbBLL.GetDataById(id);
        info.gbc_Id = int.Parse(ddlCategory.SelectedValue);
        info.gb_name = txtName.Text;
        info.gb_mail = txtMail.Text;
        info.gb_show_mail = bool.Parse(ChkVisible.Checked.ToString());
        info.gb_title = txtTitle.Text;
        info.gb_content = Ckeditorl1.Text;
        info.gb_editdate = DateTime.Now;
        if (gbBLL.Update(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30014"));
        }
    }
}