using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class Manager_BannerCustomer_Add : BasePage
{
    BannerCustomerBLL bcsBLL = new BannerCustomerBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
    }
    private void InitPage()
    {
        phcompanyname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phcompanyname"));
        phcompanytype.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phcompanytype"));
        phcompanyphone.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phcompanyphone"));
        phfax.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phfax"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phname"));
        phsex.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phsex"));
        phphone.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phphone"));
        phmail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phmail"));
        phaddress.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phaddress"));
        phnote.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phnote"));        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BannerCustomerInfo info = new BannerCustomerInfo();
        info.bcs_company_name = txtcompanyname.Text;
        info.bcs_company_type = txtcompanytype.Text;
        info.bcs_company_phone = txtCompanyPhone.Text;
        info.bcs_name = txtname.Text;
        info.bcs_sex = rbSex.SelectedValue;
        info.bcs_phone = txtPhone.Text;
        info.bcs_mail = txtMail.Text;
        info.bcs_note = txtContact.Text;
        info.bcs_fax = txtCompanyfax.Text;
        info.bcs_city = address1.City;
        info.bcs_area = address1.Area;
        info.bcs_code = address1.CodeId;
        info.bcs_address = address1.Address;
        info.bcs_key = "BC" + DateTime.Now.ToString("yyyyMMddhhmm") + string.Format("{00000:00000}", bcsBLL.GetAll().Count + 1);
        info.bcs_ts = DateTime.Now;
        info.bcs_editdate = DateTime.Now;
        if (bcsBLL.Insert(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30009"));
        }
    }
    protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtContact.Text.Length < 300)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;

            ShowMessage("請輸入低於300字以內");
        }
    }
}