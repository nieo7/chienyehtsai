using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
/// <summary>
/// ProductImageInfo 的摘要描述
/// </summary>
namespace Model
{
    public class ProductImageInfo
    {
        public int pi_id { get; set; }
        public int p_id { get; set; }
        public string pi_image { get; set; }
        public string pi_thumb { get; set; }
        public string pi_imageName { get; set; }        
        public bool pi_show { get; set; }
        public string pi_type { get; set; }
        public int pi_hits { get; set; }
        public ProductImageInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static ProductImageInfo Populate(IDataReader reader)
        {
            ProductImageInfo info = new ProductImageInfo();
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