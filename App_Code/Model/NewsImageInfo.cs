using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
/// <summary>
/// NewsImageInfo 的摘要描述
/// </summary>

namespace Model
{
    
    public class NewsImageInfo
    {
        public int np_id { get; set; }
        public int n_id { get; set; }
        public string np_name { get; set; }
        public string np_imagename { get; set; }
        public NewsImageInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static NewsImageInfo Populate(IDataReader reader)
        {
            NewsImageInfo info = new NewsImageInfo();
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
