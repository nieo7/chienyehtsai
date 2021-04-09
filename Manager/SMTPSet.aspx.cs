using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webs_SMTPSet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            setSMTPDefault();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        subjectTxt.Text = "聯絡我們信件通知";
       mail1TextBox.Text = "hiehm@msn.com";
       mail2TextBox.Text = "mattchen0512@gmail.com";
       hostmailTextBox.Text = "Server@bella-uspa.com.tw";        //修改Server Mail
       hostnameTextBox.Text = "瑞恩設計股份有限公司";                              
        portTextBox.Text = "25";
        ServerTxt.Text = "mail.bella-uspa.com.tw";   //修改Server SMTP
        Label2.Text = "預設資料,如確定請按更新";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SMTPConfig.SetUserConfig("subject", subjectTxt.Text);
        SMTPConfig.SetUserConfig("mail1", mail1TextBox.Text);
        SMTPConfig.SetUserConfig("mail2", mail2TextBox.Text);
        SMTPConfig.SetUserConfig("mail3", mail3TextBox.Text);
        SMTPConfig.SetUserConfig("mail4", mail4TextBox.Text);
        SMTPConfig.SetUserConfig("mail5", mail5TextBox.Text);
        SMTPConfig.SetUserConfig("hostmail", hostmailTextBox.Text);
        SMTPConfig.SetUserConfig("hostname", hostnameTextBox.Text);
        SMTPConfig.SetUserConfig("port", portTextBox.Text);
        SMTPConfig.SetUserConfig("server", ServerTxt.Text);
        Label2.Text = "資料更新成功";        
    }
    public void setSMTPDefault()
    {
        subjectTxt.Text = SMTPConfig.GetUserConfig("subject");
        mail1TextBox.Text = SMTPConfig.GetUserConfig("mail1");
        mail2TextBox.Text = SMTPConfig.GetUserConfig("mail2");
        mail3TextBox.Text = SMTPConfig.GetUserConfig("mail3");
        mail4TextBox.Text = SMTPConfig.GetUserConfig("mail4");
        mail5TextBox.Text = SMTPConfig.GetUserConfig("mail5");
        hostmailTextBox.Text = SMTPConfig.GetUserConfig("hostmail");
        hostnameTextBox.Text = SMTPConfig.GetUserConfig("hostname");
        portTextBox.Text = SMTPConfig.GetUserConfig("port");
        ServerTxt.Text = SMTPConfig.GetUserConfig("server");
    }
}