using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

/// <summary>
/// CartInfo 的摘要描述
/// </summary>
public class CartInfo
{
	public CartInfo()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public int c_id { get; set; }
    public string c_customer { get; set; }
    public int p_id { get; set; }
    public string p_name { get; set; }
    public decimal c_unitPrice { get; set; }
    public int c_quantity { get; set; }
    public DateTime c_cartTime { get; set; }
    public string p_format { get; set; }


    public static CartInfo Populate(IDataReader reader)
    {
        CartInfo info = new CartInfo();
        for (int i = 0; i < reader.FieldCount; i++)
        {
            PropertyInfo property = info.GetType().GetProperty(reader.GetName(i));
            Type propType = property.PropertyType;
            TypeConverters.ITypeConverter typeConverter = TypeConverters.TypeConverterFactory.GetConvertType(propType);

            property.SetValue(info, Convert.ChangeType(typeConverter.Convert
                (reader.GetValue(i)), propType), null);
        }
        return info;
    }
}