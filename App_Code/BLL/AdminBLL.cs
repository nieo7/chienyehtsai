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
    /// AdminBLL 的摘要描述
    /// </summary>
    public class AdminBLL
    {

        AdminTableAdapter db = new AdminTableAdapter();
        
        public AdminBLL()
        {
            
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        /// <summary>
        /// 驗證帳號密碼
        /// </summary>
        /// <param name="Account">帳號</param>
        /// <param name="Password">密碼</param>
        /// <returns>True 登入成功 False 登入失敗</returns>
        public bool CheckAccountWithPassword(string Account, string Password)
        {
            if (db.CheckAccountWithPassword(Account, Password).Rows.Count > 0)
                return true;            
                return false;
        }

        public AdminInfo getDataByAccountWithPassword(string Account, string Password)
        {
            AdminInfo info = new AdminInfo();
            IDataReader reader = db.CheckAccountWithPassword(Account, Password).CreateDataReader();
            while (reader.Read())
            {
                info = AdminInfo.Populate(reader);
            }
            return info;
        }
        public AdminInfo getDataByAccount(string Account)
        {
            AdminInfo info = new AdminInfo();
            IDataReader reader = db.GetDataByAccount(Account).CreateDataReader();
            while (reader.Read())
            {
                info = AdminInfo.Populate(reader);
            }
            return info;
        }
        public AdminInfo getDataById(int id)
        {
            AdminInfo info = new AdminInfo();
            IDataReader reader = db.GetDataById(id).CreateDataReader();
            while (reader.Read())
            {
                info = AdminInfo.Populate(reader);
            }
            return info;
        }
        public int Insert(AdminInfo info)
        {
            return db.Insert(info.a_name, info.a_nickName, info.a_account, info.a_password, info.a_desc, info.a_lastDate, info.a_editDate);
        }
        public int Update(int id, AdminInfo info)
        {
            return db.Update(info.a_name, info.a_nickName, info.a_account, info.a_password, info.a_desc, info.a_lastDate, info.a_editDate, id);
        }
        public int UpdateLastDate(DateTime lastDate, int a_id)
        {
            return db.UpdateQueryByLastDate(lastDate, a_id);
        }
        public int Delete(int id)
        {
            return db.Delete(id);
        }
    }
}