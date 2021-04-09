using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Model;
using ArticleTableAdapters;
using System.IO;
/// <summary>
/// ArticleImageBLL 的摘要描述
/// </summary>
namespace BLL
{     
    public class ArticleImageBLL
    {
        ArticlePicTableAdapter db = new ArticlePicTableAdapter();
        public ArticleImageBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public List<ArticleImageInfo> GetDataByAid(int a_id)
        {
            List<ArticleImageInfo> infos = new List<ArticleImageInfo>();
            IDataReader reader = db.GetDataByAid(a_id).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(ArticleImageInfo.Populate(reader));
            }
            return infos;
        }
        public ArticleImageInfo GetDataById(int ap_id)
        {
            ArticleImageInfo info = new ArticleImageInfo();
            IDataReader reader = db.GetDataById(ap_id).CreateDataReader();
            if (reader.Read())
            {
                info = ArticleImageInfo.Populate(reader);
            }
            return info;
        }
        public void Insert(ArticleImageInfo info)
        {
            db.Insert(info.a_id, info.ap_name, info.ap_imagename, info.ap_show);
        }
        public void Delete(int ap_id)
        {
            ArticleImageInfo info = GetDataById(ap_id);
            if (File.Exists(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("ArticleTruePath") + info.ap_imagename)))
            {
                File.Delete(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("ArticleTruePath") + info.ap_imagename));
            }
            db.Delete(ap_id);
        }
    }
}