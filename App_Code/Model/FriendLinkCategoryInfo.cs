using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Data;
/// <summary>
/// FriendLinkCategoryInfo 的摘要描述
/// </summary>
namespace Model
{
    public class FriendLinkCategoryInfo
    {
        public int fc_id { get; set; }
        public string fc_title { get; set; }
        public DateTime fc_CreateDate { get; set; }
        public bool fc_show { get; set; }
        public int l_id { get; set; }
        public FriendLinkCategoryInfo()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public static FriendLinkCategoryInfo Populate(IDataReader reader)
        {
            FriendLinkCategoryInfo info = new FriendLinkCategoryInfo();
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