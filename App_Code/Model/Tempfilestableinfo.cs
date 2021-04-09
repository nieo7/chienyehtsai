using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

/// <summary>
/// Tempfilestableinfo 的摘要描述
/// </summary>
namespace Model
{
    public class Tempfilestableinfo
    {
        public Tempfilestableinfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public int tf_id { get; set; }
        public string tf_title { get; set; }
        public string tf_path { get; set; }
        public DateTime tf_date { get; set; }


        public static  Tempfilestableinfo Populate(IDataReader reader)
        {            
            Tempfilestableinfo info = new Tempfilestableinfo();
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