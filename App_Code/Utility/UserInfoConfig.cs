 using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;

/// <summary>
/// 寫入與讀取XML資料檔專用類別:
///1.使用此類別必需指定變數filename路徑
///EX:UserInfoConfig.filename =UserInfoConfig.WebSiteVirtualPath+"SMTPXML.xml";
/// </summary>
public static class UserInfoConfig
{
    public static string WebSiteVirtualPath
    {
        get
        {
            return HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["WebSiteVirtualPath"]);
        }
    }
    public static string filename ="";
    public static XmlDocument GetUserConfigXMLDom()
    {
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(filename);
        return xmldoc;
    }
    public static string GetUserConfig(string nodeName)
    {
        XmlDocument xmldoc = GetUserConfigXMLDom();
        XmlNodeList topM = xmldoc.DocumentElement.ChildNodes;
        string innerText = "";
        foreach (XmlElement el in topM)
        {
            if (el.Name == nodeName.Trim())
            {
                innerText = el.InnerText;
                break;
            }
        }
        return innerText;
    }
    public static void SetUserConfig(string nodeName, string nodeInnerText)
    {
        XmlDocument xmldoc = GetUserConfigXMLDom();
        XmlNodeList topM = xmldoc.DocumentElement.ChildNodes;
        foreach (XmlElement el in topM)
        {
            if (el.Name == nodeName.Trim())
            {
                el.InnerText = nodeInnerText;
                break;
            }
        }
        xmldoc.Save(filename);
    }
}
