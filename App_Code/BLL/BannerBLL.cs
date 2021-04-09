using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BannerTableAdapters;
using Model;

namespace BLL
{
    /// <summary>
    /// BannerBLL 的摘要描述
    /// </summary>
    public class BannerBLL
    {
        BannerTableAdapter db = new BannerTableAdapter();
        public BannerBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public List<BannerInfo> getAll()
        {
            List<BannerInfo> infos = new List<BannerInfo>();
            IDataReader reader = db.GetData().CreateDataReader();
            while (reader.Read())
            {
                infos.Add(BannerInfo.Populate(reader));
            }
            return infos;
        }
        public BannerInfo GetDataById(int id)
        {
            BannerInfo info = new BannerInfo();
            IDataReader reader = db.GetDataById(id).CreateDataReader();
            if (reader.Read())
            {
                info = BannerInfo.Populate(reader);
            }
            return info;
        }
        public BannerInfo GetLastBanner()
        {
            BannerInfo info = new BannerInfo();
            IDataReader reader = db.GetDataByDesc().CreateDataReader();
            reader.Read();
            info = BannerInfo.Populate(reader);
            return info;
        }
        public List<BannerInfo> GetDataByLocation(int bl_id)
        {
            List<BannerInfo> infos = new List<BannerInfo>();
            IDataReader reader = db.GetDataByLocationOrderBcAndTitle(bl_id).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(BannerInfo.Populate(reader));
            }
            return infos;
        }
        public List<BannerInfo> GetDataByCategory(int bc_id)
        {
            List<BannerInfo> infos = new List<BannerInfo>();
            IDataReader reader = db.GetDataByCategoryId(bc_id).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(BannerInfo.Populate(reader));
            }
            return infos;
        }
        public List<BannerInfo> GetDataByCustomer(int bcs_id)
        {
            List<BannerInfo> infos = new List<BannerInfo>();
            IDataReader reader = db.GetDataByCustomer(bcs_id).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(BannerInfo.Populate(reader));
            }
            return infos;
        }
        public int Insert(BannerInfo info)
        {
            return db.Insert(info.bc_id,info.b_title,info.b_url, info.b_imagename,info.b_ts, info.b_editDate, info.b_startDate, info.b_endDate,info.bcs_id,info.bl_id,info.b_price,info.b_prob,info.b_target,info.b_hits);
        }
        public int Update(BannerInfo info)
        {
            return db.Update(info.bc_id, info.b_title, info.b_url, info.b_imagename, info.b_ts, info.b_editDate, info.b_startDate, info.b_endDate, info.bcs_id, info.bl_id, info.b_price, info.b_prob, info.b_target, info.b_hits, info.b_id);
        }
        public int Delete(int b_id)
        {
            return db.Delete(b_id);
        }
    }
}
