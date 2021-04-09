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
    BannerBLL bBLL = new BannerBLL();
    BannerCategoryBLL bcBLL = new BannerCategoryBLL();
    BannerLocationBLL blBLL=new BannerLocationBLL();
    BannerCustomerBLL bcsBLL=new BannerCustomerBLL();
    BannerImgBLL bpBLL = new BannerImgBLL();    
    List<BannerImgInfo> bpImgInfos = new List<BannerImgInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            //Check_Power(7, 43, true);
            InsertDropDown();
            Bind();
            SessionClear();
        }
    }
    protected void SessionClear()
    {
        Session.Remove("bpImginfo");
    }
    protected void InitPage()
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
        phcreatedate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phcreatedate"));
        pheditdate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "pheditdate"));
    }
    public void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) != 0)
            {
                BannerInfo info = bBLL.GetDataById(id);
                ddrBannerCategory.SelectedValue = info.bc_id.ToString();
                ddrBannerLocation.SelectedValue = info.bl_id.ToString();
                ddrBannerCustomer.SelectedValue = info.bcs_id.ToString();
                txtName.Text = info.b_title;
                txtWebUrl.Text = info.b_url;
                hfImageIndex.Value = info.b_imagename;
                txtPrice.Text = info.b_price.ToString();
                txtProb.Text = info.b_prob.ToString();
                ddlTarget.SelectedValue = info.b_target;
                txtStartDate.Text = info.b_startDate.ToString("yyyy/MM/dd");
                txtEndDate.Text = info.b_endDate.ToString("yyyy/MM/dd");
                txtCreatedate.Text=info.b_ts.ToString("yyyy/MM/dd");
                txtEditDate.Text=info.b_editDate.ToString("yyyy/MM/dd");
                rpImage.DataSource = bpBLL.GetAllImgWithFriendLink(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
                rpImage.DataBind();
            }
        }
    }
    protected void InsertDropDown()
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
    protected void rpImage_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            bpBLL.Delete(int.Parse(e.CommandArgument.ToString()));            
        }
        if (e.CommandName == "Update")
        {
            BannerImgInfo info = bpBLL.GetImgByKey(int.Parse(e.CommandArgument.ToString()));
            hfImageIndex.Value = info.bp_imagename;
        }
        rpImage.DataSource = bpBLL.GetAllImgWithFriendLink(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
        rpImage.DataBind();
    }
    protected void btImage_Click(object sender, EventArgs e)
    {
        if (fuImage.HasFile)
        {
            string imgFilename = WebUtility.ChangeFileNameAsRandom(fuImage.FileName);
            if (WebUtility.CheckImageExt(System.IO.Path.GetExtension(imgFilename)))
            {
                string serverFileName = WebUtility.MergePathAndFileName(imgFilename, Tools.GetAppSettings("BannerImageTruePath"));
                fuImage.SaveAs(serverFileName);
                BannerImgInfo info = new BannerImgInfo();
                info.bp_id = Tools.GetInt32SafeFromQueryString(this.Page, "id", 0);
                info.bp_image = imgFilename;
                info.bp_imagename = imgFilename;
                bpBLL.Insert(info);
                rpImage.DataSource = bpBLL.GetAllImgWithFriendLink(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
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
        BannerInfo info = bBLL.GetDataById(id);
        info.bc_id = Tools.TryParseMethod(ddrBannerCategory.SelectedValue);
        info.bl_id = Tools.TryParseMethod(ddrBannerLocation.SelectedValue);
        info.bcs_id = Tools.TryParseMethod(ddrBannerCustomer.SelectedValue);
        info.b_title = txtName.Text;
        info.b_url = txtWebUrl.Text;
        info.b_imagename = hfImageIndex.Value;
        info.b_price = Tools.TryParseMethod(txtPrice.Text);
        info.b_prob = Tools.TryParseMethod(txtProb.Text);
        info.b_target = ddlTarget.SelectedValue;
        info.b_editDate = DateTime.Now;
        info.b_startDate = Tools.TryParseDateMethod(txtStartDate.Text);
        info.b_endDate = Tools.TryParseDateMethod(txtEndDate.Text);
        if (bBLL.Update(info) > 0)
        {
            Response.Redirect("List.aspx?header=修改訊息完成!", true);
        }
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
