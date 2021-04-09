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
public partial class Manager_FriendLink_Add : BasePage
{
    FriendLinkCategoryBLL fcBLL = new FriendLinkCategoryBLL(lid);
    FriendLinkBLL fBLL = new FriendLinkBLL(lid);
    TempfilestableBLL tfBLL = new TempfilestableBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            BindDate();
            InsertDropDown();
        }
    }
    private void InitPage()
    {
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLink", "phcategory"));
        phtitle.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLink", "phtitle"));
        //phurl.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLink", "phurl"));
        phimage.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLink", "phimage"));
        //phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLink", "phshow"));
    }
    protected void btImage_Click(object sender, EventArgs e)
    {
        if (fuImage.HasFile)
        {
            string imgFileName = WebUtility.ChangeFileNameAsRandom(fuImage.FileName);
            if (WebUtility.CheckImageExt(System.IO.Path.GetExtension(imgFileName)))
            {
                Button1.Enabled = false;
                string serverFileName = WebUtility.MergePathAndFileName(imgFileName, Tools.GetAppSettings("ProductImageTempPath"));
                fuImage.SaveAs(serverFileName);
                tfBLL.InsertTempFiles("FriendLink", Tools.GetAppSettings("ProductImageTempPath")+imgFileName);
                Image1.ImageUrl = Tools.GetAppSettings("ProductImageTempPath") + imgFileName;
                Image1.AlternateText = imgFileName;                
                Button1.Enabled = true;
            }
            else
            {
                this.Page.Controls.Add(Tools.Tomsg("副檔名格式錯誤"));
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedValue != "0")
        {
            if (!Directory.Exists(Server.MapPath("FriendLinkTruePath")))
            {
                System.IO.Directory.CreateDirectory(Server.MapPath("~/ImageCollection/friendLink/"));
            }
            if (System.IO.File.Exists(Server.MapPath(Image1.ImageUrl)))
            {
                System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath(Image1.ImageUrl));
                file.CopyTo(Server.MapPath(Tools.GetAppSettings("FriendLinkTruePath") + Image1.AlternateText));
            }
                FriendLinkInfo info = new FriendLinkInfo();    
                info.fc_id = int.Parse(ddlCategory.SelectedValue);
                info.f_title = txtTitle.Text;
                info.f_name = txtName.Text;
                info.f_books = uc3.Text;
                info.f_degree = uc1.Text;
                info.f_field = txtPhone.Text;
                info.f_history = uc2.Text;
                info.f_license = txtEmail.Text;
                info.f_specialty = uc4.Text;
                info.f_ts = DateTime.Parse(txtDate.Text);
                info.l_id = lid;
                //info.f_url = txtUrl.Text;
                info.f_img = Image1.AlternateText;
                //info.f_show = bool.Parse(rbShow.SelectedValue);
                if (fBLL.Insert(info) > 0)
                {
                    Response.Redirect("List.aspx?header=" + Getmessage("30009"));
                }                      
        }
        else
        {
            ShowMessage("請選擇職稱");
        }
    }
    public void InsertDropDown()
    {
        ddlCategory.DataSource = fcBLL.GetDataByLid(lid);
        ddlCategory.DataTextField = "fc_title";
        ddlCategory.DataValueField = "fc_id";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("==請選擇職稱==", "0"));
    }
    protected void BindDate()
    {
        txtDate.Text = DateTime.Now.ToShortDateString();
    }

}