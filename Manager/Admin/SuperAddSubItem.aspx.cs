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
public partial class Manager_Admin_SuperAddItem : BasePage
{
    AdminItem2BLL ai2BLL = new AdminItem2BLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlHead header = (HtmlHead)this.Master.FindControl("head1");
        header.Title = UserInfoConfig.GetUserConfig("title");
        if (!IsPostBack)
        {
            //Check_Power(999, 999, true);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminItem2Info info = new AdminItem2Info();
        info.ai2_name = TextBox_Name.Text;
        info.ai2_url = TextBox_Url.Text;
        info.ai2_no1 = int.Parse(DropDownList_No1.SelectedValue);
        info.ai2_visible = true;
        ai2BLL.Insert(info);
        Response.Redirect("SuperItemEditList2.aspx?id=" + id);
    }
}
