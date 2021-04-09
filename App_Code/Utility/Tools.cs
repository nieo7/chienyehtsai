using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.ComponentModel;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
/// <summary>
/// Tools 的摘要描述
/// </summary>
public class Tools
{
    private static string LogoImagePathSavePath = ConfigurationManager.AppSettings["LogoImagePath"];
    private readonly static string LogoImagePath_serverPath = HttpContext.Current.Server.MapPath(LogoImagePathSavePath);
    private readonly static string BannerImagePath = ConfigurationManager.AppSettings["BannerImagePath"];
    private readonly static string ImageSavePath = ConfigurationManager.AppSettings["MemberImagePath"];

	public Tools()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    /*
    方法名稱: GetRandomString
    方法說明: 取得亂數所產生的英文字母大小寫與數字組合的字串
    參數說明: length - 要產生的亂數字串長度
    傳回值: string - 亂數字串
    使用範例: 
            //code可能為 m0bJ57L7PX08A0ice9sb0Lngu
            string code = Tools.GetRandomString(25);
    */
    public static string GetRandomString(int length)
    {
        Random r = new Random();

        string code = "";

        for (int i = 0; i < length; ++i)
            switch (r.Next(0, 3))
            {
                case 0: code += r.Next(0, 10); break;
                case 1: code += (char)r.Next(65, 91); break;
                case 2: code += (char)r.Next(97, 122); break;
            }

        return code;
    }

    /*
   方法名稱: GetMD5String
   方法說明: 取得加密字串(使用MD5加密)
   參數說明: password - 要加密的字串
   傳回值: string - MD5字串
   使用範例: 
           //md5值為 81DC9BDB52D04DC20036DBD8313ED055
           string md5 = Tools.GetMD5String("1234");
   */
    public static string GetMD5String(string password)
    {
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
    }

    public static string NoHTML(string Htmlstring) //去除HTML标记
    {
        //删除脚本
        Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
        //删除HTML
        Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

        Htmlstring.Replace("<", "");
        Htmlstring.Replace(">", "");
        Htmlstring.Replace("\r\n", "");
        Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

        return Htmlstring;
    }
    public static string GetAppSettings(string name)
    {
        string r = "";

        try
        {
            r = WebConfigurationManager.AppSettings[name];//web.config中的appSetting
        }
        catch (Exception ex)
        {
            r = ex.Message;
        }

        return r;
    }

    public static string GetPassword(string username, string password)
    {
        string r = Tools.GetMD5String(username + password);

        r = r.Substring(0, 10) + r.Substring(21);

        return r;
    }
    public static string GetPassword(string password)
    {
        string r = Tools.GetMD5String(password);

        r = r.Substring(0, 10) + r.Substring(21);

        return r;
    }
    public static string GetSubString(string val,int len,string str)
    {
        string result = NoHTML(val);
        result = result.Replace(" ", "");
        if (result.Length > len)
        {
            return result.Substring(0, len) + str;
        }
        else
        {
            return result;
        }
    }
    public static double BMR(bool Sex, double width, double height, double year, double category)
    {
        double result = 0;
        if (width == 0 || height == 0)
            return 0;
        if (Sex)
        {
            result = 66.4730 + (13.7516 * width) + (5.0033 * height) - (6.7550 * year);
        }
        else
        {
            result = 655.0955 + (9.5634 * width) + (1.8496 * height) - (4.6756 * year);
        }
        result = result * category;
        result = double.Parse(result.ToString("0.0"));
        
        return result;
    }
    public static double BMI(bool Sex, double width, double height)
    {
       
        if (width == 0 || height == 0)
            return 0;
        double h = 0;
        h = height / 100;

        double result = 0;
        result = width / (h * h);
        result = double.Parse(result.ToString("0.0"));
        return result;
    }
    /// <summary>
    /// 彈出小視窗
    /// </summary>
    /// <param name="message">內容</param>
    /// <returns>javascript:alert('xxx');</returns>
    public static Literal Tomsg(string message)
    {
        Literal txtMsg = new Literal();
        txtMsg.Text = "<script>alert('" + message + "')</script>" + "<BR/>";
        return txtMsg;
    }
    /// <summary>
    /// 自定义弹出窗口内容
    /// </summary>
    /// <param name="msg"></param>
    public static void AjaxShow(string msg)
    {
        //myContext.Response.Write("<script>alert('" + msg + "');</script>");
        ScriptManager.RegisterStartupScript((System.Web.UI.Page)HttpContext.Current.CurrentHandler, typeof(System.Web.UI.Page), "ShowMessage", "alert('" + msg + "');", true);
    }
    /// <summary>
    /// 自定义弹出窗口内容并直接转向一个新的页面
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="url"></param>
    public static void AjaxShow(string msg, string url)
    {
        //myContext.Response.Write("<script>alert('" + msg + "');
        //javascript:location='"+Url+"';</script>");
        ScriptManager.RegisterStartupScript(
            (System.Web.UI.Page)HttpContext.Current.CurrentHandler,
            typeof(System.Web.UI.Page), "ShowMessage", "alert('" +
            msg + "');javascript:location='" + url + "';", true);

    }

