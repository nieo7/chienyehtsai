using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

/// <summary>
/// OrderDetail 的摘要描述
/// </summary>
namespace Model
{
    public class OrderDetailInfo
    {
        public int od_id { get; set; }
        public int o_id { get; set; }
        public int p_id { get; set; }
        public string p_name { get; set; }
        public decimal od_unitPrice { get; set; }
        public int od_quantity { get; set; }
        public OrderDetailInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static OrderDetailInfo Populate(IDataReader reader)
        {
            OrderDetailInfo info = new OrderDetailInfo();
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
}