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
using BLL;
using Model;
public partial class Manager_Admin_Add : BasePage
{
    AdminBLL adBLL = new AdminBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlHead header = (HtmlHead)this.Master.FindControl("head1");
        header.Title = UserInfoConfig.GetUserConfig("title");
        if (!IsPostBack)
        {
            //Check_Power(17, 73, true);
            txtDate.Text = DateTime.Now.ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //if (IsRefresh)
        //{
        //    Tools.Show(this.Page, "請勿重複新增!");
        //    return;
        //}
        if (adBLL.getDataByAccount(txtAccount.Text) != null)
        {
            AdminInfo Info = new AdminInfo();
            Info.a_account = txtAccount.Text;
            Info.a_password = Tools.GetPassword(txtAccount.Text, txtPass.Text);
            Info.a_name = txtName.Text;
            Info.a_nickName = txtNickName.Text;
            Info.a_editDate = DateTime.Now;
            if (adBLL.Insert(Info) > 0)
            {
                Page.Controls.Add(Tools.Tomsg("新增成功"));
                Response.Redirect("List.aspx", true);
            }
            else
            {
                Page.Controls.Add(Tools.Tomsg("新增失敗"));
            }
        }
        else
        {
            Page.Controls.Add(Tools.Tomsg("已有相同帳號"));
        }
    }
}
