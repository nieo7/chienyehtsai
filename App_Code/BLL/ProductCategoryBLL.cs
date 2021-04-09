using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Model;
using ProductsTableAdapters;
using System.IO;
/// <summary>
/// ProductCategory 的摘要描述
/// </summary>
namespace BLL
{
    public class ProductCategoryBLL
    {
        ProductCategoryTableAdapter db = new ProductCategoryTableAdapter();
        DataTable DT;
        List<ProductCategoryInfo> result = new List<ProductCategoryInfo>();
        ProductBLL pBLL;
        int countmath = 0;
        int HerichCountMath = 1;
        public int lidValue { get; set; }
        public ProductCategoryBLL()
        {

        }
        public ProductCategoryBLL(int lid)
        {
            lidValue = lid;
            pBLL = new ProductBLL(lid);
        }
        #region 驗證層級專用程序
        /// <summary>
        /// 向上巡覽
        /// </summary>
        /// <param name="l_id"></param>
        /// <param name="pc_id"></param>
        /// <param name="Hierarchy">設定超過階層值</param>
        /// <returns></returns>
        public bool SearchHierarchyUpVail(int pc_id, int Hierarchy)
        {
            ProductCategoryInfo info = getEditdata(pc_id);
            if (info.pc_id != 0)
            {
                SearchHierarchyVailNow(info.pc_fatherid);
            }
            if (Hierarchy > HerichCountMath)
            {
                return true;
            }
            return false;
        }
        public bool SearchHierarchyEqualVail(int pc_id, int Hierarchy)
        {
            ProductCategoryInfo info = getEditdata(pc_id);
            if (info.pc_id != 0)
            {
                SearchHierarchyVailNow(info.pc_fatherid);
            }
            if (Hierarchy == HerichCountMath)
            {
                return true;
            }
            return false;
        }
        private void SearchHierarchyVailNow(int pc_fid)
        {
            ProductCategoryInfo info = getEditdata(pc_fid);
            if (info.pc_id != 0)
            {
                HerichCountMath += 1;
                SearchHierarchyVailNow(info.pc_fatherid);
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
        private void SearchHierarchyDownVailNow(int id)
        {
            List<ProductCategoryInfo> infos = getallFather(id, lidValue);
            if (infos.Count != 0)
            {
                HerichCountMath += 1;
            }
            foreach (ProductCategoryInfo info in infos)
            {
                SearchHierarchyDownVailNow(info.pc_id);
            }
        }
        #endregion
        public ProductCategoryInfo getEditdata(int pc_id)
        {
            ProductCategoryInfo info = new ProductCategoryInfo();
            IDataReader reader = db.GetEditData(pc_id).CreateDataReader();
            while (reader.Read())
            {
                info = ProductCategoryInfo.Populate(reader);
            }
            return info;
        }
        public List<ProductCategoryInfo> getallFather(int FatherId, int lidValue)
        {
            List<ProductCategoryInfo> infos = new List<ProductCategoryInfo>();
            IDataReader reader = db.GetFatherClass(FatherId, lidValue).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(ProductCategoryInfo.Populate(reader));
            }
            return infos;
        }
        public int getFatherSorting(int fatherid)
        {
            ProductCategoryInfo info = new ProductCategoryInfo();
            IDataReader reader = db.GetFatherSortWithLid(fatherid, lidValue).CreateDataReader();
            if (reader.Read())
            {
                info = ProductCategoryInfo.Populate(reader);
                return info.pc_sorting;
            }
            return 1;
        }
        public List<ProductCategoryInfo> UpdataSorting(int fatherid, int sorting)
        {
            List<ProductCategoryInfo> infos = new List<ProductCategoryInfo>();
            IDataReader reader = db.UpdateSorting(fatherid, sorting, lidValue).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(ProductCategoryInfo.Populate(reader));
            }
            return infos;
        }
        public List<ProductCategoryInfo> getallSortData(int fatherId) //動態選擇父類別搜詢，強制導入語系
        {
            List<ProductCategoryInfo> pdcInfos = new List<ProductCategoryInfo>();
            pdcInfos = getallFather(fatherId, lidValue);
            foreach (ProductCategoryInfo pdcInfo in pdcInfos)
            {
                result.Add(pdcInfo);
                DataFillTable2(pdcInfo.pc_id, "　└");
            }
            return result;
        }
        public void DataFillTable2(int fatherId, string fix) //此遞迴重點在於做屬性值修改
        {
            List<ProductCategoryInfo> pdcInfos = new List<ProductCategoryInfo>();
            pdcInfos = getallFather(fatherId, lidValue);
            foreach (ProductCategoryInfo pdcInfo in pdcInfos)
            {
                pdcInfo.pc_name = fix + pdcInfo.pc_name;
                result.Add(pdcInfo);
                DataFillTable2(pdcInfo.pc_id, "　" + fix);
            }
        }
        public int Insert(ProductCategoryInfo info)
        {
            //加入條件,假使新增不為主類別,l_id強制依附語系
            //目的就在於:在不同語系下,最上層主類別排序依舊以1.2.3.4.5執行
            DT = new DataTable();
            DT = db.GetFatherSortWithLid(info.pc_fatherid, info.l_id);
            if (DT.Rows.Count > 0)
            {
                info.pc_sorting = int.Parse(DT.Rows[0]["pc_sorting"].ToString()) + 1;
            }
            else
            {
                info.pc_sorting = 1;
            }
            return db.Insert(info.pc_name, info.pc_fatherid, info.pc_sorting, info.pc_image, info.pc_thumb, info.pc_show, info.l_id);
        }
        //產品類別更新
        public int Update(ProductCategoryInfo info)
        {
            int check = 1;
            //pcinfo是舊的,info是新的
            ProductCategoryInfo pcinfo = getEditdata(info.pc_id); //先取出fid值           
            if (info.pc_id != info.pc_fatherid)
            {
                List<ProductCategoryInfo> checkinfos = getallSortData(info.pc_id);
                foreach (ProductCategoryInfo ckinfo in checkinfos)
                {
                    if (ckinfo.pc_id == info.pc_fatherid)
                    {
                        check = 0;
                    }
                }
                if (check == 1)
                {
                    if (pcinfo.pc_fatherid == info.pc_fatherid)//再比較fid值
                    {
                        countmath = pcinfo.pc_sorting;    //相同時做法            
                    }
                    else
                    {
                        countmath = getFatherSorting(info.pc_fatherid) + 1;  //New class with sorting
                        result = UpdataSorting(pcinfo.pc_fatherid, pcinfo.pc_sorting);
                        foreach (ProductCategoryInfo sortinfo in result)
                        {
                            db.Update(sortinfo.pc_name, sortinfo.pc_fatherid, sortinfo.pc_sorting - 1, sortinfo.pc_image, sortinfo.pc_thumb, sortinfo.pc_show, sortinfo.l_id, sortinfo.pc_id); //不同時做法:新的Sorting值,舊的Sorting遞減
                        }
                    }
                    return db.Update(info.pc_name, info.pc_fatherid, countmath, info.pc_image, info.pc_thumb, info.pc_show, info.l_id, info.pc_id);
                }
            }
            return check;
        }
        public void Delete(int key)
        {
            //由此開始遞迴加入產品向下巡覽
            List<ProductCategoryInfo> infos = getallSortData(key);
            infos.Add(getEditdata(key));
            foreach (ProductCategoryInfo info in infos)
            {
                //由此開始連動刪除 -產品、產品格式、產品類別格式 必須等產品區域完全刪除類別寫完                
                List<ProductInfo> ProductInfos = pBLL.GetDataByCategoryID(info.pc_id);
                foreach (ProductInfo Pdinfos in ProductInfos)
                {
                    pBLL.Delete(Pdinfos.p_id);
                }
                if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(info.pc_image)))
                {
                    System.IO.File.Delete(HttpContext.Current.Server.MapPath(info.pc_image));
                }
                if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(info.pc_thumb)))
                {
                    System.IO.File.Delete(HttpContext.Current.Server.MapPath(info.pc_thumb));
                }
                result = UpdataSorting(info.pc_fatherid, info.pc_sorting);
                foreach (ProductCategoryInfo pdsort in result)
                {
                    //由此開始刪除排序
                    db.Update(pdsort.pc_name, pdsort.pc_fatherid, pdsort.pc_sorting - 1, pdsort.pc_image, pdsort.pc_thumb, pdsort.pc_show, pdsort.l_id, pdsort.pc_id); //同層級Sorting
                }
                //由此開始連動刪除 -子類別與主類別
                db.Delete(info.pc_id);
            }
        }
        public void Delete2(int key)
        {
            db.Delete(key);
        }
    }
}