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
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using BLL;
using Model;
public partial class ManagerPage : MasterBasePage
{
    AdminPowerBLL apBLL = new AdminPowerBLL();
    AdminItem1BLL ai1BLL = new AdminItem1BLL();    
    AdminBLL aBLL = new AdminBLL();
    BasePage Bs = new BasePage();
    TempfilestableBLL tempfileBLL = new TempfilestableBLL();
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Page.Header.DataBind();
    }
    protected override void OnInit(EventArgs e)
    {
        //workMethod();
       CheckLoginCookie();    
        //設定Language PostBack屬性
        ddrLanguage.SetAutoPostBack = true;                
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            //暫存檔處理專用程序                        
            Bind();
            Bs.ControlID = "ContentPlaceHolder1";
            Bs.WebControlEvent(this.Page.Master, BasePage.ControlType.TextBox, BasePage.EnevtType.onmouseover);
        }
    }
    private void InitPage()
    {
        //phsystemhelp.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("MasterPage", "phsystemhelp"));
        //phtinyurl.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("MasterPage", "phtinyurl"));
        //phtempfiles.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("MasterPage", "phtempfiles"));        
    }
    private void Bind()
    {        
        repMain.DataSource = apBLL.GetDataAccountPowerWithItem1(Tools.cookieLoginID);
        repMain.DataBind();
        AdminInfo info = aBLL.getDataById(Tools.cookieLoginID);        
        lbName.Text = info.a_account;
    }
    protected void lkLoginOut_Click(object sender, EventArgs e)
    {
        Session.Remove("User_ID");
        Response.Redirect(Tools.GetAppSettings("LoginUrl"));
    }
    protected void repMain_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater repSub = (Repeater)e.Item.FindControl("repSub");
        HiddenField hiid = (HiddenField)e.Item.FindControl("HiddenField_Id");
        repSub.DataSource = apBLL.GetDataWithItem1WithItem2ForMenu(Tools.cookieLoginID, int.Parse(hiid.Value));
        repSub.DataBind();
    }
    protected void CheckLoginCookie()
    {
        if (HttpContext.Current.Request.Cookies["User"] == null)
        {
            Response.Redirect("~/Manager/SignIn.aspx");
        }
    }
    public void workMethod()
    {
            Tools.cookieLoginID = 1;       
    }
}
