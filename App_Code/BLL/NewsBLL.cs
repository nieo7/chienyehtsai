using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using NewsTableAdapters;
using Model;

namespace BLL
{
    /// <summary>
    /// NewsBLL 的摘要描述
    /// </summary>
    public class NewsBLL
    {
        NewsTableAdapter db = new NewsTableAdapter();
        NewsImageBLL niBLL = new NewsImageBLL();
        public int lidvalue { get; set; }
        public NewsBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public NewsBLL(int lid)
        {
            lidvalue = lid;
        }
        public List<NewsInfo> getAll()
        {
            List<NewsInfo> infos = new List<NewsInfo>();
            IDataReader reader = db.GetData().CreateDataReader();
            while (reader.Read())
            {
                infos.Add(NewsInfo.Populate(reader));
            }
            return infos;
        }
        public List<NewsInfo> getAllForCH()
        {
            List<NewsInfo> infos = new List<NewsInfo>();
            IDataReader reader = db.GetDataForCH().CreateDataReader();
            while (reader.Read())
            {
                infos.Add(NewsInfo.Populate(reader));
            }
            return infos;
        }
        public List<NewsInfo> getAllForEN()
        {
            List<NewsInfo> infos = new List<NewsInfo>();
            IDataReader reader = db.GetDataForEN().CreateDataReader();
            while (reader.Read())
            {
                infos.Add(NewsInfo.Populate(reader));
            }
            return infos;
        }

        public NewsInfo getAllById(int id)
        {
            NewsInfo info = new NewsInfo();
            IDataReader reader = db.GetDataByN_id(id).CreateDataReader();
            if (reader.Read())
            {
                info = NewsInfo.Populate(reader);
            }
            return info;
        }
        public List<NewsInfo> getAllByShow(bool show)
        {
            List<NewsInfo> infos = new List<NewsInfo>();
            IDataReader reader = db.GetDataByShow(show).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(NewsInfo.Populate(reader));
            }
            return infos;
        }
        public NewsInfo GetLastNews()
        {
            NewsInfo info = new NewsInfo();
            IDataReader reader = db.GetDataByDesc().CreateDataReader();
            if (reader.Read())
            {
                info = NewsInfo.Populate(reader);
            }
            return info;
        }
        //NEW
        public List<NewsInfo> GetDataByCategoryOrderTsDESC(int nc_id)
        {
            List<NewsInfo> infos = new List<NewsInfo>();
            IDataReader reader = db.GetDataByCategoryOrderTsDESC(nc_id).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(NewsInfo.Populate(reader));
            }
            return infos;
        }

        public List<NewsInfo> GetDataByLid(int l_id)
        {
            List<NewsInfo> infos = new List<NewsInfo>();
            IDataReader reader = db.GetDataByLId(l_id).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(NewsInfo.Populate(reader));
            }
            return infos;
        }
        public List<NewsInfo> GetDataByIdAndLid(int n_id,int lid)
        {
            List<NewsInfo> infos = new List<NewsInfo>();
            IDataReader reader = db.GetDataByIdAndLid(n_id,lid).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(NewsInfo.Populate(reader));
            }
            return infos;
        }
        public List<NewsInfo> GetDataByFIdOrderDesc(int f_id,int lid)
        {
            List<NewsInfo> infos = new List<NewsInfo>();
            IDataReader reader = db.GetDataByFIdOrderDesc(f_id,lid).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(NewsInfo.Populate(reader));
            }
            return infos;
        }
        public List<NewsInfo> GetTOP3DataByLid(int lid)
        {
            List<NewsInfo> infos = new List<NewsInfo>();
            IDataReader reader = db.GetTOP3DataByLid(lid).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(NewsInfo.Populate(reader));
            }
            return infos;
        }
        
        public int Insert(NewsInfo info)
        {              
            return db.Insert(info.nc_id, info.n_title, info.n_detail, info.n_image, info.n_ts, info.n_editDate, info.n_hits, info.n_show, info.n_startDate, info.n_endDate, info.l_id,info.f_id);
        }
        public int Update(NewsInfo info)
        {
            return db.Update(info.nc_id, info.n_title, info.n_detail, info.n_image, info.n_ts, info.n_editDate, info.n_hits, info.n_show, info.n_startDate, info.n_endDate, info.l_id, info.f_id, info.n_id);
        }
        public int UpdateHits(int hits,int n_id)
        {
            return db.UpdateQueryByHits(hits, n_id);
        }
        public int Delete(int n_id)
        {
            //連動刪除NewsPic            
            List<NewsImageInfo> npinfos = niBLL.GetAllImgWithNews(n_id);
            foreach (NewsImageInfo npinfo in npinfos)
            {
                niBLL.Delete(npinfo.np_id);                
            }            
            return db.Delete(n_id);
        }
    }
}
