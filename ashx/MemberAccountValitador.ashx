<%@ WebHandler Language="C#" Class="MemberAccountValitador" %>

using System;
using System.Web;
using System.Collections.Generic;
using BLL;
using System.Web.UI.WebControls;
using System.IO;
public class MemberAccountValitador : IHttpHandler
{
    string checkstr = "OK";
    MemberBLL mbLL = new MemberBLL();    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";        
        CheckValidatorOption(context.Request["checkvar"].ToString(), context.Request["checkOption"].ToString());
        context.Response.Write(checkstr);        
    }
    public void CheckValidatorOption(string checkvar,string checkstring)
    {        
        switch (checkstring)
        {
            case "account":
                if (mbLL.GetDataByAccount(checkvar) == 0)
                {
                    checkstr = "false";
                }
                break;
            case "nickname":
                if (mbLL.GetDataByNickname(checkvar) == 0)
                {
                    checkstr = "false";
                }
                break;
        }
    }
    public bool IsReusable {
        get {
            return false;
        }
    }
}