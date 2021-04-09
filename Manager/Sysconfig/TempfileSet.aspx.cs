using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_Sysconfig_TempfileSet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserInfoConfig.filename = UserInfoConfig.WebSiteVirtualPath + "SystemConfig.xml";
            Bind();
        }
    }
    protected void Bind()
    {
        chkSet.Checked = Tools.TryParseBoolMethod(UserInfoConfig.GetUserConfig("tempStart"));
        ddrTime.SelectedValue = Tools.TryParseMethod(UserInfoConfig.GetUserConfig("tempfiletime")).ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserInfoConfig.SetUserConfig("tempStart", chkSet.Checked.ToString());
        UserInfoConfig.SetUserConfig("tempfiletime", ddrTime.SelectedValue);
        Label2.Text = "資料更新成功";        
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (phShow.Visible == false)
        {
            phShow.Visible = true;
            btnShow.Text = "隱藏";
        }
        else
        {
            phShow.Visible = false;
            btnShow.Text = "顯示";
        }
    }
}