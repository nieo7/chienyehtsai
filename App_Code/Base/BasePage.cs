using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using BLL;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

/// <summary>
/// BasePage 的摘要描述
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public BasePage()
    {
        //動態新增PreReder事件
        this.PreRender += new EventHandler(Page_PreRender);
    }
    public int saveGridValue { get; set; }
    public int findGridValue { get; set; }

    //將目前時間寫入session
    private void SetActionStamp()
    {
        Session["actionStamp"] = Server.UrlEncode(DateTime.Now.ToString());
    }
    private void SetActionStampCookie()
    {
        HttpContext.Current.Response.Cookies["actionStamp"].Value = Server.UrlEncode(DateTime.Now.ToString());
    }
    //非PostBack時將會動態產生隱藏欄位紀錄目前時間
    void Page_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //    SetActionStamp();
            SetActionStampCookie();
        }
        //ClientScript.RegisterHiddenField("actionStamp", Session["actionStamp"].ToString());
        ClientScript.RegisterHiddenField("actionStamp", HttpContext.Current.Request.Cookies["actionStamp"].Value);
    }
    /// <summary>
    /// 取得是否From中的actionStamp隱藏欄位是否等於Session時間,[否]將會動態產生隱藏欄位
    /// 使用方法:在頁面直接判斷IsRefresh如果等於true表示已經發送過該表單
    /// Eric 2011/12/02
    /// </summary>
    protected bool IsRefresh
    {
        get
        {
            if (HttpContext.Current.Request["actionStamp"] as string == Session["actionStamp"] as string)
            {
                SetActionStamp();
                return false;
            }
            return true;
        }
    }
    protected bool IsRefreshCookie
    {
        get
        {
            if (Request["actionStamp"] != null)
            {
                if (HttpContext.Current.Request["actionStamp"] as string == HttpContext.Current.Request.Cookies["actionStamp"].Value)
                {
                    SetActionStampCookie();
                    return false;
                }
            }
            return true;
        }
    }

    /// <summary>
    /// 顯示App_GlobalResources的訊息標號
    /// </summary>
    /// <param name="MsgId">訊息標號</param>
    /// <returns></returns>
    protected string Getmessage(string MsgId)
    {
        return Resources.Message.ResourceManager.GetString(MsgId);
    }
    /// <summary>
    /// 檢查是否有該功能權限
    /// </summary>
    /// <param name="fi_no1">主功能</param>
    /// <param name="fi_no2">次功能</param>
    /// <param name="bl_save">是否儲存存取資訊</param>
    public void Check_Power(int fi_no1, int fi_no2, bool bl_save)
    {
        // 載入公用函數
        Common_Func cfc = new Common_Func();
        // 若 Session 不存在則直接顯示錯誤訊息
        try
        {
            if (Check_Power(uid, "", fi_no1, fi_no2, Tools.GetIpAddress(), bl_save) == false)
                //{ }
                Response.Redirect(Tools.GetAppSettings("LoginedUrl") + "?header=權限不足!");
        }
        catch
        {
            Response.Redirect(Tools.GetAppSettings("LoginedUrl") + "?header=權限不足!");
        }
    }
    public bool Check_Power(int a_id, string a_name, int fi_no1, int fi_no2, string lg_ip, bool bl_save)
    {
        AdminPowerBLL apBLL = new AdminPowerBLL();
        AdminLoginBLL alBLL = new AdminLoginBLL();
        if (apBLL.Check(a_id, fi_no1, fi_no2, true))
        {
            if (bl_save == true)
            {
                alBLL.Insert(a_id, fi_no2, DateTime.Now, lg_ip);
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// QueryString:ID
    /// </summary>
    public int id
    {
        get
        {
            return Tools.GetInt32SafeFromQueryString(this.Page, "id", 0);
        }
    }
    /// <summary>
    /// QueryString:類別
    /// </summary>
    public int cate
    {
        get
        {
            return Priv_Cate;
        }
        set
        {
            Priv_Cate = value;
        }
    }
    private int Priv_Cate = 0;
    public void setCate(int cate)
    {
        Priv_Cate = cate;
    }
    /// <summary>
    /// 取得帳號
    /// </summary>
    public string account
    {
        get { return Tools.GetStringSafeFromQueryString(this.Page, "a"); }
    }
    /// <summary>
    /// 登入者編號
    /// </summary>
    public int uid
    {
        get
        {
            if (HttpContext.Current.Request.Cookies["User"] != null)
            {
                return int.Parse(HttpContext.Current.Request.Cookies["User"].Value);
            }
            return 0;
        }
        set
        {
            if (HttpContext.Current.Request.Cookies["User"] != null)
            {
                HttpContext.Current.Response.Cookies["User"].Value = value.ToString();
            }
            else
            {
                HttpCookie cookie = new HttpCookie("User");
                DateTime dt = DateTime.Now;
                TimeSpan ts = new TimeSpan(2, 0, 0, 0);
                cookie.Expires = dt.Add(ts);
                cookie.Value = value.ToString();
                HttpContext.Current.Response.AppendCookie(cookie);
            }
        }
    }
    /// <summary>
    /// 登入語系
    /// </summary>
    public static int lid
    {
        get
        {
            if (HttpContext.Current.Request.Cookies["Language_ID"] != null)
            {
                return int.Parse(HttpContext.Current.Request.Cookies["Language_ID"].Value.ToString());
            }
            return 0;
        }
        set
        {

            if (HttpContext.Current.Request.Cookies["Language_ID"] != null)
            {
                HttpContext.Current.Response.Cookies["Language_ID"].Value = value.ToString();
            }
            else
            {
                HttpCookie cookie = new HttpCookie("Language_ID");//定義cookie對象以及名為Info的項
                DateTime dt = DateTime.Now;//定義時間對象
                TimeSpan ts = new TimeSpan(2, 0, 0, 0);//cookie有效作用時間，具體查msdn
                cookie.Expires = dt.Add(ts);//添加作用時間
                cookie.Value = value.ToString();
                HttpContext.Current.Response.AppendCookie(cookie);//確定寫入cookie
            }
        }
    }
    /// <summary>
    /// 檢查是否已登入
    /// </summary>
    /// <returns>登入是否成功 True:成功 False:失敗
    /// </returns>

    public bool CheckUid()
    {
        if (uid == 0)
        {
            Tools.Show(this.Page, "請登入會員!");
            return false;
        }
        return true;
    }
    public bool isLogin()
    {
        if (uid == 0)
            return false;        
            return true;
    }
    protected override void OnPreLoad(EventArgs e)
    {
        base.OnPreLoad(e);
        cate = Tools.GetInt32SafeFromQueryString(this.Page, "cate", 0);
        this.Page.Title = "建業法律律師事務所高雄所後台管理系統";

        string headers = Tools.GetStringSafeFromQueryString(this.Page, "header");
        if (!IsPostBack)
        {
            if (!IsRefreshCookie)
            {
                if (headers != null && headers.Trim() != "")
                {
                    this.ShowMessage(headers);
                }
            }
        }
    }

    #region Design Matt

    #region  全域頁面控制項事件專用方法
    /// <summary>
    /// 全域頁面控制項事件專用方法
    /// </summary>
    /// <param name="mp"></param>
    /// <param name="type"></param>
    /// <param name="eventType"></param>
    public void WebControlEvent(MasterPage mp, ControlType type, EnevtType eventType)
    {
        ContentPlaceHolder cph = (ContentPlaceHolder)mp.FindControl(ControlID);
        foreach (object obj in cph.Controls)
        {
            switch (type)
            {
                case ControlType.TextBox:
                    if (obj is TextBox)
                    {
                        TextBox txtBox = (TextBox)obj;
                        if (txtBox.TextMode.ToString() != "MultiLine")
                        {
                            switch (eventType)
                            {
                                case EnevtType.onmouseover:
                                    setEnableEnterEvent(txtBox);
                                    break;

                            }
                        }
                    }
                    break;
                case ControlType.ImageButton:
                    if (obj is ImageButton)
                    {
                        ImageButton ibBtn = (ImageButton)obj;
                        switch (eventType)
                        {
                            case EnevtType.onmouseclick:
                                setEnableEnterEvent(ibBtn);
                                break;
                        }
                    }
                    break;
                case ControlType.DropDownList:
                    if (obj is DropDownList)
                    {
                        DropDownList ddl = (DropDownList)obj;
                        switch (eventType)
                        {
                            case EnevtType.onmouseover:
                                setEnableEnterEvent(ddl);
                                break;
                        }
                    }
                    break;
            }
        }
    }
    private void setEnableEnterEvent(WebControl CTY)
    {
        CTY.Attributes.Add("onmouseover", "if(this.clientWidth < this.scrollWidth) this.title=this.value; else this.title=' ';");
        CTY.Attributes.Add("onKeypress", "if(event.keyCode==13)return false;");
    }
    public string ControlID { get; set; }
    public enum ControlType
    {
        TextBox,
        ImageButton,
        DropDownList
    }
    public enum EnevtType
    {
        onKeyPress,
        onmouseclick,
        onmouseover
    }
    #endregion

    #region JQueryHumanMessage專用方法

    const string jQuery = "jQuery";
    const string showMsg = "ShowMessage";

    #region Methods (4)

    //// Protected Methods (3) 

    ///// <summary>
    ///// Getmessages the specified Message id.
    ///// </summary>
    ///// <param name="MsgId">The Message id.</param>
    ///// <returns></returns>
    //public string Getmessage(string MsgId)
    //{
    //    return Resources.Message.ResourceManager.GetString(MsgId);
    //}

    /// <summary>
    /// Registers the startup JS.
    /// </summary>
    /// <param name="RegisterName">Name of the register.</param>
    /// <param name="JS">The JS.</param>
    protected void RegisterStartupJS(string RegisterName, string JS)
    {
        string wholeJS = "<script language=\"JavaScript\"  type=\"text/javascript\" >" + JS + "</script>";
        if (ExistSM())
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), RegisterName, wholeJS, false);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), RegisterName, wholeJS);
        }
    }
    /// <summary>
    /// Shows the information message.
    /// </summary>
    /// <param name="info">The information message.</param>
    public void ShowMessage(string info)
    {
        string showMsgFunction = @"
	            function ShowMe(message,mes2) {
                    $(document).ready(function () {                    
		                humanMsg.displayMsg(message,mes2);
	                })                	
	            }";

        RegisterStartupJS("ShowMe", showMsgFunction);
        string Msglog = System.DateTime.Now.ToString("HH:mm:ss") + " &nbsp; &nbsp; &nbsp; " + info + "<br/>" + this.ViewState["MsgLog"];
        this.ViewState["MsgLog"] = Msglog;
        string js = "ShowMe('" + info + "','" + this.ViewState["MsgLog"].ToString() + "');";
        RegisterStartupJS(showMsg, js);
    }
    private bool ExistSM()
    {
        return (ScriptManager.GetCurrent(this.Page) != null);
    }
    #endregion
    #endregion
    #endregion
}
    