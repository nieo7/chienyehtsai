using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;


/// <summary>
/// GBCategoryInfo 的摘要描述
/// </summary>
public class GBCategoryInfo
{
    public int gbc_id { get; set; }
    public string gbc_title { get; set; }
    public int gbc_sort { get; set; }
    public bool gbc_show { get; set; }
	public GBCategoryInfo()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public static GBCategoryInfo Populate(IDataReader reader)
    {
        GBCategoryInfo info = new GBCategoryInfo();
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