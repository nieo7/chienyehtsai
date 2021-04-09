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

public partial class Manager_SysConfig_SysConfig : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSetup();
        }
    }
    //讀取設定檔
    protected void BindSetup()
    {
        TextBox_Title.Text = UserInfoConfig.GetUserConfig("title");
        TextBox_EnAddress.Text = UserInfoConfig.GetUserConfig("companyAddressEN");
        TextBox_Address.Text = UserInfoConfig.GetUserConfig("companyAddress");
        TextBox_Tel.Text = UserInfoConfig.GetUserConfig("companyTel");
        TextBox_Fax.Text = UserInfoConfig.GetUserConfig("companyFax");
        TextBox_SMTP.Text = UserInfoConfig.GetUserConfig("smtp");
        TextBox_Email.Text = UserInfoConfig.GetUserConfig("companyEmail");
        TextBox_Email2.Text = UserInfoConfig.GetUserConfig("companyEmail2");
        TextBox_Email3.Text = UserInfoConfig.GetUserConfig("companyEmail3");
        TextBox_Url.Text = UserInfoConfig.GetUserConfig("websitename");
        TextBox_Code.Text = UserInfoConfig.GetUserConfig("companyTaxID");
        TextBox_CompanyName.Text = UserInfoConfig.GetUserConfig("companyNameCH");
        TextBox_EnCompanyName.Text = UserInfoConfig.GetUserConfig("companyNameEN");
        TextBox_SName.Text = UserInfoConfig.GetUserConfig("companyAdmin");
        TextBox_Password.Text = UserInfoConfig.GetUserConfig("password");
        TextBox_UserName.Text = UserInfoConfig.GetUserConfig("userName");
        TextBox_Port.Text = UserInfoConfig.GetUserConfig("port");
        TextBox_Keyword.Text = UserInfoConfig.GetUserConfig("keywords");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        UserInfoConfig.SetUserConfig("title", TextBox_Title.Text);
        UserInfoConfig.SetUserConfig("companyAddress", TextBox_Address.Text);
        UserInfoConfig.SetUserConfig("companyAddressEN", TextBox_EnAddress.Text);
        UserInfoConfig.SetUserConfig("companyTel", TextBox_Tel.Text);
        UserInfoConfig.SetUserConfig("companyFax", TextBox_Fax.Text);
        UserInfoConfig.SetUserConfig("smtp", TextBox_SMTP.Text);
        UserInfoConfig.SetUserConfig("companyEmail", TextBox_Email.Text);
        UserInfoConfig.SetUserConfig("companyEmail2", TextBox_Email2.Text);
        UserInfoConfig.SetUserConfig("companyEmail3", TextBox_Email3.Text);
        UserInfoConfig.SetUserConfig("websitename", TextBox_Url.Text);
        UserInfoConfig.SetUserConfig("companyTaxID", TextBox_Code.Text);
        UserInfoConfig.SetUserConfig("companyNameCH", TextBox_CompanyName.Text);
        UserInfoConfig.SetUserConfig("companyNameEN", TextBox_EnCompanyName.Text);
        UserInfoConfig.SetUserConfig("companyAdmin", TextBox_SName.Text);
        UserInfoConfig.SetUserConfig("password", TextBox_Password.Text);
        UserInfoConfig.SetUserConfig("SMTP", TextBox_SMTP.Text);
        UserInfoConfig.SetUserConfig("port", TextBox_Port.Text);
        UserInfoConfig.SetUserConfig("userName", TextBox_UserName.Text);
        UserInfoConfig.SetUserConfig("keywords", TextBox_Keyword.Text);
        Tools.Show(this.Page, "更改完成!");
    }
}
