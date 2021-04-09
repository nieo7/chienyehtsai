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
    /// AdminItem1BLL 的摘要描述
    /// </summary>
    public class AdminItem1BLL
    {
        AdminItem1TableAdapter db = new AdminItem1TableAdapter();
        public AdminItem1BLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        //new
        public List<AdminItem1Info> GetDataByVisible()
        {
            List<AdminItem1Info> infos = new List<AdminItem1Info>();
            IDataReader reader = db.GetDataByVisible().CreateDataReader();
            while (reader.Read())
            {
                infos.Add(AdminItem1Info.Populate(reader));
            }
            return infos;
        }

        public int InsertForSort()
        {
            AdminItem1Info info = new AdminItem1Info();
            IDataReader reader = db.InsertForSort().CreateDataReader();
            if (reader.Read())
            {
                info = AdminItem1Info.Populate(reader);
                return info.ai1_sort + 1;
            }
            return 1;
        }
        public List<AdminItem1Info> getAll()
        {
            List<AdminItem1Info> infos = new List<AdminItem1Info>();
            IDataReader reader = db.GetData().CreateDataReader();
            while (reader.Read())
            {
                infos.Add(AdminItem1Info.Populate(reader));
            }
            return infos;
        }
        public AdminItem1Info getAll(int id)
        {
            AdminItem1Info info = new AdminItem1Info();
            IDataReader reader = db.GetDataByfiNo1(id).CreateDataReader();
            while (reader.Read())
            {
                info = AdminItem1Info.Populate(reader);
            }
            return info;
        }
        public DataTable getAllByPower(int a_id)
        {
            return db.GetDataByPowerAId(a_id);
        }
        public int Update(int id, AdminItem1Info info)
        {
            return db.Update(info.ai1_name, info.ai1_sort, info.ai1_visible, info.ai1_nickname, info.ai1_id);
        }
        public int Insert(AdminItem1Info info)
        {
            info.ai1_sort = InsertForSort();
            return db.Insert(info.ai1_name, info.ai1_sort, info.ai1_visible, info.ai1_nickname);
        }
    }
}