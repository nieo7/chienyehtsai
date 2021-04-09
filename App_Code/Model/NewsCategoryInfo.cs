using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

namespace Model
{
    /// <summary>
    /// NewsCategoryInfo 的摘要描述
    /// </summary>
    public class NewsCategoryInfo
    { 
        public NewsCategoryInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public int nc_id { get; set; }
        public string nc_name { get; set; }
        public int nc_fatherid { get; set; }
        public int nc_sorting { get; set; }
        public string nc_image { get; set; }
        public bool nc_show { get; set; }
        public int l_id { get; set; }

        public static NewsCategoryInfo Populate(IDataReader reader)
        {
            NewsCategoryInfo info = new NewsCategoryInfo();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                PropertyInfo property = info.GetType().GetProperty(reader.GetName(i));
                Type propType = property.PropertyType;
                TypeConverters.ITypeConverter typeConverter =TypeConverters.TypeConverterFactory.GetConvertType(propType);

                property.SetValue(info, Convert.ChangeType(typeConverter.Convert
                    (reader.GetValue(i)), propType), null);
            }
            return info;
        }
    }
}
