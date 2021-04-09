using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class contact : BasePage
{
    ContactBLL cBLL = new ContactBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Page.Title = "建業法律事務所高雄所 ( KCY )";
            txtName.Focus();
            txtName.Text = "";
            txtDetail.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            txtPhone.Text = "";
            txtSubject.Text = "";
        }
    }
    //電話號碼驗證
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtPhone.Text.Length >= 9 && txtPhone.Text.Length <= 20)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
            AddMethodSystem.ShowBox(UpdatePanel1, this.GetType(), "insertContact", "alert('電話號碼長度為9~20碼');");
        }
    }
    protected void ImgbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            ContactInfo info = new ContactInfo();
            info.c_name = txtName.Text;
            info.c_mail = txtEmail.Text;
            info.c_phone1 = txtPhone.Text;
            info.c_phone2 = txtFax.Text;
            info.c_subject = txtSubject.Text;
            info.c_detail = txtDetail.Text;
            info.c_pose_date = DateTime.Now;
            info.l_id = 1; //繁體中文
            if (cBLL.Insert(info) > 0)
            {
                AddMethodSystem.ShowBox(UpdatePanel2, this.GetType(), "insertContact", "alert('感謝您的來信，我們將盡快為您服務');document.location.href='index.aspx'");
            }
        }
    }
}