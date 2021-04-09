using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class Manager_FriendLink_View : BasePage
{
    FriendLinkCategoryBLL fcBLL = new FriendLinkCategoryBLL();
    FriendLinkBLL fBLL = new FriendLinkBLL();
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
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLink", "phcategory"));
        phtitle.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLink", "phtitle"));
        //phurl.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLink", "phurl"));
        phimage.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLink", "phimage"));
        //phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLink", "phshow"));
    }
    protected void Bind()
    {
        FriendLinkInfo info = fBLL.GetDataById(id);
        lbcategory.Text = fcBLL.GetDataById(info.fc_id).fc_title;
        lbTitle.Text = info.f_title;
        lbName.Text = info.f_name;
        lbBooks.Text = info.f_books;
        lbDegree.Text = info.f_degree;
        lbPhone.Text = info.f_field;
        lbHistory.Text = info.f_history;
        lbEmail.Text = info.f_license;
        lbSpecialty.Text = info.f_specialty;
        lbStartdate.Text = info.f_ts.ToShortDateString();
        lbEditDate.Text = info.f_editDate.ToShortDateString();
        //hyUrl.NavigateUrl = info.f_url;
        //hyUrl.Text = info.f_url;
        //hyUrl.Target = "_blank";
        Image1.ImageUrl =Tools.GetAppSettings("FriendLinkTruePath")+info.f_img;
        //rbShow.SelectedValue = info.f_show.ToString();
    }
}