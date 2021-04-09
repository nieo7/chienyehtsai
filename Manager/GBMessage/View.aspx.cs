using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Manager_GBMessage_View : BasePage
{
    GBcategoryBLL gbcBLL = new GBcategoryBLL();
    GBmessageBLL gbBLL = new GBmessageBLL();
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
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phcategory"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phname"));
        phmail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phmail"));
        phip.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phip"));
        phlevel.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phlevel"));
        phtitle.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phtitle"));
        phhits.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phhits"));
        phshowmail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phshowmail"));
        phcontent.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phcontent"));
        phcreatedate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phcreatedate"));
        pheditdate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "pheditdate"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phshow"));
    }
    protected void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) > 0)
            {
                GBmessageInfo info = gbBLL.GetDataById(id);
                lbCategory.Text = gbcBLL.GetDataById(info.gbc_Id).gbc_title;
                lbName.Text = info.gb_name;
                lbMail.Text = info.gb_mail;
                lbIp.Text = info.gb_ip;
                lbLevel.Text = info.gb_level;
                lbTitle.Text = info.gb_title;
                lbHits.Text = info.gb_hits.ToString();
                if (info.gb_show_mail)
                {
                    lbShowMail.Text = "是";
                }
                else
                {
                    lbShowMail.Text = "否";
                }
                Ckeditorl1.Text = info.gb_content;
                lbCreateDate.Text = info.gb_createdate.ToShortDateString();
                lbEditDate.Text = info.gb_editdate.ToShortDateString();
                rbShow.SelectedValue = info.gb_show.ToString();
            }
        }
    }
}