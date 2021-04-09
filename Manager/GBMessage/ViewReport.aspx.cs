using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class Manager_GBMessage_ViewReport : BasePage
{
    GBcategoryBLL gbcBLL = new GBcategoryBLL();
    GBmessageBLL gbBLL = new GBmessageBLL();
    GBreBLL gBLL = new GBreBLL();
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
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phcategory"));
        phtitle.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phtitle"));
        phrpgbre.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phrpgbre"));
    }
    protected void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) > 0)
            {
                GBmessageInfo info = gbBLL.GetDataById(id);
                lbCategory.Text = gbcBLL.GetDataById(info.gbc_Id).gbc_title;
                lbTitle.Text = info.gb_title;
                Repeater1.DataSource = gBLL.GetDataByCategoryId(info.gb_ID);
                Repeater1.DataBind();
            }
        }
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "myDelete")
        {
            if (gBLL.Delete(int.Parse(e.CommandArgument.ToString())) > 0)
            {
                //Literal litTitle = (Literal)e.Item.FindControl("litTitle");
                //AddMethodSystem.ShowBox(UpdatePanel1, this.GetType(), "DeleteCart", "alert('刪除產品: " + litTitle.Text + " 成功');");
                ShowMessage("刪除成功");
                Bind();
            }
        }
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
}