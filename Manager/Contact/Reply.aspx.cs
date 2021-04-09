using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Manager_Contact_Reply : BasePage
{
    ContactBLL cBLL = new ContactBLL(lid);
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
        phsubject.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Contact", "phsubject"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Contact", "phname"));
        phmail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Contact", "phmail"));
        phsex.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Contact", "phsex"));
        phdetail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Contact", "phdetail"));
    }
    protected void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) != 0)
            {
                ContactInfo info = cBLL.GetDataById(id);
                txtTitle.Text = "【回覆】：" + info.c_subject;
                txtName.Text = info.c_name;
                litPhone.Text = info.c_phone1;
                litFax.Text = info.c_phone2;
                txtMail.Text = info.c_mail;
                litSex.Text = info.c_sex;
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ContactInfo info = cBLL.GetDataById(id);
        info.c_check_reply = true;
        info.c_reply_date = DateTime.Now;

        //SMTP 
        //SMTPset();     
        if (cBLL.Update(info) > 0)
        {
            Response.Redirect("List.aspx?header=回覆完成");
        }
    }
    protected void SMTPset()
    {
        SMTP.Subject = txtTitle.Text + "xxxx";
        SMTP.BodyAL = new System.Collections.ArrayList();
        SMTP.BodyAL.Add("xxxx-聯絡我們信件回覆");
        SMTP.BodyAL.Add("內容<br/>:" + txtContent.Text);
        SMTP.SMTPClientArraySet(txtMail.Text);
    }
    protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtContent.Text.Length < 1000)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;

            ShowMessage("請輸入低於1000字以內");
        }
    }
}