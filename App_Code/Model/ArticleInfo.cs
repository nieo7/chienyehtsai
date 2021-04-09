using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;


namespace Model
{
    /// <summary>
    /// ArticleInfo 的摘要描述
    /// </summary>
    public class ArticleInfo
    {
        public ArticleInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public int a_id { get; set; }
        public int ac_id { get; set; }
        public string a_title { get; set; }
        public string a_detail { get; set; }
        public int a_hits { get; set; }
        public DateTime a_ts { get; set; }
        public DateTime a_editDate { get; set; }
        public bool a_show { get; set; }
        public int a_sorting { get; set; }
        public string a_img { get; set; }
        public int l_id { get; set; }
        public static ArticleInfo Populate(IDataReader reader)
        {
            ArticleInfo info = new ArticleInfo();
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