    /// <summary>
    /// 自定义弹出窗口内容，不跳转
    /// </summary>
    /// <param name="page"></param>
    /// <param name="msg"></param>
    public static void Show(System.Web.UI.Page page, string msg)
    {
        page.ClientScript.RegisterStartupScript(page.GetType(), "ShowMessage", "alert('" + msg + "');", true);
    }
    public static string getAlert(string message)
    {
        string script = "";
        script += "<script>alert('" + message + "');</script>";
        return script;
    }
    public static string getAlrtWithRehf(string message,string url)
    {
        string script = "";
        script += "<script>alert('" + message + "');window.parent['folderAREA'].location.reload();</script>";
        script += "<script>window.location='" + url + "';</script>";
        return script;
    }
    public static string folderAREAReload()
    {
        string script = "";
        script += "<script>window.parent['folderAREA'].location.reload();</script>";
        return script;
    }
    public static string GetZoomImageCode(string path, int width, int height)
    {
        return new Security().Encrypt(string.Format("{0};{1};{2}", path, width, height));
    }
     // 从 querystring 集合中安全的取得一个 string. (总是不会有 null，所以叫做 'Safe')
    public static string GetStringSafeFromQueryString(Page page, string key)
    {
        string value = page.Request.QueryString[key];
        if (value != null)
            value = HttpUtility.UrlDecode(page.Request.QueryString[key].ToString(), System.Text.Encoding.UTF8);
        return (value == null) ? string.Empty : value;
    }

    public static int GetInt32SafeFromQueryString(Page page, string key, int defaultValue)
    {
        string value = GetStringSafeFromQueryString(page, key);
        int i = defaultValue;
        try
        {
            i = int.Parse(value);
        }
        catch { }
        return i;
    }
    /// <summary> 
    /// 遞迴尋找符合條件的控制項。 
    /// </summary> 
    /// <param name="Parent">父控制項。</param> 
    /// <param name="Type">欲尋找的控制項型別。</param> 
    /// <param name="PropertyName">比對的屬性名稱。</param> 
    /// <param name="PropertyValue">比對的屬性值。</param> 
    public static object FindControlEx(System.Web.UI.Control Parent, System.Type Type, string PropertyName, object PropertyValue) 
    { 
        //System.Web.UI.Control oControl = default(System.Web.UI.Control); 
        object oFindControl = null; 
        object oValue = null;

        foreach (Control oControl in Parent.Controls)
        { 
            if (Type.IsInstanceOfType(oControl)) { 
                //取得屬性值 
                oValue = GetPropertyValue(oControl, PropertyName); 
                if (oValue.Equals(PropertyValue)) { 
                        //型別及屬性值皆符合則回傳此控制項 
                    return oControl; 
                } 
            } 
            else { 
                if (oControl.Controls.Count > 0) { 
                    //遞迴往下尋找符合條件的控制項 
                    oFindControl = FindControlEx(oControl, Type, PropertyName, PropertyValue); 
                    if (oFindControl != null) { 
                        return oFindControl; 
                    } 
                } 
            } 
        } 
        return null; 
    } 

