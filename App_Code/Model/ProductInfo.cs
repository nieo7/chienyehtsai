    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data;
    using System.Reflection;

/// <summary>
/// ProductInfo 的摘要描述
/// </summary>
namespace Model{
    public class ProductInfo
    {
        public int p_id { get; set; }
        public int pc_id { get; set; }
        public int pcs_id { get; set; }
        public string p_name { get; set; }
        public string p_serial { get; set; }
        public int p_status { get; set; }
        public bool p_show { get; set; }
        public bool p_show_hot { get; set; }
        public string p_detail { get; set; }
        public int p_stock { get; set; }
        public string p_stock_unit { get; set; }
        public int p_price1 { get; set; }
        public string p_price2 { get; set; }
        public string p_price3 { get; set; }
        public string p_price4 { get; set; }
        public string p_price5 { get; set; }
        public DateTime p_createDate { get; set; }
        public DateTime p_editDate { get; set; }
        public int p_hits { get; set; }
        public int p_sorting { get; set; }
        public string p_img { get; set; }
        public string p_files { get; set; }
        public int l_id { get; set; }
        public ProductInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static ProductInfo Populate(IDataReader reader)
        {
            ProductInfo info = new ProductInfo();
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