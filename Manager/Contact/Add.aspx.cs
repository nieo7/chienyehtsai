using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Manager_Contact_Add : BasePage
{
    ContactBLL cBLL = new ContactBLL(lid);
    SMTPclass SMTP = new SMTPclass("SMTPXML.xml");
    protected void Page_load(object sender, EventArgs e)
    {
        InitPage();
    }
    private void InitPage()
    {
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Contact", "phname"));
        phsex.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Contact", "phsex"));
        phmail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Contact", "phmail"));
        phphone1.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Contact", "phphone1"));
        phphone2.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Contact", "phphone2"));
        phaddress.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Contact", "phaddress"));
        phsubject.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Contact", "phsubject"));
        phdetail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Contact", "phdetail"));        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            ContactInfo info = new ContactInfo();
            info.c_name = txtName.Text;
            info.c_subject = txtTitle.Text;
            info.c_sex = rbSex.SelectedValue;
            info.c_phone1 = txtTel.Text;
            info.c_mail = txtMail.Text;
            info.c_address = address1.Area + address1.City + address1.CodeId + address1.Address;
            info.c_detail = txtContent.Text;
            info.c_pose_date = DateTime.Now;            
            info.c_ip = Tools.GetIpAddress();
            info.l_id = lid;
            if (cBLL.Insert(info) > 0)
            {
                //SMTP
                //SMTPSet();
                Response.Redirect("List.aspx?id=0&header=" + Getmessage("30009"));
            }
        }
    }
    public void SMTPSet()
    {
        SMTP.Subject = "xxxx-聯絡我們";        
        SMTP.BodyAL = new System.Collections.ArrayList();
        SMTP.BodyAL.Add("xxxx-聯絡我們系統通知");
        SMTP.BodyAL.Add("姓名:" + txtName.Text);
        SMTP.BodyAL.Add("電話:" + txtTel.Text);
        SMTP.BodyAL.Add("信箱:" + txtMail.Text);
        SMTP.BodyAL.Add("內容<br/>" + txtContent.Text);
        SMTP.SMTPClientArraySet(txtMail.Text);
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
        if (txtContent.Text.Length < 300)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;

            ShowMessage("請輸入低於300字以內");
        }
    }
}