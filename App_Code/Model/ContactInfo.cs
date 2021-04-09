using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Data;

/// <summary>
/// ContactInfo 的摘要描述
/// </summary>
namespace Model
{
    public class ContactInfo
    {
        public int c_id { get; set; }
        public string c_name { get; set; }
        public string c_subject { get; set; }
        public string c_sex { get; set; }
        public string c_phone1 { get; set; }
        public string c_phone2 { get; set; }
        public string c_mail { get; set; }
        public string c_address { get; set; }
        public string c_detail { get; set; }
        public bool c_check_read { get; set; }
        public bool c_check_reply { get; set; }
        public DateTime c_pose_date { get; set; }
        public DateTime c_reply_date { get; set; }
        public string c_ip { get; set; }
        public int l_id { get; set; }
        public ContactInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static ContactInfo Populate(IDataReader reader)
        {
            ContactInfo info = new ContactInfo();
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