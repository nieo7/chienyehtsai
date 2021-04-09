using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

namespace Model
{
    /// <summary>
    /// ArticleCategoryInfo 的摘要描述
    /// </summary>
    public class ArticleCategoryInfo
    {
        public ArticleCategoryInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public int ac_id { get; set; }
        public string ac_name { get; set; }
        public int ac_sorting { get; set; }
        public string ac_type { get; set; }
        public int ac_fatherId { get; set; }
        public int l_id { get; set; }

        public static ArticleCategoryInfo Populate(IDataReader reader)
        {
            ArticleCategoryInfo info = new ArticleCategoryInfo();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                PropertyInfo property = info.GetType().GetProperty(reader.GetName(i));
                Type proType = property.PropertyType;
                TypeConverters.ITypeConverter typeConverter = TypeConverters.TypeConverterFactory.GetConvertType(proType);
                property.SetValue(info, Convert.ChangeType(typeConverter.Convert(reader.GetValue(i)), proType), null);
            }
            return info;
        }
    }
}
