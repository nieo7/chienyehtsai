using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using BLL;
using Model;
using System.IO;
public partial class Manager_ProductCategory_Edit : BasePage
{
    ProductCategoryBLL pcBLL = new ProductCategoryBLL(lid);
    TempfilestableBLL tfBLL = new TempfilestableBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            InsertDropdown();
            ControlEdit();
            //檢查權限
            //Check_Power(1, 2, true);            
        }
    }
    private void InitPage()
    {
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("ProductCategory", "phcategory"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("ProductCategory", "phname"));
        phimg.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("ProductCategory", "phimg"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("ProductCategory", "phshow"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!Directory.Exists(Server.MapPath("ProductImageTruePath")))
        {
            System.IO.Directory.CreateDirectory(Server.MapPath("~/ImageCollection/product/"));
        }
        if (pcBLL.SearchHierarchyDownVail(Tools.TryParseMethod(ddlCategory.SelectedValue), id, int.Parse(UserInfoConfig.GetUserConfig("HierarchyProductCategory"))))
        {
            if (hfImg.Value != Image1.AlternateText)
            {
                System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath(Image1.ImageUrl));
                file.CopyTo(Server.MapPath(Tools.GetAppSettings("ProductImageTruePath") + Image1.AlternateText));
                if (System.IO.File.Exists(Server.MapPath(Tools.GetAppSettings("ProductImageTruePath") + hfImg.Value)))
                {
                    System.IO.File.Delete(Server.MapPath(Tools.GetAppSettings("ProductImageTruePath") + hfImg.Value));
                }
            }
            ProductCategoryInfo info = pcBLL.getEditdata(id);
            info.pc_fatherid = Tools.TryParseMethod(ddlCategory.SelectedValue);
            info.pc_name = txtName.Text;
            info.pc_image = Image1.AlternateText;
            info.pc_show = bool.Parse(rbShow.SelectedValue);
            if (pcBLL.Update(info) > 0)
                Response.Redirect("List.aspx?header=" + Getmessage("30014"), true);
            else
                ShowMessage("更新失敗: 更新類別不可為自身、不可為自身以下的子類別");
        }
        else
        {
            ShowMessage("轉換類別超越階層限制數");
        }
    }
    public void InsertDropdown()
    {
        ddlCategory.DataSource = pcBLL.getallSortData(0);
        ddlCategory.DataTextField = "pc_name";
        ddlCategory.DataValueField = "pc_id";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("==設定成主類別==", "0"));
    }
    public void ControlEdit()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) != 0)
            {
                ProductCategoryInfo info = pcBLL.getEditdata(id);
                txtName.Text = info.pc_name;
                ddlCategory.SelectedValue = info.pc_fatherid.ToString();
                if (info.pc_fatherid == 0)
                {
                    ddlCategory.Enabled = false;
                }
                Image1.ImageUrl = Tools.GetAppSettings("ProductImageTruePath") + info.pc_image;
                Image1.AlternateText = info.pc_image;
                rbShow.SelectedValue = info.pc_show.ToString().ToLower();
                hfImg.Value = info.pc_image;
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
                tfBLL.InsertTempFiles("ProductCategory", Tools.GetAppSettings("ProductImageTempPath") + imgFileName);
                Image1.ImageUrl = Tools.GetAppSettings("ProductImageTempPath") + imgFileName;
                Image1.AlternateText = imgFileName;
                UpdatePanel3.Update();
                Button2.Enabled = true;
            }
            else
            {                
                this.Page.Controls.Add(Tools.Tomsg("副檔名格式錯誤"));
            }
        }
    }
}