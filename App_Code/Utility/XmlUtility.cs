using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Xml;

/// <summary>
/// XmlUtility 的摘要描述
/// </summary>
public static class XmlUtility
{

    public static string WebSiteVirtualPath
    {
        get
        {
            return HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["WebSiteVirtualPath"]);
        }
    }
    public static string filename = "";

    public static XmlDocument GetUserConfigXMLDom()
    {
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(WebSiteVirtualPath+filename);
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
        xmldoc.Save(WebSiteVirtualPath+filename);
    }
}