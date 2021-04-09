using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
/// <summary>
/// OrderInfo 的摘要描述
/// </summary>
namespace Model
{
    public class OrderInfo
    {
        public int o_id { get; set; }
        public string o_number { get; set; }
        public string o_type { get; set; }
        public int otc_id { get; set; }
        public int p_cls_id { get; set; }
        public int m_id { get; set; }
        public string o_name { get; set; }
        public string o_mail { get; set; }
        public string o_account_number { get; set; }
        public string o_phone1 { get; set; }
        public string o_phone2 { get; set; }
        public string o_zipCode { get; set; }
        public string o_area { get; set; }
        public string o_city { get; set; }
        public string o_address { get; set; }
        public string o_detail { get; set; }
        public string o_detail_date { get; set; }
        public string o_detail_time { get; set; }
        public string o_payMethod { get; set; }
        public bool o_check_Order { get; set; }
        public bool o_check_Read { get; set; }
        public bool o_check_Pay { get; set; }
        public bool o_check_Out { get; set; }
        public string o_out_Date { get; set; }
        public bool o_cancel { get; set; }
        public string o_order_info { get; set; }
        public int o_totalPrice { get; set; }
        public DateTime o_ts { get; set; }
        public DateTime o_editDate { get; set; }
        public string o_inv_chk { get; set; }
        public string o_inv_id { get; set; }
        public string o_inv_title { get; set; }        
        public OrderInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static OrderInfo Populate(IDataReader reader)
        {
            OrderInfo info = new OrderInfo();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                PropertyInfo property = info.GetType().GetProperty(reader.GetName(i));
                Type propType = property.PropertyType;
                TypeConverters.ITypeConverter typeConverter =TypeConverters.TypeConverterFactory.GetConvertType(propType);
                property.SetValue(info,Convert.ChangeType(typeConverter.Convert(reader.GetValue(i)), propType), null);
            }
            return info;
        }
    }
}