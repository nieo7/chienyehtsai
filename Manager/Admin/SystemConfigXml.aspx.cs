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

public partial class Manager_Admin_SystemConfigXml : BasePage
{
    ArrayList AL = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlHead header = (HtmlHead)this.Master.FindControl("head1");
        header.Title = UserInfoConfig.GetUserConfig("title");
        if (!IsPostBack)
        {
            InsertDropdown();
            Bind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserInfoConfig.SetUserConfig("HierarchyProductCategory", ddlProductCategory.SelectedValue);
        UserInfoConfig.SetUserConfig("HierarchyArticleCategory", ddlArticleCategory.SelectedValue);
        UserInfoConfig.SetUserConfig("HierarchyBannerLocation", ddlBannerLocation.SelectedValue);
        UserInfoConfig.SetUserConfig("HierarchyNewsCategory", ddlNewsCategory.SelectedValue);
        Label2.Text = "資料更新成功";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Bind();
        Label2.Text = "預設資料,如確定請按更新";
    }
    protected void InsertDropdown()
    {
        for (int i = 0; i < 10; i++)
        {
            ddlProductCategory.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
            ddlArticleCategory.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
            ddlBannerLocation.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
            ddlNewsCategory.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
        }
    }
    public void Bind()
    {
        ddlProductCategory.SelectedValue = UserInfoConfig.GetUserConfig("HierarchyProductCategory");
        ddlArticleCategory.SelectedValue = UserInfoConfig.GetUserConfig("HierarchyArticleCategory");
        ddlBannerLocation.SelectedValue = UserInfoConfig.GetUserConfig("HierarchyBannerLocation");
        ddlNewsCategory.SelectedValue = UserInfoConfig.GetUserConfig("HierarchyNewsCategory");         
    }
}