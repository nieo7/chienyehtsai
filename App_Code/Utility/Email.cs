using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Text;
using System.Collections.Generic;
using System.Net;
/// <summary>
/// Email 的摘要描述
/// </summary>
public class Email
{
	public Email()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public static bool isCredentials { get; set; }
    public static void SendEmail(string to, string subject, string body)
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress(
                     "wide3751@gmail.com",
                     "瑞恩企業內部系統",
                     Encoding.UTF8);
        mail.To.Add(to);
        mail.Subject = subject;
        mail.SubjectEncoding = Encoding.UTF8;
        mail.BodyEncoding = Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Body = body;
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.EnableSsl = true;
        smtp.Credentials = new System.Net.NetworkCredential("wide3751@gmail.com", "tw8311814");
        smtp.Send(mail);
    }
}
