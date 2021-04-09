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
public partial class Manager_Sysconfig_EditPassword :BasePage
{
    AdminBLL aBLL = new AdminBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlHead header = (HtmlHead)this.Master.FindControl("head1");
        header.Title = UserInfoConfig.GetUserConfig("title");
        if (!IsPostBack)
        {
            string headers = Tools.GetStringSafeFromQueryString(this.Page, "header");            
            EditStatus();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtEditPassword.Text.Length > 3)
        {
            //if (uid != null && uid != 0)
            if(Tools.cookieLoginID !=0)
            {
                AdminInfo info = aBLL.getDataById(uid);
                info.a_password = Tools.GetPassword(lbaccount.Text.Trim(), txtEditPassword.Text);
                info.a_editDate = Convert.ToDateTime(DateTime.Now);
                aBLL.Update(uid, info);
                ShowMessage("修改成功");
            }
            else
            {
                ShowMessage("修改失敗");
            }
        }
        else
        {
            ShowMessage("密碼字數過短");
        }
    }
    public void EditStatus()
    {
        if (Request.Cookies["User"] != null && Tools.cookieLoginID != 0)
        {
            //開始抓取ID
            AdminInfo info = aBLL.getDataById(uid);
            lbaccount.Text = info.a_account;
            Label1.Text = info.a_editDate.ToShortDateString();            
        }
        else
        {
            Response.Redirect("~/Sysconfig/Default.aspx");
        }
    }
}