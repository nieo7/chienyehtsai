using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

/// <summary>
/// BannerLocationInfo 的摘要描述
/// </summary>
namespace Model
{
    public class BannerLocationInfo
    {
        public int bl_id { get; set; }
        public string bl_title { get; set; }
        public int bl_father_id { get; set; }
        public bool bl_show { get; set; }
        public BannerLocationInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static BannerLocationInfo Populate(IDataReader reader)
        {
            BannerLocationInfo info = new BannerLocationInfo();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                PropertyInfo property = info.GetType().GetProperty(reader.GetName(i));
                Type propType = property.PropertyType;
                TypeConverters.ITypeConverter typeConverter =
                    TypeConverters.TypeConverterFactory.GetConvertType(propType);
                property.SetValue(info, Convert.ChangeType(typeConverter.Convert(reader.GetValue(i)), propType), null);
            }
            return info;
        }
    }
}