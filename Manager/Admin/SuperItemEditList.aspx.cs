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
using Model;

public partial class Manager_Admin_SuperAdminItemEditList : BasePage
{
    AdminBLL adBLl = new AdminBLL();
    AdminItem1BLL ai1BLL = new AdminItem1BLL();
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            //Check_Power(999, 999, true);
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
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

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
        RadioButtonList rdList = (RadioButtonList)e.Row.FindControl("raIsVisable");
        Label lb_fi_no1 = (Label)e.Row.FindControl("lbfiNo1");
        try
        {
            rdList.SelectedValue = ai1BLL.getAll(int.Parse(lb_fi_no1.Text)).ai1_visible.ToString();
        }
        catch { }
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            bool isOk = false;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                RadioButtonList rdList = (RadioButtonList)GridView1.Rows[i].FindControl("raIsVisable");
                TextBox txt_name = (TextBox)GridView1.Rows[i].FindControl("txtFi_name1");
                TextBox txt_nickname = (TextBox)GridView1.Rows[i].FindControl("txtFi_nickname");
                TextBox txt_sort = (TextBox)GridView1.Rows[i].FindControl("txtFi_sort1");
                Label lb_fi_no1 = (Label)GridView1.Rows[i].FindControl("lbfiNo1");
                AdminItem1Info info = ai1BLL.getAll(int.Parse(lb_fi_no1.Text));
                info.ai1_visible = bool.Parse(rdList.SelectedValue);
                info.ai1_name = txt_name.Text;
                info.ai1_nickname = txt_nickname.Text;
                info.ai1_sort = int.Parse(txt_sort.Text);
                if (ai1BLL.Update(info.ai1_id, info) > 0)
                    isOk = true;
            }
            if (isOk == true)
                Response.Redirect("SuperItemEditList.aspx?header=修改成功!", true);
            else
                Response.Redirect("SuperItemEditList.aspx?header=修改失敗!", true);
        }
        catch (Exception ex)
        {
            Response.Redirect("SuperItemEditList.aspx?header=" + ex.Message.ToString(), true);
        }

    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        for(int i =0;i<GridView1.Rows.Count;i++)
        {
            RadioButtonList rdList = (RadioButtonList)GridView1.Rows[i].FindControl("raIsVisable");
            if (rdList != null)
                rdList.SelectedValue = "True";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            RadioButtonList rdList = (RadioButtonList)GridView1.Rows[i].FindControl("raIsVisable");
            if (rdList != null)
                rdList.SelectedValue = "False";
        }
    }
}
