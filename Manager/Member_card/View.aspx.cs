using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class Manager_Member_card_View : BasePage
{
    Member_cardBLL mcBLL = new Member_cardBLL();
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
        phmcnumber.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phmcnumber"));
        phmcpassword.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phmcpassword"));
        phmcstatus.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phmcstatus"));
        phmcnote.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phmcnote"));
        phmcadddate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phmcadddate"));
        phmceditdate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phmceditdate"));
    }
    protected void Bind()
    {
        if (Request.QueryString["id"] != null)
        {
            if (Tools.TryParseMethod(Request.QueryString["id"].ToString()) != 0)
            {
                Member_cardInfo info = mcBLL.GetDataByMid(int.Parse(Request.QueryString["id"].ToString()));
                lbCardNumber.Text = info.mc_number;
                lbPAss.Text = info.mc_pass;
                ddlLevel.SelectedValue = info.mc_status.ToString();
                txtContact.Text = info.mc_note;
                lbCreateDate.Text = info.mc_adddate.ToString("yyyy/MM/dd hh:mm");
                lbEditDate.Text = info.mc_editdate.ToString("yyyy/MM/dd hh:mm");
            }
        }
    }
}