using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
/// <summary>
/// OrderTransCost 的摘要描述
/// </summary>
public class OrderTransCostInfo
{
    public int otc_id { get; set; }
    public string otc_name { get; set; }
    public int otc_cost { get; set; }
    public string otc_detail { get; set; }
    public bool otc_show { get; set; }
    public OrderTransCostInfo()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public static OrderTransCostInfo Populate(IDataReader reader)
    {
        OrderTransCostInfo info = new OrderTransCostInfo();
        for (int i = 0; i < reader.FieldCount; i++)
        {
            PropertyInfo property = info.GetType().GetProperty(reader.GetName(i));
            Type propType = property.PropertyType;
            TypeConverters.ITypeConverter typeConverter =
                TypeConverters.TypeConverterFactory.GetConvertType(propType);

            property.SetValue(info,
                Convert.ChangeType(typeConverter.Convert(reader.GetValue(i)), propType), null);
        }
        return info;
    }
}