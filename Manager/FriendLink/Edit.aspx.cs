using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.IO;
public partial class Manager_FriendLink_Edit : BasePage
{
    FriendLinkBLL fBLL = new FriendLinkBLL(lid);
    FriendLinkCategoryBLL fcBLL = new FriendLinkCategoryBLL(lid);
    TempfilestableBLL tfBLL = new TempfilestableBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            BindCategory();
            Bind();
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
    protected void BindCategory()
    {
        ddrCategory.DataSource = fcBLL.GetDataByLid(lid);
        ddrCategory.DataTextField = "fc_title";
        ddrCategory.DataValueField = "fc_id";
        ddrCategory.DataBind();
        //ddrCategory.Items.Insert(0, new ListItem("全部顯示", "0"));
    }
    protected void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) > 0)
            {
                FriendLinkInfo info = fBLL.GetDataById(id);
                ddrCategory.SelectedValue = info.fc_id.ToString();
                txtTitle.Text = info.f_title;
                txtName.Text = info.f_name;
                ckbooks.Text = info.f_books;
                //txtDegree.Text = info.f_degree;
                ckdegree.Text = info.f_degree;
                txtPhone.Text = info.f_field;
                //txtHistory.Text = info.f_history;
                ckhistory.Text = info.f_history;
                txtEmail.Text = info.f_license;
                ckspecialty.Text = info.f_specialty;
                txtEditDate.Text = DateTime.Now.ToShortDateString();
                //txtUrl.Text = info.f_url;
                Image1.ImageUrl = Tools.GetAppSettings("FriendLinkTruePath") + info.f_img;
                Image1.AlternateText = info.f_img;
                hfImg.Value = info.f_img;
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
                Button1.Enabled = false;
                string serverFileName = WebUtility.MergePathAndFileName(imgFileName, Tools.GetAppSettings("ProductImageTempPath"));
                fuImage.SaveAs(serverFileName);
                tfBLL.InsertTempFiles("FriendLink", Tools.GetAppSettings("ProductImageTempPath") + imgFileName);
                Image1.ImageUrl = Tools.GetAppSettings("ProductImageTempPath") + imgFileName;
                Image1.AlternateText = imgFileName;
                UpdatePanel3.Update();
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
        if (ddrCategory.SelectedValue != "0")
        {
            if (!Directory.Exists(Server.MapPath("FriendLinkTruePath")))
            {
                System.IO.Directory.CreateDirectory(Server.MapPath("~/ImageCollection/friendLink/"));
            }
            FriendLinkInfo info = fBLL.GetDataById(id);
            if (hfImg.Value != Image1.AlternateText)
            {
                System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath(Image1.ImageUrl));
                file.CopyTo(Server.MapPath(Tools.GetAppSettings("FriendLinkTruePath") + Image1.AlternateText));
                if (System.IO.File.Exists(Server.MapPath(Tools.GetAppSettings("FriendLinkTruePath") + hfImg.Value)))
                {
                    System.IO.File.Delete(Server.MapPath(Tools.GetAppSettings("FriendLinkTruePath") + hfImg.Value));
                }
            }
            info.fc_id = int.Parse(ddrCategory.SelectedValue);
            info.f_title = txtTitle.Text;
            info.f_name = txtName.Text;
            //info.f_degree = txtDegree.Text;
            info.f_degree = ckdegree.Text;
            info.f_history = ckhistory.Text;
            info.f_books = ckbooks.Text;
            info.f_specialty = ckspecialty.Text;
            info.f_license = txtEmail.Text;
            info.f_field = txtPhone.Text;
            info.f_editDate = DateTime.Now;
            //info.f_url = txtUrl.Text;
            info.f_img = Image1.AlternateText;
            //info.f_show = bool.Parse(rbShow.SelectedValue);
            if (fBLL.Update(info) > 0)
            {
                Response.Redirect("List.aspx?header=修改訊息完成!", true);
            }
        }
        else
        {
            ShowMessage("請選擇職稱");
        }
    }
}