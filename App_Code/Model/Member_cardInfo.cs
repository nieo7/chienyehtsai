using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Data;

/// <summary>
/// Member_cardInfo 的摘要描述
/// </summary>
public class Member_cardInfo
{
    public int mc_id { get; set; }
    public string mc_number { get; set; }
    public string mc_pass { get; set; }
    public int mc_status { get; set; }
    public int m_id { get; set; }
    public string mc_note { get; set; }
    public DateTime mc_adddate { get; set; }
    public DateTime mc_editdate { get; set; }
	public Member_cardInfo()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public static Member_cardInfo Populate(IDataReader reader)
    {
        Member_cardInfo info = new Member_cardInfo();
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