using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class Manager_Products_View : BasePage
{
    ProductCategoryBLL pcBLL = new ProductCategoryBLL();
    ProductBLL pBLL = new ProductBLL(lid);
    ProductImageBLL piBLL = new ProductImageBLL();
    ProductSubFormatBLL psfBLL = new ProductSubFormatBLL();
    ProductDownloadBLL pdBLL = new ProductDownloadBLL();    
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {           
                ControlStatus();       
        }
    }
    private void InitPage()
    {
        phpc.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phpc"));
        phstate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phstate"));
        phserial.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phserial"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phname"));
        phdetail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phdetail"));        
        phprice1.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phprice1"));
        phprice2.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phprice2"));
        phprice3.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phprice3"));
        phprice4.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phprice4"));
        phprice5.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phprice5"));
        phformat.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phformat"));
        phfile.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phfile"));
        phrpImage.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phrpImage"));
        phcreatedate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phcreatedate"));
        pheditdate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "pheditdate"));
        phshowhot.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phshowhot"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phshow"));
        phstock.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phstock"));
        phstockunit.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phstockunit"));               
    }
    public void ControlStatus()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) > 0)
            {
                ProductInfo info = pBLL.GetProductForEdit(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
                lbcategory.Text = pcBLL.getEditdata(info.pc_id).pc_name;
                if (info.p_status == 0)
                {
                    lbState.Text = "上架";
                }
                else if (info.p_status == 1)
                {
                    lbState.Text = "缺貨";
                }
                else
                {
                    lbState.Text = "下架";
                }
                lbserial.Text = info.p_serial;
                lbTitle.Text = info.p_name;
                lbContent.Text = info.p_detail;
                lbPrice1.Text = info.p_price1.ToString();
                lbPrice2.Text = info.p_price2;
                lbprice3.Text = info.p_price3;
                lbprice4.Text = info.p_price4;
                lbprice5.Text = info.p_price5;
                lbBuilddate.Text = info.p_createDate.ToString("yyyy/MM/dd HH:mm");
                lbeditdate.Text = info.p_editDate.ToString("yyyy/MM/dd HH:mm");
                if (info.p_show)
                {
                    lbshow.Text = "顯示";
                }
                else
                {
                    lbshow.Text = "隱藏";
                }
                chkshowhot.Checked = info.p_show_hot;
                lbstock.Text = info.p_stock.ToString();
                lbstockunit.Text = info.p_stock_unit;
                rpFormat.DataSource = psfBLL.GetFormatWithProduct(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
                rpFormat.DataBind();

                rpDownload.DataSource = pdBLL.GetallFilesWithProduct(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
                rpDownload.DataBind();

                rpImage.DataSource = piBLL.GetallImgWithProduct(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
                rpImage.DataBind();
            }
        }
    }
}