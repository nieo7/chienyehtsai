using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Model;
using ArticleTableAdapters;

namespace BLL
{
    /// <summary> 
    /// ArticleBLL 的摘要描述
    /// </summary>
    public class ArticleBLL
    {
        ArticleTableAdapter db = new ArticleTableAdapter();
        ArticleImageBLL aiBLL = new ArticleImageBLL();
        List<ArticleInfo> result = new List<ArticleInfo>();
        int countmath = 0;
        public static int lidValue { get; set; }
        public ArticleBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public ArticleBLL(int lid)
        {
            lidValue = lid;
        }

        public List<ArticleInfo> getAll()
        {
            List<ArticleInfo> infos = new List<ArticleInfo>();
            IDataReader reader = db.GetData().CreateDataReader();
            while (reader.Read())
            {
                infos.Add(ArticleInfo.Populate(reader));
            }
            return infos;
        }
        public List<ArticleInfo> GetDataByAcidAndSortOrderSort(int ac_id, int sort)
        {
            List<ArticleInfo> infos = new List<ArticleInfo>();
            IDataReader reader = db.GetDataByAcidAndSortOrderSort(ac_id, sort).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(ArticleInfo.Populate(reader));
            }
            return infos;
        }
        public List<ArticleInfo> getAllByShow(bool show)
        {
            List<ArticleInfo> infos = new List<ArticleInfo>();
            IDataReader reader = db.GetDataByShow(show).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(ArticleInfo.Populate(reader));
            }
            return infos;
        }
        public List<ArticleInfo> GetDataByCategoryOrderSort(int ac_id)
        {
            List<ArticleInfo> infos = new List<ArticleInfo>();
            IDataReader reader = db.GetDataByCategoryOrderSort(ac_id).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(ArticleInfo.Populate(reader));
            }
            return infos;
        }
        public ArticleInfo GetDataByAid(int id)
        {
            ArticleInfo info = new ArticleInfo();
            IDataReader reader = db.GetDataByA_Id(id).CreateDataReader();
            if (reader.Read())
            {
                info = ArticleInfo.Populate(reader);
            }
            return info;
        }
        public List<ArticleInfo> GetDataById(int id)
        {
            List<ArticleInfo> infos = new List<ArticleInfo>();
            IDataReader reader = db.GetDataByA_Id(id).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(ArticleInfo.Populate(reader));
            }
            return infos;
        }
        public ArticleInfo GetDataOrderIdDESC()
        {
            ArticleInfo info = new ArticleInfo();
            IDataReader reader = db.GetDataOrderIdDESC().CreateDataReader();
            if (reader.Read())
            {
                info = ArticleInfo.Populate(reader);
            }
            return info;
        }
        public int GetDataByCategoryOrderSortDESC(int ac_id)
        {
            ArticleInfo info = new ArticleInfo();
            IDataReader reader = db.GetDataByCategoryOrderSortDESC(ac_id).CreateDataReader();
            if (reader.Read())
            {
                info = ArticleInfo.Populate(reader);
                return info.a_sorting + 1;
            }
            return 1;
        }
        public int Insert(ArticleInfo info)
        {
            return db.Insert(info.ac_id, info.a_title, info.a_detail, info.a_hits, info.a_ts, info.a_editDate, info.a_show, GetDataByCategoryOrderSortDESC(info.ac_id), info.a_img, info.l_id);
        }
        public int Update(ArticleInfo info)
        {
            ArticleInfo ainfo = GetDataByAid(info.a_id);
            if (ainfo.ac_id == info.ac_id)
            {
                countmath = info.ac_id;
            }
            else
            {
                countmath = GetDataByCategoryOrderSortDESC(info.ac_id);
                result = GetDataByAcidAndSortOrderSort(ainfo.ac_id, ainfo.a_sorting);
                foreach (ArticleInfo sortinfo in result)
                {
                    db.Update(sortinfo.ac_id, sortinfo.a_title, sortinfo.a_detail, sortinfo.a_hits, sortinfo.a_ts, sortinfo.a_editDate, sortinfo.a_show, sortinfo.a_sorting - 1, sortinfo.a_img, sortinfo.l_id, sortinfo.a_id);
                }
            }
            return db.Update(info.ac_id, info.a_title, info.a_detail, info.a_hits, info.a_ts, info.a_editDate, info.a_show, countmath, info.a_img, info.l_id, info.a_id);
        }
        public int UpdateHits(int hits, int a_id)
        {
            return db.UpdateQueryByHits(hits, a_id);
        }
        public int Delete(int a_id)
        {
            List<ArticleImageInfo> imgInfos = aiBLL.GetDataByAid(a_id);
            foreach (ArticleImageInfo imginfo in imgInfos)
            {
                aiBLL.Delete(imginfo.ap_id);
            }
            ArticleInfo info = GetDataByAid(a_id);
            List<ArticleInfo> Sortinfos = GetDataByAcidAndSortOrderSort(info.ac_id, info.a_sorting);
            foreach (ArticleInfo sortinfo in Sortinfos)
            {
                db.Update(sortinfo.ac_id, sortinfo.a_title, sortinfo.a_detail, sortinfo.a_hits, sortinfo.a_ts, sortinfo.a_editDate, sortinfo.a_show, sortinfo.a_sorting - 1, sortinfo.a_img, sortinfo.l_id, sortinfo.a_id);
            }
            return db.Delete(a_id);
        }
    }
}