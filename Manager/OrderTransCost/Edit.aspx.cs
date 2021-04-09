using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Manager_OrderTransCost_Edit :BasePage
{
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
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("OrderTransCost", "phname"));
        phcost.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("OrderTransCost", "phcost"));
        phdetail.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("OrderTransCost", "phdetail"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("OrderTransCost", "phshow"));
    }
    protected void Bind()
    {
        if (Request.QueryString["id"] != null)
        {
            if (Tools.TryParseMethod(id.ToString()) !=0)
            {
                OrderTransCostInfo info = otcBLL.GetDataById(Tools.TryParseMethod(Request.QueryString["id"].ToString()));
                txtName.Text = info.otc_name;
                txtPrice.Text = info.otc_cost.ToString();
                Ckeditorl1.Text = info.otc_detail;
                rbShow.SelectedValue = info.otc_show.ToString();
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        OrderTransCostInfo info = otcBLL.GetDataById(Tools.TryParseMethod(Request.QueryString["id"].ToString()));
        info.otc_name = txtName.Text;
        info.otc_cost = Tools.TryParseMethod(txtPrice.Text);
        info.otc_detail = Ckeditorl1.Text;
        info.otc_show = bool.Parse(rbShow.SelectedValue);
        if (otcBLL.Update(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30014"));
        }
    }
}