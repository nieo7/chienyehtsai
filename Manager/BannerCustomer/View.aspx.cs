using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Manager_BannerCustomer_View : BasePage
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
        phnumber.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phnumber"));
    }
    protected void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) != 0)
            {
                BannerCustomerInfo info = bcsBLL.GetDataById(id);
                lbNumber.Text = info.bcs_key;
                lbCompanyname.Text = info.bcs_company_name;
                lbType.Text = info.bcs_company_type;
                lbCompanyPhone.Text = info.bcs_company_phone;
                lbfax.Text = info.bcs_fax;
                lbname.Text = info.bcs_name;
                lbSex.Text = info.bcs_sex;
                lbPhone.Text = info.bcs_phone;
                lbMail.Text = info.bcs_mail;
                lbAddress.Text = info.bcs_city + info.bcs_code + info.bcs_area + info.bcs_address;
                litNote.Text = info.bcs_note;
                lbts.Text = info.bcs_ts.ToString("yyyy/MM/dd hh:mm");
                lbEdit.Text = info.bcs_editdate.ToString("yyyy/MM/dd hh:mm");
            }
        }
    }
}