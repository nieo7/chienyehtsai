using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Model;
using GBMessageTableAdapters;

/// <summary>
/// GBreBLL 的摘要描述
/// </summary>
public class GBreBLL
{
    GBreTableAdapter db = new GBreTableAdapter();
	public GBreBLL()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public List<GBreInfo> GetDataByCategoryId(int gb_id)
    {
        List<GBreInfo> infos = new List<GBreInfo>();
        IDataReader reader = db.GetDataByCategoryId(gb_id).CreateDataReader();
        while (reader.Read())
        {
            infos.Add(GBreInfo.Populate(reader));
        }
        return infos;
    }
    public int Insert(GBreInfo info)
    {
        return db.Insert(info.g_name, info.g_mail, info.g_show_mail, info.g_ip, info.g_level, info.g_content, info.gb_id, info.g_adddate,info.g_url);
    }
    public int Delete(int g_id)
    {
        return db.Delete(g_id);
    }
}