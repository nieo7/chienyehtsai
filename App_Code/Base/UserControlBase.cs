using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// UserControlBase 的摘要描述
/// </summary>
public class UserControlBase : System.Web.UI.UserControl
{
    public BasePage bp = new BasePage();
    public UserControlBase()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        bp = (BasePage)this.Page;
    }
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
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
}
