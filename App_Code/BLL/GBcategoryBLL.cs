using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Model;
using GBMessageTableAdapters;

/// <summary>
/// GBcategoryBLL 的摘要描述
/// </summary>
public class GBcategoryBLL
{
    GBCategoryTableAdapter db = new GBCategoryTableAdapter();
    GBmessageBLL gbBLL = new GBmessageBLL();
	public GBcategoryBLL()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public int InsertSorting()
    {
        GBCategoryInfo info = new GBCategoryInfo();
        IDataReader reader = db.InsertSorting().CreateDataReader();
        if (reader.Read())
        {
            info = GBCategoryInfo.Populate(reader);
            return info.gbc_sort + 1;
        }
        return 1;
    }
    public DataTable GetData()
    {
        return db.GetData();
    }
    public GBCategoryInfo GetDataById(int gbc_id)
    {
        GBCategoryInfo info = new GBCategoryInfo();
        IDataReader reader = db.GetDataById(gbc_id).CreateDataReader();
        if (reader.Read())
        {
            info = GBCategoryInfo.Populate(reader);
        }
        return info;
    }
    public List<GBCategoryInfo> GetDataBySort(int sort)
    {
        List<GBCategoryInfo> infos = new List<GBCategoryInfo>();
        IDataReader reader = db.GetDataBySort(sort).CreateDataReader();
        while (reader.Read())
        {
            infos.Add(GBCategoryInfo.Populate(reader));
        }
        return infos;
    }
    public int Insert(GBCategoryInfo info)
    {
        return db.Insert(info.gbc_title, InsertSorting(), info.gbc_show);
    }
    public int Update(GBCategoryInfo info)
    {
        return db.Update(info.gbc_title, info.gbc_sort, info.gbc_show, info.gbc_id);
    }
    public int Delete(int gbc_id)
    {
        GBCategoryInfo info=GetDataById(gbc_id);
        List<GBCategoryInfo> infos = GetDataBySort(info.gbc_sort);
        foreach (GBCategoryInfo sortinfos in infos)
        {
            db.Update(sortinfos.gbc_title, sortinfos.gbc_sort - 1, sortinfos.gbc_show, sortinfos.gbc_id);
        }
        //連動刪除GBmessage        
        List<GBmessageInfo> GBinfos = gbBLL.GetDataByCategoryId(gbc_id);
        foreach (GBmessageInfo gbInfosD in GBinfos)
        {
            gbBLL.Delete(gbInfosD.gb_ID);
        }
        return db.Delete(gbc_id);
    }
}