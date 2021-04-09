using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL;
using Model;

public partial class Manager_Member_card_Edit : BasePage
{
    Member_cardBLL mcBLL = new Member_cardBLL();
    MemberBLL mBLL = new MemberBLL();
    SMTPclass SMTP = new SMTPclass("SMTPXML.xml");
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
        phmcnumber.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phmcnumber"));
        phmcpassword.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phmcpassword"));
        phmcstatus.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phmcstatus"));
        phmcnote.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phmcnote"));
        phmcadddate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phmcadddate"));
        phmceditdate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phmceditdate"));
        phmcSMTP.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phmcSMTP"));
    }
    protected void Bind()
    {
        if (Request.QueryString["id"] != null)
        {
            if (Tools.TryParseMethod(Request.QueryString["id"].ToString()) > 0)
            {
                MemberInfo minfo = mBLL.GetDataById(int.Parse(Request.QueryString["id"].ToString()));
                Member_cardInfo info = mcBLL.GetDataByMid(int.Parse(Request.QueryString["id"].ToString()));
                lbAccount.Text = minfo.m_account;
                lbCardNumber.Text = info.mc_number;
                txtPass.Text = info.mc_pass;
                ddlLevel.SelectedValue = info.mc_status.ToString();
                txtContact.Text = info.mc_note;
                lbCreateDate.Text = info.mc_adddate.ToString("yyyy/MM/dd hh:mm");
                lbEditDate.Text = info.mc_editdate.ToString("yyyy/MM/dd hh:mm");
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Member_cardInfo info = mcBLL.GetDataByMid(int.Parse(Request.QueryString["id"].ToString()));
        info.mc_pass = txtPass.Text.Trim().ToLower();
        info.mc_status = int.Parse(ddlLevel.SelectedValue);
        info.mc_note = txtContact.Text;
        info.mc_editdate = DateTime.Now;
        if (mcBLL.Update(info) > 0)
        {
            //SetSmtpArray();
            Response.Redirect("~/Manager/Member/List.aspx?header=" + Getmessage("30014"));
        }
    }
    protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtContact.Text.Length < 300)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;

            ShowMessage("請輸入低於300字以內");
        }
    }
    public void SetSmtpArray()
    {
        SMTP.Subject = "xxxx-會員卡開通";
        SMTP.emailAL = new System.Collections.ArrayList();
        SMTP.BodyAL = new System.Collections.ArrayList();
        SMTP.BodyAL.Add("xxxx-會員卡系統通知");
        SMTP.BodyAL.Add("帳號:" + lbAccount.Text.Trim());
        SMTP.BodyAL.Add("卡片編號:" + lbCardNumber.Text);
        SMTP.BodyAL.Add("卡片密碼:" + txtPass.Text);
        SMTP.BodyAL.Add("請點擊驗證頁面開通帳號:");
        SMTP.BodyAL.Add("內容<br/>" + txtContact.Text);
        SMTP.SMTPClientArraySet(mBLL.GetDataById(id).m_mail);
    }
}