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
using System.IO;

public partial class Manager_NewsCategory_Edit : BasePage
{    
    NewsCategoryBLL ncBLL = new NewsCategoryBLL(lid);
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
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phcategory"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phname"));
        phimg.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phimg"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phshow"));
    }
    protected void BindCategory()
    {
        ddlCategory.DataSource = ncBLL.GetallSortData(0);
        ddlCategory.DataTextField = "nc_name";
        ddlCategory.DataValueField = "nc_id";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("==設定成主類別==", "0"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!Directory.Exists(Server.MapPath("NewsImageTruePath")))
        {
            System.IO.Directory.CreateDirectory(Server.MapPath("~/ImageCollection/news/"));
        }
        if (ncBLL.SearchHierarchyDownVail(Tools.TryParseMethod(ddlCategory.SelectedValue), id, int.Parse(UserInfoConfig.GetUserConfig("HierarchyNewsCategory"))))
        {
            if (hfImg.Value != Image1.AlternateText)
            {
                FileInfo file = new FileInfo(Server.MapPath(Image1.ImageUrl));
                file.CopyTo(Server.MapPath(Tools.GetAppSettings("NewsImageTruePath") + Image1.AlternateText));
                if (File.Exists(Server.MapPath(Tools.GetAppSettings("NewsImageTruePath") + hfImg.Value)))
                {
                    File.Delete(Server.MapPath(Tools.GetAppSettings("NewsImageTruePath") + hfImg.Value));
                }
            }
            NewsCategoryInfo info = ncBLL.getAllById(id);
            info.nc_fatherid = Tools.TryParseMethod(ddlCategory.SelectedValue);
            info.nc_name = txtName.Text;
            info.nc_show = bool.Parse(rbShow.SelectedValue);
            info.nc_image = Image1.AlternateText;
            if (ncBLL.Update(info) > 0)
            {
                Response.Redirect("List.aspx?header=修改訊息完成!", true);
            }
            else
            {
                ShowMessage("更新失敗: 更新類別不可為自身、不可為自身以下的子類別");
            }
        }
        else
        {
            ShowMessage("轉換類別超越階層限制數");
        }
    }
    public void Bind()
    {
        if (Request.QueryString["id"] != null)
        {
            if (Tools.TryParseMethod(id.ToString()) != 0)
            {
                NewsCategoryInfo info = ncBLL.getAllById(id);
                txtName.Text = info.nc_name;
                ddlCategory.SelectedValue = info.nc_fatherid.ToString();
                if (info.nc_fatherid == 0)
                {
                    ddlCategory.Enabled = false;
                }
                Image1.ImageUrl = Tools.GetAppSettings("NewsImageTruePath") + info.nc_image;
                Image1.AlternateText = info.nc_image;
                rbShow.SelectedValue = info.nc_show.ToString().ToLower();
                hfImg.Value = info.nc_image;
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
                Button2.Enabled = false;
                string serverFileName = WebUtility.MergePathAndFileName(imgFileName, Tools.GetAppSettings("ProductImageTempPath"));
                fuImage.SaveAs(serverFileName);
                tfBLL.InsertTempFiles("NewsCategory", Tools.GetAppSettings("ProductImageTempPath") + imgFileName);
                Image1.ImageUrl = Tools.GetAppSettings("ProductImageTempPath") + imgFileName;
                Image1.AlternateText = imgFileName;                
                Button2.Enabled = true;
            }
            else
            {
                this.Page.Controls.Add(Tools.Tomsg("副檔名格式錯誤"));
            }
        }
    }
}
