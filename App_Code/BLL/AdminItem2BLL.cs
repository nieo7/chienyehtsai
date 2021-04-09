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
    /// AdminItem2BLL 的摘要描述
    /// </summary>
    public class AdminItem2BLL
    {
        AdminItem2TableAdapter db = new AdminItem2TableAdapter();
        public AdminItem2BLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }        
        public int InsertForSort(int ai2_no1)
        {
            AdminItem2Info info = new AdminItem2Info();
            IDataReader reader = db.InsertForSort(ai2_no1).CreateDataReader();
            if (reader.Read())
            {
                info = AdminItem2Info.Populate(reader); 
                return info.ai2_sort + 1;
            }  
                return 1;            
        }
        public DataTable getAllBya_id(int a_id,int ai2_no1)
        {
            return db.GetDataByPowerAIdWithNo1(a_id, ai2_no1);
        }
        public AdminItem2Info getAll(int id)
        {
            AdminItem2Info info = new AdminItem2Info();
            IDataReader reader = db.GetDataByfiNo2(id).CreateDataReader();
            while (reader.Read())
            {
                info = AdminItem2Info.Populate(reader);
            }
            return info;
        }
        public AdminItem2Info getAllByPowerAIdWithNo2(int a_id, int ai2_no1)
        {
            AdminItem2Info info = new AdminItem2Info();
            IDataReader reader = db.GetDataByPowerAIdWithNo1(a_id, ai2_no1).CreateDataReader();
            while (reader.Read())
            {
                info = AdminItem2Info.Populate(reader);
            }
            return info;
        }
        public IList<AdminItem2Info> getAllByPowerAIdWithNo1(int a_id, int ai_no2)
        {
            List<AdminItem2Info> infos = new List<AdminItem2Info>();
            IDataReader reader = db.GetDataByPowerAIdWithNo1(a_id, ai_no2).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(AdminItem2Info.Populate(reader));
            }
            return infos;
        }
        public int Insert(AdminItem2Info info)
        {
            info.ai2_sort = InsertForSort(info.ai2_no1);
            return db.Insert(info.ai2_name, info.ai2_sort, info.ai2_visible, info.ai2_no1,info.ai2_url);
        }
        public int Update(int id,AdminItem2Info info)
        {
            return db.Update(info.ai2_name, info.ai2_sort, info.ai2_visible, info.ai2_no1, info.ai2_url, info.ai2_id);
        }
    }
}