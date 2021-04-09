using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class Manager_Order_View : System.Web.UI.Page
{
    OrderBLL oBLL = new OrderBLL();
    OrderDetailBLL odBLL = new OrderDetailBLL();
    OrderTransCostBLL otcBLL = new OrderTransCostBLL();
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
        phnumber.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phnumber"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phname"));
        phmail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phmail"));
        phaddress.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phaddress"));
        phphone1.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phphone1"));
        phphone2.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phphone2"));
        phcheckread.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phcheckread"));
        phcheckpay.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phcheckpay"));
        phcheckout.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phcheckout"));
        phsubtotal.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phsubtotal"));
        phtranscost.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phtranscost"));
        phgrandtotal.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phgrandtotal"));
        phcreatedate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phcreatedate"));
        phdetail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phdetail"));
        phshowproduct.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phshowproduct"));
    }
    protected void Bind()
    {
        OrderInfo info = oBLL.GetOrderById(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
        lbNumber.Text = info.o_number;
        lbTitle.Text = info.o_name;
        lbEmail.Text = info.o_mail;
        lbAddress.Text =info.o_city+info.o_zipCode+info.o_area+info.o_address;
        lbPhone.Text = info.o_phone1;
        lbPhone2.Text = info.o_phone2;
        if (info.o_check_Read)
        {
            lbRead.Text = "已閱讀";
        }
        else
        {
            lbRead.Text = "尚未閱讀";
        }
        rbCheckPay.SelectedValue = info.o_check_Pay.ToString();
        rbCheckOut.SelectedValue = info.o_check_Out.ToString();
        lbSubTotal.Text = info.o_totalPrice.ToString();
        lbTransCost.Text = otcBLL.GetDataByIdForCost(info.otc_id).ToString();
        lbGrandTotal.Text = (int.Parse(lbSubTotal.Text) + int.Parse(lbTransCost.Text)).ToString();
        lbCreateDate.Text = info.o_ts.ToString();
        litDetail.Text = info.o_detail;
        GridView1.DataSource = odBLL.GetOrderDetailByOid(info.o_id);        
        GridView1.DataBind();
    }
}