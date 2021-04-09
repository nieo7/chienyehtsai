using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Data;
/// <summary>
/// MemberInfo 的摘要描述
/// </summary>
namespace Model
{
    public class MemberInfo
    {
        public int m_id { get; set; }
        public int m_level { get; set; }
        public string m_account { get; set; }
        public string m_fname { get; set; }
        public string m_name { get; set; }
        public string m_nickname { get; set; }
        public string m_number { get; set; }
        public string m_mail { get; set; }
        public string m_pass { get; set; }
        public string m_sex { get; set; }
        public string m_birthday { get; set; }
        public string m_zipcode { get; set; }
        public string m_area { get; set; }
        public string m_city { get; set; }
        public string m_address { get; set; }
        public string m_phone1 { get; set; }
        public string m_phone2 { get; set; }
        public int m_login_times { get; set; }
        public string m_note { get; set; }
        public DateTime m_adddate { get; set; }
        public DateTime m_editdate { get; set; }
        public DateTime m_lastlogindate { get; set; }
        public string m_check_code { get; set; }
        public bool m_eaper { get; set; }
        public bool m_block { get; set; }
        public MemberInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        public static MemberInfo Populate(IDataReader reader)
        {
            MemberInfo info = new MemberInfo();
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