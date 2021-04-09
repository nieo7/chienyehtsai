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

public partial class Manager_Article_List : BasePage
{
    ArticleCategoryBLL acBLL = new ArticleCategoryBLL(lid);
    ArticleBLL aBLL = new ArticleBLL(lid);
    protected void Page_Init(object sender, EventArgs e)
    {
        InitPage();        
        if (!IsPostBack)
        {
            ObjectDataSource1.SelectParameters["l_id"].DefaultValue = lid.ToString();          
        }
    }
    protected void InitPage()
    {
        phfather.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phfather"));
        GridView1.Columns[2].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phrpimage"));
        GridView1.Columns[3].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phname"));
        GridView1.Columns[4].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phfather"));
        GridView1.Columns[5].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Article", "phshow"));
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlHead header = (HtmlHead)this.Master.FindControl("head1");
        header.Title = UserInfoConfig.GetUserConfig("title");
        if (!IsPostBack)
        {
            //Check_Power(1, 2, true);
            string headers = Tools.GetStringSafeFromQueryString(this.Page, "header");
            if (headers != null && headers.Trim() != "")
            {
                this.ShowMessage(headers);
            }
            InsertDropdown();
        }
    }
    public void InsertDropdown()
    {
        ddrCategory.DataSource = acBLL.GetallSortData(0);
        ddrCategory.DataTextField = "ac_name";
        ddrCategory.DataValueField = "ac_id";
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
    protected void btnDel_Click(object sender, EventArgs e)
    {
        int delcount = 0;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox chkSel = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("chkSelect");
            if (chkSel.Checked == true)
            {
                delcount++;
                if (aBLL.Delete((int)GridView1.DataKeys[i].Value) > 0)
                {
                    ShowMessage("刪除成功");
                }
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
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("a_title", txtKeyWord.Text, int.Parse(ddrCategory.SelectedValue), "ac_id", ""));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("a_title", txtKeyWord.Text, int.Parse(ddrCategory.SelectedValue), "ac_id", ""));
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("a_title", txtKeyWord.Text, int.Parse(ddrCategory.SelectedValue), "ac_id", ""));
    }
    protected void Delete(object sender, CommandEventArgs e)
    {
        aBLL.Delete(int.Parse(e.CommandArgument.ToString()));
        GridView1.DataBind();
        this.ShowMessage("刪除成功!");
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
    public string getTitle(int id)
    {
        if (id == 0)
        {
            return "";
        }
        ArticleCategoryInfo info = acBLL.getAllById(id);
        return info.ac_name;
    }
    protected void ddrCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("a_title", txtKeyWord.Text, int.Parse(ddrCategory.SelectedValue), "ac_id", ""));
    }
}