    /// <summary> 
    /// 取得物件的屬性值。 
    /// </summary> 
    /// <param name="Component">具有要擷取屬性的物件。</param> 
    /// <param name="PropertyName">屬性名稱。</param> 
    public static object GetPropertyValue(object Component, string PropertyName)
    {
        PropertyDescriptor Prop = TypeDescriptor.GetProperties(Component)[PropertyName];
        return Prop.GetValue(Component);
    }
    /// <summary>
    /// 抓取Client端IP值
    /// </summary>
    /// <returns></returns>
    public static string GetIpAddress()
    {
        string strIpAddr = string.Empty;

        if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null || HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf("unknown") > 0)
        {
            strIpAddr = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        else if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(",") > 0)
        {
            strIpAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Substring(1, HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(",") - 1);
        }
        else if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(";") > 0)
        {
            strIpAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Substring(1, HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(";") - 1);
        }
        else
        {
            strIpAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        }
        return strIpAddr; ;
    }
    public static bool IsNumeric(string val)
    {
        int result = 0;
        bool isOk = Int32.TryParse(val, out result);
        return isOk;
    }
    public static bool IsDateTime(string val)
    {
        DateTime result = DateTime.Now;
        bool isOk = DateTime.TryParse(val, out result);
        return isOk;
    }
    public static string ConvertBytes(long Bytes)
    {
        if (Bytes >= 1073741824)
            return (Bytes / 1024 / 1024 / 1024).ToString("#0.00") + " GB";
        else if (Bytes > 1048576)
            return (Bytes / 1024 / 1024).ToString("#0.00") + " MB";
        else if (Bytes >= 1024)
            return (Bytes / 1024).ToString("#0.00") + " KB";
        else if (Bytes > 0 && Bytes < 1024)
            return Bytes + " Bytes";
        else
            return "0 Bytes";
    }
    public static bool IsValidTel(string strIn)
    {
        return Regex.IsMatch(strIn, @"(\d+-)?(\d{4}-?\d{7}|\d{3}-?\d{8}|^\d{7,8})(-\d+)?");
    }
    /// <summary> 
         /// 檢查統一編號是否正確 
         /// </summary> 
         /// <param name="id1">要檢查的統一編號字串</param> 
         /// <returns>Boolean值</returns> 
    public static Boolean isCompanyID(String strIdno)
    {
        int result =0;
        if (strIdno == null || strIdno.Trim().Length != 8)
        {
            return false;
        }
        else if (!int.TryParse(strIdno, out result))
        {
            return false;
        }

        int ii;

        try
        {
            ii = Convert.ToInt32(strIdno);
        }
        catch (Exception)
        {
            return false;
        }
        int c1;
        int c2;
        int c3;
        int c4;
        int c5;
        int c6;
        int c7;
        int c8;
        try
        {
            c1 = Convert.ToInt32(strIdno.Substring(0, 1));
            c2 = Convert.ToInt32(strIdno.Substring(1, 1));
            c3 = Convert.ToInt32(strIdno.Substring(2, 1));
            c4 = Convert.ToInt32(strIdno.Substring(3, 1));
            c5 = Convert.ToInt32(strIdno.Substring(4, 1));
            c6 = Convert.ToInt32(strIdno.Substring(5, 1));
            c7 = Convert.ToInt32(strIdno.Substring(6, 1));
            c8 = Convert.ToInt32(strIdno.Substring(7, 1));
        }
        catch (Exception)
        {
            return false;
        }

        int y = c1 + c3 + c5 + c8;
        int t = c2 * 2;
        y = y + t / 10 + t % 10;
        t = c4 * 2;
        y = y + t / 10 + t % 10;
        t = c6 * 2;
        y = y + t / 10 + t % 10;
        t = c7 * 4;
        y = y + t / 10 + t % 10;
        int k = y;
        if (y % 10 == 0)
        {
            return true;
        }
        if (c7 == 7)
        {
            y -= 9;
            return y % 10 == 0;
        }
        else
        {
            return false;
        }
    }
    public static string getFileImg(string file)
    {
        string img = "";
        switch (file)
        {
            case "pdf": img = "../images/file_pdf.gif"; break;
            case "xls": img = "../images/file_excel.gif"; break;
            case "xlsx": img = "../images/file_excel.gif"; break;
            case "rar": img = "../images/file_rar.gif"; break;
            case "doc": img = "../images/file_word.gif"; break;
            case "docx": img = "../images/file_word.gif"; break;
            case "jpg": img = "../images/file_img.gif"; break;
            case "gif": img = "../images/file_img.gif"; break;
            default: img = "../images/icon_F_more.gif"; break;
        }
        return img;
    }
    //是否同一周
    public static bool IsInSameWeek(DateTime dtmS, DateTime dtmE)
    {
        TimeSpan ts = dtmE - dtmS;
        double dbl = ts.TotalDays;
        int intDow = Convert.ToInt32(dtmE.DayOfWeek);
        if (intDow == 0)
            intDow = 7;
        if (dbl >= 7 || dbl >= intDow)
            return false;
        else
            return true;
    }
    public static string GetFirstImg(string html)
    {
        return Regex.Match(html, @"(?i)(<img.*?>)").Value;
    }
    public static DateTime getDateNow()
    {
        return DateTime.Now.AddHours(int.Parse(Tools.GetAppSettings("TimeDifference")));
    }
    public static void CloseColorBox()
    {
        HttpContext.Current.Response.Write("<script>parent.$.fn.colorbox.close(); </script>");
    }
    public static void CloseColorBoxReLoad()
    {
        HttpContext.Current.Response.Write("<script>parent.$.fn.colorbox.close(); parent.location.reload(1);</script>");
    }
    public static void CloseColorBoxReLoad(string message)
    {
        HttpContext.Current.Response.Write("<script>alert('" + message + "');parent.$.fn.colorbox.close(); parent.location.reload(1);</script>");
    }
    public static string getFoodImageUrl(string img, int width, int height)
    {
        string path = Tools.GetAppSettings("FoodImagePath");
        string noimage = "~/images/nophoto.gif";
        string s = string.Format("~/GetZoomImage2.ashx?img={0}&w={1}&h={2}&cutw={3}&cuth={4}&notimg={5}", path + img, width, height, width, height, noimage);
        return s;
    }
    public static int getSafeInt32(string obj)
    {
        int result = 0;
        int.TryParse(obj, out result);
        return result;
    }
    public static double getSafeDouble(string obj)
    {
        double result = 0;
        double.TryParse(obj, out result);
        return result;
    }
    /// <summary>
    /// 限制顯示字串數
    /// </summary>
    /// <param name="stringCount">設定單行最大值</param>
    /// <param name="Getstring">字串本體</param>
    /// <param name="ByteCount">總字串最大值</param>
    /// <returns></returns>
    public static string GetandSetStringNoOtherWithByteNoLine(int stringCount, string Getstring, int ByteCount)
     {
         string Setstring = "";
         int savecount = 0;
         int numcount = 0;

         if (System.Text.Encoding.Default.GetBytes(Getstring).Length > stringCount)
         {
             for (int i = 0; i < Getstring.Length; i++)
             {
                 if (numcount < ByteCount)
                 {
                     if (Encoding.Default.GetBytes(Getstring.Substring(i, 1)).Length == 2)
                     {
                         savecount += 2;
                         numcount += 2;
                     }
                     else
                     {
                         savecount += 1;
                         numcount += 1;

                     }
                     if (savecount > stringCount)
                     {
                         //  Setstring += "\n";
                         savecount = 0;
                     }
                     Setstring += Getstring.Substring(i, 1);
                 }
                 else
                 {
                     break;
                 }
             }
         }
         return Setstring;
    }

    /// <summary>
    /// 使用者登入後台專用
    /// </summary>
    public static int cookieLoginID
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
    public static int TryParseMethod(string check)
    {
        int num = 0;
        int.TryParse(check, out num);
        return num;    
    }
    public static bool TryParseBoolMethod(string check)
    {
        bool choice = false;
        bool.TryParse(check, out choice);
        return choice;
    }
    public static DateTime TryParseDateMethod(string check)
    {
        DateTime choice = DateTime.MinValue;
        DateTime.TryParse(check, out choice);
        return choice;
    }
}
