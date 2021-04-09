using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Model;
using NewsTableAdapters;


namespace BLL
{
    /// <summary>
    /// NewsCategoryBLL 的摘要描述
    /// </summary>
    public class NewsCategoryBLL
    {
        NewsCategoryTableAdapter db = new NewsCategoryTableAdapter();
        List<NewsCategoryInfo> result = new List<NewsCategoryInfo>();
        NewsBLL nBLL;
        int countmath = 0;
        int HerichCountMath = 1;
        public static int lidValue { get; set; }
        public NewsCategoryBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public NewsCategoryBLL(int lid)
        {
            lidValue = lid;
            nBLL = new NewsBLL(lid);
        }
        public bool SearchHierarchyUpVail(int id, int Hierarchy)
        {
            NewsCategoryInfo info = getAllById(id);
            if (info.nc_id != 0)
            {
                SearchHierarchyVailNow(info.nc_fatherid);
            }
            if (Hierarchy > HerichCountMath)
            {
                return true;
            }
            return false;
        }
        public bool SearchHierarchyEqualVail(int id, int Hierarchy)
        {
            NewsCategoryInfo info = getAllById(id);
            if (info.nc_id != 0)
            {
                SearchHierarchyVailNow(info.nc_fatherid);
            }
            if (Hierarchy == HerichCountMath)
            {
                return true;
            }
            return false;
        }
        private void SearchHierarchyVailNow(int fid)
        {
            NewsCategoryInfo info = getAllById(fid);
            if (info.nc_id != 0)
            {
                HerichCountMath += 1;
                SearchHierarchyVailNow(info.nc_fatherid);
            }
        }
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
            List<NewsCategoryInfo> infos = GetDataByFatherIdAndLidOrderSorting(bl_id, lidValue);
            if (infos.Count != 0)
            {
                HerichCountMath += 1;
            }
            foreach (NewsCategoryInfo info in infos)
            {
                SearchHierarchyDownVailNow(info.nc_id);
            }
        }
        public List<NewsCategoryInfo> getAll()
        {
            List<NewsCategoryInfo> infos = new List<NewsCategoryInfo>();
            IDataReader reader = db.GetData().CreateDataReader();
            while (reader.Read())
            {
                infos.Add(NewsCategoryInfo.Populate(reader));
            }
            return infos;
        }
        //New
        /// <summary>
        /// 動態導入父類別搜尋
        /// </summary>
        /// <param name="fatherId"></param>
        /// <returns></returns>
        public List<NewsCategoryInfo> GetallSortData(int fatherId)
        {
            List<NewsCategoryInfo> ncInfos = new List<NewsCategoryInfo>();
            ncInfos = GetDataByFatherIdAndLidOrderSorting(fatherId, lidValue);
            foreach (NewsCategoryInfo ncinfo in ncInfos)
            {
                result.Add(ncinfo);
                DataFillTable2(ncinfo.nc_id, "　└");
            }
            return result;
        }
        /// <summary>
        /// 遞迴-向下巡覽,此遞迴重點在於做屬性值修改
        /// </summary>
        /// <param name="fatherId"></param>
        /// <param name="fix"></param>
        public void DataFillTable2(int fatherId, string fix)
        {
            List<NewsCategoryInfo> nccInfos = new List<NewsCategoryInfo>();
            nccInfos = GetDataByFatherIdAndLidOrderSorting(fatherId, lidValue);
            foreach (NewsCategoryInfo ncInfo in nccInfos)
            {
                ncInfo.nc_name = fix + ncInfo.nc_name;
                result.Add(ncInfo);
                DataFillTable2(ncInfo.nc_id, "　" + fix);
            }
        }
        /// <summary>
        /// 取出所有Father與Lid符合的資料,並以Sort排序
        /// </summary>
        /// <param name="fatherId"></param>
        /// <param name="lidvalue"></param>
        /// <returns></returns>
        public List<NewsCategoryInfo> GetDataByFatherIdAndLidOrderSorting(int fatherId, int lidvalue)
        {
            List<NewsCategoryInfo> infos = new List<NewsCategoryInfo>();
            IDataReader reader = db.GetDataByFatherIdAndLidOrderSorting(fatherId, lidvalue).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(NewsCategoryInfo.Populate(reader));
            }
            return infos;
        }
        public int GetDataByFatherIdAndLidOrderSortDESC(int fatherId, int lidvalue)
        {
            NewsCategoryInfo info = new NewsCategoryInfo();
            IDataReader reader = db.GetDataByFatherIdAndLidOrderSortDESC(fatherId, lidvalue).CreateDataReader();
            if (reader.Read())
            {
                info = NewsCategoryInfo.Populate(reader);
                return info.nc_sorting + 1;
            }
            return 1;
        }
        public NewsCategoryInfo getAllById(int id)
        {
            NewsCategoryInfo info = new NewsCategoryInfo();
            IDataReader reader = db.GetDataById(id).CreateDataReader();
            while (reader.Read())
            {
                info = NewsCategoryInfo.Populate(reader);
            }
            return info;
        }
        public List<NewsCategoryInfo> UpdataSorting(int fatherid, int sorting)
        {
            List<NewsCategoryInfo> infos = new List<NewsCategoryInfo>();
            IDataReader reader = db.UpdataSorting(fatherid, sorting, lidValue).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(NewsCategoryInfo.Populate(reader));
            }
            return infos;
        }
        //NEW End
        public int Insert(NewsCategoryInfo info)
        {
            int sortinfo = GetDataByFatherIdAndLidOrderSortDESC(info.nc_fatherid, info.l_id);
            return db.Insert(info.nc_name, info.nc_fatherid, info.nc_image, info.nc_show, info.l_id, sortinfo);
        }
        public int Update(NewsCategoryInfo info)
        {
            int check = 1;
            NewsCategoryInfo ncinfo = getAllById(info.nc_id);
            //1.限制選自己
            if (info.nc_fatherid != info.nc_id)
            {
                //2.不可選自己的下一層
                List<NewsCategoryInfo> checkinfos = GetallSortData(info.nc_id); //以自己為父,取出向下所有資料
                foreach (NewsCategoryInfo ckinfo in checkinfos)
                {
                    if (ckinfo.nc_id == info.nc_fatherid) //選取值FatherId 若等於 nc_id,即不可更新
                    {
                        check = 0;
                    }
                }
                if (check == 1)
                {
                    if (info.nc_fatherid == ncinfo.nc_fatherid)
                    {
                        countmath = ncinfo.nc_sorting;
                    }
                    else
                    {
                        countmath = GetDataByFatherIdAndLidOrderSortDESC(info.nc_fatherid, lidValue);
                        result = UpdataSorting(ncinfo.nc_fatherid, ncinfo.nc_sorting);
                        foreach (NewsCategoryInfo sortinfo in result)
                        {
                            db.Update(sortinfo.nc_name, sortinfo.nc_fatherid, sortinfo.nc_image, sortinfo.nc_show, sortinfo.l_id, countmath, sortinfo.nc_id);
                        }
                    }
                    return db.Update(info.nc_name, info.nc_fatherid, info.nc_image, info.nc_show, info.l_id, countmath, info.nc_id);
                }
            }       
            return check;
        }
        public void Delete(int nc_id)
        {
            List<NewsCategoryInfo> infos = GetallSortData(nc_id);
            infos.Add(getAllById(nc_id));
            foreach (NewsCategoryInfo info in infos)
            {
                //由此開始連動刪除News
                List<NewsInfo> ninfos = nBLL.GetDataByCategoryOrderTsDESC(nc_id);
                foreach (NewsInfo ninfo in ninfos)
                {
                    nBLL.Delete(ninfo.n_id);
                }
                if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("NewsImageTruePath") + info.nc_image)))
                {
                    System.IO.File.Delete(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("NewsImageTruePath") + info.nc_image));
                }
                result = UpdataSorting(info.nc_fatherid, info.nc_sorting);
                foreach (NewsCategoryInfo ncsort in result)
                {
                    db.Update(ncsort.nc_name, ncsort.nc_fatherid, ncsort.nc_image, ncsort.nc_show, ncsort.l_id, ncsort.nc_sorting - 1, ncsort.nc_id);
                }
                db.Delete(info.nc_id);
            }
        }
    }
}