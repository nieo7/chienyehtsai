using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Manager_FriendLinkCategory_Edit : BasePage
{
    FriendLinkCategoryBLL fcBLL = new FriendLinkCategoryBLL(lid);
    FriendLinkCategoryInfo info;
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
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLinkCategory", "phname"));
        phcreatedate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLinkCategory", "phcreatedate"));
        //phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLinkCategory", "phshow"));
    }
    public void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) > 0)
            {
                info = fcBLL.GetDataById(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
                txtName.Text = info.fc_title;
                lbCreate.Text = info.fc_CreateDate.ToShortDateString();
                //rbShow.SelectedValue = info.fc_show.ToString().ToLower();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        info = fcBLL.GetDataById(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
        info.fc_title = txtName.Text;
        
        //info.fc_show = bool.Parse(rbShow.SelectedValue);
        if (fcBLL.Update(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30014"));
        }
        else
        {
            ShowMessage("修改失敗");
        }
    }
}