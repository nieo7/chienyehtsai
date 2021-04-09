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
public partial class Manager_Products_Add : BasePage
{    
    ProductCategoryBLL pcBLL = new ProductCategoryBLL(lid);
    ProductBLL pdBLL = new ProductBLL(lid);      
    ProductImageBLL pdimgBLL = new ProductImageBLL();
    ProductSubFormatBLL pdsFMBLL = new ProductSubFormatBLL();
    ProductTempFormatBLL pdtFMBLL = new ProductTempFormatBLL();
    ProductDownloadBLL pddBLL = new ProductDownloadBLL();
    TempfilestableBLL tfBLL = new TempfilestableBLL();
    List<ProductImageInfo> pdImgInfos = new List<ProductImageInfo>();
    List<ProductDownloadInfo> pdDlInfos = new List<ProductDownloadInfo>();
    protected void Page_Init(object sender, EventArgs e)
    {    
        InsertDropdown();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            BindFormat();// 初次頁面產品規格顯示      
            SessionClear();
        }        
        hfLanguage.Value = lid.ToString();        
    }
    private void InitPage()
    {
        phpc.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phpc"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phname"));
        phformat.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phformat"));
        phserial.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phserial"));
        phstate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phstate"));
        phstock.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phstock"));
        phstockunit.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phstockunit"));
        phprice1.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phprice1"));
        phprice2.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phprice2"));
        phprice3.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phprice3"));
        phprice4.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phprice4"));
        phprice5.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phprice5"));
        phfile.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phfile"));
        phrpImage.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phrpImage"));
        phshowhot.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phshowhot"));
        phdetail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phdetail"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Product", "phshow"));
    }
    // 繫結產品規格
    protected void BindFormat()
    {       
            rpFormat.DataSource = pdtFMBLL.GetallWithCategory(Tools.TryParseMethod(ddlCategory.SelectedValue));
            rpFormat.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (int.Parse(UserInfoConfig.GetUserConfig("HierarchyProductCategory")) != 0)
        {
            if (ddlCategory.SelectedValue != "0")
            {
                if (pcBLL.SearchHierarchyEqualVail(Tools.TryParseMethod(ddlCategory.SelectedValue), int.Parse(UserInfoConfig.GetUserConfig("HierarchyProductCategory"))))
                {
                    InsertData();
                }
                else
                {
                    ShowMessage("資料新增於錯誤階層");
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
        ProductInfo info = new ProductInfo();
        info.pc_id = Tools.TryParseMethod(ddlCategory.SelectedValue);
        info.pcs_id = 0;
        info.p_name = txtName.Text;
        info.p_serial = txtSerial.Text;
        info.p_status = Tools.TryParseMethod(ddrState.SelectedValue);
        info.p_show = bool.Parse(rbShow.SelectedValue);
        info.p_show_hot = bool.Parse(rbHotShow.SelectedValue);
        info.p_detail = CkeditPro1.Text; //在PostBack下可能失效
        info.p_stock = Tools.TryParseMethod(txtStock.Text);
        info.p_stock_unit = txtStock_unit.Text;
        //價格欄位除了原價以外,其餘不限定輸入格式
        info.p_price1 = Tools.TryParseMethod(txtPrice1.Text); //加入驗證
        info.p_price2 = txtPrice2.Text;
        info.p_price3 = txtPrice3.Text;
        info.p_price4 = txtPrice4.Text;
        info.p_price5 = txtPrice5.Text;
        info.p_createDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        info.p_editDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        info.p_img = hfProductImage.Value; //紀錄首圖
        info.p_files = hfDownloadFile.Value;
        info.l_id = lid;
        pdBLL.Insert(info);
        //由此開始加入ProductImage資料表
        ProductInfo pdinfos = pdBLL.GetLastProduct();
        InsertProductImage(pdinfos.p_id);
        //由此開始加入ProductSubFormat資料表
        InsertProductSubFormat(pdinfos.p_id);
        //由此開始加入ProductDownload資料表        
        InsertProductDownload(pdinfos.p_id);
        SessionClear();
        Response.Redirect("List.aspx?header=" + Getmessage("30009"));
    }
    protected void SessionClear()
    {
        Session.Remove("pdinfo");
        Session.Remove("pdimginfo");
    }
    private void InsertProductDownload(int ProductID)
    {
        for (int i = 0; i < rpDownload.Items.Count; i++)
        {
            HyperLink hyPath = (HyperLink)rpDownload.Items[i].FindControl("hytempPath");            
            System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath(hyPath.NavigateUrl));
            if (file.Exists)
            {
                file.CopyTo(Server.MapPath(Tools.GetAppSettings("ProductDLTruePath") + hyPath.Text));
            }
            ProductDownloadInfo pddInfo = new ProductDownloadInfo();
            pddInfo.p_id = ProductID;
            pddInfo.pd_name = hyPath.Text;
            pddInfo.pd_type = hyPath.Text;
            pddInfo.pd_value = "";
            pddInfo.pd_createdate = DateTime.Now;
            pddBLL.Insert(pddInfo);            
        }
    }
    private void InsertProductSubFormat(int ProductID)
    {
        ProductSubFormatInfo info = new ProductSubFormatInfo();
        //讀取ItemDataBound
        for (int i = 0; i < rpFormat.Items.Count; i++)
        {
            CheckBox ckbox = (CheckBox)rpFormat.Items[i].FindControl("ckFormat");            
            Label lbtxtFormatName = (Label)rpFormat.Items[i].FindControl("lbFormat");
            TextBox txtFormatValue = (TextBox)rpFormat.Items[i].FindControl("txtFormatValue");
            TextBox txtSorting = (TextBox)rpFormat.Items[i].FindControl("txtSorting");
            info.p_id = ProductID;
            info.psf_name = lbtxtFormatName.Text;
            info.psf_value = txtFormatValue.Text;
            info.psf_sorting = Tools.TryParseMethod(txtSorting.Text); //必須驗證
            if (pdsFMBLL.Insert(info) > 0)
            {
                ShowMessage("新增規格成功");
            }
        }            
    }
    protected void btNewFormat_Click(object sender, EventArgs e)
    {
        if (txtNewFormat.Text == "")
        {
            //this.Page.Controls.Add(Tools.Tomsg("請輸入規格名稱"));
            ShowMessage("請輸入規格名稱");
            return;
        }
        ProductTempFormatInfo info = new ProductTempFormatInfo();
        info.pc_id = Tools.TryParseMethod(ddlCategory.SelectedValue);
        info.pf_name = txtNewFormat.Text;
        info.pf_sorting = pdtFMBLL.GetCategorySortingDesc(info.pc_id);
        //寫入TempFormat 名稱、排序、類別
        pdtFMBLL.Insert(info);
        //再提出給予Repeater
        rpFormat.DataSource = pdtFMBLL.GetallWithCategory(info.pc_id);
        rpFormat.DataBind();
    }
    protected void btFile_Click(object sender, EventArgs e)
    {
        //ProductFile產品檔案        
        if (fuFile.HasFile)
        {
            string filename = WebUtility.ChangeFileNameAsRandom(fuFile.FileName);
            string ServerFilename = WebUtility.MergePathAndFileName(filename, Tools.GetAppSettings("ProductDLTempPath"));
            fuFile.SaveAs(ServerFilename);
            if (Session["pdinfo"] == null)
            {
                pdDlInfos = new List<ProductDownloadInfo>();
            }
            else
            {
                pdDlInfos = (List<ProductDownloadInfo>)Session["pdinfo"];
            }
            ProductDownloadInfo info = new ProductDownloadInfo();
            info.pd_name = filename;
            pdDlInfos.Add(info);
            tfBLL.InsertTempFiles("product",Tools.GetAppSettings("ProductDLTempPath")+filename);
            Session["pdinfo"] = pdDlInfos;
            rpDownload.DataSource = pdDlInfos;
            rpDownload.DataBind();
        }
        else
        {
            this.ShowMessage(this.Getmessage("30011"));
        }
    }
    //儲存更新
    protected void btSave_Click(object sender, EventArgs e)
    { 
        for (int i = 0; i < rpFormat.Items.Count; i++)
        {
            Label lbformatID = (Label)rpFormat.Items[i].FindControl("lbFormatID");
            Label lbformat = (Label)rpFormat.Items[i].FindControl("lbFormat");
            TextBox txtFormatValue = (TextBox)rpFormat.Items[i].FindControl("txtFormatValue");
            TextBox txtSorting = (TextBox)rpFormat.Items[i].FindControl("txtSorting");
            ProductTempFormatInfo info = new ProductTempFormatInfo();
            info.pf_id = Tools.TryParseMethod(lbformatID.Text);
            info.pc_id = Tools.TryParseMethod(ddlCategory.SelectedValue);
            info.pf_name = lbformat.Text;
            info.pf_value = txtFormatValue.Text;
            info.pf_sorting = Tools.TryParseMethod(txtSorting.Text); //必須驗證
            pdtFMBLL.Update(info);
            ShowMessage("儲存規格成功");
        }
        rpFormat.DataSource = pdtFMBLL.GetallWithCategory(Tools.TryParseMethod(ddlCategory.SelectedValue));
        rpFormat.DataBind();
    }
    protected void btFormat_Click(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedValue == "0")
        {
            Page.Controls.Add(Tools.Tomsg("請選擇您拷貝的類別!"));
            return;
        }
        if (ddrFormat.SelectedValue == "0")
        {
            Page.Controls.Add(Tools.Tomsg("請選擇您拷貝的類別!"));
            return;
        }
        //讀取TempFormat資料表給予Repeater當Source
        IList<ProductTempFormatInfo> infos = pdtFMBLL.GetallWithCategory(Tools.TryParseMethod(ddrFormat.SelectedValue));
        //在拷貝的同時就寫入TempFormat成為新規格
        for (int i = 0; i < infos.Count; i++)
        {
            pdtFMBLL.Insert(infos[i]);               
        }
        //以Category類別值讀取TempFormat資料給予Repeater當Source
        rpFormat.DataSource = pdtFMBLL.GetallWithCategory(Tools.TryParseMethod(ddlCategory.SelectedValue));
        rpFormat.DataBind();
        ShowMessage("成功從" + ddrFormat.SelectedItem.Text + "拷貝到" + ddlCategory.SelectedItem.Text + "!");
    }
    protected void btImage_Click(object sender, EventArgs e)
    {            
            if (fuImage.HasFile)
            {
                //檔名切換            
               string imgFileName = WebUtility.ChangeFileNameAsRandom(fuImage.FileName);
                if (WebUtility.CheckImageExt(System.IO.Path.GetExtension(imgFileName)))
                {
                    //從Web.Config取得路徑
                    string serverFileName = WebUtility.MergePathAndFileName(imgFileName, Tools.GetAppSettings("ProductImageTempPath"));
                    fuImage.SaveAs(serverFileName);
                    if (Session["pdimginfo"] == null)
                    {
                        pdImgInfos = new List<ProductImageInfo>();
                    }
                    else
                    {
                        pdImgInfos = (List<ProductImageInfo>)Session["pdimginfo"];
                    }
                    ProductImageInfo info = new ProductImageInfo();
                    info.pi_image = imgFileName;
                    info.pi_imageName = imgFileName;
                    pdImgInfos.Add(info);
                    tfBLL.InsertTempFiles("product",Tools.GetAppSettings("ProductImageTempPath") + imgFileName);
                    Session["pdimginfo"]= pdImgInfos;  
                    rpImage.DataSource = pdImgInfos;
                    rpImage.DataBind();
                }
                else
                {
                    this.Page.Controls.Add(Tools.Tomsg("副檔名格式錯誤"));
                }
            }
        }
    //Download按鈕事件-刪除
    protected void rpDownload_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            if (Session["pdinfo"] != null)
            {
                pdDlInfos = (List<ProductDownloadInfo>)Session["pdinfo"];
                Label lb = (Label)e.Item.FindControl("lbDownloadID");
                foreach (ProductDownloadInfo pdDinfo in pdDlInfos)
                {
                    if (pdDinfo.pd_name.ToString() == lb.Text)
                    {
                        System.IO.File.Delete(Server.MapPath(Tools.GetAppSettings("ProductDLTempPath")+pdDinfo.pd_name));
                        pdDlInfos.Remove(pdDinfo);
                        Session["pdinfo"]=pdDlInfos;
                        rpDownload.DataSource=pdDlInfos;
                        rpDownload.DataBind();
                        Page.Controls.Add(Tools.Tomsg("刪除成功"));
                        return ;
                    }
                }
            }
        }
        if (e.CommandName == "Update")
        {
            if (Session["pdinfo"] != null)
            {
                pdDlInfos = (List<ProductDownloadInfo>)Session["pdinfo"];
                hfDownloadFile.Value = e.CommandArgument.ToString();
                Session["pdinfo"] = pdDlInfos;
                rpDownload.DataSource = pdDlInfos;
                rpDownload.DataBind();
                Page.Controls.Add(Tools.Tomsg("更新成功!"));
            }
        }
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
    //設定Repeater的主圖後控制項功能開關
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
    //設定Repeater的Delete與Update
    protected void rpImage_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            if (Session["pdimginfo"] != null)
            {
                pdImgInfos = (List<ProductImageInfo>)Session["pdimginfo"];
                Label lb = (Label)e.Item.FindControl("lbImageID");
                foreach (ProductImageInfo pdiInfo in pdImgInfos)
                {
                    if (pdiInfo.pi_image == lb.Text)
                    {
                        System.IO.File.Delete(Server.MapPath(Tools.GetAppSettings("ProductImageTempPath") + pdiInfo.pi_image));
                        pdImgInfos.Remove(pdiInfo);
                        Session["pdimginfo"] = pdImgInfos;
                        rpImage.DataSource = pdImgInfos;
                        rpImage.DataBind();
                        //一段Script視窗語法
                        //Page.Controls.Add(Tools.Tomsg("刪除成功!"));
                        ShowMessage("刪除成功！");
                        return;
                    }
                }
            }
        }
        if (e.CommandName == "Update")
        {
            if (Session["pdimginfo"] != null)
            {
                pdImgInfos = (List<ProductImageInfo>)Session["pdimginfo"];

                hfProductImage.Value = e.CommandArgument.ToString();
                Session["pdimginfo"] = pdImgInfos;
                rpImage.DataSource = pdImgInfos;
                rpImage.DataBind();
                Page.Controls.Add(Tools.Tomsg("更新成功!"));
            }
        }
    }
    //repeater刪除規格事件
    //動態上下排序事件寫於此
    protected void rpFormat_ItemCommand(object source, RepeaterCommandEventArgs e)
    {       
        Label lb = (Label)e.Item.FindControl("lbFormatID");
        Label lb2;
        Label lb3;
        int ClickNowKey = 0;
        int RdyChangeKey = 0;
        int ClickNowSort = 0;
        int RdyChangeSort = 0;
        if (e.CommandName == "Delete")
        {
            pdtFMBLL.Delete(int.Parse(lb.Text));
        }
        if (e.CommandName == "btnSortUp")
        {
            ClickNowKey = e.Item.ItemIndex;
            RdyChangeKey = e.Item.ItemIndex - 1;
            if (ClickNowKey > 0)
            {

                 lb2 = (Label)rpFormat.Items[ClickNowKey].FindControl("lbFormatID");
                 lb3 = (Label)rpFormat.Items[RdyChangeKey].FindControl("lbFormatID");
                ProductTempFormatInfo pdTFMClick = pdtFMBLL.GettempKey(int.Parse(lb2.Text));
                ProductTempFormatInfo pdTFMChange = pdtFMBLL.GettempKey(int.Parse(lb3.Text));
                ClickNowSort = pdTFMClick.pf_sorting;
                RdyChangeSort = pdTFMChange.pf_sorting;
                pdTFMClick.pf_sorting = RdyChangeSort;
                pdTFMChange.pf_sorting = ClickNowSort;
                pdtFMBLL.Update(pdTFMClick);
                pdtFMBLL.Update(pdTFMChange);
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
            if (ClickNowKey + 1 < rpFormat.Items.Count) //底部判斷錯誤
            {    
                lb2 = (Label)rpFormat.Items[ClickNowKey].FindControl("lbFormatID");
                lb3 = (Label)rpFormat.Items[RdyChangeKey].FindControl("lbFormatID");
                ProductTempFormatInfo pdTFMClick = pdtFMBLL.GettempKey(int.Parse(lb2.Text));
                ProductTempFormatInfo pdTFMChange = pdtFMBLL.GettempKey(int.Parse(lb3.Text));
                ClickNowSort = pdTFMClick.pf_sorting;
                RdyChangeSort = pdTFMChange.pf_sorting;
                pdTFMClick.pf_sorting = RdyChangeSort;
                pdTFMChange.pf_sorting = ClickNowSort;
                pdtFMBLL.Update(pdTFMClick);
                pdtFMBLL.Update(pdTFMChange);
            }
            else
            {
                ShowMessage("此項目排序已是最底");
            }
        }
        rpFormat.DataSource = pdtFMBLL.GetallWithCategory(Tools.TryParseMethod(ddlCategory.SelectedValue));
        rpFormat.DataBind();
    }
    public void InsertDropdown()
    {
        ddlCategory.DataSource = pcBLL.getallSortData(0);
        ddlCategory.DataTextField = "pc_name";
        ddlCategory.DataValueField = "pc_id";
        ddlCategory.DataBind();
        if (int.Parse(UserInfoConfig.GetUserConfig("HierarchyProductCategory")) != 0)
        {
            ddlCategory.Items.Insert(0, new ListItem("==請選擇類別==", "0"));
        }
    }
    private void InsertProductImage(int ProductID)
    {        
        //筆數
        for (int i = 0; i < rpImage.Items.Count; i++)
        {
            ProductImageInfo pdiInfo = new ProductImageInfo();
            Image lbtxtFormatName = (Image)rpImage.Items[i].FindControl("Image1");
            if (lbtxtFormatName != null)
            {
                //由此寫入真實檔原圖轉移程序
                if (System.IO.File.Exists(Server.MapPath(Tools.GetAppSettings("ProductImageTempPath") + lbtxtFormatName.AlternateText)))
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath(Tools.GetAppSettings("ProductImageTempPath") + lbtxtFormatName.AlternateText));
                    file.CopyTo(Server.MapPath(Tools.GetAppSettings("ProductImageTruePath") + lbtxtFormatName.AlternateText));                                        
                }
                pdiInfo.p_id = ProductID;
                pdiInfo.pi_image = lbtxtFormatName.AlternateText;
                pdiInfo.pi_imageName = lbtxtFormatName.AlternateText;
            }
            pdimgBLL.Insert(pdiInfo);            
        }
    }  
    protected void ddrFormat_DataBound(object sender, EventArgs e)
    {
        ddrFormat.Items.Insert(0, new ListItem("==請選擇類別==", "0"));
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFormat();
    }

}
