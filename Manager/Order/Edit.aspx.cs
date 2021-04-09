using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Web.UI.HtmlControls;
public partial class Manager_Order_Edit : BasePage
{
    OrderBLL oBLL = new OrderBLL();
    OrderDetailBLL odBLL = new OrderDetailBLL();
    OrderTransCostBLL otcBLL = new OrderTransCostBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            ControlStatus();
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
    public void ControlStatus()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) > 0)
            {
                OrderInfo info = oBLL.GetOrderById(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
                lbNumber.Text = info.o_number;
                txtName.Text = info.o_name;
                txtEmail.Text = info.o_mail;
                address1.Area = info.o_area;
                address1.City = info.o_city;
                address1.Address = info.o_address;
                address1.CodeId = info.o_zipCode;
                txtPhone.Text = info.o_phone1;
                txtPhone2.Text = info.o_phone2;
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
                lbPS.Text = info.o_detail;
                GridView1.DataSource = odBLL.GetOrderDetailByOid(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
                GridView1.DataBind();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        OrderInfo info = oBLL.GetOrderById(Tools.GetInt32SafeFromQueryString(this.Page, "id", 0));
        info.o_name = txtName.Text;
        info.o_mail = txtEmail.Text;
        info.o_area = address1.Area;
        info.o_city = address1.City;
        info.o_address = address1.Address;
        info.o_zipCode = address1.CodeId;
        info.o_phone1 = txtPhone.Text;
        info.o_phone2 = txtPhone2.Text;
        info.o_check_Pay = bool.Parse(rbCheckPay.SelectedValue);
        info.o_check_Read = true;
        info.o_check_Out = bool.Parse(rbCheckOut.SelectedValue);
        info.o_editDate = Convert.ToDateTime(DateTime.Now);
        if (oBLL.Update(info) > 0)
        {
            Response.Redirect("List.aspx?header=訂單: " + info.o_number + " 更新成功");
        }
        ShowMessage(Getmessage("30015"));
    }
}