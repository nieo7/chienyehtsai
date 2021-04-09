using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using Model;
using ProductsTableAdapters;
/// <summary>
/// ProductBLL 的摘要描述
/// </summary>
namespace BLL
{
    public class ProductBLL
    {
        ProductTableAdapter db = new ProductTableAdapter();
        ProductImageBLL pdImgBLL = new ProductImageBLL();
        ProductSubFormatBLL pdsFMBLL = new ProductSubFormatBLL();
        ProductDownloadBLL pddBLL = new ProductDownloadBLL();
        public int lidValue { get; set; }
        public ProductBLL()
        {
            
        }
        public ProductBLL(int lid)
        {
            lidValue = lid;
        }
        public List<ProductInfo> GetallProduct()
        {
           List<ProductInfo> infos = new List<ProductInfo>();
            IDataReader reader = db.GetData().CreateDataReader();
            while (reader.Read())
            {
                infos.Add(ProductInfo.Populate(reader));
            }
            return infos;
        }
        public ProductInfo GetProductForEdit(int p_id)
        {
            ProductInfo info = new ProductInfo();
            IDataReader reader = db.GetProductForEdit(p_id).CreateDataReader();
            if (reader.Read())
            {
                reader.Read();
                info = ProductInfo.Populate(reader);
            }
            return info;
        }
        public ProductInfo GetLastProduct()
        {
            ProductInfo info = new ProductInfo();
            IDataReader reader = db.GetDataByDesc().CreateDataReader();
            if (reader.Read())
            {
                info = ProductInfo.Populate(reader);
            }
            return info;
        }
        public List<ProductInfo> GetProductSortingWithDelete(int pc_id,int sorting)
        {
            List<ProductInfo> infos = new List<ProductInfo>();
            IDataReader reader = db.GetProductSortingWithDelete(pc_id, sorting).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(ProductInfo.Populate(reader));
            }
            return infos;
        }
        public int InsertSorting(int pc_id)
        {
            ProductInfo info = new ProductInfo();
            IDataReader reader = db.InsertSorting(pc_id).CreateDataReader();
            while (reader.Read())
            {
                info = ProductInfo.Populate(reader);
            }
            return info.p_sorting + 1;
        }
        public List<ProductInfo> GetDataByCategoryID(int pc_id)
        {
            List<ProductInfo> infos = new List<ProductInfo>();
            IDataReader reader = db.GetDataByCategoryID(pc_id).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(ProductInfo.Populate(reader));
            }
            return infos;
        }
        public int Insert(ProductInfo info)
        {            
            return db.Insert(info.pc_id, info.pcs_id, info.p_name, info.p_serial, info.p_status, info.p_show, info.p_show_hot, info.p_detail, info.p_stock, info.p_stock_unit, info.p_price1, info.p_price2, info.p_price3, info.p_price4, info.p_price5, info.p_createDate, info.p_editDate, info.p_hits, InsertSorting(info.pc_id),info.p_img,info.p_files,info.l_id);        
        }
        public int Update(ProductInfo info)
        {
            //找出原本的info
            ProductInfo Beforceinfo = GetProductForEdit(info.p_id);
            if (Beforceinfo.pc_id == info.pc_id)
            {
                return db.Update(info.pc_id, info.pcs_id, info.p_name, info.p_serial, info.p_status, info.p_show, info.p_show_hot, info.p_detail, info.p_stock, info.p_stock_unit, info.p_price1, info.p_price2, info.p_price3, info.p_price4, info.p_price5, info.p_createDate, info.p_editDate, info.p_hits, info.p_sorting, info.p_img,info.p_files,info.l_id,info.p_id);
            }
            else
            {
                List<ProductInfo> infosBeforce = GetProductSortingWithDelete(Beforceinfo.pc_id, Beforceinfo.p_sorting);
                foreach (ProductInfo infos in infosBeforce)
                {
                    db.Update(infos.pc_id, infos.pcs_id, infos.p_name, infos.p_serial, infos.p_status, infos.p_show, infos.p_show_hot, infos.p_detail, infos.p_stock, infos.p_stock_unit, infos.p_price1, infos.p_price2, infos.p_price3
                        , infos.p_price4, infos.p_price5, infos.p_createDate, infos.p_editDate, infos.p_hits, infos.p_sorting - 1, infos.p_img,info.p_files,info.l_id,infos.p_id);
                }
                return db.Update(info.pc_id, info.pcs_id, info.p_name, info.p_serial, info.p_status, info.p_show, info.p_show_hot, info.p_detail, info.p_stock, info.p_stock_unit, info.p_price1, info.p_price2, info.p_price3, info.p_price4,
                      info.p_price5, info.p_createDate, info.p_editDate, info.p_hits, InsertSorting(info.pc_id), info.p_img,info.p_files,info.l_id,info.p_id);
            }
        }
        public void Delete(int p_id)
        {                           
            //由此開始刪除圖片
            List<ProductImageInfo> ImgInfos = pdImgBLL.GetallImgWithProduct(p_id);
            foreach(ProductImageInfo infoimg in ImgInfos)
            {
                if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("ProductImageTruePath") + infoimg.pi_imageName)))
                {
                    System.IO.File.Delete(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("ProductImageTruePath") + infoimg.pi_imageName));
                }
                if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("ProductImageTruePath") + infoimg.pi_thumb)))
                {
                    System.IO.File.Delete(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("ProductImageTruePath") + infoimg.pi_thumb));
                }
                pdImgBLL.Delete(infoimg.pi_id);
            }          
            //由此開始刪除檔案
            List<ProductDownloadInfo> FileInfos = pddBLL.GetallFilesWithProduct(p_id);
            foreach (ProductDownloadInfo infoFile in FileInfos)
            {
                if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("ProductDLTruePath") + infoFile.pd_name)))
                {
                    System.IO.File.Delete(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("ProductDLTruePath") + infoFile.pd_name));
                }
                pddBLL.Delete(infoFile.pd_id);
            }
            //由此開始刪除格式
            List<ProductSubFormatInfo> SubInfos = pdsFMBLL.GetFormatWithProduct(p_id);
            foreach (ProductSubFormatInfo infoFormat in SubInfos)
            {
                pdsFMBLL.Delete(infoFormat.psf_id);
            }
            //由此開始刪除排序
            ProductInfo info = GetProductForEdit(p_id);
            List<ProductInfo> SortingInfos = GetProductSortingWithDelete(info.pc_id, info.p_sorting);
            foreach (ProductInfo pdinfo in SortingInfos)
            {
                db.Update(pdinfo.pc_id, pdinfo.pcs_id, pdinfo.p_name, pdinfo.p_serial, pdinfo.p_status, pdinfo.p_show, pdinfo.p_show_hot, pdinfo.p_detail, pdinfo.p_stock, pdinfo.p_stock_unit, pdinfo.p_price1, pdinfo.p_price2, pdinfo.p_price3, pdinfo.p_price4, pdinfo.p_price5, pdinfo.p_createDate, pdinfo.p_editDate, pdinfo.p_hits, pdinfo.p_sorting - 1, pdinfo.p_img,pdinfo.p_files,pdinfo.l_id,pdinfo.p_id);
            }
            db.Delete(p_id);
        }
    }
}