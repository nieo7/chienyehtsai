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

public partial class Manager_Admin_SystemConfigList : BasePage
{
    SystemConfigBLL scBLL = new SystemConfigBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Check_Power("17", "76", true);
            InsertDropdown();
        }
    }
    protected void InsertDropdown()
    {
        ddrCategory.DataSource = scBLL.GetDataSelectDistinctOrderClass();
        ddrCategory.DataTextField = "sc_Class";
        ddrCategory.DataValueField = "sc_Class";
        ddrCategory.DataBind();
        ddrCategory.Items.Insert(0, new ListItem("全部顯示", "0"));
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("sc_Name", txtKeyWord.Text, ddrCategory.SelectedValue, "sc_Class", ""));
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
        int checkcount = 0;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            HiddenField hi_Id = (HiddenField)GridView1.Rows[i].FindControl("HiddenField_Id");
            CheckBox chkvalue = (CheckBox)GridView1.Rows[i].FindControl("chk_value");
            TextBox TextBox_Desc = (TextBox)GridView1.Rows[i].FindControl("TextBox_Desc");
            SystemConfigInfo info = scBLL.getAll(int.Parse(hi_Id.Value));
            if (info.sc_Id != 0)
            {
                info.sc_Admin = uid;
                info.sc_Desc = TextBox_Desc.Text;
                info.sc_Value = chkvalue.Checked.ToString().ToLower();
                if (scBLL.Update(info) > 0)
                    checkcount++;
            }
        }
        ShowMessage("資料 "+checkcount+" 筆: 修改成功");
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("sc_Name", txtKeyWord.Text, ddrCategory.SelectedValue, "sc_Class", ""));
    }
}
