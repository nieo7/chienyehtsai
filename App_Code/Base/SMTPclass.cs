using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Collections;
using System.Web.Configuration;
using System.Xml;

   /// <summary>
    /// SMTP主要異動變數為:主旨
    /// </summary>
public class SMTPclass
{
    ArrayList AL = new ArrayList();
    ArrayList smtp = new ArrayList();
    public ArrayList emailAL { get; set; }
    public ArrayList BodyAL { get; set; }
    public string Subject { get; set; }
    public SMTPclass()
    {

    }
    /// <summary>
    /// 輸入XML檔案名稱,例: SMTPXML.xml
    /// </summary>
    /// <param name="xmlname"></param>
    public SMTPclass(string xmlname)
    {        
        // TODO: 在此加入建構函式的程式碼     
        UserInfoConfig.filename = UserInfoConfig.WebSiteVirtualPath+xmlname;
    }
    public void SendMail(ArrayList SmtpList)
    {
        //發件者信箱,名稱,編碼
        MailAddress mailFrom = new MailAddress(smtp[0].ToString(), smtp[1].ToString(), Encoding.UTF8);
        MailMessage mail = new MailMessage();
        mail.From = mailFrom;  //發件者
        try
        {
            for (int i = 0; i < AL.Count; i++)
            {
                if (AL[i].ToString().Trim() != string.Empty)
                {
                    mail.To.Add(AL[i].ToString()); //收件者
                }
            }
        }
        catch
        {
            mail.To.Add("hiehm@msn.com");
        }
        mail.IsBodyHtml = true;
        //異動變數區
        mail.Body = "<table><tr><td>訪客姓名：" + AddMethodSystem.NoHTML(SmtpList[6].ToString()) + "</td></tr>";
        if (smtp[11].ToString() != string.Empty)
        {
            mail.Body += "<tr><td>主   旨：" + AddMethodSystem.NoHTML(smtp[11].ToString()) + "</td></tr>";
        }
        if (smtp[9].ToString() != string.Empty)
        {
            mail.Body += "<tr><td>地   址：" + AddMethodSystem.NoHTML(smtp[9].ToString()) + "</td></tr>";
        }
        if (smtp[7].ToString() != string.Empty)
        {
            mail.Body += "<tr><td>聯絡電話：" + AddMethodSystem.NoHTML(smtp[7].ToString()) + "</td></tr>";
        }
        if (smtp[8].ToString() != string.Empty)
        {
            mail.Body += "<tr><td>手  機：" + AddMethodSystem.NoHTML(smtp[8].ToString()) + "</td></tr>";
        }
        if (smtp[10].ToString() != string.Empty)
        {
            mail.Body += "<tr><td>電子信箱：" + AddMethodSystem.NoHTML(smtp[10].ToString()) + "</td></tr>";
        }
        if (smtp[12].ToString() != string.Empty)
        {
            mail.Body += "<br/>內容:<br/><div style='width:600px;height:300px'><textarea id='Contents' name='Contents' style='width:600px;height:300px'>" + AddMethodSystem.NoHTML(smtp[12].ToString()) + "</textarea></div>";
        }
        if (smtp[3].ToString() != string.Empty)
        {
            mail.Body += "<tr><td>申請帳號：" + AddMethodSystem.NoHTML(smtp[3].ToString()) + "</td></tr>";
        }
        if (smtp[4].ToString() != string.Empty)
        {
            mail.Body += "<tr><td>網站名稱：" + AddMethodSystem.NoHTML(smtp[4].ToString()) + "</td></tr>";
        }
        //異動變數區
        mail.Body += "</table>";
        if (smtp[18].ToString() != string.Empty)
        {
            mail.Subject = AddMethodSystem.NoHTML(smtp[18].ToString());
        }
        else
        {
            mail.Subject = AddMethodSystem.NoHTML(smtp[13].ToString());
        }
        mail.SubjectEncoding = Encoding.UTF8;
        mail.Priority = MailPriority.Normal;
        SmtpClient SMTP = new SmtpClient(smtp[15].ToString(), int.Parse(smtp[14].ToString())); //主機位置與port
        //發送者驗證
        SMTP.Credentials = new NetworkCredential(smtp[0].ToString(), smtp[2].ToString()); //server@domainname        
        SMTP.Send(mail);
        if (smtp[16].ToString() != string.Empty)
        {
            RegistAccountURL(smtp);
        }
    }
    //帳號申請ＵＲＬ驗證專用SMTP
    public void RegistAccountURL(ArrayList UserSmtp)
    {
        MailAddress mailFromUser = new MailAddress(UserSmtp[0].ToString(), UserSmtp[1].ToString(), Encoding.UTF8);
        MailMessage mailUser = new MailMessage();
        mailUser.From = mailFromUser;
        mailUser.To.Add(UserSmtp[10].ToString());
        mailUser.IsBodyHtml = true;
        mailUser.Body = "<table><tr><td>申請人姓名：" + AddMethodSystem.NoHTML(UserSmtp[6].ToString()) + "</td></tr>";
        if (smtp[3].ToString() != string.Empty)
        {
            mailUser.Body += "<tr><td>您申請的7000GO帳號名稱：" + AddMethodSystem.NoHTML(smtp[3].ToString()) + "</td></tr>";
        }
        if (smtp[4].ToString() != string.Empty)
        {
            mailUser.Body += "<tr><td>您註冊的7000GO網站名稱：" + AddMethodSystem.NoHTML(smtp[4].ToString()) + "</td></tr>";
        }
        mailUser.Body += "<tr><td>請點擊下面網址通過帳戶驗證</td></tr>";
        mailUser.Body += "<tr><td>" + UserSmtp[16].ToString() + "</td></tr>";
        mailUser.Body += "</table><br/>";
        //在此加入信件Footer設定
        mailUser.Body += FooterSet();
        mailUser.Subject = AddMethodSystem.NoHTML(smtp[17].ToString());
        mailUser.SubjectEncoding = Encoding.UTF8;
        mailUser.Priority = MailPriority.Normal;
        SmtpClient SMTP = new SmtpClient(smtp[15].ToString(), int.Parse(smtp[14].ToString())); //主機位置與port            
        SMTP.Credentials = new NetworkCredential(smtp[0].ToString(), smtp[2].ToString()); //server@domainname
        SMTP.Send(mailUser);
    }
    //全域信件Footer設定
    public string FooterSet()
    {
        StringBuilder SB = new StringBuilder();
        SB.Append("<p><img height='40' src='mail_logo.jpg' />服務<br/>");
        SB.Append("<a href='http://www.7000go.com/service.aspx' target='_blank'>網站平台及開店平台租用│資料庫系統程式開發│資料備份及維護│網站代管</a><br/>");
        SB.Append("<p>kevin 企劃業務部<br/>T E L ： ( 0 7 ) 3 3 5 - 6 7 3 6 轉1 3<br/>F A X ： ( 0 2 ) 3 3 5 - 0 1 8 2<br/>E - M A I l ： p o y u 0 9 1 7 @ h o t m a i l . c o m<br/>W E B S I T E ： h t t p : / / w w w . 7000go . c o m / m a i n /");
        return SB.ToString();
    }
    

