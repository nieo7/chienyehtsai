using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Manager_BannerCustomer_List : BasePage
{
    BannerCustomerBLL bcsBLL = new BannerCustomerBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
    }
    private void InitPage()
    {
        gridView.Columns[2].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phcompanyname"));
        gridView.Columns[3].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phcompanytype"));
        gridView.Columns[4].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phcompanyphone"));
        gridView.Columns[5].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phname"));
        gridView.Columns[6].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phsex"));
        gridView.Columns[7].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phphone"));
        gridView.Columns[8].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phmail"));
        gridView.Columns[9].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerCustomer", "phfax"));        
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        int delcount = 0;
        for (int i = 0; i < gridView.Rows.Count; i++)
        {
            CheckBox chkSel = (CheckBox)gridView.Rows[i].Cells[0].FindControl("chkSelect");
            if (chkSel.Checked == true)
            {

                if (bcsBLL.Delete((int)gridView.DataKeys[i].Value) > 0)
                {
                    delcount++;
                }
            }
        }
        if (delcount != 0)
        {
            gridView.DataBind();
            ShowMessage("刪除" + delcount + " 筆資料成功");
        }
        else
        {
            ShowMessage("請至少選擇一筆資料");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (rbCompanyName.Checked)
        {
            ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("bcs_company_name", txtKeyWord.Text, ""));
        }
        else if (rbName.Checked)
        {
            ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("bcs_name", txtKeyWord.Text, ""));
        }
        else
        {
            ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("bcs_key", txtKeyWord.Text, ""));
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
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
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        if (((CheckBox)sender).Checked == true)
        {
            foreach (GridViewRow row in gridView.Rows)
            {
                ((CheckBox)row.FindControl("chkSelect")).Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow row in gridView.Rows)
            {
                ((CheckBox)row.FindControl("chkSelect")).Checked = false;
            }
        }
    }
    protected void Delete(object sender, CommandEventArgs e)
    {
        if (bcsBLL.Delete(int.Parse(e.CommandArgument.ToString())) > 0)
        {
            ShowMessage("刪除成功");
        }
        else
        {
            ShowMessage("Banner資料中有其相對應之資料,不予刪除");
        }
        gridView.DataBind();        
    }
    protected void GoToPage_TextChanged(object sender, EventArgs e)
    {
        TextBox txtGoToPage = (TextBox)sender;
        int pageNumber;
        if (int.TryParse(txtGoToPage.Text.Trim(), out pageNumber) && pageNumber > 0 && pageNumber <= this.gridView.PageCount)
        {
            this.gridView.PageIndex = pageNumber - 1;
        }
        else
        {
            this.gridView.PageIndex = 0;
        }
    }
    protected void GvCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dropDown = (DropDownList)sender;
        this.gridView.PageSize = int.Parse(dropDown.SelectedValue);
    }
}