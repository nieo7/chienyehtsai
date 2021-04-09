using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BannerTableAdapters;
using Model;

/// <summary>
/// BannerCustomerBLL 的摘要描述
/// </summary>
namespace BLL
{
    public class BannerCustomerBLL
    {
        BannerCustomerTableAdapter db = new BannerCustomerTableAdapter();
        BannerBLL bBLL = new BannerBLL();
        public BannerCustomerBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public List<BannerCustomerInfo> GetAll()
        {
            List<BannerCustomerInfo> infos = new List<BannerCustomerInfo>();
            IDataReader reader = db.GetData().CreateDataReader();
            while (reader.Read())
            {
                infos.Add(BannerCustomerInfo.Populate(reader));
            }
            return infos;
        }
        public BannerCustomerInfo GetDataById(int bcs_id)
        {
            BannerCustomerInfo info = new BannerCustomerInfo();
            IDataReader reader = db.GetDataById(bcs_id).CreateDataReader();
            if (reader.Read())
            {
                info = BannerCustomerInfo.Populate(reader);
            }
            return info;
        }
        public int Insert(BannerCustomerInfo info)
        {
            return db.Insert(info.bcs_key, info.bcs_company_name, info.bcs_company_type, info.bcs_company_phone, info.bcs_name, info.bcs_sex, info.bcs_phone, info.bcs_mail, info.bcs_fax, info.bcs_address, info.bcs_note, info.bcs_ts, info.bcs_editdate, info.bcs_city, info.bcs_area, info.bcs_code);
        }
        public int Update(BannerCustomerInfo info)
        {
            return db.Update(info.bcs_key, info.bcs_company_name, info.bcs_company_type, info.bcs_company_phone, info.bcs_name, info.bcs_sex, info.bcs_phone, info.bcs_mail, info.bcs_fax, info.bcs_address, info.bcs_note, info.bcs_ts, info.bcs_editdate, info.bcs_city, info.bcs_area, info.bcs_code, info.bcs_id);
        }
        public int Delete(int bcs_id)
        {
            if (bBLL.GetDataByCustomer(bcs_id).Count >= 0)
            {
                return 0;
            }            
            return db.Delete(bcs_id);
        }
    }
}