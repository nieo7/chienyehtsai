using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Model;
using ProductsTableAdapters;
using System.IO;
/// <summary>
/// ProductImageBLL 的摘要描述
/// </summary>
namespace BLL
{
    public class ProductImageBLL
    {
        ProductImagesTableAdapter db = new ProductImagesTableAdapter();
        public ProductImageBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public ProductImageInfo GetImgWithKey(int pi_id)
        {
            ProductImageInfo info = new Model.ProductImageInfo();
            IDataReader reader = db.GetImageWithKey(pi_id).CreateDataReader();
            if (reader.Read())
            {
                info = ProductImageInfo.Populate(reader);
            }
           return info;
        }
        public List<ProductImageInfo> GetallImgWithProduct(int p_id)
        {
            List<ProductImageInfo> infos = new List<Model.ProductImageInfo>();
            IDataReader reader = db.GetallImgWithProduct(p_id).CreateDataReader();
            while (reader.Read())
            {
                infos.Add(ProductImageInfo.Populate(reader));
            }
            return infos;
        }
        public void Insert(ProductImageInfo info)
        {
            db.Insert(info.p_id, info.pi_image, info.pi_thumb, info.pi_imageName, info.pi_show, info.pi_type, info.pi_hits);            
        }
        public void Delete(int pi_id)
        {
            ProductImageInfo info = GetImgWithKey(pi_id);
            if (File.Exists(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("ProductImageTruePath") + info.pi_imageName)))
            {
                File.Delete(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("ProductImageTruePath") + info.pi_imageName));
            }
            if(File.Exists(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("ProductImageTruePath")+info.pi_thumb)))
            {
                File.Delete(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("ProductImageTruePath") + info.pi_thumb));
            }
            db.Delete(pi_id);
        }
    }    
}