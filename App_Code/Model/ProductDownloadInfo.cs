using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
/// <summary>
/// ProductDownload 的摘要描述
/// </summary>
namespace Model
{
    public class ProductDownloadInfo
    {
        public int pd_id { get; set; }
        public int p_id { get; set; }
        public string pd_name { get; set; }
        public string pd_type { get; set; }
        public string pd_value { get; set; }
        public DateTime pd_createdate { get; set; }
        public ProductDownloadInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static ProductDownloadInfo Populate(IDataReader reader)
        {
            ProductDownloadInfo info = new ProductDownloadInfo();
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