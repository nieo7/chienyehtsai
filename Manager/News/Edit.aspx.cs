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

public partial class Manager_News_Edit : BasePage
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
            //Check_Power(1, 32, true);
            Bind();
            BindCategory();
        }
    }
    private void InitPage()
    {
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phcategory"));
        phtitle.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phtitle"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phshow"));
        phdetail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phdetail"));
        phstartdate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phstartdate"));
        phcreatedate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phcreatedate"));
        pheditdate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "pheditdate"));
        phrpimage.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("News", "phrpimage"));
    }
    protected void BindCategory()
    {
        ddrCategory.DataSource = fBLL.GetDataByLid(lid);
        ddrCategory.DataTextField = "f_title";
        ddrCategory.DataValueField = "f_id";
        ddrCategory.DataBind();
        if (int.Parse(UserInfoConfig.GetUserConfig("HierarchyNewsCategory")) !=0)
        {
            ddrCategory.Items.Insert(0, new ListItem("==請選擇發文者==", "0"));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //if (int.Parse(UserInfoConfig.GetUserConfig("HierarchyNewsCategory")) != 0)
        //{
            //if (ddrCategory.SelectedValue != "0")
            //{
            //   InsertData();
            //    //if (ncBLL.SearchHierarchyEqualVail(Tools.TryParseMethod(ddrCategory.SelectedValue), int.Parse(UserInfoConfig.GetUserConfig("HierarchyNewsCategory"))))
            //    //{
            //    //    InsertData();
            //    //}
            //    //else
            //    //{
            //    //    ShowMessage("資料修改於錯誤類別之中");
            //    //}
            //}
            //else
            //{
            //    ShowMessage("請選擇發文者");
            //}
            InsertData();
        //}
        //else
        //{
        //    InsertData();
        //}
    }
    protected void InsertData()
    {
        NewsInfo info = nBLL.getAllById(id);
        //info.nc_id = Tools.TryParseMethod(ddrCategory.SelectedValue);
        info.n_title = txtName.Text;
        info.n_detail = Ckeditorl1.Text;
        info.n_show = ChkVisible.Checked;
        info.n_endDate = DateTime.Parse(txtEndDate.Text);
        info.n_startDate = DateTime.Parse(txtStartDate.Text);
        info.n_editDate = DateTime.Parse(txtEditDate.Text);
        info.n_image = hfImageIndex.Value;
        info.f_id = int.Parse(ddrCategory.SelectedValue);
        if (nBLL.Update(info) > 0)
        {            
            Response.Redirect("List.aspx?header=修改訊息完成!", true);
        }
    }
    public void Bind()
    {
        if (Request.QueryString["id"] != null)
        {
            if (Tools.TryParseMethod(id.ToString()) != 0)
            {
                NewsInfo info = nBLL.getAllById(id);
                FriendLinkInfo finfo = fBLL.getDataByLid(lid);
                ddrCategory.SelectedValue = finfo.f_id.ToString();
                txtName.Text = info.n_title;
                Ckeditorl1.Text = info.n_detail;
                ChkVisible.Checked = info.n_show;
                txtAddDate.Text = info.n_ts.ToString("yyyy/MM/dd HH:mm");
                txtEditDate.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
                txtStartDate.Text = info.n_startDate.ToString("yyyy/MM/dd");
                txtEndDate.Text = info.n_endDate.ToString("yyyy/MM/dd");
                hfImageIndex.Value = info.n_image;
                rpImage.DataSource = niBLL.GetAllImgWithNews(id);
                rpImage.DataBind();
            }
        }
    }
    protected void rpImage_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {            
            niBLL.Delete(int.Parse(e.CommandArgument.ToString()));
        }
        if (e.CommandName == "Update")
        {
            NewsImageInfo info = niBLL.GetImgWithKey(int.Parse(e.CommandArgument.ToString()));
            hfImageIndex.Value = info.np_imagename;
        }
        rpImage.DataSource = niBLL.GetAllImgWithNews(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
        rpImage.DataBind();
    }
    protected void btImage_Click(object sender, EventArgs e)
    {
        if (fuImage.HasFile)
        {
            string imgFilename = WebUtility.ChangeFileNameAsRandom(fuImage.FileName);
            if (WebUtility.CheckImageExt(System.IO.Path.GetExtension(imgFilename)))
            {
                string serverFileName = WebUtility.MergePathAndFileName(imgFilename, Tools.GetAppSettings("NewsImageTruePath"));
                fuImage.SaveAs(serverFileName);
                NewsImageInfo info = new NewsImageInfo();
                info.n_id = Tools.GetInt32SafeFromQueryString(this.Page, "id", 0);
                info.np_name = imgFilename;
                info.np_imagename = imgFilename;
                niBLL.Insert(info);
                tfBLL.InsertTempFiles("News", Tools.GetAppSettings("NewsImageTruePath") + imgFilename);
                rpImage.DataSource = niBLL.GetAllImgWithNews(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
                rpImage.DataBind();
            }
        }
        else
        {
            this.ShowMessage("請選擇一個檔案");
        }
    }
    protected void rpImage_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton lkbtnUpdate = (LinkButton)e.Item.FindControl("lkUpdate");
        Label lbimgName = (Label)e.Item.FindControl("lbImage");
        if (lbimgName != null)
        {
            if (hfImageIndex.Value == lbimgName.Text)
            {
                lkbtnUpdate.Enabled = false;
            }
        }
    }
}



