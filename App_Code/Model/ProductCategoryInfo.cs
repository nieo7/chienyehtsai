using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

/// <summary>
/// ProductCategoryInfo 的摘要描述
/// </summary>
namespace Model
{
    public class ProductCategoryInfo
    {
        public ProductCategoryInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public int pc_id { get; set; }
        public string pc_name { get; set; }
        public int pc_fatherid { get; set; }
        public int pc_sorting { get; set; }
        public string pc_image { get; set; }
        public string pc_thumb { get; set; }
        public bool  pc_show { get; set; }
        public int l_id { get; set; }

        public static ProductCategoryInfo Populate(IDataReader reader)
        {
            ProductCategoryInfo info = new ProductCategoryInfo();
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