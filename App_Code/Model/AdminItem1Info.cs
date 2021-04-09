using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Data;

namespace Model
{
    /// <summary>
    /// AdminItem1Info 的摘要描述
    /// </summary>
    public class AdminItem1Info
    {
        public AdminItem1Info()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public int ai1_id { get; set; }
        public int ai1_sort { get; set; }
        public string ai1_name { get; set; }
        public string ai1_nickname { get; set; }
        public bool ai1_visible { get; set; }

        public static AdminItem1Info Populate(IDataReader reader)
        {
            AdminItem1Info info = new AdminItem1Info();
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