    //利用雙ArrayList組合,製作非固定欄位與格式的SMTP~(未來都使用此方式)
    /// <summary>
    /// 此方法為:前端客戶發送
    /// </summary>
    public void SMTPClientArraySet(string email)
    {
        MailAddress mailFromUser = new MailAddress(UserInfoConfig.GetUserConfig("hostmail"), UserInfoConfig.GetUserConfig("hostname"), Encoding.UTF8);
        MailMessage mailUser = new MailMessage();
        mailUser.From = mailFromUser;
        emailAL.Add(email);
        if (emailAL.Count > 0)
        {
            for (int i = 0; i < emailAL.Count; i++)
            {
                if (emailAL[i].ToString() != string.Empty)
                {
                    mailUser.To.Add(emailAL[i].ToString());
                }
            }
        }
        mailUser.IsBodyHtml = true;
        mailUser.Body = "<p>";
        if (BodyAL.Count > 0)
        {
            for (int i = 0; i < BodyAL.Count; i++)
            {
                mailUser.Body += BodyAL[i].ToString() + "<br/>";
            }
        }
        mailUser.Body += "</p>";
        //mailUser.Body += FooterSet(); 底部設定
        mailUser.Subject = Subject;
        mailUser.SubjectEncoding = Encoding.UTF8;
        mailUser.BodyEncoding = Encoding.UTF8;
        mailUser.Priority = MailPriority.Normal;
        SmtpClient SMTP = new SmtpClient(UserInfoConfig.GetUserConfig("server"), int.Parse(UserInfoConfig.GetUserConfig("port")));
        SMTP.Credentials = new NetworkCredential(UserInfoConfig.GetUserConfig("hostmail"), UserInfoConfig.GetUserConfig("mailpass")); //server@domainname
        SMTP.Send(mailUser);
    }
    public void SMTPServerArraySet()
    {
        MailAddress mailFromUser = new MailAddress(UserInfoConfig.GetUserConfig("hostmail"), UserInfoConfig.GetUserConfig("hostname"), Encoding.UTF8);
        MailMessage mailUser = new MailMessage();
        mailUser.From = mailFromUser;
        emailAL.Add(UserInfoConfig.GetUserConfig("mail1"));
        emailAL.Add(UserInfoConfig.GetUserConfig("mail2"));
        emailAL.Add(UserInfoConfig.GetUserConfig("mail3"));
        emailAL.Add(UserInfoConfig.GetUserConfig("mail4"));
        emailAL.Add(UserInfoConfig.GetUserConfig("mail5"));
        if (emailAL.Count > 0)
        {
            for (int i = 0; i < emailAL.Count; i++)
            {
                if (emailAL[i].ToString() != string.Empty)
                {
                    mailUser.To.Add(emailAL[i].ToString());
                }
            }
        }
        mailUser.IsBodyHtml = true;
        mailUser.Body = "<p>";
        if (BodyAL.Count > 0)
        {
            for (int i = 0; i < BodyAL.Count; i++)
            {
                mailUser.Body += BodyAL[i].ToString() + "<br/>";
            }
        }
        mailUser.Body += "</p>";
        //mailUser.Body += FooterSet(); 底部設定
        mailUser.Subject = Subject;
        mailUser.SubjectEncoding = Encoding.UTF8;
        mailUser.BodyEncoding = Encoding.UTF8;
        mailUser.Priority = MailPriority.Normal;
        SmtpClient SMTP = new SmtpClient(UserInfoConfig.GetUserConfig("server"), int.Parse(UserInfoConfig.GetUserConfig("port")));
        SMTP.Credentials = new NetworkCredential(UserInfoConfig.GetUserConfig("hostmail"), UserInfoConfig.GetUserConfig("mailpass")); //server@domainname
        SMTP.Send(mailUser);
    }
    //定義在SMTPArraySet方法裡
}
