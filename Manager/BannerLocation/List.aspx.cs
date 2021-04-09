using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Web.UI.HtmlControls;

public partial class Manager_BannerLocation_List : BasePage
{
    BannerLocationBLL blBLL = new BannerLocationBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlHead header = (HtmlHead)this.Master.FindControl("head1");
        header.Title = UserInfoConfig.GetUserConfig("title");
        InitPage();
        if (!IsPostBack)
        {
            InsertDropdown();
        }
    }
    protected void InsertDropdown()
    {
        ddlCategory.DataSource = blBLL.GetallSortData(0);
        ddlCategory.DataTextField = "bl_title";
        ddlCategory.DataValueField = "bl_id";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("==請選擇頁面搜尋==", "0"));
    }
    protected void InitPage()
    {
        GridView1.Columns[2].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerLocation", "phname"));
        GridView1.Columns[3].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("BannerLocation", "phfather"));
    }
    public string getTitle(int id)
    {
        if (id == 0)
        {
            return "此資料為頁面";
        }
        BannerLocationInfo info = blBLL.GetDataById(id);
        return info.bl_title;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("bl_title", txtKeyWord.Text, Tools.TryParseMethod(ddlCategory.SelectedValue), "bl_father_id", ""));        
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        int delcount = 0;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox chkSel = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("chkSelect");
            if (chkSel.Checked == true)
            {
                if (blBLL.Delete((int)GridView1.DataKeys[i].Value) > 0)
                {
                    delcount++;
                }
                else
                {
                    ShowMessage("尚有Banner對應資料存在,不予刪除此位置");
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("bl_title", txtKeyWord.Text, Tools.TryParseMethod(ddlCategory.SelectedValue), "bl_father_id",""));        
    }
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("bl_title", txtKeyWord.Text, Tools.TryParseMethod(ddlCategory.SelectedValue), "bl_father_id", ""));        
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
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBox check = (CheckBox)sender;
    }
    protected void Delete(object sender, CommandEventArgs e)
    {
        if (blBLL.Delete(int.Parse(e.CommandArgument.ToString())) > 0)
        {
            ShowMessage("刪除成功");
        }
        else
        {
            ShowMessage("尚有Banner對應資料存在,不予刪除此位置");
        }
        GridView1.DataBind();
        
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
    protected void GvCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dropDown = (DropDownList)sender;
        this.GridView1.PageSize = int.Parse(dropDown.SelectedValue);
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
}