using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Model;
using BannerTableAdapters;
using System.IO;

/// <summary>
/// BannerLocationBLL 的摘要描述
/// 廣告位置專用類別:
/// 1.限制不給予Edit轉換父類別功能
/// </summary>
namespace BLL
{
    public class BannerLocationBLL
    {
        BannerLocationTableAdapter db = new BannerLocationTableAdapter();
        BLL.BannerBLL bBLL = new BLL.BannerBLL();
        List<BannerLocationInfo> result = new List<BannerLocationInfo>();
        int HerichCountMath = 1;
        public BannerLocationBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public bool SearchHierarchyUpVail(int id, int Hierarchy)
        {
            BannerLocationInfo info = GetDataById(id);
            if (info.bl_id != 0)
            {
                SearchHierarchyVailNow(info.bl_father_id);
            }
            if (Hierarchy > HerichCountMath)
            {
                return true;
            }
            return false;
        }
        public bool SearchHierarchyEqualVail(int id, int Hierarchy)
        {
            BannerLocationInfo info = GetDataById(id);
            if (info.bl_id != 0)
            {
                SearchHierarchyVailNow(info.bl_father_id);
            }
            if (Hierarchy == HerichCountMath)
            {
                return true;
            }
            return false;
        }
        private void SearchHierarchyVailNow(int bl_fid)
        {
            BannerLocationInfo info = GetDataById(bl_fid);
            if (info.bl_id != 0)
            {
                HerichCountMath += 1;
                SearchHierarchyVailNow(info.bl_father_id);
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
            List<BannerLocationInfo> infos = GetDataByFatherId(bl_id);
            if (infos.Count != 0)
            {
                HerichCountMath += 1;
            }
            foreach (BannerLocationInfo info in infos)
            {
                SearchHierarchyDownVailNow(info.bl_id);
            }
        }
        public BannerLocationInfo GetDataById(int bl_id)
        {
            BannerLocationInfo info = new BannerLocationInfo();
            IDataReader reader = db.GetDataById(bl_id).CreateDataReader();
            if (reader.Read())
            {
                info = BannerLocationInfo.Populate(reader);
            }
            return info;
        }
        public List<BannerLocationInfo> GetallSortData(int fatherId)
        {
            List<BannerLocationInfo> infos = GetDataByFatherId(fatherId);            
            foreach (BannerLocationInfo info in infos)
            {
                result.Add(info);
                DataFillTable2(info.bl_id, "　└");
            }
            return result;
        }
        public void DataFillTable2(int fatherId, string fix)
        {
            List<BannerLocationInfo> Infos =GetDataByFatherId(fatherId); 
            foreach (BannerLocationInfo blInfo in Infos)
            {
                blInfo.bl_title = fix + blInfo.bl_title;
                result.Add(blInfo);
                DataFillTable2(blInfo.bl_id, "　" + fix);
            }
        }
        public List<BannerLocationInfo> GetAllUpSortData(int fatherId)
        {
            BannerLocationInfo info=GetDataById(fatherId);
            if (info.bl_id != 0)
            {          
                result.Add(info);
                GetAllUpSortData(info.bl_father_id);
            }            
            return result;
        }
        public List<BannerLocationInfo> GetDataByFatherId(int fatherId)
        {
            List<BannerLocationInfo> infos = new List<BannerLocationInfo>();
            IDataReader reader = db.GetDataByFatherId(fatherId).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(BannerLocationInfo.Populate(reader));
            }
            return infos;
        }
        public int Insert(BannerLocationInfo info)
        {
            return db.Insert(info.bl_title, info.bl_father_id, info.bl_show);
        }
        public int Update(BannerLocationInfo info)
        {
            return db.Update(info.bl_title, info.bl_father_id, info.bl_show, info.bl_id);
        }
        public int Delete(int bl_id)
        {
            //判斷Banner裡是否有相對應之資料,有則不予刪除
            int check = 1;
            List<BannerLocationInfo> infos = GetallSortData(bl_id);
            infos.Add(GetDataById(bl_id));
            foreach (BannerLocationInfo info in infos)
            {
                if (bBLL.GetDataByLocation(info.bl_id).Count != 0)
                {
                    check = 0;
                    break;
                }                
            }
            if (check != 0)
            {
                foreach (BannerLocationInfo info in infos)
                {
                    db.Delete(info.bl_id);
                }
            }
            return check;            
        }
    }
}