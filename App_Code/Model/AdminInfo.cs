using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

namespace Model
{
    /// <summary>
    /// AdminInfo 的摘要描述
    /// </summary>
    public class AdminInfo
    {
        public AdminInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public int a_id { get; set; }
        public string a_name { get; set; }
        public string a_nickName { get; set; }
        public string a_account { get; set; }
        public string a_password { get; set; }
        public string a_desc { get; set; }
        public DateTime a_lastDate { get; set; }
        public DateTime a_editDate { get; set; }


        public static AdminInfo Populate(IDataReader reader)
        {
            AdminInfo info = new AdminInfo();
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