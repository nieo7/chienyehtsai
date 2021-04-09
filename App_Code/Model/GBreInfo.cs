using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

/// <summary>
/// GBreInfo 的摘要描述
/// </summary>
public class GBreInfo
{
    public int g_id { get; set; }
    public string g_name { get; set; }
    public string g_mail { get; set; }
    public bool g_show_mail { get; set; }
    public string g_ip { get; set; }
    public string g_level { get; set; }
    public string g_content { get; set; }
    public int gb_id { get; set; }
    public DateTime g_adddate { get; set; }
    public string g_url { get; set; }
	public GBreInfo()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public static GBreInfo Populate(IDataReader reader)
    {
        GBreInfo info = new GBreInfo();
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