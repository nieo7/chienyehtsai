using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

namespace Model
{
    /// <summary>
    /// BannerImgInfo 的摘要描述
    /// </summary>
    public class BannerImgInfo
    {
        public int bp_id { get; set; }
        public int b_id { get; set; }
        public string bp_image { get; set; }
        public string bp_imagename { get; set; }

        public BannerImgInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static BannerImgInfo Populate(IDataReader reader)
        {
            BannerImgInfo info = new BannerImgInfo();
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
