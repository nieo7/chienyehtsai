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

public partial class Manager_SysConfig_Default : BasePage
{
    AdminBLL aBLL = new AdminBLL();
    protected void Page_Load(object sender, EventArgs e)
    {

        HtmlHead header = (HtmlHead)this.Master.FindControl("head1");
        header.Title = UserInfoConfig.GetUserConfig("title") + "管理後台";
        if (!IsPostBack)
        {
            if (uid == 0)
                return;
            AdminInfo info = aBLL.getDataById(uid);
            lbAcc.Text = info.a_account;
            lbIp.Text = Tools.GetIpAddress();
            lbinit_time.Text = info.a_lastDate.ToString();
            lbName.Text = info.a_name.ToString();
            lbNickName.Text = info.a_nickName.ToString();
            lbEditTime.Text = info.a_editDate.ToString();
        }
    }
}
