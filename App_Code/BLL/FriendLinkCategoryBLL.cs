using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Model;
using FriendLinkTableAdapters;
/// <summary>
/// FriendLinkCategoryBLL 的摘要描述
/// </summary>
namespace BLL
{
    public class FriendLinkCategoryBLL
    {
        FriendLinkCategoryTableAdapter db = new FriendLinkCategoryTableAdapter();
        FriendLinkBLL fBLL;
        public static int lidValue { get; set; }
        public FriendLinkCategoryBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public FriendLinkCategoryBLL(int lid)
        {
            lidValue = lid;
            fBLL = new FriendLinkBLL(lid);
        }
        public DataTable getall()
        {
            return db.GetData();
        }
        public List<FriendLinkCategoryInfo> GetAll()
        {
            List<FriendLinkCategoryInfo> infos = new List<FriendLinkCategoryInfo>();
            IDataReader reader = db.GetData().CreateDataReader();
            while (reader.Read())
            {
                infos.Add(FriendLinkCategoryInfo.Populate(reader));
            }
            return infos;
        }
        public List <FriendLinkCategoryInfo> GetDataByLid(int lid)
        {
            List<FriendLinkCategoryInfo> infos = new List <FriendLinkCategoryInfo>();
            IDataReader reader = db.GetDataByLid(lid).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(FriendLinkCategoryInfo.Populate(reader));
            }
            return infos;
        }
        public FriendLinkCategoryInfo GetDataById(int fc_id)
        {
            FriendLinkCategoryInfo info = new FriendLinkCategoryInfo();
            IDataReader reader = db.GetDataByID(fc_id).CreateDataReader();
            if (reader.Read())
            {
                info = FriendLinkCategoryInfo.Populate(reader);
            }
            return info;
        }
        public List<FriendLinkInfo> GetDataByCategoryId(int fc_id)
        {
            List<FriendLinkInfo> infos = new List<FriendLinkInfo>();
            IDataReader reader = db.GetDataByID(fc_id).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(FriendLinkInfo.Populate(reader));
            }
            return infos;
        }
        public int Insert(FriendLinkCategoryInfo info)
        {
            return db.Insert(info.fc_title,info.fc_CreateDate,info.fc_show,info.l_id);
        }
        public int Update(FriendLinkCategoryInfo info)
        {
            return db.Update(info.fc_title, info.fc_CreateDate,info.fc_show,info.l_id,info.fc_id);
        }
        
        public int Delete(int key)
        {
            List<FriendLinkInfo> infos = GetDataByCategoryId(key);
            foreach(FriendLinkInfo info in infos)
            {
                fBLL.Delete(info.f_id);
            }
            return db.Delete(key);
        }

    }
}