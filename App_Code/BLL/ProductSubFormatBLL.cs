using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using ProductsTableAdapters;
using Model;
/// <summary>
/// ProductSubFormatBLL 的摘要描述
/// </summary>
public class ProductSubFormatBLL
{
    Product_subFormatTableAdapter db = new Product_subFormatTableAdapter();
	public ProductSubFormatBLL()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public int GetFormatInsertSorting(int p_id)
    {
        int check = 1;
        ProductSubFormatInfo info = new ProductSubFormatInfo();
        IDataReader reader = db.GetSubformatInsertSorting(p_id).CreateDataReader();
        if (reader.Read())
        {            
            info = ProductSubFormatInfo.Populate(reader);
            check = info.psf_sorting + 1;
        }
        return check;
        
    }
    public ProductSubFormatInfo GetSubFormatKey(int psf_id)
    {
        ProductSubFormatInfo info = new ProductSubFormatInfo();
        IDataReader reader = db.GetSubFormatKey(psf_id).CreateDataReader();
        if (reader.Read())
        {
            info = ProductSubFormatInfo.Populate(reader);
        }
        return info;
    }
    public List<ProductSubFormatInfo> GetFormatWithProduct(int p_id)
    {
        List<ProductSubFormatInfo> infos = new List<ProductSubFormatInfo>();
        IDataReader reader = db.GetFormatWithProduct(p_id).CreateDataReader();
        while (reader.Read())
        {
            infos.Add(ProductSubFormatInfo.Populate(reader));
        }
        return infos;
    }
    public List<ProductSubFormatInfo> UpdateSorting(int p_id, int psf_sorting)
    {
        List<ProductSubFormatInfo> infos = new List<ProductSubFormatInfo>();
        IDataReader reader = db.UpdateSubFormatSorting(p_id, psf_sorting).CreateDataReader();
        while (reader.Read())
        {
            infos.Add(ProductSubFormatInfo.Populate(reader));
        }
       return infos;
    }
    
    public int Insert(ProductSubFormatInfo info)
    {
        return db.Insert(info.p_id, info.psf_name, info.psf_value, info.psf_sorting);
    }
    public void Update(ProductSubFormatInfo info)
    {
        db.Update(info.p_id, info.psf_name, info.psf_value, info.psf_sorting, info.psf_id);
    }
    public void Delete(int psf_id)
    {
        ProductSubFormatInfo info = GetSubFormatKey(psf_id);
        List<ProductSubFormatInfo> infos = UpdateSorting(info.p_id, info.psf_sorting);
        foreach (ProductSubFormatInfo pdsinfo in infos)
        {
            db.Update(pdsinfo.p_id, pdsinfo.psf_name, pdsinfo.psf_value, pdsinfo.psf_sorting - 1, pdsinfo.psf_id);
        }
        db.Delete(psf_id);
    }
}