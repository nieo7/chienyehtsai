using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SystemConfigTableAdapters;
using Model;

namespace BLL
{
    /// <summary>
    /// SystemConfigBLL 的摘要描述
    /// </summary>
    public class SystemConfigBLL
    {
        SystemConfigTableAdapter db = new SystemConfigTableAdapter();
        public SystemConfigBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        
        public List<SystemConfigInfo> getAll()
        {
            List<SystemConfigInfo> infos = new List<SystemConfigInfo>();
            IDataReader reader = db.GetData().CreateDataReader();
            while (reader.Read())
            {
                infos.Add(SystemConfigInfo.Populate(reader));
            }
            return infos;
        }
        public List<SystemConfigInfo> GetDataSelectDistinctOrderClass()
        {
            List<SystemConfigInfo> infos = new List<SystemConfigInfo>();
            IDataReader reader = db.GetDataSelectDistinctOrderClass().CreateDataReader();
            while (reader.Read())
            {
                infos.Add(SystemConfigInfo.Populate(reader));
            }
            return infos;
        }           
        public SystemConfigInfo getAll(int id)
        {
            SystemConfigInfo info = new SystemConfigInfo();
            IDataReader reader = db.GetDataById(id).CreateDataReader();
            while (reader.Read())
            {
                info = SystemConfigInfo.Populate(reader);
            }
            return info;
        }
        public static string getDataByClassWithName(string className, string name)
        {
            SystemConfigTableAdapter db = new SystemConfigTableAdapter();
            string result = "";
            IDataReader reader = db.GetDataByClassWithName(className, name).CreateDataReader();
            SystemConfigInfo info = new SystemConfigInfo();
            while (reader.Read())
            {
                info = SystemConfigInfo.Populate(reader);
            }
            if (info.sc_Id != 0)
                result = info.sc_Value; 
            return result;
        }
        public int Insert(SystemConfigInfo info)
        {
            return db.Insert(info.sc_Class, info.sc_Name, info.sc_Value, info.sc_DefaultValue, info.sc_Desc, info.sc_Admin, info.sc_enable, info.sc_adminenable, info.sc_ts);
        }
        public int Update(SystemConfigInfo info)
        {
            return db.Update(info.sc_Class, info.sc_Name, info.sc_Value, info.sc_DefaultValue, info.sc_Desc, info.sc_Admin, info.sc_enable, info.sc_adminenable, info.sc_ts,info.sc_Id);
        }
        public int Delete(int sc_Id)
        {
            return db.Delete(sc_Id);
        }
    }
}