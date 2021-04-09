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
public partial class Manager_News_Add : BasePage
{
    NewsBLL nBLL = new NewsBLL(lid);
    NewsCategoryBLL ncBLL = new NewsCategoryBLL(lid);
    NewsImageBLL niBLL = new NewsImageBLL();
    FriendLinkBLL fBLL = new FriendLinkBLL(lid);
    TempfilestableBLL tfBLL = new TempfilestableBLL();
    List<NewsImageInfo> npImgInfos = new List<NewsImageInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        InitPage();
        if (!IsPostBack)
        {
            //檢查權限
            //Check_Power(1, 2, true);            
            BindDate();
            InsertDropdown();
            if (Session["npImginfo"] != null)
            {
                SessionClear();
            }
        }
    }
    private void InitPage()
    {
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phcategory"));
        phtitle.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phtitle"));
        phdetail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phdetail"));
        phstartdate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phstartdate"));
        phcreatedate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phcreatedate"));
        phrpimage.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phrpimage"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phshow"));
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //if (int.Parse(UserInfoConfig.GetUserConfig("HierarchyNewsCategory")) != 0)
        //{
            if (ddrNewsCategory.SelectedValue != "0")
            {
                //if (ncBLL.SearchHierarchyEqualVail(int.Parse(ddrNewsCategory.SelectedValue), int.Parse(UserInfoConfig.GetUserConfig("HierarchyNewsCategory"))))
                //{
                //    InsertData();
                //}
                //else
                //{
                //    ShowMessage("資料新增於錯誤階層");
                //}
                InsertData();
            }
            else
            {
                ShowMessage("請選擇發文者");
            }
        //}
        //else
        //{
        //    InsertData();
        //}
    }
    protected void InsertData()
    {
        NewsInfo info = new NewsInfo();
        
        //info.nc_id = Tools.TryParseMethod(ddrNewsCategory.SelectedValue);
        info.n_hits = 0;
        info.n_detail = Ckeditorl1.Text;
        info.n_title = txtName.Text;
        info.n_ts = DateTime.Parse(txtDate.Text);
        info.n_startDate = DateTime.Parse(txtStartDate.Text);
        info.n_endDate = DateTime.Parse(txtEndDate.Text);
        info.n_image = hfNewsImage.Value;
        info.n_show = bool.Parse(rbShow.SelectedValue);
        info.l_id = lid;
        info.f_id = int.Parse(ddrNewsCategory.SelectedValue);
        if (nBLL.Insert(info) > 0)
        {
            //加入NewsPic資料表            
            InsertNewsImage(nBLL.GetLastNews().n_id);
            SessionClear();
            Response.Redirect("List.aspx?header=" + Getmessage("30009"));
        }
    }
    private void SessionClear()
    {
        Session.Remove("npImginfo");
    }
    protected void BindDate()
    {
        txtStartDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
        txtEndDate.Text = DateTime.Now.AddYears(10).ToString("yyyy/MM/dd");
        txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
    }
    private void InsertNewsImage(int NewsID)
    {
        NewsImageInfo npinfo = new NewsImageInfo();
        //筆數
        for (int i = 0; i < rpImage.Items.Count; i++)
        {            
            Image lbtxtFormatName = (Image)rpImage.Items[i].FindControl("Image1");
            if (lbtxtFormatName != null)
            {
                //由此寫入真實檔原圖轉移程序
                if (System.IO.File.Exists(Server.MapPath(Tools.GetAppSettings("NewsImageTempPath") + lbtxtFormatName.AlternateText)))
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath(Tools.GetAppSettings("NewsImageTempPath") + lbtxtFormatName.AlternateText));
                    file.CopyTo(Server.MapPath(Tools.GetAppSettings("NewsImageTruePath") + lbtxtFormatName.AlternateText));
                }
                npinfo.n_id = NewsID;
                npinfo.np_name = lbtxtFormatName.AlternateText;
                npinfo.np_imagename = lbtxtFormatName.AlternateText;
            }
            niBLL.Insert(npinfo);
        }
    }
    //設定Repeater的Delete與Update
    protected void rpImage_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            if (Session["npImginfo"] != null)
            {
                npImgInfos = (List<NewsImageInfo>)Session["npImginfo"];
                Label lb = (Label)e.Item.FindControl("lbImageID");
                foreach (NewsImageInfo npinfo in npImgInfos)
                {
                    if (npinfo.np_name == lb.Text)
                    {
                        System.IO.File.Delete(Server.MapPath(Tools.GetAppSettings("NewsImageTempPath") + npinfo.np_name));
                        npImgInfos.Remove(npinfo);
                        Session["npImginfo"] = npImgInfos;
                        rpImage.DataSource = npImgInfos;
                        rpImage.DataBind();
                        ShowMessage("刪除成功!");
                        return;
                    }
                }
            }
        }
        if (e.CommandName == "Update")
        {
            if (Session["npImginfo"] != null)
            {
                npImgInfos = (List<NewsImageInfo>)Session["npImginfo"];
                hfNewsImage.Value = e.CommandArgument.ToString();
                Session["npImginfo"] = npImgInfos;
                rpImage.DataSource = npImgInfos;
                rpImage.DataBind();
                Page.Controls.Add(Tools.Tomsg("更新成功!"));
            }
        }
    }
    //設定Repeater的主圖後控制項功能開關
    protected void rpImage_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lbImage = (Label)e.Item.FindControl("lbImage");
        LinkButton lkUpdate = (LinkButton)e.Item.FindControl("lkUpdate");
        if (lbImage != null)
        {
            if (hfNewsImage.Value == lbImage.Text)
            {
                lkUpdate.Enabled = false;
            }
        }
    }

    protected void btImage_Click(object sender, EventArgs e)
    {
        //檔名切換            
        if (fuImage.HasFile)
        {
            string imgFileName = WebUtility.ChangeFileNameAsRandom(fuImage.FileName);
            if (WebUtility.CheckImageExt(System.IO.Path.GetExtension(imgFileName)))
            {
                //從Web.Config取得路徑
                string serverFileName = WebUtility.MergePathAndFileName(imgFileName, Tools.GetAppSettings("NewsImageTempPath"));
                fuImage.SaveAs(serverFileName);
                if (Session["npImginfo"] == null)
                {
                    npImgInfos = new List<NewsImageInfo>();
                }
                else
                {
                    npImgInfos = (List<NewsImageInfo>)Session["npImginfo"];
                }
                NewsImageInfo info = new NewsImageInfo();
                info.np_name = imgFileName;
                info.np_imagename = imgFileName;
                npImgInfos.Add(info);
                tfBLL.InsertTempFiles("News", Tools.GetAppSettings("NewsImageTempPath") + imgFileName);
                Session["npImginfo"] = npImgInfos;
                rpImage.DataSource = npImgInfos;
                rpImage.DataBind();
            }
            else
            {
                this.Page.Controls.Add(Tools.Tomsg("副檔名格式錯誤"));
            }
        }
    }
    public void InsertDropdown()
    {
        ddrNewsCategory.DataSource = fBLL.GetDataByLid(lid);
        ddrNewsCategory.DataTextField = "f_title";
        ddrNewsCategory.DataValueField = "f_id";
        ddrNewsCategory.DataBind();
        if (int.Parse(UserInfoConfig.GetUserConfig("HierarchyNewsCategory")) !=0)
        {
            ddrNewsCategory.Items.Insert(0, new ListItem("==請選擇發文者==", "0"));
        }
    }
}
