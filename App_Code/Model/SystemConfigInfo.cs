using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Data;

namespace Model
{
    /// <summary>
    /// SysconfigInfo 的摘要描述
    /// </summary>
    public class SystemConfigInfo
    {
        public SystemConfigInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public int sc_Id { get; set; }
        public string sc_Class { get; set; }
        public string sc_Name { get; set; }
        public string sc_Value { get; set; }
        public string sc_DefaultValue { get; set; }
        public string sc_Desc { get; set; }
        public int sc_Admin { get; set; }
        public bool sc_enable { get; set; }
        public bool sc_adminenable { get; set; }
        public DateTime sc_ts { get; set; }

        public static SystemConfigInfo Populate(IDataReader reader)
        {
            SystemConfigInfo info = new SystemConfigInfo();
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