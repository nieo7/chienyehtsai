using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Data;

namespace Model
{
    /// <summary>
    /// AdminItem2Info 的摘要描述
    /// </summary>
    public class AdminItem2Info
    {
        public AdminItem2Info()
        {
        }
        public int ai2_id { get; set; }
        public int ai2_no1{ get; set; }
        public int ai2_sort { get; set; }
        public string ai2_name { get; set; }
        public string ai2_url { get; set; }
        public bool ai2_visible { get; set; }

        public static AdminItem2Info Populate(IDataReader reader)
        {
            AdminItem2Info info = new AdminItem2Info();
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