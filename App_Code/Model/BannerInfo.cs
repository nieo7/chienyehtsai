using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

namespace Model
{
    /// <summary>
    /// BannerInfo 的摘要描述
    /// </summary>
    public class BannerInfo
    {
        public BannerInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public int b_id { get; set; }
        public int bc_id { get; set; }
        public int bcs_id { get; set; }
        public int bl_id { get; set; }
        public string b_title { get; set; }
        public string b_url { get; set; }
        public string b_imagename { get; set; }
        public int b_price { get; set; }
        public int b_prob { get; set; }
        public string b_target { get; set; }        
        public int b_hits { get; set; }
        public DateTime b_ts { get; set; }
        public DateTime b_editDate { get; set; }
        public DateTime b_startDate { get; set; }
        public DateTime b_endDate { get; set; }

        public static BannerInfo Populate(IDataReader reader)
        {
            BannerInfo info = new BannerInfo();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                PropertyInfo property = info.GetType().GetProperty(reader.GetName(i));
                Type propType = property.PropertyType;
                TypeConverters.ITypeConverter typeConverter =
                    TypeConverters.TypeConverterFactory.GetConvertType(propType);
                property.SetValue(info,Convert.ChangeType(typeConverter.Convert(reader.GetValue(i)), propType), null);
            }
            return info;
        }
    }
}
