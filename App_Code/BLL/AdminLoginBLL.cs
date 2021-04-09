using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AdminTableAdapters;
using Model;
namespace BLL
{
    /// <summary>
    /// AdminLoginBLL 的摘要描述
    /// </summary>
    public class AdminLoginBLL
    {
        AdminLoginTableAdapter db = new AdminLoginTableAdapter();
        public AdminLoginBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        public DataTable getAll()
        {
            return db.GetData();
        }
        public int Insert(AdminLoginInfo info)
        {
            return db.Insert(info.a_id, info.al_no2, info.al_logintime, info.al_ip);
        }
        public int Insert(int a_id, int al_no2, DateTime logintime, string al_ip)
        {
            return db.Insert(a_id, al_no2, logintime, al_ip);
        }
        public int Delete(int id)
        {
            return db.Delete(id);
        }
    }
}