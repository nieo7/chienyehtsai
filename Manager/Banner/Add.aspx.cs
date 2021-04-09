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
    BannerBLL bBLL = new BannerBLL();
    BannerCategoryBLL bcBLL = new BannerCategoryBLL();
    BannerLocationBLL blBLL = new BannerLocationBLL();
    BannerCustomerBLL bcsBLL = new BannerCustomerBLL();
    BannerImgBLL bpBLL = new BannerImgBLL();
    TempfilestableBLL tfBLL = new TempfilestableBLL();
    List<BannerImgInfo> bpImgInfos = new List<BannerImgInfo>();

    protected void Page_Load(object sender, EventArgs e)
    {        
        InitPage();
        if (!IsPostBack)
        {
            InsertDropdown();            
            //檢查權限
            //Check_Power(7, 12, true);                        
            SessionClear();
        }
    }
    private void InitPage()
    {
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phcategory"));
        phlocation.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phlocation"));
        phcustomer.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phcustomer"));
        phtitle.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phtitle"));
        phurl.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phurl"));
        phprice.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phprice"));
        phprob.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phprob"));
        phtarget.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phtarget"));
        phstartdate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phstartdate"));
        phenddate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phenddate"));
        phimg.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phimg"));
    }
    protected void SessionClear()
    {
        Session.Remove("bpImginfo");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {    
        //三種關係資料表判斷式,無可定義 SelectValue !="0"
        //廣告資料可不引入三個資料表之間的關係
        if (Page.IsValid)
        {
            if (int.Parse(UserInfoConfig.GetUserConfig("HierarchyBannerLocation")) != 0)
            {
                if (blBLL.SearchHierarchyEqualVail(Tools.TryParseMethod(ddrBannerLocation.SelectedValue), int.Parse(UserInfoConfig.GetUserConfig("HierarchyBannerLocation"))))
                {
                    InsertData();
                }
                else
                {
                    ShowMessage("位置選擇於錯誤階層");
                }
            }
            else
            {
                InsertData();
            }
        }
    }
    protected void InsertData()
    {
        BannerInfo info = new BannerInfo();
        info.bc_id = Tools.TryParseMethod(ddrBannerCategory.SelectedValue);
        info.bcs_id = Tools.TryParseMethod(ddrBannerCustomer.SelectedValue);
        info.bl_id = Tools.TryParseMethod(ddrBannerLocation.SelectedValue);
        info.b_title = txtName.Text;
        info.b_url = txtWebUrl.Text;
        info.b_imagename = hfNewsImage.Value;
        info.b_price =Tools.TryParseMethod(txtPrice.Text);
        info.b_prob = Tools.TryParseMethod(txtProb.Text);
        info.b_target = ddlTarget.SelectedValue;
        info.b_hits = 0;
        info.b_ts = DateTime.Now;
        info.b_editDate = DateTime.Now;
        info.b_startDate = DateTime.Parse(txtStartDate.Text);
        info.b_endDate = DateTime.Parse(txtEndDate.Text);      
        if (bBLL.Insert(info) > 0)
        {
            //加入BannerPic資料表
            BannerInfo bpinfos = bBLL.GetLastBanner();
            InsertBannerImage(bpinfos.b_id);
            Response.Redirect("List.aspx?header=" + Getmessage("30009"));
        }
    }
    private void InsertBannerImage(int BannerID)
    {
        BannerImgInfo bpinfo = new BannerImgInfo();        
        for (int i = 0; i < rpImage.Items.Count; i++)
        {
            Image lbtxtFormatName = (Image)rpImage.Items[i].FindControl("Image1");
            if (lbtxtFormatName != null)
            {                
                if (System.IO.File.Exists(Server.MapPath(Tools.GetAppSettings("ProductImageTempPath") + lbtxtFormatName.AlternateText)))
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath(Tools.GetAppSettings("ProductImageTempPath") + lbtxtFormatName.AlternateText));
                    file.CopyTo(Server.MapPath(Tools.GetAppSettings("BannerImageTruePath") + lbtxtFormatName.AlternateText));
                }
                bpinfo.b_id = BannerID;
                bpinfo.bp_image = lbtxtFormatName.AlternateText;
                bpinfo.bp_imagename = lbtxtFormatName.AlternateText;
            }
            bpBLL.Insert(bpinfo);
        }
    }
    //設定Repeater的Delete與Update
    protected void rpImage_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            if (Session["bpImginfo"] != null)
            {
                bpImgInfos = (List<BannerImgInfo>)Session["bpImginfo"];
                Label lb = (Label)e.Item.FindControl("lbImageID");
                foreach (BannerImgInfo bpinfo in bpImgInfos)
                {
                    if (bpinfo.bp_image == lb.Text)
                    {
                        System.IO.File.Delete(Server.MapPath(Tools.GetAppSettings("ProductImageTempPath") + bpinfo.bp_image));
                        bpImgInfos.Remove(bpinfo);
                        Session["bpImginfo"] = bpImgInfos;
                        rpImage.DataSource = bpImgInfos;
                        rpImage.DataBind();
                        ShowMessage("刪除成功!");
                        return;
                    }
                }
            }
        }
        if (e.CommandName == "Update")
        {
            if (Session["bpImginfo"] != null)
            {
                bpImgInfos = (List<BannerImgInfo>)Session["bpImginfo"];
                hfNewsImage.Value = e.CommandArgument.ToString();
                Session["bpImginfo"] = bpImgInfos;
                rpImage.DataSource = bpImgInfos;
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
        if (fuImage.HasFile)
        {            
            string imgFileName = WebUtility.ChangeFileNameAsRandom(fuImage.FileName);
            if (WebUtility.CheckImageExt(System.IO.Path.GetExtension(imgFileName)))
            {
                //從Web.Config取得路徑
                string serverFileName = WebUtility.MergePathAndFileName(imgFileName, Tools.GetAppSettings("ProductImageTempPath"));
                fuImage.SaveAs(serverFileName);                
                if (Session["bpImginfo"] == null)
                {
                    bpImgInfos = new List<BannerImgInfo>();
                }
                else
                {
                    bpImgInfos = (List<BannerImgInfo>)Session["bpImginfo"];
                }
                BannerImgInfo info = new BannerImgInfo();
                info.bp_image = imgFileName;
                info.bp_imagename = imgFileName;
                bpImgInfos.Add(info);
                tfBLL.InsertTempFiles("Banner", Tools.GetAppSettings("NewsImageTempPath") + imgFileName);
                Session["bpImginfo"] = bpImgInfos;
                rpImage.DataSource = bpImgInfos;
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
        ddrBannerCategory.DataSource = bcBLL.getAll();
        ddrBannerCategory.DataTextField = "bc_title";
        ddrBannerCategory.DataValueField = "bc_id";
        ddrBannerCategory.DataBind();
        ddrBannerCategory.Items.Insert(0, new ListItem("==請選擇類別==", "0"));

        ddrBannerLocation.DataSource = blBLL.GetallSortData(0);
        ddrBannerLocation.DataTextField = "bl_title";
        ddrBannerLocation.DataValueField = "bl_id";
        ddrBannerLocation.DataBind();
        if (int.Parse(UserInfoConfig.GetUserConfig("HierarchyBannerLocation")) != 0)
        {
            ddrBannerLocation.Items.Insert(0, new ListItem("==請選擇位置==", "0"));
        }

        ddrBannerCustomer.DataSource = bcsBLL.GetAll();
        ddrBannerCustomer.DataTextField = "bcs_company_name";
        ddrBannerCustomer.DataValueField = "bcs_id";
        ddrBannerCustomer.DataBind();
        ddrBannerCustomer.Items.Insert(0, new ListItem("==請選擇客戶==", "0"));
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (DateTime.MinValue != Tools.TryParseDateMethod(txtStartDate.Text))
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
            ShowMessage("請輸入正確日期格式");
        }
    }
}
