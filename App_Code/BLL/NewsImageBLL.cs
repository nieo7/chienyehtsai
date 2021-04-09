using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Model;
using NewsTableAdapters;
using System.IO;

namespace BLL
{
    /// <summary>
    /// NewsImageBLL 的摘要描述
    /// </summary>
    public class NewsImageBLL
    {
        NewsPicTableAdapter db = new NewsPicTableAdapter();
        public NewsImageBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public NewsImageInfo GetImgWithKey(int np_id)
        {
            NewsImageInfo info = new Model.NewsImageInfo();
            IDataReader reader = db.GetImageWithKey(np_id).CreateDataReader();
            if (reader.Read())
            {
                info = NewsImageInfo.Populate(reader);
            }
            return info;
        }
        public List<NewsImageInfo> GetAllImgWithNews(int n_id)
        {
            List<NewsImageInfo> infos = new List<Model.NewsImageInfo>();
            IDataReader reader = db.GetAllImgWithNews(n_id).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(NewsImageInfo.Populate(reader));
            }
            return infos;
        }
        public void Insert(NewsImageInfo info)
        {
            db.Insert(info.n_id, info.np_name,info.np_imagename);
        }
        public void Delete(int np_id)
        {
            NewsImageInfo info = GetImgWithKey(np_id);
            if (File.Exists(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("NewsImageTruePath") + info.np_name)))
            {
                File.Delete(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("NewsImageTruePath") + info.np_name));
            }
            db.Delete(np_id);
        }
    }
}
