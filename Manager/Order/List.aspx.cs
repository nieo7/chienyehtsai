using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Web.UI.HtmlControls;
public partial class Manager_Order_List : BasePage
{
    OrderBLL oBLL = new OrderBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlHead header = (HtmlHead)this.Master.FindControl("head1");
        header.Title = UserInfoConfig.GetUserConfig("title");
        InitPage();
    }
    protected void InitPage()
    {
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phname"));
        phnumber.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phnumber"));
        GridView1.Columns[2].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phnumber"));
        GridView1.Columns[3].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phname"));
        GridView1.Columns[4].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phcheckpay"));
        GridView1.Columns[5].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phcheckout"));
        GridView1.Columns[6].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phcheckread"));
        GridView1.Columns[7].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Order", "phcreatedate"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (rbProductName.Checked)
        {
            ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("o_name", txtKeyWord.Text, ""));
        }
        else
        {
            ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("o_number", txtKeyWord.Text, ""));
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridView gridView = (GridView)sender;
        if (gridView.SortExpression.Length > 0)
        {
            int cellIndex = -1;
            foreach (DataControlField field in gridView.Columns)
            {
                if (field.SortExpression == gridView.SortExpression)
                {
                    cellIndex = gridView.Columns.IndexOf(field);
                    break;
                }
            }

            if (cellIndex > -1)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    //  this is a header row,
                    //  set the sort style
                    e.Row.Cells[cellIndex].CssClass = gridView.SortDirection == SortDirection.Ascending ? "sortascheaderstyle" : "sortdescheaderstyle";
                }
                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //  this is an alternating row
                    e.Row.Cells[cellIndex].CssClass = e.Row.RowIndex % 2 == 0 ? "sortalternatingrowstyle" : "sortrowstyle";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbRead = (Label)e.Row.FindControl("lbIsRead");
            lbRead.Text = lbRead.Text == "True" ? "O" : "<b>X</b>";
            Label lbPay = (Label)e.Row.FindControl("lbIsPay");
            lbPay.Text = lbPay.Text == "True" ? "O" : "<b>X</b>";
            Label lbSend = (Label)e.Row.FindControl("lbIsSend");
            lbSend.Text = lbSend.Text == "True" ? "O" : "<b>X</b>";
        }
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            Label lblTotalNumberOfPages = (Label)e.Row.FindControl("lblTotalNumberOfPages");
            lblTotalNumberOfPages.Text = GridView1.PageCount.ToString();

            TextBox txtGoToPage = (TextBox)e.Row.FindControl("txtGoToPage");
            txtGoToPage.Text = (GridView1.PageIndex + 1).ToString();

            DropDownList ddlPageSize = (DropDownList)e.Row.FindControl("ddlPageSize");
            ddlPageSize.SelectedValue = GridView1.PageSize.ToString();
        }
    }
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        if (((CheckBox)sender).Checked == true)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                ((CheckBox)row.FindControl("chkSelect")).Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                ((CheckBox)row.FindControl("chkSelect")).Checked = false;
            }
        }
    }
    protected void Delete(object sender, CommandEventArgs e)
    {
        oBLL.Delete(int.Parse(e.CommandArgument.ToString()));
        GridView1.DataBind();
        ShowMessage("刪除成功");
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
        GridView1.DataBind();
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
    protected void btnDel_Click(object sender, EventArgs e)
    {
        int delcount = 0;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox chkSel = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("chkSelect");
            if (chkSel.Checked == true)
            {
                delcount++;
                oBLL.Delete((int)GridView1.DataKeys[i].Value);
            }
        }
        if (delcount != 0)
        {
            this.ShowMessage(this.Getmessage("30014") + " 刪除數:" + delcount);
        }
        else
        {
            this.ShowMessage(this.Getmessage("30013") + " 請至少選擇一筆資料");
        }
        GridView1.DataBind();
    }
}