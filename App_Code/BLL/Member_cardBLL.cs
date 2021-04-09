using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MemberTableAdapters;
using Model;

/// <summary>
/// Member_cardBLL 的摘要描述
/// </summary>
public class Member_cardBLL
{
    Member_cardTableAdapter db = new Member_cardTableAdapter();
	public Member_cardBLL()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public DataTable Getall()
    {
        return db.GetData();
    }
    public Member_cardInfo GetDataByID(int mc_id)
    {
        Member_cardInfo info = new Member_cardInfo();
        IDataReader reader = db.GetDataByID(mc_id).CreateDataReader();
        if (reader.Read())
        {
            info = Member_cardInfo.Populate(reader);
        }
        return info;
    }
    public Member_cardInfo GetDataByMid(int m_id)
    {
        Member_cardInfo info = new Member_cardInfo();
        IDataReader reader = db.GetDataByMId(m_id).CreateDataReader();
        if (reader.Read())
        {
            info = Member_cardInfo.Populate(reader);
        }
        return info;
    }
    public int Insert(Member_cardInfo info)
    {
        return db.Insert(info.mc_number, info.mc_pass, info.mc_status, info.m_id, info.mc_note, info.mc_adddate, info.mc_editdate);
    }
    public int Update(Member_cardInfo info)
    {
        return db.Update(info.mc_number, info.mc_pass, info.mc_status, info.m_id, info.mc_note, info.mc_adddate, info.mc_editdate, info.mc_id);
    }
    public int Delete(int mc_id)
    {
        return db.Delete(mc_id);
    }
}