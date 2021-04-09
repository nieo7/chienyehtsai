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
    NewsBLL nBLL = new NewsBLL();
    NewsCategoryBLL ncBLL = new NewsCategoryBLL();
    NewsImageBLL niBLL = new NewsImageBLL();
    FriendLinkBLL fBLL = new FriendLinkBLL();
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
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phcategory"));
        phtitle.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phtitle"));
        phhits.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phhits"));
        phdetail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phdetail"));
        phimg.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phimg"));
        phcreatedate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phcreatedate"));
        pheditdate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "pheditdate"));
        phstartdate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phstartdate"));
        phenddate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phenddate"));
        phrpimage.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phrpimage"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phshow"));    
    }
    protected void Bind()
    {
        if (Request.QueryString["id"] != null)
        {
            if (Tools.TryParseMethod(id.ToString()) > 0)
            {
                NewsInfo info = nBLL.getAllById(id);
                FriendLinkInfo finfo = fBLL.getDataByLid(lid);
                lbCategory.Text = finfo.f_title;
                lbTitle.Text = info.n_title;
                litContent.Text = info.n_detail;
                img1.ImageUrl = Tools.GetAppSettings("NewsImageTruePath") + info.n_image;
                lbHits.Text = info.n_hits.ToString();
                lbBuilddate.Text = info.n_ts.ToString("yyyy/MM/dd HH:mm");
                lbEditDate.Text = info.n_editDate.ToString("yyyy/MM/dd HH:mm");
                lbStartdate.Text = info.n_startDate.ToString("yyyy/MM/dd");
                lbEnddate.Text = info.n_endDate.ToString("yyyy/MM/dd");
                if (info.n_show)
                {
                    lbShow.Text = "顯示";
                }
                else
                {
                    lbShow.Text = "不顯示";
                }
                rpImage.DataSource = niBLL.GetAllImgWithNews(id);
                rpImage.DataBind();
            }           
        }
    }
}
