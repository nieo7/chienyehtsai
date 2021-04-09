using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class Manager_Member_Add : BasePage
{
    MemberBLL mBLL = new MemberBLL();
    SMTPclass SMTP = new SMTPclass("SMTPXML.xml");
    protected void Page_Load(object sender, EventArgs e)
    {
     //   Response.Redirect("http://localhost/baystarsManager/Manager/Member/MemberCheckPage.aspx?name='somey'&checkcode='Ws65p2Xw37R090sO7e8D'");
        InitPage();
    }
    private void InitPage()
    {
        phaccount.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phaccount"));
        phfname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phfname"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phname"));
        phnickname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phnickname"));
        phmail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phmail"));
        phsex.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phsex"));
        phbirthday.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phbirthday"));
        phaddress.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phaddress"));
        phphone1.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phphone1"));
        phphone2.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phphone2"));
        phnote.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phnote"));
        phSMTP.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phSMTP"));
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtTel.Text.Length >= 9 && txtTel.Text.Length <= 20)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
            ShowMessage("請輸入9碼");
        }
    }
    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtPhone.Text.Length >= 10 && txtPhone.Text.Length <= 20)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;

            ShowMessage("請輸入10~20碼之間");
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            MemberInfo info =new MemberInfo();
            info.m_account = txtAccount.Text;
            info.m_fname = txtFirstName.Text;
            info.m_name = txtname.Text;
            info.m_nickname = txtNickname.Text;            
            info.m_number = "KM" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + string.Format("{00000:00000}", mBLL.Getall().Rows.Count + 1);
            info.m_mail = txtMail.Text;
            info.m_pass = Tools.GetRandomString(8);
            info.m_sex = rbSex.SelectedValue;
            info.m_birthday = txtBirthday.Text;
            info.m_zipcode = address1.CodeId;
            info.m_city = address1.City;
            info.m_area = address1.Area;
            info.m_address = address1.Address;
            info.m_phone1 = txtTel.Text;
            info.m_phone2 = txtPhone.Text;
            info.m_note = txtContact.Text;
            info.m_adddate = DateTime.Now;
            info.m_editdate = DateTime.Now;
            info.m_check_code = Tools.GetRandomString(20);
            if (mBLL.Insert(info) > 0)
            {
                if (rbSMTP.SelectedValue == "1")
                {
                    //SetSmtpArray();
                }
                Response.Redirect("List.aspx?header=" + Getmessage("30009"));
            }
        }
    }
    public void SetSmtpArray()
    {
        MemberInfo info = mBLL.GetDataOrderAdddate();
        SMTP.Subject = "xxxx-會員帳號開通";
        SMTP.emailAL = new System.Collections.ArrayList();
        SMTP.BodyAL = new System.Collections.ArrayList();
        SMTP.BodyAL.Add("xxxx-會員系統通知");
        SMTP.BodyAL.Add("帳號:" + txtAccount.Text.Trim());
        SMTP.BodyAL.Add("密碼:" + info.m_pass);
        SMTP.BodyAL.Add("請點擊驗證頁面開通帳號:");
        SMTP.BodyAL.Add("http://localhost/baystarsManager/Manager/Member/MemberCheckPage.aspx?name="+info.m_account+"&checkcode="+info.m_check_code);        
        SMTP.BodyAL.Add("內容<br/>" + txtContact.Text);
        SMTP.SMTPClientArraySet(txtMail.Text.Trim());
    }

}