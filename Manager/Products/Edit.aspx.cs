using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Manager_Products_Edit : BasePage
{
    ProductCategoryBLL pdcBLL = new ProductCategoryBLL(lid);
    ProductBLL pdBLL = new ProductBLL(lid);
    ProductDownloadBLL PddBLL = new ProductDownloadBLL();
    ProductImageBLL pdImgBLL = new ProductImageBLL();
    ProductSubFormatBLL pdsFM = new ProductSubFormatBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            //Check_Power(2, 34, true);
            Bind();
            InsertDropdown();
            ControlStatus();
        }
    }
    private void InitPage()
    {
        phpc.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phpc"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phname"));
        phformat.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phformat"));
        phserial.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phserial"));
        phstate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phstate"));
        phdetail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phdetail"));
        phshowhot.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phshowhot"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phshow"));
        phstock.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phstock"));
        phstockunit.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phstockunit"));
        phprice1.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phprice1"));
        phprice2.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phprice2"));
        phprice3.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phprice3"));
        phprice4.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phprice4"));
        phprice5.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phprice5"));
        phfile.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phfile"));
        phrpImage.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phrpImage"));
        phcreatedate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phcreatedate"));
        pheditdate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "pheditdate"));        
    }
    public void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) > 0)
            {
                //Loading格式
                rpFormat.DataSource = pdsFM.GetFormatWithProduct(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
                rpFormat.DataBind();

                //Loading檔案
                rpDownload.DataSource = PddBLL.GetallFilesWithProduct(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
                rpDownload.DataBind();
                //Loading圖片
                rpImage.DataSource = pdImgBLL.GetallImgWithProduct(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
                rpImage.DataBind();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (int.Parse(UserInfoConfig.GetUserConfig("HierarchyProductCategory")) != 0)
        {
            if (ddrCategory.SelectedValue != "0")
            {
                if (pdcBLL.SearchHierarchyEqualVail(Tools.TryParseMethod(ddrCategory.SelectedValue), int.Parse(UserInfoConfig.GetUserConfig("HierarchyProductCategory"))))
                {
                    InsertData();
                }
                else
                {
                    ShowMessage("資料修改於錯誤類別之中");
                }
            }
            else
            {
                ShowMessage("請選擇類別");
            }
        }
        else
        {
            InsertData();
        }
    }
    protected void InsertData()
    {
        ProductInfo info = pdBLL.GetProductForEdit(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
        info.pc_id = Tools.TryParseMethod(ddrCategory.SelectedValue);
        info.p_name = txtName.Text;
        info.p_serial = txtSerial.Text;
        info.p_status = Tools.TryParseMethod(ddrState.SelectedValue);
        info.p_show = bool.Parse(rbShow.SelectedValue);
        info.p_show_hot = bool.Parse(rbHotShow.SelectedValue);
        info.p_detail = ckeditProduct.Text;
        info.p_stock = Tools.TryParseMethod(txtStock.Text);
        info.p_stock_unit = txtStock_unit.Text;
        info.p_price1 = Tools.TryParseMethod(txtPrice1.Text);
        info.p_price2 = txtPrice2.Text;
        info.p_price3 = txtPrice3.Text;
        info.p_price4 = txtPrice4.Text;
        info.p_price5 = txtPrice5.Text;
        info.p_editDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        info.p_img = hfImageIndex.Value;
        info.p_files = hfDownloadFile.Value;
        if (pdBLL.Update(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30014"));
        }
    }
    protected void rpImage_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {            
            pdImgBLL.Delete(int.Parse(e.CommandArgument.ToString()));
        }
        if (e.CommandName == "Update")
        {
            ProductImageInfo info = pdImgBLL.GetImgWithKey(int.Parse(e.CommandArgument.ToString()));
            hfImageIndex.Value = info.pi_imageName;
        }
        rpImage.DataSource = pdImgBLL.GetallImgWithProduct(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
        rpImage.DataBind();
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
    protected void btImage_Click(object sender, EventArgs e)
    {
        if (fuImage.HasFile)
        {
            string imgFilename = WebUtility.ChangeFileNameAsRandom(fuImage.FileName);
            if (WebUtility.CheckImageExt(System.IO.Path.GetExtension(imgFilename)))
            {
                Button1.Enabled = false;
                string serverfilename = WebUtility.MergePathAndFileName(imgFilename, Tools.GetAppSettings("ProductImageTruePath"));
                fuImage.SaveAs(serverfilename);                
                ProductImageInfo pdimg = new ProductImageInfo();
                pdimg.p_id = Tools.GetInt32SafeFromQueryString(this.Page, "id", 0);
                pdimg.pi_imageName = imgFilename;
                pdimg.pi_image = imgFilename;
                pdImgBLL.Insert(pdimg);
                Button1.Enabled = true;
                rpImage.DataSource = pdImgBLL.GetallImgWithProduct(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
                rpImage.DataBind();
            }
        }
    }
    protected void rpDownload_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {            
            PddBLL.Delete(int.Parse(e.CommandArgument.ToString()));
        }
        if (e.CommandName == "Update")
        {
            ProductDownloadInfo info = PddBLL.GetFileWithKey(int.Parse(e.CommandArgument.ToString()));
            hfDownloadFile.Value = info.pd_name;
        }
        rpDownload.DataSource = PddBLL.GetallFilesWithProduct(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
        rpDownload.DataBind();
    }
    protected void rpDownload_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lbDL = (Label)e.Item.FindControl("lbDownloadID");
        LinkButton lkupdate = (LinkButton)e.Item.FindControl("lnkUpdate");
        if (lbDL != null)
        {
            if (hfDownloadFile.Value == lbDL.Text)
            {
                lkupdate.Enabled = false;
            }
        }
    }
    protected void btFile_Click(object sender, EventArgs e)
    {
        if (fuFile.HasFile)
        {
            string filename = WebUtility.ChangeFileNameAsRandom(fuFile.FileName);
            string ServerFilename = WebUtility.MergePathAndFileName(filename, Tools.GetAppSettings("ProductDLTruePath"));
            fuFile.SaveAs(ServerFilename);            
            ProductDownloadInfo info = new ProductDownloadInfo();
            info.pd_name = filename;
            info.pd_type = filename;
            info.p_id = Tools.GetInt32SafeFromQueryString(this.Page, "id", 0);
            PddBLL.Insert(info);
            rpDownload.DataSource = PddBLL.GetallFilesWithProduct(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
            rpDownload.DataBind();
        }
        else
        {
            this.ShowMessage("請選擇一個檔案");
        }
    }
    protected void rpFormat_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label lb2;
        Label lb3;
        int ClickNowKey = 0;
        int RdyChangeKey = 0;
        int ClickNowSort = 0;
        int RdyChangeSort = 0;
        if (e.CommandName == "Delete")
        {
            Label lb = (Label)e.Item.FindControl("lbFormatID");
            pdsFM.Delete(int.Parse(lb.Text));
        }
        if (e.CommandName == "btnSortUp")
        {
            ClickNowKey = e.Item.ItemIndex;
            RdyChangeKey = e.Item.ItemIndex - 1;
            if (ClickNowKey > 0)
            {
                lb2 = (Label)rpFormat.Items[ClickNowKey].FindControl("lbFormatID");
                lb3 = (Label)rpFormat.Items[RdyChangeKey].FindControl("lbFormatID");
                ProductSubFormatInfo pdsFMClick = pdsFM.GetSubFormatKey(int.Parse(lb2.Text));
                ProductSubFormatInfo pdsFMChange = pdsFM.GetSubFormatKey(int.Parse(lb3.Text));
                ClickNowSort = pdsFMClick.psf_sorting;
                RdyChangeSort = pdsFMChange.psf_sorting;
                pdsFMClick.psf_sorting = RdyChangeSort;
                pdsFMChange.psf_sorting = ClickNowSort;
                pdsFM.Update(pdsFMClick);
                pdsFM.Update(pdsFMChange);
            }
            else
            {
                ShowMessage("此項目排序已是第一位");
            }
        }
        if (e.CommandName == "btnSortDown")
        {
            ClickNowKey = e.Item.ItemIndex;
            RdyChangeKey = e.Item.ItemIndex + 1;
            if (ClickNowKey + 1 < rpFormat.Items.Count)
            {
                lb2 = (Label)rpFormat.Items[ClickNowKey].FindControl("lbFormatID");
                lb3 = (Label)rpFormat.Items[RdyChangeKey].FindControl("lbFormatID");
                ProductSubFormatInfo pdsFMClick = pdsFM.GetSubFormatKey(int.Parse(lb2.Text));
                ProductSubFormatInfo pdsFMChange = pdsFM.GetSubFormatKey(int.Parse(lb3.Text));
                ClickNowSort = pdsFMClick.psf_sorting;
                RdyChangeSort = pdsFMChange.psf_sorting;
                pdsFMClick.psf_sorting = RdyChangeSort;
                pdsFMChange.psf_sorting = ClickNowSort;
                pdsFM.Update(pdsFMClick);
                pdsFM.Update(pdsFMChange);
            }
            else
            {
                ShowMessage("此項目排序已是最底");
            }
        }
        rpFormat.DataSource = pdsFM.GetFormatWithProduct(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
        rpFormat.DataBind();
    }
    protected void btNewFormat_Click(object sender, EventArgs e)
    {
        if (txtNewFormat.Text == "")
        {            
            ShowMessage("請輸入規格名稱");
            return;
        }
        ProductSubFormatInfo info = new ProductSubFormatInfo();
        info.p_id = Tools.GetInt32SafeFromQueryString(this.Page, "id", 0);
        info.psf_name = txtNewFormat.Text;
        info.psf_sorting = pdsFM.GetFormatInsertSorting(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
        pdsFM.Insert(info);
        rpFormat.DataSource = pdsFM.GetFormatWithProduct(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
        rpFormat.DataBind();
    }
    public void InsertDropdown()
    {
        ddrCategory.DataSource = pdcBLL.getallSortData(0);
        ddrCategory.DataTextField = "pc_name";
        ddrCategory.DataValueField = "pc_id";
        ddrCategory.DataBind();
        if (int.Parse(UserInfoConfig.GetUserConfig("HierarchyProductCategory")) != 0)
        {
            ddrCategory.Items.Insert(0, new ListItem("==請選擇類別==", "0"));
        }
    }
    public void ControlStatus()
    {
        ProductInfo info = pdBLL.GetProductForEdit(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
        ddrCategory.SelectedValue = info.pc_id.ToString();       
        ddrState.SelectedValue = info.p_status.ToString();
        txtName.Text = info.p_name;
        ckeditProduct.Text = info.p_detail;
        rbHotShow.SelectedValue = info.p_show_hot.ToString();
        rbShow.SelectedValue = info.p_show.ToString();
        txtStock.Text = info.p_stock.ToString();
        txtStock_unit.Text = info.p_stock_unit;
        txtSerial.Text = info.p_serial;
        txtPrice1.Text = info.p_price1.ToString();
        txtPrice2.Text = info.p_price2;
        txtPrice3.Text = info.p_price3;
        txtPrice4.Text = info.p_price4;
        txtPrice5.Text = info.p_price5;
        txtAddDate.Text = info.p_createDate.ToShortDateString();
        txtEditeDate.Text = info.p_editDate.ToShortDateString();
        hfImageIndex.Value = info.p_img;
    }
}