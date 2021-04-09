using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;


namespace Model
{
    /// <summary>
    /// News 的摘要描述
    /// </summary>
    public class NewsInfo
    {
        public NewsInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public int n_id { get; set; }
        public int nc_id { get; set; }
        public string n_title { get; set; }
        public string n_detail { get; set; }
        public string n_image { get; set; }
        public DateTime n_ts { get; set; }
        public DateTime n_editDate { get; set; }
        public int n_hits { get; set; }
        public bool n_show { get; set; }
        public DateTime n_startDate { get; set; }
        public DateTime n_endDate { get; set; }
        public int l_id { get; set; }
        public int f_id { get;set;}
        public static NewsInfo Populate(IDataReader reader)
        {
            NewsInfo info = new NewsInfo();
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