using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MemberTableAdapters;
using Model;
/// <summary>
/// MemberBLL 的摘要描述
/// </summary>
public class MemberBLL
{
    MemberTableAdapter db = new MemberTableAdapter();
    Member_cardBLL mcBLL = new Member_cardBLL();
	public MemberBLL()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public DataTable Getall()
    {
        return db.GetData();
    }
    public int GetDataByAccount(string account)
    {
        MemberInfo info = new MemberInfo();
        IDataReader reader = db.GetDataByAccount(account).CreateDataReader();
        if (reader.Read())
        {
            return 0;
        }
        return 1;
    }
    public int GetDataByNickname(string nickname)
    {
        MemberInfo info = new MemberInfo();
        IDataReader reader = db.GetDataByNickname(nickname).CreateDataReader();
        if (reader.Read())
        {
            return 0;
        }
        return 1;
    }
    public MemberInfo GetDataById(int m_id)
    {
        MemberInfo info = new MemberInfo();
        IDataReader reader = db.GetDataById(m_id).CreateDataReader();
        if (reader.Read())
        {
            info = MemberInfo.Populate(reader);
        }
        return info;
    }
    public MemberInfo GetDataOrderAdddate()
    {
        MemberInfo info = new MemberInfo();
        IDataReader reader = db.GetDataORDERadddate().CreateDataReader();
        if (reader.Read())
        {
            info = MemberInfo.Populate(reader);
        }
        return info;
    }
    public MemberInfo GetDataByAccountAndCheckcode(string account, string checkcode)
    {
        MemberInfo info = new MemberInfo();
        IDataReader reader = db.GetDataByAccountAndCheckcode(account, checkcode).CreateDataReader();
        if (reader.Read())
        {
            info = MemberInfo.Populate(reader);
        }
        return info;        
    }
    public int Insert(MemberInfo info)
    {
        return db.Insert(info.m_level, info.m_account, info.m_fname, info.m_name, info.m_nickname, info.m_number, info.m_mail, info.m_pass, info.m_sex, info.m_birthday, info.m_zipcode, info.m_city, info.m_address
                                       , info.m_phone1, info.m_phone2, info.m_login_times, info.m_note, info.m_adddate, info.m_editdate, info.m_lastlogindate, info.m_check_code, info.m_eaper, info.m_block,info.m_area);
    }
    public int Update(MemberInfo info)
    {
        return db.Update(info.m_level, info.m_account, info.m_fname, info.m_name, info.m_nickname, info.m_number, info.m_mail, info.m_pass, info.m_sex, info.m_birthday, info.m_zipcode, info.m_city, info.m_address
                                          , info.m_phone1, info.m_phone2, info.m_login_times, info.m_note, info.m_adddate, info.m_editdate, info.m_lastlogindate,"OK", info.m_eaper, info.m_block, info.m_area,info.m_id);
    }
    public int Delete(int m_id)
    {
        //連動刪除Member_card        
        Member_cardInfo mcinfos = mcBLL.GetDataByMid(m_id);
        mcBLL.Delete(mcinfos.mc_id);
        return db.Delete(m_id);
    }
}