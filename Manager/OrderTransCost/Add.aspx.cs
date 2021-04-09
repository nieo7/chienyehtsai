using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class Manager_OrderTransCost_Add : BasePage
{
    OrderTransCostBLL otcBLL = new OrderTransCostBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
    }
    private void InitPage()
    {
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("OrderTransCost", "phname"));
        phcost.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("OrderTransCost", "phcost"));
        phdetail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("OrderTransCost", "phdetail"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("OrderTransCost", "phshow"));
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        OrderTransCostInfo info = new OrderTransCostInfo();
        info.otc_name = txtName.Text;
        info.otc_cost = Tools.TryParseMethod(txtPrice.Text);
        info.otc_detail = Ckeditorl1.Text;
        info.otc_show = bool.Parse(rbShow.SelectedValue);
        if (otcBLL.Insert(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30009"));
        }
    }
}