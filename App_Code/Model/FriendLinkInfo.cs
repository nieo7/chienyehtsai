using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

/// <summary>
/// FriendLinkInfo 的摘要描述
/// </summary>
namespace Model
{
    public class FriendLinkInfo
    {
        public int f_id { get; set; }
        public int fc_id { get; set; }
        public string f_title { get; set; }
        public string f_name { get; set; }
        public string f_degree { get; set; }
        public string f_history { get; set; }
        public string f_books { get; set; }
        public string f_specialty { get; set; }
        public string f_license { get; set; }
        public string f_field { get; set; }
        public int f_sorting { get; set; }
        public string f_url { get; set; }
        public string f_img { get; set; }
        public bool f_show { get; set; }
        public DateTime f_ts { get; set; }
        public DateTime f_editDate { get; set; }
        public int l_id { get; set; }

        public FriendLinkInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static FriendLinkInfo Populate(IDataReader reader)
        {
            FriendLinkInfo info = new FriendLinkInfo();
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