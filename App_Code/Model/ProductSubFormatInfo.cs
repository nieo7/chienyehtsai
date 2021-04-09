using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
/// <summary>
/// ProductSubFormatInfo 的摘要描述
/// </summary>
namespace Model
{
    public class ProductSubFormatInfo
    {
        public int psf_id { get; set; }
        public int p_id { get; set; }
        public string psf_name { get; set; }
        public string psf_value { get; set; }
        public int psf_sorting { get; set; }
        public ProductSubFormatInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static ProductSubFormatInfo Populate(IDataReader reader)
        {
            ProductSubFormatInfo info = new ProductSubFormatInfo();
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