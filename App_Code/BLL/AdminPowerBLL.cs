using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdminTableAdapters;
using Model;
using System.Data;
namespace BLL
{
    /// <summary>
    /// AdminPowerBLL 的摘要描述
    /// </summary>
    public class AdminPowerBLL
    {
        AdminPowerTableAdapter db = new AdminPowerTableAdapter();
        public AdminPowerBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        //當INNER JOIN資料表且必須於BLL中處理時，就只能用DataTable去承接
        public DataTable GetDataWithItem1WithItem2ForMenu(int aid, int ai1_id)
        {
            return db.GetDataWithItem1WithItem2ForMenu(aid, ai1_id);
        }

        public bool Check(int a_id, int fi_no1, int fi_no2, bool enable)
        {
            if (db.GetDataByCheck(a_id, fi_no1, fi_no2, enable).Rows.Count > 0)
                return true;
            return false;
        }
        public AdminPowerInfo getAllaIdNo1No2(int a_id,int fi_no1,int fi_no2)
        {
            AdminPowerInfo info = new AdminPowerInfo();
            IDataReader reader = db.GetDataByaIdNo1No2(a_id,fi_no1,fi_no2).CreateDataReader();
            while (reader.Read())
            {
                info = AdminPowerInfo.Populate(reader);
            }
            return info;
        }
        public AdminPowerInfo getDataByID(int ap_id)
        {
            AdminPowerInfo info = new AdminPowerInfo();
            IDataReader reader = db.GetDataByID(ap_id).CreateDataReader();
            while (reader.Read())
            {
                info = AdminPowerInfo.Populate(reader);
            }
            return info;
        }
        public IList<AdminPowerInfo> getDataByaId(int aId)
        {
            List<AdminPowerInfo> infos = new List<AdminPowerInfo>();
            IDataReader reader = db.GetDataByaId(aId).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(AdminPowerInfo.Populate(reader));
            }
            return infos;
        }
        public DataTable GetDataAccountPowerWithItem1(int ap_aid)
        {
            return db.GetDataAccountPowerWithItem1(ap_aid);
        }
        public int Insert(AdminPowerInfo info)
        {
            return db.Insert(info.ap_no1,info.ap_no2, info.ap_aid, info.ap_enable);
        }
        public int Delete(int id)
        {
            return db.Delete(id);
        }
        public void DeleteByaId(int aId)
        {
            db.DeleteByaId(aId);
        }
    }
}