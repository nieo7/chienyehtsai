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

public partial class Manager_News_List : BasePage
{
    BannerBLL bBLL = new BannerBLL();
    BannerCategoryBLL bcBLL = new BannerCategoryBLL();
    BannerCustomerBLL bcsBLL = new BannerCustomerBLL();
    BannerLocationBLL blBLL = new BannerLocationBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            InsertDropdown();
        }        
    }
    private void InitPage()
    {
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phcategory"));
        phcustomer.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phcustomer"));
        phlocation.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phlocation"));
        GridView1.Columns[2].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phimg"));
        GridView1.Columns[3].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phtitle"));
        GridView1.Columns[4].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phprice"));
        GridView1.Columns[5].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phstartdate"));
        GridView1.Columns[6].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Banner", "phenddate"));
    }
    protected void InsertDropdown()
    {
        ddrBannerCategory.DataSource = bcBLL.getAll();
        ddrBannerCategory.DataTextField = "bc_title";
        ddrBannerCategory.DataValueField = "bc_id";
        ddrBannerCategory.DataBind();
        ddrBannerCategory.Items.Insert(0, new ListItem("==請選擇類別==", "0"));

        ddrBannerLocation.DataSource = blBLL.GetallSortData(0);
        ddrBannerLocation.DataTextField = "bl_title";
        ddrBannerLocation.DataValueField = "bl_id";
        ddrBannerLocation.DataBind();
        ddrBannerLocation.Items.Insert(0, new ListItem("==請選擇位置==", "0"));

        ddrBannerCustomer.DataSource = bcsBLL.GetAll();
        ddrBannerCustomer.DataTextField = "bcs_company_name";
        ddrBannerCustomer.DataValueField = "bcs_id";
        ddrBannerCustomer.DataBind();
        ddrBannerCustomer.Items.Insert(0, new ListItem("==請選擇客戶==", "0"));
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
    protected void btnDel_Click(object sender, EventArgs e)
    {
        int delcount = 0;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox chkSel = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("chkSelect");
            if (chkSel.Checked == true)
            {                
                if(bBLL.Delete((int)GridView1.DataKeys[i].Value)>0)
                {
                    delcount++;
                }             
            }
        }
        if (delcount != 0)
        {
            this.ShowMessage(this.Getmessage("30014") + "刪除數" + delcount);           
        }
        else
        {
            this.ShowMessage(this.Getmessage("30013") + "請至少選擇一筆資料");
        }        
        GridView1.DataBind();        
    }
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        Search();
    }
    protected void Search()
    {
        if (rbTitle.Checked)
        {
            ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("b_title", "b_title", "b_price", txtKeyWord.Text, Tools.TryParseMethod(ddrBannerCategory.SelectedValue), "bc_id", Tools.TryParseMethod(ddrBannerCustomer.SelectedValue), "bcs_id", Tools.TryParseMethod(ddrBannerLocation.SelectedValue), "bl_id", ""));
        }
        else
        {
            ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("b_price", "b_title", "b_price", txtKeyWord.Text, Tools.TryParseMethod(ddrBannerCategory.SelectedValue), "bc_id", Tools.TryParseMethod(ddrBannerCustomer.SelectedValue), "bcs_id", Tools.TryParseMethod(ddrBannerLocation.SelectedValue), "bl_id", ""));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Search();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Search();
    }
    protected void Delete(object sender, CommandEventArgs e)
    {
        if (bBLL.Delete(int.Parse(e.CommandArgument.ToString())) > 0)
        {
            this.ShowMessage("刪除成功!");
            GridView1.DataBind();         
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {            
            for (int i = 0; i < this.GridView1.HeaderRow.Cells.Count - 1; i++)
            {
                e.Row.Cells[i].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            }
        }
        catch { }

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
    protected void ddrCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Search();
    }
}
