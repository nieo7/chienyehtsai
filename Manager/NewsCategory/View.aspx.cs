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

public partial class Manager_NewsCategory_NewsCategoryView : BasePage
{
    NewsCategoryBLL ncBLL = new NewsCategoryBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            //Check_Power(1, 33, true);
            Bind();
        }
    }
    private void InitPage()
    {
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phcategory"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phname"));
        phsort.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phsort"));
        phimg.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phimg"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phshow"));
    }
    protected void Bind()
    {
        if (Request.QueryString["id"] != null)
        {
            if (Tools.TryParseMethod(Request.QueryString["id"].ToString()) != 0)
            {
                NewsCategoryInfo info = ncBLL.getAllById(id);
                if (info.nc_fatherid != 0)
                {
                    lbcategory.Text = ncBLL.getAllById(info.nc_id).nc_name;
                }
                lbName.Text = info.nc_name;
                lbSorting.Text = info.nc_sorting.ToString();
                img1.ImageUrl = Tools.GetAppSettings("NewsImageTruePath") + info.nc_image;
                if (info.nc_show)
                {
                    lbShow.Text = "顯示";
                }
                else
                {
                    lbShow.Text = "不顯示";
                }                
            }
        }
    }
}
