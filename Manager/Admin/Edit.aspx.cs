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
public partial class Manager_News_Edit :BasePage
{
    AdminBLL adBLL = new AdminBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlHead header = (HtmlHead)this.Master.FindControl("head1");
        header.Title = UserInfoConfig.GetUserConfig("title");
        if (id == 0)
        {
            Response.Redirect("List.aspx");
            return;
        }
        if (!IsPostBack)
        {
            //Check_Power(17, 74, true);
            Bind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminInfo info = adBLL.getDataById(id);
        info.a_name = txtName.Text;
        info.a_account = txtAccount.Text;
        info.a_nickName = txtNickName.Text;
        if (txtPass.Text.Trim() != "")
            info.a_password = Tools.GetPassword(txtAccount.Text, txtPass.Text);
        if (adBLL.Update(id, info) > 0)
        {
            ShowMsg("修改完成", "List.aspx");
        }
        else
        {
            Tools.Show(this.Page, "修改失敗");
        }
    }
    public void ShowMsg(string message, string url)
    {
        Response.Write("<script>");
        Response.Write("alert('" + message + "!!');");
        Response.Write("window.location='" + url + "';");
        Response.Write("</script>");
        Response.End();
    }
    public void Bind()
    {
        AdminInfo info = adBLL.getDataById(id);
        txtName.Text = info.a_name;
        txtAccount.Text = info.a_account;
        txtEditeDate.Text = info.a_editDate.ToString();
        txtNickName.Text = info.a_nickName;
    }
}
