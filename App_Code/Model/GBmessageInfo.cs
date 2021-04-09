using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

/// <summary>
/// GBmessage 的摘要描述
/// </summary>
public class GBmessageInfo
{
    public int gb_ID { get; set; }
    public int gbc_Id { get; set; }
    public string gb_name { get; set; }
    public string gb_mail { get; set; }
    public bool gb_show_mail { get; set; }
    public string gb_ip { get; set; }
    public string gb_level { get; set; }
    public string gb_title { get; set; }
    public string gb_content { get; set; }
    public DateTime gb_createdate { get; set; }
    public DateTime gb_editdate { get; set; }
    public bool gb_show { get; set; }
    public int gb_hits { get; set; }
    public GBmessageInfo()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public static GBmessageInfo Populate(IDataReader reader)
    {
        GBmessageInfo info = new GBmessageInfo();
        for (int i = 0; i < reader.FieldCount; i++)
        {
            PropertyInfo property = info.GetType().GetProperty(reader.GetName(i));
            Type propType = property.PropertyType;
            TypeConverters.ITypeConverter typeConverter = TypeConverters.TypeConverterFactory.GetConvertType(propType);
            property.SetValue(info, Convert.ChangeType(typeConverter.Convert(reader.GetValue(i)), propType), null);
        }
        return info;
    }
}