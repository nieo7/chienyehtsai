using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Resources;
using System.Threading;

/// <summary>
/// WebUtility 的摘要说明
/// </summary>
public static class WebUtility
{
    private readonly static string language = ConfigurationManager.AppSettings["language"];
    private readonly static string newslistPath = ConfigurationManager.AppSettings["NewsListPath"];
    public static void PreView(string htmlEnCode,Page page)
    {
        htmlEnCode = htmlEnCode.Replace("\n", "");
        htmlEnCode = htmlEnCode.Replace("\r", "");
        htmlEnCode = htmlEnCode.Replace('\"', '\'');
        string scriptBlock = Regex.Match(htmlEnCode, @"<script(\s|\S)*script>").Value;
        if (scriptBlock != "")
        {
           string handledScriptBlock = scriptBlock.Replace("<", @"\x3c");
           handledScriptBlock = handledScriptBlock.Replace(">", @"\x3e"); 
           htmlEnCode= htmlEnCode.Replace(scriptBlock, handledScriptBlock);
        }
    //    page.Response.Write("<script language='javascript'> OpenWindow=open(''); OpenWindow.document.write('");
    //    page.Response.Write(htmlEnCode + "');</script>");
        page.ClientScript.RegisterClientScriptBlock(page.GetType(), "a", "<script language='javascript'>\n\r OpenWindow=open('');\n\r OpenWindow.document.write(\"" + htmlEnCode + "\");\n\r</script>");
    }
    public static string getFileString(string filePath)
    {
        Encoding code = Encoding.UTF8;
        StreamReader sr = new StreamReader(filePath, code);
        string content = sr.ReadToEnd();
        sr.Close();

        return content;
    }
    public static void delFile(string filePath){
        File.Delete(filePath);
    }
    ////功能:生成新闻页
    ////参数:
    ////filecontent: 文章主体内容(不包含模板)．
    ////fileName:　文件名.如"11233.html"
    ////header: 标题
    //public static void GeneralNewsPage(string fileContent,string header, string fileName,int categoryId)
    //{
    //    string complete = ArticleFacade.MergerPages(ArticleFacade.getTemplateFile(), fileContent,header,categoryId);
    //    string path = HttpContext.Current.Server.MapPath( newslistPath+ fileName);
    //    StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);
    //    sw.Write(complete);
    //    sw.Flush();
    //    sw.Close();
       
    //}
    //将文件名更改为随机数,后辍不变如: big.jpg -> 2007090812035890.jpg
    public static string ChangeFileNameAsRandom(string oldFileName)
    {
        int index = oldFileName.LastIndexOf('.');
        string AfterTheString = oldFileName.Substring(index);
        if (!Regex.Match(AfterTheString, @"^(.jpg|.png|.gif|.jpeg|.JPG|.PNG|.GIF|.JPEG|.SWF|.swf|.doc|.pdf)$").Success)
        {
            Tools.Tomsg("此檔案類型不支援,請上傳jpg,png,gif,jpeg");
        }
        System.Threading.Thread.Sleep(1);
        return DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond + AfterTheString;

    }
    //产生服务器图片的完整路径
    //参数: fileName 文件名  ex: 2007013545346.jpg
    //      path                ex:/images/
    //返回; fullName            ex: d:/fckeditro/images/2007013545346.jpg
    public static string MergePathAndFileName(string FileName,string path)
    {

        string serverPath = HttpContext.Current.Server.MapPath(path);
        return serverPath + FileName;
    }
    public static void SetCulture()
    {
        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
    }
    //input:fullName:  d:\image\a.jpg
    //output:fileName    a.jpg
    public static string GegFileName(string fullName)
    {
         int lastIndex=fullName.LastIndexOf('\\');
        return fullName.Substring(lastIndex);

    }
    /// <summary>
    /// 檢查圖片副檔名
    /// </summary>
    /// <param name="ext">副檔名稱</param>
    /// <returns></returns>
    public static bool CheckImageExt(string ext)
    {
        bool check = false;
        string[] strext=new string[]{".jpg",".jpeg",".png",".gif",".bmp"};
        for (int i = 0; i < strext.Length; i++)
        {
            if (ext.ToLower() == strext[i].ToString())
            {
                check = true;
                break;
            }            
        }
        return check;        
    }
}
