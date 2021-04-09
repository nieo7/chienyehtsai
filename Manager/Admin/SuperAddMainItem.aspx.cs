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
public partial class Manager_Admin_SuperAddMainItem : BasePage
{
    AdminItem1BLL ai1BLL = new AdminItem1BLL();
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
        AdminItem1Info info = new AdminItem1Info();
        info.ai1_name = TextBox_Name.Text;
        info.ai1_nickname = txtNickname.Text;
        info.ai1_visible = true;
        if (ai1BLL.Insert(info) > 0)
        {
            ShowMessage("新增主項目: "+TextBox_Name.Text+" 成功");
        }
    }
}
