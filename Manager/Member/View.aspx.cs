using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class Manager_Member_View : BasePage
{
    MemberBLL mBLL = new MemberBLL();
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
        phaccount.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phaccount"));
        phlevel.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phlevel"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phname"));
        phsex.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phsex"));
        phbirthday.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phbirthday"));
        phaddress.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phaddress"));
        phphone1.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phphone1"));
        phphone2.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phphone2"));
        phnickname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phnickname"));
        phnumber.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phnumber"));
        phmail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phmail"));
        phlogintime.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phlogintime"));
        phnote.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phnote"));
        phcreatedate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phcreatedate"));
        pheditdate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "pheditdate"));
        phlastlogindate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phlastlogindate"));
        phcheckcode.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phcheckcode"));
        pheaper.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "pheaper"));
        phblock.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phblock"));

    }
    protected void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) > 0)
            {
                MemberInfo info = mBLL.GetDataById(int.Parse(Request.QueryString["id"].ToString()));
                lbaccount.Text = info.m_account;
                lblevel.Text = info.m_level.ToString();
                lbName.Text = info.m_fname + info.m_name;
                lbsex.Text = info.m_sex;
                lbbirthday.Text = info.m_birthday;
                lbAddress.Text = info.m_city + info.m_area + info.m_zipcode + info.m_address;
                lbPhone1.Text = info.m_phone1;
                lbPhone2.Text = info.m_phone2;
                lbnickname.Text = info.m_nickname;
                lbnumber.Text = info.m_number;
                lbmail.Text = info.m_mail;
                lbLoginCount.Text = info.m_login_times.ToString();
                txtContent.Text = info.m_note;
                lbCreateDate.Text = info.m_adddate.ToString("yyyy/MM/dd hh:mm");
                lbEditDate.Text = info.m_editdate.ToString("yyyy/MM/dd hh:mm");
                lbLastlogindate.Text = info.m_lastlogindate.ToString("yyyy/MM/dd hh:mm");
                if (info.m_check_code != "OK")
                {
                    lbregist.Text = "X";
                }
                else
                {
                    lbregist.Text = "O";
                }
                rbEaper.SelectedValue = info.m_eaper.ToString().ToLower();
                rbBlock.SelectedValue = info.m_block.ToString().ToLower();
            }
        }
    }
}