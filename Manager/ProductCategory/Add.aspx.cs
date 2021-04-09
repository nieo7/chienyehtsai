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
public partial class Manager_ProductCategory_Add : BasePage
{
    ProductCategoryBLL pcBLL = new ProductCategoryBLL(lid);
    TempfilestableBLL tfBLL = new TempfilestableBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            InsertDropdown();
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
            Directory.CreateDirectory(Server.MapPath("~/ImageCollection/product/"));
        }
        if (File.Exists(Server.MapPath(Image1.ImageUrl)))
        {
            System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath(Image1.ImageUrl));
            file.CopyTo(Server.MapPath(Tools.GetAppSettings("ProductImageTruePath") + Image1.AlternateText));
        }        
        if (ddlCategory.SelectedValue != "0")
        {
            if (pcBLL.SearchHierarchyUpVail(int.Parse(ddlCategory.SelectedValue),int.Parse(UserInfoConfig.GetUserConfig("HierarchyProductCategory"))))
            {
                InsertData();
            }
            else
            {
                ShowMessage("新增超越限制階層");
            }
        }
        else
        {
            InsertData();
        }
    }
    protected void InsertData()
    {
        ProductCategoryInfo info = new ProductCategoryInfo();
        info.pc_fatherid = Tools.TryParseMethod(ddlCategory.SelectedValue);
        info.pc_name = txtName.Text;
        info.pc_image = Image1.AlternateText;
        info.pc_show = bool.Parse(rbShow.SelectedValue);
        info.l_id = lid;
        if (pcBLL.Insert(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30009"), true);
        }
    }
    public void InsertDropdown()
    {
        ddlCategory.DataSource = pcBLL.getallSortData(0);
        ddlCategory.DataTextField = "pc_name";
        ddlCategory.DataValueField = "pc_id";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("==新增主類別==", "0"));
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
                Button2.Enabled = true;
            }
            else
            {
                this.Page.Controls.Add(Tools.Tomsg("副檔名格式錯誤"));
            }
        }      
    }
}