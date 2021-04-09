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
    ArticleCategoryBLL acBLL = new ArticleCategoryBLL(lid);
    ArticleBLL aBLL = new ArticleBLL(lid);
    ArticleImageBLL aiBLL = new ArticleImageBLL();
    TempfilestableBLL tfBLL = new TempfilestableBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            //Check_Power(1, 32, true);
            BindCategory();
            Bind();
        }
    }
    private void InitPage()
    {
        phfather.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phfather"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phname"));
        phdetail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phdetail"));
        phrpimage.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phrpimage"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phshow"));
    }
    protected void BindCategory()
    {
        ddrCategory.DataSource = acBLL.GetallSortData(0);
        ddrCategory.DataTextField = "ac_name";
        ddrCategory.DataValueField = "ac_id";
        ddrCategory.DataBind();
        if (int.Parse(UserInfoConfig.GetUserConfig("HierarchyArticleCategory")) != 0)
        {
            ddrCategory.Items.Insert(0, new ListItem("==請選擇類別==", "0"));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //if (int.Parse(UserInfoConfig.GetUserConfig("HierarchyArticleCategory")) != 0)
        //{
        //    if (ddrCategory.SelectedValue != "0")
        //    {
        //        if (acBLL.SearchHierarchyEqualVail(Tools.TryParseMethod(ddrCategory.SelectedValue), int.Parse(UserInfoConfig.GetUserConfig("HierarchyArticleCategory"))))
        //        {
        //            InsertData();
        //        }
        //        else
        //        {
        //            ShowMessage("資料修改於錯誤類別之中");
        //        }
        //    }
        //    else
        //    {
        //        ShowMessage("請選擇類別");
        //    }
        //}
        //else
        //{
        //    InsertData();
        //}
        InsertData();
    }
    protected void InsertData()
    {
        ArticleInfo info = aBLL.GetDataByAid(id);
        info.ac_id = Tools.TryParseMethod(ddrCategory.SelectedValue);
        info.a_title = txtTitle.Text;
        info.a_detail = Ckeditorl1.Text;
        info.a_show = bool.Parse(rbShow.SelectedValue);
        info.a_editDate = DateTime.Now;
        info.a_img = hfImageIndex.Value;
        if (aBLL.Update(info) > 0)
        {           
            Response.Redirect("~/Manager/Sysconfig/Default.aspx?header=" + Getmessage("30014"));
        }
    }
    public void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) > 0)
            {
                ArticleInfo info = aBLL.GetDataByAid(id);
                ddrCategory.SelectedValue = info.ac_id.ToString();
                txtTitle.Text = info.a_title;
                Ckeditorl1.Text = info.a_detail;
                txtAddDate.Text = info.a_ts.ToString("yyyy/MM/dd hh:mm");
                txtEditDate.Text = info.a_editDate.ToString("yyyy/MM/dd hh:mm");
                rbShow.SelectedValue = info.a_show.ToString().ToLower();
                hfImageIndex.Value = info.a_img;
                rpImage.DataSource = aiBLL.GetDataByAid(id);
                rpImage.DataBind();
            }
        }
    }
    protected void rpImage_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            aiBLL.Delete(int.Parse(e.CommandArgument.ToString()));
        }
        if (e.CommandName == "Update")
        {
            ArticleImageInfo info = aiBLL.GetDataById(int.Parse(e.CommandArgument.ToString()));
            hfImageIndex.Value = info.ap_imagename;
        }
        rpImage.DataSource = aiBLL.GetDataByAid(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
        rpImage.DataBind();
    }
    protected void btImage_Click(object sender, EventArgs e)
    {
        if (fuImage.HasFile)
        {
            string imgFilename = WebUtility.ChangeFileNameAsRandom(fuImage.FileName);
            if (WebUtility.CheckImageExt(System.IO.Path.GetExtension(imgFilename)))
            {
                string serverFileName = WebUtility.MergePathAndFileName(imgFilename, Tools.GetAppSettings("ArticleTruePath"));
                fuImage.SaveAs(serverFileName);
                ArticleImageInfo info = new ArticleImageInfo();
                info.a_id = Tools.GetInt32SafeFromQueryString(this.Page, "id", 0);
                info.ap_name = imgFilename;
                info.ap_imagename = imgFilename;
                aiBLL.Insert(info);
                tfBLL.InsertTempFiles("Ariticle", Tools.GetAppSettings("ArticleTruePath") + imgFilename);
                rpImage.DataSource = aiBLL.GetDataByAid(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
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
