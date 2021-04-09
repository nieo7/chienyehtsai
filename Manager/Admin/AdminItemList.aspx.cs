using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using BLL;

public partial class Manager_Admin_ItemList : BasePage
{
    AdminBLL adBLL = new AdminBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlHead header = (HtmlHead)this.Master.FindControl("head1");
        header.Title = UserInfoConfig.GetUserConfig("title");
        if (!IsPostBack)
        {
            //Check_Power(17, 75, true);
            string headers = Request["header"];
            if (headers != null && headers.Trim() != "")
            {
                message.Visible = true;
                message.InnerHtml = "&nbsp;文章：<b style='color:red;'>" + headers.Trim() + "&nbsp;&nbsp;</b>修改已完成!";
            }
        } 
    }
    protected void GvCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dropDown = (DropDownList)sender;
        this.GridView1.PageSize = int.Parse(dropDown.SelectedValue);
    }
    protected void GoToPage_TextChanged(object sender, EventArgs e)
    {
        TextBox txtGoToPage = (TextBox)sender;

        int pageNumber;
        if (int.TryParse(txtGoToPage.Text.Trim(), out pageNumber) && pageNumber > 0 && pageNumber <= this.GridView1.PageCount)
        {
            this.GridView1.PageIndex = pageNumber - 1;
        }
        else
        {
            this.GridView1.PageIndex = 0;
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
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Delete(object sender, CommandEventArgs e)
    {
        adBLL.Delete(int.Parse(e.CommandArgument.ToString()));
        GridView1.DataBind();
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

        if (e.Row.RowType == DataControlRowType.Pager)
        {
            Label lblTotalNumberOfPages = (Label)e.Row.FindControl("lblTotalNumberOfPages");
            lblTotalNumberOfPages.Text = gridView.PageCount.ToString();

            TextBox txtGoToPage = (TextBox)e.Row.FindControl("txtGoToPage");
            txtGoToPage.Text = (gridView.PageIndex + 1).ToString();

            DropDownList ddlPageSize = (DropDownList)e.Row.FindControl("ddlPageSize");
            ddlPageSize.SelectedValue = gridView.PageSize.ToString();
        }
    }
    protected void btnSetPower_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminItemEditList.aspx?id=" + Request.QueryString["id"].ToString(), true);        
    }
}
