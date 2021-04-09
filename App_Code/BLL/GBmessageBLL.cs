using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Model;
using GBMessageTableAdapters;

/// <summary>
/// GBmessageBLL 的摘要描述
/// </summary>
public class GBmessageBLL
{
    GBmessageTableAdapter db = new GBmessageTableAdapter();
    GBreBLL gBLL = new GBreBLL();
	public GBmessageBLL()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public GBmessageInfo GetDataById(int gb_id)
    {
        GBmessageInfo info = new GBmessageInfo();
        IDataReader reader = db.GetDataById(gb_id).CreateDataReader();
        if (reader.Read())
        {
            info = GBmessageInfo.Populate(reader);
        }
        return info;
    }
    public List<GBmessageInfo> GetDataByCategoryId(int gbc_id)
    {
        List<GBmessageInfo> infos = new List<GBmessageInfo>();
        IDataReader reader = db.GetDataByCategoryId(gbc_id).CreateDataReader();
        while (reader.Read())
        {
            infos.Add(GBmessageInfo.Populate(reader));
        }
        return infos;
    }
    public int Insert(GBmessageInfo info)
    {
        return db.Insert(info.gbc_Id, info.gb_name, info.gb_mail, info.gb_show_mail, info.gb_ip, info.gb_level, info.gb_title, info.gb_content, info.gb_createdate, info.gb_editdate, info.gb_hits,info.gb_show);
    }
    public int Update(GBmessageInfo info)
    {
        return db.Update(info.gbc_Id, info.gb_name, info.gb_mail, info.gb_show_mail, info.gb_ip, info.gb_level, info.gb_title, info.gb_content, info.gb_createdate, info.gb_editdate, info.gb_hits,info.gb_show,info.gb_ID);
    }
    public int Delete(int gb_id)
    {
        //連動刪除GBre        
        List<GBreInfo> infos = gBLL.GetDataByCategoryId(gb_id);
        foreach (GBreInfo infoGBre in infos)
        {
            gBLL.Delete(infoGBre.g_id);
        }
        return db.Delete(gb_id);
    }
}