using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

namespace Model
{
    /// <summary>
    /// BannerCategoryInfo 的摘要描述
    /// </summary>
    public class BannerCategoryInfo
    {
        public BannerCategoryInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public int bc_id { get; set; }
        public string bc_title { get; set; }
        public bool bc_show { get; set; }

        public static BannerCategoryInfo Populate(IDataReader reader)
        {
            BannerCategoryInfo info = new BannerCategoryInfo();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                PropertyInfo property = info.GetType().GetProperty(reader.GetName(i));
                Type propType = property.PropertyType;
                TypeConverters.ITypeConverter typeConverter = TypeConverters.TypeConverterFactory.GetConvertType(propType);

                property.SetValue(info, Convert.ChangeType(typeConverter.Convert
                    (reader.GetValue(i)), propType), null);
            }
            return info;
        }
    }
}
