using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Model;
using BannerTableAdapters;
using System.IO;

namespace BLL
{
    /// <summary>
    /// BannerImgBLL 的摘要描述
    /// </summary>
    public class BannerImgBLL
    {
        BannerPicTableAdapter db = new BannerPicTableAdapter();
        public BannerImgBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public BannerImgInfo GetImgByKey(int bp_id)
        {
            BannerImgInfo info = new Model.BannerImgInfo();
            IDataReader reader = db.GetDataImgByKey(bp_id).CreateDataReader();
            if (reader.Read())
            {
                info = BannerImgInfo.Populate(reader);
            }
            return info;
        }
        public List<BannerImgInfo> GetDataByBid(int b_id)
        {
            List<BannerImgInfo> infos = new List<Model.BannerImgInfo>();
            IDataReader reader = db.GetDataByBid(b_id).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(BannerImgInfo.Populate(reader));
            }
            return infos;
        }
        public void Insert(BannerImgInfo info)
        {
            db.Insert(info.b_id, info.bp_image, info.bp_imagename);
        }
        public void Delete(int bp_id)
        {
            BannerImgInfo info = GetImgByKey(bp_id);
            if (File.Exists(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("BannerImageTruePath") + info.bp_imagename)))
            {
                File.Delete(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("BannerImageTruePath") + info.bp_imagename));
            }
            db.Delete(bp_id);
        }
    }
}
