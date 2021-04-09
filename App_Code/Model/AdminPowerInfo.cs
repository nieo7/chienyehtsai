using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Data;

namespace Model
{
    /// <summary>
    /// AdminPowerInfo 的摘要描述
    /// </summary>
    public class AdminPowerInfo
    {
        public AdminPowerInfo()
        {

        }
        public int ap_id { get; set; }
        public int ap_aid { get; set; }
        public int ap_no1 { get; set; }
        public int ap_no2 { get; set; }
        public bool ap_enable { get; set; }

        public static AdminPowerInfo Populate(IDataReader reader)
        {
            AdminPowerInfo info = new AdminPowerInfo();
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