using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
/// <summary>
/// ProductTempFormat 的摘要描述
/// </summary>
namespace Model
{
    public class ProductTempFormatInfo
    {
        public int pf_id { get; set; }
        public int pc_id { get; set; }
        public string pf_name { get; set; }
        public string pf_value { get; set; }
        public int pf_sorting { get; set; }
        public ProductTempFormatInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static ProductTempFormatInfo Populate(IDataReader reader)
        {
            ProductTempFormatInfo info = new ProductTempFormatInfo();
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
}