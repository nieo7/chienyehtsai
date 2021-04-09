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
    /// BannerCategoryBLL 的摘要描述
    /// </summary>
    public class BannerCategoryBLL
    {
        BannerCategoryTableAdapter db = new BannerCategoryTableAdapter();
        BannerBLL bBLL = new BannerBLL();
        public BannerCategoryBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        public List<BannerCategoryInfo> getAll()
        {
            List<BannerCategoryInfo> infos = new List<BannerCategoryInfo>();
            IDataReader reader = db.GetData().CreateDataReader();
            while (reader.Read())
            {
                infos.Add(BannerCategoryInfo.Populate(reader));
            }
            return infos;
        }
        public List<BannerCategoryInfo> getAllByShow(bool show)
        {
            List<BannerCategoryInfo> infos = new List<BannerCategoryInfo>();
            IDataReader reader = db.GetDataByShow(show).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(BannerCategoryInfo.Populate(reader));
            }
            return infos;
        }
        public BannerCategoryInfo GetDataById(int bc_id)
        {
            BannerCategoryInfo info = new BannerCategoryInfo();
            IDataReader reader = db.GetDataById(bc_id).CreateDataReader();
            if (reader.Read())
            {
                info = BannerCategoryInfo.Populate(reader);
            }
            return info;
        }
        public DataTable GetData()
        {
            return db.GetData();
        }
        public int Insert(BannerCategoryInfo info)
        {
            return db.Insert(info.bc_title, info.bc_show);
        }
        public int Update(BannerCategoryInfo info)
        {
            return db.Update(info.bc_title, info.bc_show, info.bc_id);
        }
        public int Delete(int bc_id)
        {
            if (bBLL.GetDataByCategory(bc_id).Count > 0)
            {
                return 0;
            }
            return db.Delete(bc_id);
        }
    }
}
