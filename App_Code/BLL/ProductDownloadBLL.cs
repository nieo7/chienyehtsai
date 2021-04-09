using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ProductsTableAdapters;
using Model;
using System.IO;
/// <summary>
/// ProductDownload 的摘要描述
/// </summary>
public class ProductDownloadBLL
{
    ProductDownloadTableAdapter db = new ProductDownloadTableAdapter();
    public ProductDownloadBLL()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public ProductDownloadInfo GetFileWithKey(int pd_id)
    {
        ProductDownloadInfo info = new ProductDownloadInfo();
        IDataReader reader = db.GetFilesWithkey(pd_id).CreateDataReader();
        if (reader.Read())
        {
            info =ProductDownloadInfo.Populate(reader);
        }
        return info;
    }
    public List<ProductDownloadInfo> GetallFilesWithProduct(int p_id)
    {
        List<ProductDownloadInfo> infos = new List<ProductDownloadInfo>();
        IDataReader reader = db.GetallFilesWithProduct(p_id).CreateDataReader();
        while (reader.Read())
        {
            infos.Add(ProductDownloadInfo.Populate(reader));
        }
        return infos;
    }
    public int Insert(ProductDownloadInfo info)
    {
        return db.Insert(info.p_id, info.pd_name, info.pd_type, info.pd_value,info.pd_createdate);
    }
    public void Delete(int pd_id)
    {
        ProductDownloadInfo info = GetFileWithKey(pd_id);
        if (File.Exists(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("ProductDLTruePath") + info.pd_name)))
        {
            File.Delete(HttpContext.Current.Server.MapPath(Tools.GetAppSettings("ProductDLTruePath") + info.pd_name));
        }
        db.Delete(pd_id);
    }
}