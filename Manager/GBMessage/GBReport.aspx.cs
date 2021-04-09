using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class Manager_GBMessage_GBReport : BasePage
{
    GBmessageBLL gbBLL = new GBmessageBLL();
    GBreBLL gBLL = new GBreBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            Bind();
            BindRepeater();
        }
    }
    private void InitPage()
    {
        phtoptitle.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phtoptitle"));
        phhits.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phhits"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phname"));
        phcontent.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phcontent"));
        phcreatedate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phcreatedate"));
        pheditdate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "pheditdate"));
        phrpgbre.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phrpgbre"));
        phtitle.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phtitle"));
        phgbrename.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phgbrename"));
        phgbremail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phgbremail"));
        phgbreurl.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phgbreurl"));
        phgbrecontent.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phgbrecontent"));
    }
    protected void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) > 0)
            {
                GBmessageInfo info = gbBLL.GetDataById(id);
                Page.Title = info.gb_title;
                lbTitle.Text = info.gb_title;
                lbHits.Text = info.gb_hits.ToString();
                lbName.Text = info.gb_name;
                litContent.Text = info.gb_content;
                lbCreateDate.Text = info.gb_createdate.ToString("yyyy/MM/dd hh:mm");
                lbEditDate.Text = info.gb_editdate.ToString("yyyy/MM/dd hh:mm");
                txtTitle.Text = "Re:" + info.gb_title;
            }
        }
    }
    protected void BindRepeater()
    {
        RpGBre.DataSource = gBLL.GetDataByCategoryId(id);
        RpGBre.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (string.Compare(Request.Cookies["CheckCode"].Value, this.TextBox1.Text, true) == 0)
        {
            GBreInfo info = new GBreInfo();
            info.g_name = txtName.Text;
            info.g_mail = txtMail.Text;
            info.g_show_mail = bool.Parse(chkReportMail.Checked.ToString());
            info.g_ip = Tools.GetIpAddress();
            info.g_content = txtContent.Text;
            info.gb_id = id;
            info.g_adddate = DateTime.Now;
            info.g_url = txtUrl.Text;
            if (gBLL.Insert(info) > 0)
            {
                Response.Redirect("List.aspx?header=" + Getmessage("30009"));
            }
        }
        else
        {
            ShowMessage("驗證碼輸入失敗");
        }
        Response.Cookies.Remove("CheckCode");
    }
    protected void RpGBre_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        GBmessageInfo info = gbBLL.GetDataById(id);
        Literal lt = (Literal)e.Item.FindControl("litTitle");
        lt.Text = "Re:" + info.gb_title;

    }
}