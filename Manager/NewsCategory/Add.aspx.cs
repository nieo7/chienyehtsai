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
public partial class Manager_NewsCategory_Add : BasePage
{
    NewsCategoryBLL ncBLL = new NewsCategoryBLL(lid);
    TempfilestableBLL tfBLL = new TempfilestableBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            InsertDropdown();
        }
    }
    private void InitPage()
    {
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phcategory"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phname"));
        phimg.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phimg"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phshow"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!Directory.Exists(Server.MapPath("NewsImageTruePath")))
        {
            Directory.CreateDirectory(Server.MapPath("~/ImageCollection/news/"));
        }
        if (File.Exists(Server.MapPath(Image1.ImageUrl)))
        {
            System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath(Image1.ImageUrl));
            file.CopyTo(Server.MapPath(Tools.GetAppSettings("NewsImageTruePath") + Image1.AlternateText));
        }        
        if (ddlCategory.SelectedValue != "0")
        {
            if (ncBLL.SearchHierarchyUpVail(Tools.TryParseMethod(ddlCategory.SelectedValue), int.Parse(UserInfoConfig.GetUserConfig("HierarchyNewsCategory"))))
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
        NewsCategoryInfo info = new NewsCategoryInfo();
        info.nc_fatherid = Tools.TryParseMethod(ddlCategory.SelectedValue);
        info.nc_name = txtName.Text;
        info.nc_image = Image1.AlternateText;
        info.nc_show = bool.Parse(rbShow.SelectedValue);
        info.l_id = lid;
        if (ncBLL.Insert(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30009"));
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
    protected void InsertDropdown()
    {
        ddlCategory.DataSource = ncBLL.GetallSortData(0);
        ddlCategory.DataTextField = "nc_name";
        ddlCategory.DataValueField = "nc_id";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("==新增主類別==", "0"));
    }
}
