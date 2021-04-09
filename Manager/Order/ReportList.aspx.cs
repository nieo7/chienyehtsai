using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Web.UI.HtmlControls;
using System.Data;
public partial class Manager_Order_ReportList : BasePage
{
    OrderBLL oBLL = new OrderBLL();
    OrderTransCostBLL otcBLL = new OrderTransCostBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlHead header = (HtmlHead)this.Master.FindControl("head1");
        header.Title = UserInfoConfig.GetUserConfig("title");
        if (!IsPostBack)
        {
            ReportBind(DateTime.MinValue, DateTime.Now);//上方區塊的Bind();
        }
        txtStartDate.Attributes.Add("ReadOnly", "ReadOnly");
        txtEndDate.Attributes.Add("ReadOnly", "ReadOnly");
    }
    protected void ReportBind(DateTime StartTime, DateTime EndTime)
    {
        lbTimeMessage.Text = "目前報表查詢日期為:" + StartTime.ToString("yyyy/MM/dd") + "~" + EndTime.ToString("yyyy/MM/dd");
        DataTable DtAll = oBLL.GetDateByThreadDate(StartTime, EndTime);
        DataTable DtPay = oBLL.GetDataByThreadDateAndPay(StartTime, EndTime);
        DataTable DtOut = oBLL.GetDataByThreadTimeAndOut(StartTime, EndTime);
        ReportBindControl(DtAll, lbCount1, lbSubTotal1, lbGrandTotal1);
        ReportBindControl(DtPay, lbCount5, lbSubTotal5, lbGrandTotal5);
        ReportBindControl(DtOut, lbCount6, lbSubTotal6, lbGrandTotal6);
    }
    protected void ReportBindControl(DataTable DT, Label lbCount, Label lbSubTotal, Label lbGrandTotal)
    {
        int OrderSubTotal = 0;
        int OrderGrandTotal = 0;
        for (int i = 0; i < DT.Rows.Count; i++)
        {
            OrderSubTotal += int.Parse(DT.Rows[i]["o_totalPrice"].ToString());
            OrderGrandTotal += otcBLL.GetDataByIdForCost(int.Parse(DT.Rows[i]["otc_id"].ToString()));
        }
        lbCount.Text = DT.Rows.Count.ToString();
        lbSubTotal.Text = OrderSubTotal.ToString();
        lbGrandTotal.Text = (OrderSubTotal + OrderGrandTotal).ToString();
    }
    protected void rbAll_CheckedChanged(object sender, EventArgs e)
    {
        divMonth.Visible = false;
        divYear.Visible = false;
        divDate.Visible = false;
    }
    protected void rbMonth_CheckedChanged(object sender, EventArgs e)
    {
        divMonth.Visible = true;
        divYear.Visible = false;
        divDate.Visible = false;
        for (int i = DateTime.Now.AddYears(-10).Year; i < DateTime.Now.AddYears(10).Year; i++)
        {
            ddrMonthYear.Items.Add(new ListItem(i.ToString() + "年", i.ToString()));
        }
        for (int i = 1; i <= 12; i++)
        {
            ddrMonthMonth.Items.Add(new ListItem(i.ToString() + "月", i.ToString()));
        }
        ddrMonthYear.SelectedValue = DateTime.Now.Year.ToString();
        ddrMonthMonth.SelectedValue = DateTime.Now.Month.ToString();
    }
    protected void rbYear_CheckedChanged(object sender, EventArgs e)
    {
        divMonth.Visible = false;
        divYear.Visible = true;
        divDate.Visible = false;
        for (int i = DateTime.Now.AddYears(-10).Year; i < DateTime.Now.AddYears(10).Year; i++)
        {
            ddrYear.Items.Add(new ListItem(i.ToString() + "年", i.ToString()));
        }
    }
    protected void rbTimeThread_CheckedChanged(object sender, EventArgs e)
    {
        divMonth.Visible = false;
        divYear.Visible = false;
        divDate.Visible = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime date1 = DateTime.Now, date2 = DateTime.Now;
        if (rbAll.Checked)
        {
            date1 = DateTime.MinValue;
            date2 = DateTime.Now.AddDays(1);
        }
        else if (rbMonth.Checked)
        {
            date1 = DateTime.Parse(ddrMonthYear.SelectedValue + "/" + ddrMonthMonth.SelectedValue + "/1");
            date2 = DateTime.Parse(ddrMonthYear.SelectedValue + "/" + ddrMonthMonth.SelectedValue + "/" + DateTime.DaysInMonth(int.Parse(ddrMonthYear.SelectedValue),int.Parse(ddrMonthMonth.SelectedValue)));
            date2 = date2.AddDays(1);
        }
        else if (rbYear.Checked)
        {
            date1 = DateTime.Parse(ddrYear.SelectedValue + "/1/1");
            date2 = DateTime.Parse(ddrYear.SelectedValue + "/12/31");
        }
        else
        {
            date1 = DateTime.Parse(txtStartDate.Text);
            date2 = DateTime.Parse(txtEndDate.Text);
        }
        ReportBind(date1, date2);
        ObjectDataSource1.FilterExpression = "o_ts >=#" + date1.ToString("yyyy/MM/dd") + "# AND o_ts <=#" + date2.ToString("yyyy/MM/dd") + "#";
        ObjectDataSource1.DataBind();
        GridView1.DataBind();        
    }
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hfTransCost = (HiddenField)e.Row.FindControl("hfTranCost");
            Literal litGrandTotal = (Literal)e.Row.FindControl("litGrandTotal");
            litGrandTotal.Text = (int.Parse(hfTransCost.Value) + int.Parse(litGrandTotal.Text)).ToString();

            Label lbPay = (Label)e.Row.FindControl("lbPay");
            lbPay.Text = lbPay.Text == "True" ? "O" : "<b>X</b>";
            Label lbSend = (Label)e.Row.FindControl("lbSendOut");
            lbSend.Text = lbSend.Text == "True" ? "O" : "<b>X</b>";
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GvCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dropdown = (DropDownList)sender;
        this.GridView1.PageSize = int.Parse(dropdown.SelectedValue);
        if (GridView1.PageCount == 0)
        {
            Response.Redirect(Request.Url.ToString());
        }
    }
    protected void GoToPage_TextChanged(object sender, EventArgs e)
    {
        TextBox txtgotopage = (TextBox)sender;
        int pageNumber;
        if (int.TryParse(txtgotopage.Text.Trim(), out pageNumber) && pageNumber > 0 && pageNumber <= this.GridView1.PageCount)
        {
            this.GridView1.PageIndex = pageNumber - 1;
        }
        else
        {
            this.GridView1.PageIndex = GridView1.PageCount - 1;
            ShowMessage("超出分頁最大值");
        }
    }
}