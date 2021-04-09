using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// SMTPConfig 的摘要描述
/// </summary>
public static class SMTPConfig 
{
    public static string GetUserConfig(string nodename){
        XmlUtility.filename = "SMTPXML.xml";
        return XmlUtility.GetUserConfig(nodename);
    }
    public static void SetUserConfig(string nodeName, string nodeInnerText)
    {
        XmlUtility.filename = "SMTPXML.xml";
        XmlUtility.SetUserConfig(nodeName, nodeInnerText);
    }
}