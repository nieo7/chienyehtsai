using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Manager_BannerCustomer_Edit : BasePage
{
    BannerCustomerBLL bcsBLL = new BannerCustomerBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            Bind();
        }
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
    protected void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) != 0)
            {
                BannerCustomerInfo info=bcsBLL.GetDataById(id);
                txtcompanyname.Text = info.bcs_company_name;
                txtcompanytype.Text = info.bcs_company_type;
                txtCompanyPhone.Text = info.bcs_company_phone;
                txtCompanyfax.Text = info.bcs_fax;
                txtContact.Text = info.bcs_note;
                rbSex.SelectedValue = info.bcs_sex;
                txtMail.Text = info.bcs_mail;
                txtname.Text = info.bcs_name;
                txtPhone.Text = info.bcs_phone;
                address1.City = info.bcs_city;
                address1.Area = info.bcs_area;
                address1.CodeId = info.bcs_code;
                address1.Address = info.bcs_address;
                txtCreatedate.Text = info.bcs_ts.ToString("yyyy/MM/dd");
                txtEditdate.Text = info.bcs_editdate.ToString("yyyy/MM/dd");
            }
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BannerCustomerInfo info = bcsBLL.GetDataById(id);
        info.bcs_company_name = txtcompanyname.Text;
        info.bcs_company_type = txtcompanytype.Text;
        info.bcs_company_phone = txtCompanyPhone.Text;
        info.bcs_fax = txtCompanyfax.Text;
        info.bcs_name = txtname.Text;
        info.bcs_mail = txtMail.Text;
        info.bcs_phone = txtPhone.Text;
        info.bcs_sex = rbSex.SelectedValue;
        info.bcs_note = txtContact.Text;
        info.bcs_editdate = DateTime.Now;
        if (bcsBLL.Update(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30014"));
        }
    }
}