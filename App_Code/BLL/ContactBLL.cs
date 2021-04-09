using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using Model;
using ContactTableAdapters;

/// <summary>
/// ContactBLL 的摘要描述
/// </summary>
public class ContactBLL
{
    ContactTableAdapter db = new ContactTableAdapter();
    public int lidvalue { get; set; }
	public ContactBLL()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public ContactBLL(int lid)
    {
        lidvalue = lid;
    }
    public ContactInfo GetDataById(int c_id)
    {
        ContactInfo info = new ContactInfo();
        IDataReader reader = db.GetDataByID(c_id).CreateDataReader();
        if (reader.Read())
        {
            info = ContactInfo.Populate(reader);
        }
        return info;
    }
    public int Insert(ContactInfo info)
    {
        return db.Insert(info.c_name, info.c_subject, info.c_sex, info.c_phone1, info.c_phone2, info.c_mail, info.c_address, info.c_detail, info.c_check_read, info.c_check_reply, info.c_pose_date, info.c_reply_date, info.c_ip, info.l_id);
    }
    public int Update(ContactInfo info)
    {
        return db.Update(info.c_name, info.c_subject, info.c_sex, info.c_phone1, info.c_phone2, info.c_mail, info.c_address, info.c_detail, info.c_check_read, info.c_check_reply, info.c_pose_date, info.c_reply_date, info.c_ip, info.l_id, info.c_id);
    }
    public int Delete(int c_id)
    {
        return db.Delete(c_id);
    }
}