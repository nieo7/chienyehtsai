using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Text;
using System.Web.UI;
using System.Text.RegularExpressions;


/// <summary>
/// AddMethodSystem 的摘要描述:主要為欄位加工與顯示加工的方法
/// </summary>
public class AddMethodSystem
{
    public StringBuilder StringBul { get; set; }
    public Random ar;
    private string[] EngCollection = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    public AddMethodSystem()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }
    #region 亂數註冊
    public string AddRandomPassword()
    {
        ar = new Random();
        StringBul = new StringBuilder();
        for (int i = 1; i < 11; i++)
        {
            if (ar.Next(2) > 0)
            {
                StringBul.Append(AddaEnglish());
            }
            else
            {
                StringBul.Append(AddaMath());
            }
        }
        return StringBul.ToString();

    }
    public string AddaMath()
    {
        return ar.Next(0, 99).ToString();

    }
    public string AddaEnglish()
    {
        return EngCollection[ar.Next(25)];
    }
    #endregion

    #region UpdataPanel彈跳視窗

    public static void ShowBox(UpdatePanel up1, Type type, string Order, string Script)
    {
        ScriptManager.RegisterClientScriptBlock(up1, type, Order, Script, true);
    }
    public static void ShowBox(UpdatePanel up1, Type type, string selectType)
    {
        switch (selectType)
        {
            case "A":
                ScriptManager.RegisterClientScriptBlock(up1, type, "ADD", "alert('新增成功');document.location.href=window.location;", true);
                break;
            case "E":
                ScriptManager.RegisterClientScriptBlock(up1, type, "EDIT", "alert('編輯成功');document.location.href=window.location;", true);
                break;
            case "D":
                ScriptManager.RegisterClientScriptBlock(up1, type, "Delete", "alert('刪除成功');document.location.href=window.location;", true);
                break;
            case "F":
                ScriptManager.RegisterClientScriptBlock(up1, type, "FailPageSearch", "alert('查無資料,請依照程序使用');", true);
                break;
            case "Upload":
                ScriptManager.RegisterClientScriptBlock(up1, type, "UploadStatus", "alert('請上傳壓縮檔');", true);
                break;
        }
    }
    #endregion

    #region string字元擷取組合
    //String字元擷取組合
    public static string GetandSetString(int stringCount, string Getstring)
    {
        string Setstring = "";
        int savecount = 0;
        if (System.Text.Encoding.Default.GetBytes(Getstring).Length > stringCount)
        {
            for (int i = 0; i < Getstring.Length; i++)
            {
                if (savecount < stringCount)
                {
                    if (Encoding.Default.GetBytes(Getstring.Substring(i, 1)).Length == 2)
                    {
                        savecount += 2;
                    }
                    else
                    {
                        savecount += 1;
                    }
                    Setstring += Getstring.Substring(i, 1);
                }
                else
                {
                    break;
                }
            }
            return Setstring + "...";
        }
        else
        {
            return Getstring;
        }
    }
    public static string GetandSetStringNoOther(int stringCount, string Getstring)
    {
        string Setstring = "";
        int savecount = 0;
        if (System.Text.Encoding.Default.GetBytes(Getstring).Length > stringCount)
        {
            for (int i = 0; i < Getstring.Length; i++)
            {
                if (savecount < stringCount)
                {
                    if (Encoding.Default.GetBytes(Getstring.Substring(i, 1)).Length == 2)
                    {
                        savecount += 2;
                    }
                    else
                    {
                        savecount += 1;
                    }
                    Setstring += Getstring.Substring(i, 1);
                }
                else
                {
                    break;
                }
            }
            return Setstring;
        }
        else
        {
            return Getstring;
        }
    }

    /// <summary>
    /// 此方法為斷行時使用,不限高度
    /// </summary>
    /// <param name="stringCount"></param>
    /// <param name="GetString"></param>
    /// <returns></returns>
    public static string GetandSetStringBrokenMath(int stringCount, string GetString)
    {//預計寫入字數常度控制程式
        string SetString = "";
        int savecount = 0;
        for (int i = 0; i < GetString.Length; i++)
        {
            if (savecount == 52)
            {
                SetString += "\n";
            }
            SetString += GetString.Substring(i, 1);
            savecount += 1;
        }
        return SetString;
    }

    /// <summary>
    /// 此方法設定行數與高度
    /// </summary>
    /// <param name="stringCount"></param>
    /// <param name="GetString"></param>
    /// <param name="NumsCount"></param>
    /// <returns></returns>
    public static string GetandSetStringBrokenMath(int stringCount, string GetString, int NumsCount)
    {//預計寫入字數常度控制程式
        string SetString = "";
        int savecount = 0;
        int numcount = 0;
        for (int i = 0; i < GetString.Length; i++)
        {
            if (numcount != NumsCount)
            {
                if (savecount == stringCount)
                {
                    SetString += "\n";
                }
                SetString += GetString.Substring(i, 1);
                savecount += 1;
                numcount += 1;
            }
            else
            {
                SetString += "...";
                break;
            }
        }
        return SetString;
    }
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
            return Setstring;
        }
        else
        {
            return Getstring;
        }
    }
    #endregion

    #region ADO.NET專用轉換字串
    /// <summary>
    /// 只有Title可以使用,Ckedit不可
    /// </summary>
    /// <param name="Htmlstring"></param>
    /// <returns></returns>
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
        Htmlstring = Htmlstring.Replace("'", "Mark_1"); //'號
        Htmlstring = Htmlstring.Replace("\"", "Mark_2"); //"號
        Htmlstring = Htmlstring.Replace("\n", "<br/>");
        //Htmlstring = Htmlstring.Replace(" ", "&nbsp;");         
        Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
        return Htmlstring;
    }
    /// <summary>
    /// textMulit模式特殊字元置換程序
    /// </summary>
    /// <param name="Htmlstring"></param>
    /// <returns></returns>
    public static string NOHTML2(string Htmlstring)
    {
        Htmlstring = Htmlstring.Replace("'", "Mark_1"); //'號
        Htmlstring = Htmlstring.Replace("\"", "Mark_2"); //"號
        Htmlstring = Htmlstring.Replace("\n", "<br/>");
        //       Htmlstring = Htmlstring.Replace(" ", "&nbsp;");

        return Htmlstring;
    }

    /// <summary>
    /// textMulit模式特殊字元解譯程序
    /// CK處理不了的
    /// </summary>
    /// <param name="HtmlString"></param>
    /// <returns></returns>
    public static string DecodeHtml2(string HtmlString)
    {
        HtmlString = HtmlString.Replace("Mark_1", "'");
        HtmlString = HtmlString.Replace("Mark_2", "\"");
        HtmlString = HtmlString.Replace("<br/>", "\n");
        HtmlString = HtmlString.Replace("&nbsp;", " ");
        HtmlString = HttpContext.Current.Server.HtmlDecode(HtmlString);
        return HtmlString;
    }
    #endregion

    #region Ado.net WHERE組合字串方法
    //支援多型
    /// <summary>
    /// 此方法為Radio擁有2欄位且擁有欄位為:Price
    /// </summary>
    /// <param name="SELECT">SELECT欄位</param>
    /// <param name="Tablename">資料表名稱</param>
    /// <param name="RadioColumn">RadioButton選擇值</param>
    /// <param name="RadioColumnSet1">RadioButton欄位1</param>
    /// <param name="RadioColumnSet2">RadioButton欄位2</param>
    /// <param name="Txtbox1">TextBox輸入字串</param>
    /// <param name="DropdownValue">DropdownList下拉類別</param>
    /// <param name="DropdownSet1">DropdownList下拉欄位</param>
    /// <param name="ORDER">排序字串</param>
    /// <returns></returns>
    public static string SearchWHEREString(string SELECT, string Tablename, string RadioColumn, string RadioColumnSet1, string RadioColumnSet2, string Txtbox1, int DropdownValue, string DropdownSet1, string ORDER)
    {
        int i = 0;
        StringBuilder sb = new StringBuilder();
        sb.Append("SELECT " + SELECT + " FROM " + Tablename + " WHERE 1=1");
        if (RadioColumn == RadioColumnSet1)
        {
            if (Txtbox1.ToLower() != "all" && Txtbox1 != string.Empty)
            {
                sb.Append(" AND " + RadioColumnSet1 + " LIKE '%" + AddMethodSystem.NoHTML(Txtbox1) + "%'");
            }
        }
        else
        {
            if (Txtbox1.ToLower() != "all" && Txtbox1 != string.Empty)
            {
                if (int.TryParse(Txtbox1, out i))
                {
                    sb.Append(" AND " + RadioColumnSet2 + "<=" + int.Parse(Txtbox1));
                }
                else
                {
                    sb.Append(" AND " + RadioColumnSet1 + " LIKE '%" + AddMethodSystem.NoHTML(Txtbox1) + "%'");
                }
            }
        }
        if (DropdownValue != 0)
        {
            sb.Append(" AND " + DropdownSet1 + "=" + DropdownValue);
        }
        sb.Append(ORDER);
        return sb.ToString();
    }
    /// <summary>
    /// 此種方法用在Radio有N欄位且都為String值
    /// </summary>
    /// <param name="SELECT"></param>
    /// <param name="Tablename"></param>
    /// <param name="RadioColumn"></param>
    /// <param name="RadioColumnSet1"></param>
    /// <param name="RadioColumnSet2"></param>
    /// <param name="Txtbox1"></param>
    /// <param name="DropdownValue"></param>
    /// <param name="DropdownSet1"></param>
    /// <param name="ORDER"></param>
    /// <returns></returns>
    public static string SearchWHEREString(string SELECT, string Tablename, string RadioColumn, string Txtbox1, int DropdownValue, string DropdownSet1, string ORDER)
    {
        StringBuilder sb2 = new StringBuilder();
        sb2.Append("SELECT " + SELECT + " FROM " + Tablename + " WHERE 1=1");
        if (Txtbox1.ToLower() != "all" && Txtbox1 != string.Empty)
        {
            sb2.Append(" AND " + RadioColumn + " LIKE '%" + AddMethodSystem.NoHTML(Txtbox1) + "%'");
        }

        if (DropdownValue != 0)
        {
            sb2.Append(" AND " + DropdownSet1 + "=" + DropdownValue);
        }
        sb2.Append(ORDER);
        return sb2.ToString();
    }

    public static string SearchWHEREString(string SELECT, string Tablename, int DropdownValue, string DropdownSet1, string ORDER)
    {
        StringBuilder SBsimple = new StringBuilder();
        SBsimple.Append("SELECT " + SELECT + " FROM " + Tablename + " WHERE 1=1");
        if (DropdownValue != 0)
        {
            SBsimple.Append("AND " + DropdownSet1 + "=" + DropdownValue);
        }
        SBsimple.Append(ORDER);
        return SBsimple.ToString();
    }

    /// <summary>
    /// 此方法為無Dropdown與Radio分別欄位
    /// </summary>
    /// <param name="SELECT"></param>
    /// <param name="Tablename"></param>
    /// <param name="RadioColumn"></param>
    /// <param name="Txtbox1"></param>
    /// <param name="ORDER"></param>
    /// <returns></returns>
    public static string SearchWHEREString(string SELECT, string Tablename, string RadioColumn, string Txtbox1, string ORDER)
    {
        StringBuilder sb3 = new StringBuilder();
        sb3.Append("SELECT " + SELECT + " FROM " + Tablename + " WHERE 1=1");
        if (Txtbox1.ToLower() != "all" && Txtbox1 != string.Empty)
        {
            sb3.Append(" AND " + RadioColumn + " LIKE '%" + AddMethodSystem.NoHTML(Txtbox1) + "%'");
        }
        sb3.Append(ORDER);
        return sb3.ToString();
    }

    /// <summary>
    /// 此方法為無Radio但擁有兩個DropdownList的選擇條件
    /// </summary>
    /// <param name="SELECT"></param>
    /// <param name="Tablename"></param>
    /// <param name="RadioColumn">字串查詢欄位</param>
    /// <param name="Txtbox1">查詢值</param>
    /// <param name="DropdownValue">Dropdown值1</param>
    /// <param name="DropdownSet1">Dropdown欄位1</param>
    /// <param name="DropdownValue2">Dropdown值2</param>
    /// <param name="DropdownSet2">Dropdown欄位2</param>
    /// <param name="ORDER"></param>
    /// <returns></returns>
    public static string SearchWHEREString(string SELECT, string Tablename, string RadioColumn, string Txtbox1, int DropdownValue, string DropdownSet1, int DropdownValue2, string DropdownSet2, string ORDER)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("SELECT " + SELECT + " FROM " + Tablename + " WHERE 1=1");
        if (Txtbox1.ToLower() != "all" && Txtbox1 != string.Empty)
        {
            sb.Append(" AND " + RadioColumn + " LIKE '%" + AddMethodSystem.NoHTML(Txtbox1) + "%'");
        }
        if (DropdownValue != 0)
        {
            sb.Append(" AND " + DropdownSet1 + "=" + DropdownValue);
        }
        if (DropdownValue2 != 0)
        {
            sb.Append(" AND " + DropdownSet2 + "=" + DropdownValue2);
        }
        sb.Append(ORDER);
        return sb.ToString();
    }
    #endregion

    #region ObjectDataSource WHERE組合字串方法

    //支援多型

    /// <summary>
    /// 此方法為:單一TextBox搜尋-控制項:1
    /// </summary>
    /// <param name="SELECT"></param>
    /// <param name="Tablename"></param>
    /// <param name="RadioColumn">欄位名</param>
    /// <param name="Txtbox1">欄位值</param>    
    /// <returns></returns>
    public static string SearchWHEREStringObject(string RadioColumn, string Txtbox1, string ORDER)
    {
        StringBuilder sb3 = new StringBuilder();
        sb3.Append("1=1");
        if (Txtbox1.ToLower() != "all" && Txtbox1 != string.Empty)
        {
            sb3.Append(" AND " + RadioColumn + " LIKE '%" + AddMethodSystem.NoHTML(Txtbox1) + "%'");
        }
        //  sb3.Append(ORDER);
        return sb3.ToString();
    }

    /// <summary>
    /// 此方法為:單一下拉選單搜尋-控制項:1
    /// </summary>
    /// <param name="DropdownValue">下拉值</param>
    /// <param name="DropdownSet1">欄位名</param>    
    /// <returns></returns>
    public static string SearchWHEREStringObject(int DropdownValue, string DropdownSet1, string ORDER)
    {
        StringBuilder sb2 = new StringBuilder();
        sb2.Append("1=1");
        if (DropdownValue != 0)
        {
            sb2.Append("AND " + DropdownSet1 + "=" + DropdownValue);
        }
        //   sb2.Append(ORDER);
        return sb2.ToString();
    }

    /// <summary>
    /// 輸入值與下拉選單值都為string-控制項:2
    /// </summary>
    /// <param name="RadioColumn">欄位名</param>
    /// <param name="Txtbox1">欄位值</param>
    /// <param name="DropdownValue">下拉值</param>
    /// <param name="DropdownSet1">欄位名</param>    
    /// <returns></returns>
    public static string SearchWHEREStringObject(string RadioColumn, string Txtbox1, string DropdownValue, string DropdownSet1, string ORDER)
    {

        StringBuilder sb2 = new StringBuilder();
        sb2.Append("1=1");
        if (Txtbox1.ToLower() != "all" && Txtbox1 != string.Empty)
        {
            sb2.Append(" AND " + RadioColumn + " LIKE '%" + AddMethodSystem.NoHTML(Txtbox1) + "%'");
        }

        if (DropdownValue != "0")
        {
            sb2.Append(" AND " + DropdownSet1 + "='" + DropdownValue + "'");
        }
        //   sb2.Append(ORDER);
        return sb2.ToString();
    }

    /// <summary>
    /// 此種方法用在Radio有N欄位且搭配一個Int值Dropdown-控制項:2
    /// </summary>        
    /// <param name="RadioColumn">欄位名</param>    
    /// <param name="Txtbox1">欄位值</param>
    /// <param name="DropdownValue">Int下拉值</param>
    /// <param name="DropdownSet1">欄位名</param>    
    /// <returns></returns>
    public static string SearchWHEREStringObject(string RadioColumn, string Txtbox1, int DropdownValue, string DropdownSet1, string ORDER)
    {

        StringBuilder sb2 = new StringBuilder();
        sb2.Append("1=1");
        if (Txtbox1.ToLower() != "all" && Txtbox1 != string.Empty)
        {
            sb2.Append(" AND " + RadioColumn + " LIKE '%" + AddMethodSystem.NoHTML(Txtbox1) + "%'");
        }

        if (DropdownValue != 0)
        {
            sb2.Append(" AND " + DropdownSet1 + "=" + DropdownValue);
        }
        //   sb2.Append(ORDER);
        return sb2.ToString();
    }

    /// <summary>
    /// 此方法為Radio有Ｎ欄擁有兩個Int值DropdownList的選擇條件
    /// </summary>
    /// <param name="RadioColumn">欄位名</param>
    /// <param name="Txtbox1">查詢值</param>
    /// <param name="DropdownValue">Int值1</param>
    /// <param name="DropdownSet1">欄位名1</param>
    /// <param name="DropdownValue2">Int值2</param>
    /// <param name="DropdownSet2">欄位名2</param>    
    /// <returns></returns>
    public static string SearchWHEREStringObject(string RadioColumn, string Txtbox1, int DropdownValue, string DropdownSet1, int DropdownValue2, string DropdownSet2, string ORDER)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("1=1");
        if (Txtbox1.ToLower() != "all" && Txtbox1 != string.Empty)
        {
            sb.Append(" AND " + RadioColumn + " LIKE '%" + AddMethodSystem.NoHTML(Txtbox1) + "%'");
        }
        if (DropdownValue != 0)
        {
            sb.Append(" AND " + DropdownSet1 + "=" + DropdownValue);
        }
        if (DropdownValue2 != 0)
        {
            sb.Append(" AND " + DropdownSet2 + "=" + DropdownValue2);
        }
        //sb.Append(ORDER);
        return sb.ToString();
    }

    /// <summary>
    /// 此方法為Radio擁有2種屬性String,Int 且擁有一個下拉選單
    /// </summary>    
    /// <param name="RadioColumn">選擇的欄位名</param>
    /// <param name="RadioColumnSet1">string欄位名</param>
    /// <param name="RadioColumnSet2">Int欄位名</param>
    /// <param name="Txtbox1">TextBox輸入字串</param>
    /// <param name="DropdownValue">下拉值</param>
    /// <param name="DropdownSet1">下拉欄位</param>    
    /// <returns></returns>
    public static string SearchWHEREStringObject(string RadioColumn, string RadioColumnSet1, string RadioColumnSet2, string Txtbox1, int DropdownValue, string DropdownSet1, string ORDER)
    {        
        StringBuilder sb = new StringBuilder();
        sb.Append("1=1");
        if (Txtbox1.ToLower() != "all" && Txtbox1 != string.Empty)
        {
            if (RadioColumn == RadioColumnSet1)
            {
                sb.Append(" AND " + RadioColumnSet1 + " LIKE '%" + AddMethodSystem.NoHTML(Txtbox1) + "%'");
            }
            else
            {    
                    if (Tools.TryParseMethod(Txtbox1.ToString()) != 0)
                    {
                        sb.Append(" AND " + RadioColumnSet2 + "<=" + int.Parse(Txtbox1));
                    }
                    else
                    {
                        sb.Append(" AND " + RadioColumnSet1 + " LIKE '%" + AddMethodSystem.NoHTML(Txtbox1) + "%'");
                    }   
            }
        }
        if (DropdownValue != 0)
        {
            sb.Append(" AND " + DropdownSet1 + "=" + DropdownValue);
        }
        //   sb.Append(ORDER);
        return sb.ToString();
    }

    /// <summary>
    /// Radio擁有兩種屬性:String,Int 且 擁有三個Int下拉選單 控制項:4
    /// </summary>
    /// <param name="RadioColumn">選擇的欄位名</param>
    /// <param name="RadioColumnSet1">String欄位名</param>
    /// <param name="RadioColumnSet2">Int欄位名</param>
    /// <param name="Txtbox1">搜尋值</param>
    /// <param name="ddvalue1">下拉值1</param>
    /// <param name="ddset1">欄位名1</param>
    /// <param name="ddvalue2">下拉值2</param>
    /// <param name="ddset2">欄位名2</param>
    /// <param name="ddvalue3">下拉值3</param>
    /// <param name="ddset3">欄位名3</param>        
    public static string SearchWHEREStringObject(string RadioColumn, string RadioColumnSet1, string RadioColumnSet2, string Txtbox1, int ddvalue1, string ddset1, int ddvalue2, string ddset2, int ddvalue3, string ddset3, string ORDER)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("1=1");
        if (Txtbox1.ToLower() != "all" && Txtbox1 != string.Empty)
        {
            if (RadioColumn == RadioColumnSet2)
            {
                if (Tools.TryParseMethod(Txtbox1.ToString()) != 0)
                {
                    sb.Append(" AND " + RadioColumnSet2 + "<=" + int.Parse(Txtbox1));
                }
                else
                {
                    sb.Append(" AND " + RadioColumnSet1 + " LIKE '%" + AddMethodSystem.NoHTML(Txtbox1) + "%'");
                }   
            }
            else
            {
                sb.Append(" AND " + RadioColumnSet1 + " LIKE '%" + AddMethodSystem.NoHTML(Txtbox1) + "%'");
            }
        }
        if (ddvalue1 != 0)
        {
            sb.Append(" AND " + ddset1 + "=" + ddvalue1);
        }
        if (ddvalue2 != 0)
        {
            sb.Append(" AND " + ddset2 + "=" + ddvalue2);
        }
        if (ddvalue3 != 0)
        {
            sb.Append(" AND " + ddset3 + "=" + ddvalue3);
        }
        //   sb.Append(ORDER);
        return sb.ToString();
    }
    #endregion

    #region LINQ專用WHERE查詢組合字串
    /// <summary>
    /// 此方法為Radio欄位為string
    /// </summary>
    /// <param name="RadioColumns"></param>
    /// <param name="txtbox"></param>     
    /// <returns></returns>
    public static string LinqSearchWhereString(string RadioColumns, string txtbox)
    {
        StringBuilder LSb = new StringBuilder();
        LSb.Append("1==1");
        if (txtbox.ToLower() != "all" && txtbox != string.Empty)
        {
            LSb.Append(" && " + RadioColumns + ".Contains(\"" + txtbox + "\")");
        }
        return LSb.ToString();
    }

    /// <summary>
    /// LINQ專用WHERE查詢組合字串,此方法為1個查詢值與1個類別查詢欄位為int
    /// </summary>
    /// <param name="RadioColumns"></param>
    /// <param name="txtbox"></param>
    /// <returns></returns>
    public static string LinqSearchWhereString(string RadioColumns, string txtbox, string DropdownCol, int DropdownValue)
    {
        StringBuilder LSb2 = new StringBuilder();
        LSb2.Append("1==1");
        if (txtbox.ToLower() != "all" && txtbox != string.Empty)
        {
            LSb2.Append(" && " + RadioColumns + ".Contains(\"" + txtbox + "\")");
        }
        if (DropdownValue != 0)
        {
            LSb2.Append(" && " + DropdownCol + "==" + DropdownValue);
        }
        return LSb2.ToString();
    }
    /// <summary>
    /// LINQ專用WHERE查詢組合字串,此方法為1個查詢值與2個類別查詢欄位為int
    /// </summary>
    /// <param name="RadioColumns">Radio查詢欄位</param>
    /// <param name="txtbox">textBox查詢值</param>
    /// <param name="DropdownCol1">Dropdown類別欄位1</param>
    /// <param name="DropdownValue1">類別值1</param>
    /// <param name="DropdownCol2">Dropdown類別欄位2</param>
    /// <param name="DropdownValue2">類別值2</param>
    /// <returns></returns>
    public static string LinqSearchWhereString(string RadioColumns, string txtbox, string DropdownCol1, int DropdownValue1, string DropdownCol2, int DropdownValue2)
    {
        StringBuilder LS = new StringBuilder();
        LS.Append("1==1");
        if (txtbox.ToLower() != "all" && txtbox != string.Empty)
        {
            LS.Append(" && " + RadioColumns + ".Contains(\"" + txtbox + "\")");
        }
        if (DropdownValue1 != 0)
        {
            LS.Append(" && " + DropdownCol1 + "==" + DropdownValue1);
        }
        if (DropdownValue2 != 0)
        {
            LS.Append(" && " + DropdownCol2 + "==" + DropdownValue2);
        }
        return LS.ToString();
    }
    public static string LinqSearchWhereString(string RadioColumns, string txtbox, string DropdownCol, string DropdownValue)
    {
        StringBuilder LSb3 = new StringBuilder();
        LSb3.Append("1==1");
        if (txtbox.ToLower() != "all" && txtbox != string.Empty)
        {
            LSb3.Append(" && " + RadioColumns + ".Contains(\"" + txtbox + "\")");
        }
        if (DropdownValue != "all")
        {
            LSb3.Append(" && " + DropdownCol + "==" + int.Parse(DropdownValue));
        }
        return LSb3.ToString();
    }

    /// <summary>
    /// LINQ專用WHERE查詢組合字串,此方法為判斷日期欄位(1欄多值)+下拉式欄位字串查詢(多欄位1值)的情況
    /// </summary>
    /// <param name="DropdownCol">查詢欄位</param>
    /// <param name="txtbox">查詢字串</param>
    /// <param name="site_col">使用者欄位</param>
    /// <param name="site_value">使用者ID</param>
    public static string LinqSearchWhereString(string DropdownCol, string txtbox, string DateCol, string DateYearValue, string DateMonthValue, string DateDayValue)
    {
        StringBuilder LSb4 = new StringBuilder();
        LSb4.Append("1==1");
        if (DropdownCol != "all" && txtbox != "all" && txtbox != string.Empty)
        {
            LSb4.Append(" && " + DropdownCol + ".Contains(\"" + txtbox + "\")");
        }
        if (DateYearValue != "0")
        {
            LSb4.Append(" && " + DateCol + ".Contains(\"" + DateYearValue);
            if (DateMonthValue != "0")
            {
                LSb4.Append("/" + DateMonthValue);
                if (DateDayValue != "0")
                {
                    LSb4.Append("/" + DateDayValue);
                }
            }
            LSb4.Append("\")");
        }
        return LSb4.ToString();
    }
    #endregion
}