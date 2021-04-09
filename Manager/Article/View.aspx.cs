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
    ArticleCategoryBLL acBLL = new ArticleCategoryBLL();
    ArticleBLL aBLL = new ArticleBLL();
    ArticleImageBLL aiBLL = new ArticleImageBLL();
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
        phfather.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phfather"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phname"));
        phdetail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phdetail"));
        phhits.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phhits"));
        phts.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phts"));
        pheditdate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "pheditdate"));
        phrpimage.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phrpimage"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phshow"));
    }
    protected void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) > 0)
            {
                ArticleInfo info = aBLL.GetDataByAid(id);
                if (info.ac_id != 0)
                {
                    lbCategory.Text = acBLL.getAllById(info.ac_id).ac_name;
                }
                lbTitle.Text = info.a_title;
                litContent.Text = info.a_detail;
                lbhits.Text = info.a_hits.ToString();
                lbBuilddate.Text = info.a_ts.ToString("yyyy/MM/dd hh:mm");
                lbEditDate.Text = info.a_editDate.ToString("yyyy/MM/dd hh:mm");
                Image1.ImageUrl = Tools.GetAppSettings("ArticleTruePath") + info.a_img;
                if (info.a_show)
                {
                    lbShow.Text = "顯示";
                }
                else
                {
                    lbShow.Text = "隱藏";
                }
                rpImage.DataSource = aiBLL.GetDataByAid(id);
                rpImage.DataBind();
            }
        }
    }
}

