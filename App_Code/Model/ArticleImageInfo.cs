using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;


/// <summary>
/// ArticleImageInfo 的摘要描述
/// </summary>
namespace Model
{
    public class ArticleImageInfo
    {
        public int ap_id { get; set; }
        public int a_id { get; set; }
        public string ap_name { get; set; }
        public string ap_imagename { get; set; }
        public bool ap_show { get; set; }
        public ArticleImageInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static ArticleImageInfo Populate(IDataReader reader)
        {
            ArticleImageInfo info = new ArticleImageInfo();
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
