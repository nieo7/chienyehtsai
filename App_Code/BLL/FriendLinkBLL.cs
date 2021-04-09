using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using FriendLinkTableAdapters;
using Model;
/// <summary>
/// FriendLinkBLL 的摘要描述
/// </summary>
namespace BLL
{
    public class FriendLinkBLL
    {        
        FriendLinkTableAdapter db = new FriendLinkTableAdapter();
        public int lidvalue { get; set; }
        public FriendLinkBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public FriendLinkBLL(int lid)
        {
            lidvalue = lid;
        }

        public int InsertSortingWithCategory(int fc_id)
        {
            FriendLinkInfo info = new FriendLinkInfo();
            IDataReader reader = db.InsertSorting(fc_id).CreateDataReader();
            if (reader.Read())
            {
                info = FriendLinkInfo.Populate(reader);
                return info.f_sorting + 1;
            }
            return 1;
        }
        public List<FriendLinkInfo> GetSortingWithDelete(int fc_id, int f_sorting)
        {
            List<FriendLinkInfo> infos = new List<FriendLinkInfo>();
            IDataReader reader = db.GetkSortingWithDelete(fc_id, f_sorting).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(FriendLinkInfo.Populate(reader));
            }
            return infos;
        }
        public FriendLinkInfo GetDataById(int f_id)
        {
            FriendLinkInfo info = new FriendLinkInfo();
            IDataReader reader = db.GetDataById(f_id).CreateDataReader();
            if (reader.Read())
            {                
                info = FriendLinkInfo.Populate(reader);
            }
            return info;
        }
        public List< FriendLinkInfo> getDataById(int f_id)
        {
            List<FriendLinkInfo> infos = new List<FriendLinkInfo>();
            IDataReader reader = db.GetDataById(f_id).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(FriendLinkInfo.Populate(reader));
            }
            return infos;
        }
        public List<FriendLinkInfo> GetDataByCategoryAndLid(int fc_id, int lid)
        {
            List<FriendLinkInfo> infos = new List<FriendLinkInfo>();
            IDataReader reader = db.GetDataByCategoryAndLid(fc_id,lid).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(FriendLinkInfo.Populate(reader));
            }
            return infos;
        }
        public List<FriendLinkInfo> GetDataByLid(int lid)
        {
            List<FriendLinkInfo> infos = new List<FriendLinkInfo>();
            IDataReader reader = db.GetDataByLid(lid).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(FriendLinkInfo.Populate(reader));
            }
            return infos;
        }
        public FriendLinkInfo getDataByLid(int lid)
        {
            FriendLinkInfo info = new FriendLinkInfo();
            IDataReader reader = db.GetDataByLid(lid).CreateDataReader();
            if (reader.Read())
            {
                info = FriendLinkInfo.Populate(reader);
            }
            return info;
        }


        public int Insert(FriendLinkInfo info)
        {
            return db.Insert(info.fc_id, info.f_title, InsertSortingWithCategory(info.fc_id), info.f_url, info.f_img, info.f_show,info.f_degree,info.f_history,info.f_books,info.f_specialty,info.f_license,info.f_field,info.f_ts,info.f_editDate,info.l_id,info.f_name);
        }
        public int Update(FriendLinkInfo info)
        {
            FriendLinkInfo BeforceInfo = GetDataById(info.f_id);
            if (BeforceInfo.fc_id == info.fc_id)
            {
                return db.Update(info.fc_id, info.f_title, info.f_sorting, info.f_url, info.f_img, info.f_show,info.f_degree,info.f_history,info.f_books,info.f_specialty,info.f_license,info.f_field,info.f_ts,info.f_editDate,info.l_id,info.f_name, info.f_id);
            }
            else
            {
                List<FriendLinkInfo> infosBeforce = GetSortingWithDelete(BeforceInfo.fc_id, BeforceInfo.f_sorting);
                foreach (FriendLinkInfo infos in infosBeforce)
                {
                    db.Update(infos.fc_id, infos.f_title, infos.f_sorting - 1, infos.f_url, infos.f_img, infos.f_show,info.f_degree,info.f_history,info.f_books,info.f_specialty,info.f_license,info.f_field,info.f_ts,info.f_editDate,info.l_id,info.f_name, infos.f_id);
                }
                return db.Update(info.fc_id, info.f_title, InsertSortingWithCategory(info.fc_id), info.f_url, info.f_img, info.f_show,info.f_degree,info.f_history,info.f_books,info.f_specialty,info.f_license,info.f_field,info.f_ts,info.f_editDate,info.l_id,info.f_name, info.f_id);
            }
        }        
        public int Delete(int key)
        {
            FriendLinkInfo info = GetDataById(key);
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("FriendLinkTruePath")+info.f_img)))
            {
                System.IO.File.Delete(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("FriendLinkTruePath") + info.f_img));
            }
            //由此開始刪除排序
            List<FriendLinkInfo> SortingInfos = GetSortingWithDelete(info.fc_id, info.f_sorting);            
            foreach (FriendLinkInfo infoDel in SortingInfos)
            {
                db.Update(infoDel.fc_id, infoDel.f_title, infoDel.f_sorting - 1, infoDel.f_url, infoDel.f_img, infoDel.f_show,infoDel.f_degree,infoDel.f_history,infoDel.f_books,infoDel.f_specialty,infoDel.f_license,infoDel.f_field,infoDel.f_ts,infoDel.f_editDate,infoDel.l_id,info.f_name, infoDel.f_id);
            }
            return db.Delete(key);
        }
    }
}