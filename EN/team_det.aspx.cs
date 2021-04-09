using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class EN_team_det : BasePage
{
    FriendLinkBLL fBLL = new FriendLinkBLL();
    NewsBLL nBLL = new NewsBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Page.Title = "Chien Yeh Law Offices Kaohsiung Office(KCY)";
            Bind();
        }
    }
    protected void Bind()
    {
        FriendLinkInfo info = fBLL.GetDataById(id);
        litName.Text = info.f_title;
        litTitle.Text = info.f_name;
        litDegree.Text = info.f_degree;
        litHistory.Text = info.f_history;
        litBooks.Text = info.f_books;
        litSpecialty.Text = info.f_specialty;
        //litEmail.Text = info.f_license;
        //litPhone.Text = info.f_field;
        if (info.f_img != "")
        {
            Image1.ImageUrl = string.Format(Tools.GetAppSettings("FriendLinkTruePath") + info.f_img);
        }
        else
        {
            Image1.ImageUrl = "img/team/person.jpg";
        }
        Rpnews.DataSource = nBLL.GetDataByFIdOrderDesc(id,2);
        Rpnews.DataBind();
    }
}