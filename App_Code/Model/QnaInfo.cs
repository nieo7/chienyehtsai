using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

/// <summary>
/// QnaInfo 的摘要描述
/// </summary>
namespace Model
{
    public class QnaInfo
    {
        public int q_id { get; set; }
        public string q_title { get; set; }
        public string q_content { get; set; }
        public int q_sort { get; set; }
        public bool q_show { get; set; }
        public DateTime q_CreateDate { get; set; }
        public DateTime q_EditDate { get; set; }
        public QnaInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static QnaInfo Populate(IDataReader reader)
        {
            QnaInfo info = new QnaInfo();
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