using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

/// <summary>
/// AdminLoginInfo 的摘要描述
/// </summary>
namespace Model
{
    public class AdminLoginInfo
    {
        public int al_id { get; set; }
        public int a_id { get; set; }
        public int al_no2 { get; set; }
        public DateTime al_logintime { get; set; }
        public string al_ip { get; set; }
        public AdminLoginInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static AdminLoginInfo Populate(IDataReader reader)
        {
            AdminLoginInfo info = new AdminLoginInfo();
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