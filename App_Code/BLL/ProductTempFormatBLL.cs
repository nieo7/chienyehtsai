using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using ProductsTableAdapters;
using Model;
/// <summary>
/// ProductTempFormat 的摘要描述:產品類別專用規格紀錄表
/// </summary>
public class ProductTempFormatBLL
{
    ProductTempFormatTableAdapter db = new ProductTempFormatTableAdapter();
    public ProductTempFormatBLL()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public List<ProductTempFormatInfo> GetallWithCategory(int pc_id)
    {
        List<ProductTempFormatInfo> infos = new List<ProductTempFormatInfo>();
        IDataReader reader = db.GetDataByCategory(pc_id).CreateDataReader();
        while (reader.Read())
        {
            infos.Add(ProductTempFormatInfo.Populate(reader));
        }
        return infos;
    }
    public ProductTempFormatInfo GettempKey(int pf_id)
    {
        ProductTempFormatInfo info = new ProductTempFormatInfo();
        IDataReader reader = db.GetTempKey(pf_id).CreateDataReader();
        while (reader.Read())
        {
            info = ProductTempFormatInfo.Populate(reader);
        }
        return info;
    }
    public List<ProductTempFormatInfo> UpdateSortingWithCategory(int pc_id,int sorting)
    {
        List<ProductTempFormatInfo> infos = new List<ProductTempFormatInfo>();
        IDataReader reader = db.UpdateSorting(pc_id, sorting).CreateDataReader();
        while (reader.Read())
        {
            infos.Add(ProductTempFormatInfo.Populate(reader));
        }
        return infos;
    }
    public int GetCategorySortingDesc(int pc_id)
    {
        ProductTempFormatInfo info = new ProductTempFormatInfo();
        IDataReader reader = db.GetCategorySortingDESC(pc_id).CreateDataReader();
        if (reader.Read())
        {
            info = ProductTempFormatInfo.Populate(reader);
            return info.pf_sorting + 1;
        }
        return 1;
    }
    public void Insert(ProductTempFormatInfo info)
    {
        info.pf_sorting = GetCategorySortingDesc(info.pc_id);
        db.Insert(info.pc_id, info.pf_name, info.pf_value, info.pf_sorting);
    }
    public void Update(ProductTempFormatInfo info)
    {
        db.Update(info.pc_id, info.pf_name, info.pf_value, info.pf_sorting, info.pf_id);
    }
    public void Delete(int pf_id)
    {        
        ProductTempFormatInfo info = GettempKey(pf_id);
        List<ProductTempFormatInfo> infos = UpdateSortingWithCategory(info.pc_id, info.pf_sorting);
        foreach (ProductTempFormatInfo pdtfm in infos)
        {
            db.Update(pdtfm.pc_id, pdtfm.pf_name, pdtfm.pf_value, pdtfm.pf_sorting - 1, pdtfm.pf_id);
        }
        db.Delete(pf_id);
    }
}