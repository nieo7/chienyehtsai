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
    ArticleBLL aBLL = new ArticleBLL(lid);
    ArticleCategoryBLL acBLL = new ArticleCategoryBLL(lid);
    ArticleImageBLL aiBLL = new ArticleImageBLL();
    TempfilestableBLL tfBLL = new TempfilestableBLL();
    List<ArticleImageInfo> arimgInfos = new List<ArticleImageInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            //檢查權限
            //Check_Power(1, 2, true);            
            BindCategory();            
            SessionClear();
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
        ddlCategory.DataSource = acBLL.GetallSortData(0);
        ddlCategory.DataTextField = "ac_name";
        ddlCategory.DataValueField = "ac_id";
        ddlCategory.DataBind();
        //階層驗證判斷式
        if (int.Parse(UserInfoConfig.GetUserConfig("HierarchyArticleCategory")) != 0)
        {
            ddlCategory.Items.Insert(0, new ListItem("==選擇主類別==", "0"));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {  
        //階層驗證判斷式
        //if (int.Parse(UserInfoConfig.GetUserConfig("HierarchyArticleCategory")) != 0)
        //{
        //    if (ddlCategory.SelectedValue != "0")
        //    {
        //        //階層驗證判斷式
        //        if (acBLL.SearchHierarchyEqualVail(Tools.TryParseMethod(ddlCategory.SelectedValue), int.Parse(UserInfoConfig.GetUserConfig("HierarchyArticleCategory"))))
        //        {
        //            InsertData();
        //        }
        //        else
        //        {
        //            ShowMessage("資料新增於錯誤階層");
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
        ArticleInfo info = new ArticleInfo();
        info.ac_id = Tools.TryParseMethod(ddlCategory.SelectedValue);
        info.a_title = txtName.Text;
        info.a_detail = Ckeditorl1.Text;
        info.a_ts = DateTime.Now;
        info.a_editDate = DateTime.Now;
        info.a_show = bool.Parse(rbShow.SelectedValue);
        info.a_img = hfProductImage.Value;
        info.l_id = lid;
        if (aBLL.Insert(info) > 0)
        {
            InsertArticleImage(aBLL.GetDataOrderIdDESC().a_id);
            SessionClear();
            Response.Redirect("List.aspx?header=" + Getmessage("30009"));
        }
    }
    protected void SessionClear()
    {
        Session.Remove("arimginfo");
    }
    public void InsertArticleImage(int a_id)
    {
        for (int i = 0; i < rpImage.Items.Count; i++)
        {
            ArticleImageInfo info = new ArticleImageInfo();
            Image lbtxtFormatName = (Image)rpImage.Items[i].FindControl("Image1");
            if (lbtxtFormatName != null)
            {
                if (System.IO.File.Exists(Server.MapPath(Tools.GetAppSettings("ProductImageTempPath") + lbtxtFormatName.AlternateText)))
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath(Tools.GetAppSettings("ProductImageTempPath") + lbtxtFormatName.AlternateText));
                    file.CopyTo(Server.MapPath(Tools.GetAppSettings("ArticleTruePath") + lbtxtFormatName.AlternateText));
                }
            
            info.a_id = a_id;
            info.ap_imagename = lbtxtFormatName.AlternateText;
            info.ap_name = lbtxtFormatName.AlternateText;
            }
            aiBLL.Insert(info);
        }
    }
    protected void btImage_Click(object sender, EventArgs e)
    {
        if (fuImage.HasFile)
        {
            string imgFilename = WebUtility.ChangeFileNameAsRandom(fuImage.FileName);
            if (WebUtility.CheckImageExt(System.IO.Path.GetExtension(imgFilename)))
            {
                string serverFileName = WebUtility.MergePathAndFileName(imgFilename, Tools.GetAppSettings("ProductImageTempPath"));
                fuImage.SaveAs(serverFileName);
                if (Session["arimginfo"] == null)
                {
                    arimgInfos = new List<ArticleImageInfo>();
                }
                else
                {
                    arimgInfos = (List<ArticleImageInfo>)Session["arimginfo"];
                }
                ArticleImageInfo info=new ArticleImageInfo();
                info.ap_imagename = imgFilename;
                info.ap_name = imgFilename;
                arimgInfos.Add(info);
                tfBLL.InsertTempFiles("article", Tools.GetAppSettings("ProductImageTempPath") + imgFilename);
                Session["arimginfo"] = arimgInfos;
                rpImage.DataSource = arimgInfos;
                rpImage.DataBind();
            }
        }
    }
    protected void rpImage_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            if (Session["arimginfo"] != null)
            {
                arimgInfos = (List<ArticleImageInfo>)Session["arimginfo"];
                Label lb = (Label)e.Item.FindControl("lbImageID");
                foreach (ArticleImageInfo arInfo in arimgInfos)
                {
                    if (arInfo.ap_imagename == lb.Text)
                    {
                        System.IO.File.Delete(Server.MapPath(Tools.GetAppSettings("ProductImageTempPath") + arInfo.ap_imagename));
                        arimgInfos.Remove(arInfo);
                        Session["arimginfo"] = arimgInfos;
                        rpImage.DataSource = arimgInfos;
                        rpImage.DataBind();                     
                        ShowMessage("刪除成功！");
                        return;
                    }
                }
            }
        }
        if (e.CommandName == "Update")
        {
            if (Session["arimginfo"] != null)
            {
                arimgInfos = (List<ArticleImageInfo>)Session["arimginfo"];

                hfProductImage.Value = e.CommandArgument.ToString();
                Session["arimginfo"] = arimgInfos;
                rpImage.DataSource = arimgInfos;
                rpImage.DataBind();
                Page.Controls.Add(Tools.Tomsg("更新成功!"));
            }
        }
    }
    protected void rpImage_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lbImage = (Label)e.Item.FindControl("lbImage");
        LinkButton lkUpdate = (LinkButton)e.Item.FindControl("lkUpdate");
        if (lbImage != null)
        {
            if (hfProductImage.Value == lbImage.Text)
            {
                lkUpdate.Enabled = false;
            }
        }        
    }
}
