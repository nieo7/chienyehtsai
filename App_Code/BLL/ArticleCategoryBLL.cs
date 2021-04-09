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
    /// ArticleCategoryBLL 的摘要描述
    /// </summary>
    public class ArticleCategoryBLL
    {
        ArticleCategoryTableAdapter db = new ArticleCategoryTableAdapter();
        ArticleBLL aBLL;
        List<ArticleCategoryInfo> result = new List<ArticleCategoryInfo>();
        int countmath = 0;
        int HerichCountMath = 1;
        public static int lidValue { get; set; }
        public ArticleCategoryBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public ArticleCategoryBLL(int lid)
        {
            lidValue = lid;
            aBLL = new ArticleBLL(lid);
        }
        public bool SearchHierarchyUpVail(int ac_id, int Hierarchy)
        {
            ArticleCategoryInfo info = getAllById(ac_id);
            if (info.ac_id != 0)
            {
                SearchHierarchyVailNow(info.ac_fatherId);
            }
            if (Hierarchy > HerichCountMath)
            {
                return true;
            }
            return false;
        }
        public bool SearchHierarchyEqualVail(int ac_id, int Hierarchy)
        {
            ArticleCategoryInfo info = getAllById(ac_id);
            if (info.ac_id != 0)
            {
                SearchHierarchyVailNow(info.ac_fatherId);
            }
            if (Hierarchy == HerichCountMath)
            {
                return true;
            }
            return false;
        }
        private void SearchHierarchyVailNow(int fid)
        {
            ArticleCategoryInfo info = getAllById(fid);
            if (info.ac_id != 0)
            {
                HerichCountMath += 1;
                SearchHierarchyVailNow(info.ac_fatherId);
            }
        }
        /// <summary>
        /// 目標類別的向上巡覽值”+”自身類別向下巡覽值”必須 <= xml設定階層值
        /// </summary>
        /// <param name="selectFid">選擇類別</param>
        /// <param name="id">欲轉換之類別</param>
        /// <param name="Hierarchy">階層值</param>
        /// <returns></returns>
        public bool SearchHierarchyDownVail(int selectFid, int id, int Hierarchy)
        {
            SearchHierarchyVailNow(selectFid);
            SearchHierarchyDownVailNow(id);
            if (HerichCountMath <= Hierarchy) 
            {
                return true;
            }
            return false;
        }
        private void SearchHierarchyDownVailNow(int bl_id)
        {
            List<ArticleCategoryInfo> infos = GetDataByFatherIdAndLidOrderSorting(bl_id, lidValue);
            if (infos.Count != 0)
            {
                HerichCountMath += 1;
            }
            foreach (ArticleCategoryInfo info in infos)
            {
                SearchHierarchyDownVailNow(info.ac_id);
            }
        }
        public List<ArticleCategoryInfo> getAll()
        {
            List<ArticleCategoryInfo> infos = new List<ArticleCategoryInfo>();
            IDataReader reader = db.GetData().CreateDataReader();
            while (reader.Read())
            {
                infos.Add(ArticleCategoryInfo.Populate(reader));
            }
            return infos;
        }
        public ArticleCategoryInfo getAllById(int id)
        {
            ArticleCategoryInfo info = new ArticleCategoryInfo();
            IDataReader reader = db.GetDataByAcId(id).CreateDataReader();
            if (reader.Read())
            {
                info = ArticleCategoryInfo.Populate(reader);
            }
            return info;
        }
        //new
        public List<ArticleCategoryInfo> GetallSortData(int fatherId)
        {
            List<ArticleCategoryInfo> acInfos = new List<ArticleCategoryInfo>();
            acInfos = GetDataByFatherIdAndLidOrderSorting(fatherId, lidValue);
            foreach (ArticleCategoryInfo acinfo in acInfos)
            {
                result.Add(acinfo);
                DataFillTable2(acinfo.ac_id, "　└");
            }
            return result;
        }
        public void DataFillTable2(int fatherId, string fix)
        {
            List<ArticleCategoryInfo> nccInfos = new List<ArticleCategoryInfo>();
            nccInfos = GetDataByFatherIdAndLidOrderSorting(fatherId, lidValue);
            foreach (ArticleCategoryInfo ncInfo in nccInfos)
            {
                ncInfo.ac_name = fix + ncInfo.ac_name;
                result.Add(ncInfo);
                DataFillTable2(ncInfo.ac_id, "　" + fix);
            }
        }
        public List<ArticleCategoryInfo> GetDataByFatherIdAndLidOrderSorting(int fatherId, int lidvalue)
        {
            List<ArticleCategoryInfo> infos = new List<ArticleCategoryInfo>();
            IDataReader reader = db.GetDataByFatherIdAndLidOrderSorting(fatherId, lidvalue).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(ArticleCategoryInfo.Populate(reader));
            }
            return infos;
        }
        public int GetDataByFatherIdAndLidOrderSortDESC(int fatherId, int lidvalue)
        {
            ArticleCategoryInfo info = new ArticleCategoryInfo();
            IDataReader reader = db.GetDataByFatherIdAndLidOrderSortDESC(fatherId, lidvalue).CreateDataReader();
            if (reader.Read())
            {
                info = ArticleCategoryInfo.Populate(reader);
                return info.ac_sorting + 1;
            }
            return 1;
        }
        public List<ArticleCategoryInfo> UpdataSorting(int fatherid, int sorting)
        {
            List<ArticleCategoryInfo> infos = new List<ArticleCategoryInfo>();
            IDataReader reader = db.UpdataSorting(fatherid, sorting, lidValue).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(ArticleCategoryInfo.Populate(reader));
            }
            return infos;
        }
        public int Insert(ArticleCategoryInfo info)
        {
            int sortinfo = GetDataByFatherIdAndLidOrderSortDESC(info.ac_fatherId, info.l_id);
            return db.Insert(info.ac_name,sortinfo, info.ac_type, info.ac_fatherId, info.l_id);
        }
        public int Update(ArticleCategoryInfo info)
        {
            int check = 1;
            ArticleCategoryInfo acinfo = getAllById(info.ac_id);
            if (info.ac_id != info.ac_fatherId)
            {
                List<ArticleCategoryInfo> checkinfos = GetallSortData(info.ac_id);
                foreach (ArticleCategoryInfo ckinfo in checkinfos)
                {
                    if (ckinfo.ac_id == info.ac_fatherId)
                    {
                        check = 0;
                    }
                }
                if (check == 1)
                {
                    if (acinfo.ac_fatherId == info.ac_fatherId)
                    {
                        countmath = acinfo.ac_sorting;
                    }
                    else
                    {
                        countmath = GetDataByFatherIdAndLidOrderSortDESC(info.ac_fatherId, lidValue);
                        result = UpdataSorting(acinfo.ac_fatherId, acinfo.ac_sorting);
                        foreach (ArticleCategoryInfo sortinfo in result)
                        {
                            db.Update(sortinfo.ac_name, sortinfo.ac_sorting - 1, sortinfo.ac_type, sortinfo.ac_fatherId, sortinfo.l_id, sortinfo.ac_id);
                        }
                    }
                    return db.Update(info.ac_name, countmath, info.ac_type, info.ac_fatherId, info.l_id, info.ac_id);
                }
            }
            return check;
        }
        public void Delete(int ac_id)
        {            
            //連動刪除-Article            
            List<ArticleInfo> ainfos = aBLL.GetDataByCategoryOrderSort(ac_id);
            foreach (ArticleInfo ainfo in ainfos)
            {
                aBLL.Delete(ainfo.a_id);
            }            
            List<ArticleCategoryInfo> infos = GetallSortData(ac_id);
            infos.Add(getAllById(ac_id));
            foreach (ArticleCategoryInfo info in infos)
            {
                result = UpdataSorting(info.ac_fatherId,info.ac_sorting);
                foreach (ArticleCategoryInfo acinfo in result)
                {
                    db.Update(acinfo.ac_name, acinfo.ac_sorting - 1, acinfo.ac_type, acinfo.ac_fatherId, acinfo.l_id, acinfo.ac_id);
                }
                db.Delete(info.ac_id);
            }            
        }
    }
}
