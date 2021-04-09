using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL;
using Model;
public partial class Manager_FriendLinkCategory_Add : BasePage
{
    FriendLinkCategoryBLL fcBLL = new FriendLinkCategoryBLL(lid);
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
    }
    private void InitPage()
    {
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLinkCategory", "phname"));
        //phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLinkCategory", "phshow"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Trim() != string.Empty)
        {
            FriendLinkCategoryInfo info = new FriendLinkCategoryInfo();
            info.fc_title = txtName.Text.Trim();
            info.fc_CreateDate = DateTime.Now;
            info.l_id = lid;
            //info.fc_show = bool.Parse(rbShow.SelectedValue);
            if (fcBLL.Insert(info) > 0)
            {
                Response.Redirect("List.aspx?header=職稱:" + Getmessage("30009"));
            }
        }
        else
        {
            ShowMessage("請輸入標題");
        }
    }
}
