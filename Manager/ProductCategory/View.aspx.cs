using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using BLL;
using Model;

public partial class Manager_ProductCategory_View : BasePage
{
    ProductCategoryBLL pcBLL = new ProductCategoryBLL(lid);
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            ViewControl();
        }
    }
    private void InitPage()
    {
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("ProductCategory", "phcategory"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("ProductCategory", "phname"));
        phimg.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("ProductCategory", "phimg"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("ProductCategory", "phshow"));
    }
    protected void ViewControl()
    {
        ProductCategoryInfo info = pcBLL.getEditdata(id);
        if (info.pc_id != 0)
        {
            if (info.pc_fatherid != 0)
            {
                lbcategory.Text = pcBLL.getEditdata(info.pc_fatherid).pc_name;
            }
            lbTitle.Text = info.pc_name;
            img1.ImageUrl =Tools.GetAppSettings("ProductImageTruePath")+info.pc_image;
            lbshow.Text = info.pc_show.ToString();
        }
    }
}