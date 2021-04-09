using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antlr3.ST;
using System.IO;
/// <summary>
/// StringTemplated 的摘要描述
/// </summary>
/// 
namespace Utility
{
    public class StringTemplated
    {
        public StringTemplated()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static StringTemplate FromFile(string rootDir, string fileName, string locale)
        {
            try
            {
                if (File.Exists(rootDir + "/" + fileName + "_" + locale + "_resource.st"))
                { //如果有客製的Template先使用客製的
                    return new StringTemplateGroup("myGroup", rootDir).GetInstanceOf(fileName + "_" + locale + "_resource");
                }

                if (File.Exists(rootDir + "/" + fileName + "_resource.st")) //如果有客製的Template先使用客製的(Locale是空的)
                {
                    return new StringTemplateGroup("myGroup", rootDir).GetInstanceOf(fileName + "_resource");
                }
            }
            catch
            {  //do nothing
                //CronUtility.Log("EnterNotice GetStringTemplate Exception", ex.ToString)
            }

            if (File.Exists(rootDir + "/" + fileName + "_" + locale + ".st") == false)  //不存在locale的st檔,使用default template
            {
                return new StringTemplateGroup("myGroup", rootDir).GetInstanceOf(fileName);
            }

            return new StringTemplateGroup("myGroup", rootDir).GetInstanceOf(fileName + "_" + locale);
        }
        public static StringTemplate FromFile(string rootDir, string fileName)
        {
            try
            {
                if (File.Exists(rootDir + "/" + fileName + "_resource.st"))
                { //如果有客製的Template先使用客製的
                    return new StringTemplateGroup("myGroup", rootDir).GetInstanceOf(fileName + "_resource");
                }

                if (File.Exists(rootDir + "/" + fileName + "_resource.st")) //如果有客製的Template先使用客製的(Locale是空的)
                {
                    return new StringTemplateGroup("myGroup", rootDir).GetInstanceOf(fileName + "_resource");
                }
            }
            catch
            {  //do nothing
                //CronUtility.Log("EnterNotice GetStringTemplate Exception", ex.ToString)
            }

            if (File.Exists(rootDir + "/" + fileName + ".st") == false)  //不存在locale的st檔,使用default template
            {
                return new StringTemplateGroup("myGroup", rootDir).GetInstanceOf(fileName);
            }

            return new StringTemplateGroup("myGroup", rootDir).GetInstanceOf(fileName);
        }
    }
}