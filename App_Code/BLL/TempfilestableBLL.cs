using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TempfilestableTableAdapters;
using Model;
using System.Collections;
/// <summary>
/// TempfilestableBLL 暫存檔案專用類別
/// 使用Switch方式導入
/// </summary>
namespace BLL
{
    public class TempfilestableBLL:System.Web.UI.Page
    {
        TempfilestableTableAdapter db = new TempfilestableTableAdapter();
        Tempfilestableinfo info = new Tempfilestableinfo();
        //ArrayList AL = new ArrayList();
        public TempfilestableBLL()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            UserInfoConfig.filename = UserInfoConfig.WebSiteVirtualPath + "SystemConfig.xml";
        }

        protected List<Tempfilestableinfo> GetData()
        {
            List<Tempfilestableinfo> infos = new List<Tempfilestableinfo>();
            IDataReader reader = db.GetData().CreateDataReader();
            while (reader.Read())
            {
                infos.Add(Tempfilestableinfo.Populate(reader));
            }
            return infos;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ModelName">欲寫入暫存檔的主類別,例:product、news</param>
        public void InsertTempFiles(string ModelName,string path)
        {
            db.Insert(ModelName,path,Convert.ToDateTime(DateTime.Today.ToShortDateString()));
        }
        public void DeleteTempFiles()
        {
            List<Tempfilestableinfo> infos = GetData();
            foreach (Tempfilestableinfo info in infos)
            {
                if (DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(info.tf_date.ToShortDateString()).AddDays(double.Parse(UserInfoConfig.GetUserConfig("tempfiletime")))) >= 0)
                {
                    if (System.IO.File.Exists(Server.MapPath(info.tf_path)))
                    {
                        System.IO.File.Delete(Server.MapPath(info.tf_path));
                    }
                    Delete(info.tf_id);
                }   
            }
        }
        public void Delete(int tf_id)
        {
            db.Delete(tf_id);
        }
        //public  int Insert()
        //{                        
        //    List<Tempfilestableinfo> infos = new List<Tempfilestableinfo>();
        //    if (Session["ImageTempArray"] != null　)
        //    {
        //        AL = (ArrayList)Session["ImageTempArray"];
        //        for (int i = 0; i < AL.Count; i++)
        //        {
        //            info.tf_title = "";
        //            info.tf_path = AL[i].ToString();
        //            info.tf_date =Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //            db.Insert(info.tf_title, info.tf_path, info.tf_date);
        //        }
        //        Session.Remove("ImageTempArray");
        //    }
        //    if (Session["pdimginfo"] != null || Session["pdinfo"] !=null)
        //    {
        //        InsertTempWithProduct();
        //    } 
        //    return AL.Count;
        //}
        //public void InsertTempWithProduct()
        //{
        //    if (Session["pdimginfo"] != null)
        //    {
        //        List<ProductImageInfo> pdImgInfos = new List<ProductImageInfo>();
        //        pdImgInfos = (List<ProductImageInfo>)Session["pdimginfo"];
        //        foreach (ProductImageInfo infos in pdImgInfos)
        //        {
        //            info.tf_title = infos.pi_imageName;
        //            info.tf_path = Tools.GetAppSettings("ProductImageTempPath") + infos.pi_imageName;
        //            info.tf_date =Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //            db.Insert(info.tf_title, info.tf_path, info.tf_date);
        //        }
        //        Session.Remove("pdimginfo");
        //    }
        //    if (Session["pdinfo"] != null)
        //    {
        //        List<ProductDownloadInfo> pdfileInfos = new List<ProductDownloadInfo>();
        //        pdfileInfos = (List<ProductDownloadInfo>)Session["pdinfo"];
        //        foreach (ProductDownloadInfo infos in pdfileInfos)
        //        {
        //            info.tf_title = infos.pd_name;
        //            info.tf_path = Tools.GetAppSettings("ProductDLTempPath") + infos.pd_name;
        //            info.tf_date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //            db.Insert(info.tf_title, info.tf_path, info.tf_date);
        //        }
        //        Session.Remove("pdinfo");
        //    }
        //}
    }
}