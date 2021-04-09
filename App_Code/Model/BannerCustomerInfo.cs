using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

/// <summary>
/// BannerCustomerInfo 的摘要描述
/// </summary>
namespace Model
{
    public class BannerCustomerInfo
    {
        public int bcs_id { get; set; }
        public string bcs_key { get; set; }
        public string bcs_company_name { get; set; }
        public string bcs_company_type { get; set; }
        public string bcs_company_phone { get; set; }
        public string bcs_name { get; set; }
        public string bcs_sex { get; set; }
        public string bcs_phone { get; set; }
        public string bcs_mail { get; set; }
        public string bcs_fax { get; set; }
        public string bcs_city { get; set; }
        public string bcs_area { get; set; }
        public string bcs_code { get; set; }
        public string bcs_address { get; set; }
        public string bcs_note { get; set; }
        public DateTime bcs_ts { get; set; }
        public DateTime bcs_editdate { get; set; }
        public BannerCustomerInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static BannerCustomerInfo Populate(IDataReader reader)
        {
            BannerCustomerInfo info = new BannerCustomerInfo();
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