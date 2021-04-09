using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using BLL;
using Model;
public partial class Manager_SignIn : BasePage
{
    AdminBLL aBLL = new AdminBLL();
    AdminLoginBLL alBLL = new AdminLoginBLL();
    TempfilestableBLL tfBLL = new TempfilestableBLL();    
    protected void BtLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string password = Tools.GetPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            //檢查密碼是否符合超級密碼
            if (txtPassword.Text.Trim() == SystemConfigBLL.getDataByClassWithName("Main", "SuperCode"))
            {
                AdminInfo infoSuper = aBLL.getDataByAccount(txtUserName.Text.Trim());
                uid = infoSuper.a_id;
                Response.Redirect(Tools.GetAppSettings("LoginedUrl"), true);
                return;
            }
            //檢查帳號密碼是否正確
            AdminInfo info = aBLL.getDataByAccountWithPassword(txtUserName.Text.Trim(), password);            
            if (info.a_id != 0)
            {
                uid = info.a_id;
                aBLL.UpdateLastDate(DateTime.Now, info.a_id);
                //由此開始判斷暫存檔過期
                if (UserInfoConfig.GetUserConfig("tempStart").ToLower() == "true")
                {
                    tfBLL.DeleteTempFiles();
                }
                AdminLoginInfo alinfo = new AdminLoginInfo();
                alinfo.a_id = info.a_id;
                alinfo.al_logintime = DateTime.Now;
                alinfo.al_ip = Tools.GetIpAddress();
                alinfo.al_no2 = 0;
                alBLL.Insert(alinfo);
                Response.Redirect(Tools.GetAppSettings("LoginedUrl"), true);
            }
            else
            {
                message.Text = "帳號或密碼有誤，請重新輸入！";
            }
        }
        catch (Exception ex)
        {
            message.Text = ex.Message;
        }
    }
}
