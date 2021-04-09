using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Manager_OrderTransCost_View : BasePage
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
            if (Tools.TryParseMethod(Request.QueryString["id"].ToString()) != 0)
            {
                OrderTransCostInfo info = otcBLL.GetDataById(Tools.TryParseMethod(Request.QueryString["id"].ToString()));
                lbName.Text = info.otc_name;
                lbPrice.Text = info.otc_cost.ToString();
                litDetail.Text = info.otc_detail;
                rbShow.SelectedValue = info.otc_show.ToString();
            }
        }
    }
}