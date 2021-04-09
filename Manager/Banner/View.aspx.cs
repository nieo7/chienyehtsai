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

public partial class Manager_News_NewsView : BasePage
{
    BannerBLL bBLL = new BannerBLL();
    BannerCustomerBLL bcsBLL = new BannerCustomerBLL();
    BannerLocationBLL blBLL = new BannerLocationBLL();
    BannerCategoryBLL bcBLL = new BannerCategoryBLL();
    BannerImgBLL bpBLL = new BannerImgBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Check_Power(7, 44, true);            
            Bind();
        }
    }
    protected void Bind()
    {        
        BannerInfo info = bBLL.GetDataById(id);
        BannerLocationInfo blinfo = blBLL.GetDataById(info.bl_id);
        List<BannerLocationInfo> blinfos = blBLL.GetAllUpSortData(blinfo.bl_father_id);
        blinfo.bl_title = "　→　" + blinfo.bl_title;
        blinfos.Add(blinfo);
        lbCategory.Text = bcBLL.GetDataById(info.bc_id).bc_title;
        foreach (BannerLocationInfo Fblinfo in blinfos)
        {
            lbLocation.Text += Fblinfo.bl_title;
        }
        lbCustomer.Text = bcsBLL.GetDataById(info.bcs_id).bcs_company_name;
        lbTitle.Text = info.b_title;
        lbWebUrl.Text = info.b_url;
        lbPrice.Text = info.b_price.ToString();
        lbProb.Text = info.b_prob.ToString();
        if (info.b_target == "_blank")
        {
            lbTarget.Text = "開新頁顯示";
        }
        else
        {
            lbTarget.Text = "本頁顯示";
        }
        lbHits.Text = info.b_hits.ToString();
        lbCreateDate.Text = info.b_ts.ToString("yyyy/MM/dd");
        lbEditDate.Text = info.b_editDate.ToString("yyyy/MM/dd");
        lbStartDate.Text = info.b_startDate.ToString("yyyy/MM/dd");
        lbEndDate.Text = info.b_endDate.ToString("yyyy/MM/dd");
        rpImage.DataSource = bpBLL.GetDataByBid(id);
        rpImage.DataBind();
    }
}
