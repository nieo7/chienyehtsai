using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL;
using Model;
public partial class Manager_News_List : BasePage
{
    NewsCategoryBLL ncBLL = new NewsCategoryBLL(lid);
    NewsBLL nBLL = new NewsBLL(lid);    
    protected void Page_Init(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            ObjectDataSource1.SelectParameters["l_id"].DefaultValue = lid.ToString();
        }        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlHead header = (HtmlHead)this.Master.FindControl("head1");
        header.Title = UserInfoConfig.GetUserConfig("title");
        InitPage();
        if (!IsPostBack)
        {
            //Check_Power(1, 2, true);
            InsertDropdown();
        }
    }
    protected void InitPage()
    {
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phcategory"));
        GridView1.Columns[3].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phimg"));
        GridView1.Columns[4].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phname"));
        GridView1.Columns[5].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phcategory"));
        GridView1.Columns[6].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("NewsCategory", "phshow"));
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
               ncBLL.Delete((int)GridView1.DataKeys[i].Value);
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
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("nc_name", txtKeyWord.Text, int.Parse(ddrCategory.SelectedValue), "nc_fatherid", lid, "l_id", ""));        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("nc_name", txtKeyWord.Text, int.Parse(ddrCategory.SelectedValue), "nc_fatherid", lid, "l_id", ""));        
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBox check = (CheckBox)sender;
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
    public void InsertDropdown()
    {
        ddrCategory.DataSource = ncBLL.GetallSortData(0);
        ddrCategory.DataTextField = "nc_name";
        ddrCategory.DataValueField = "nc_id";
        ddrCategory.DataBind();
        ddrCategory.Items.Insert(0, new ListItem("全部顯示", "0"));
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("nc_name", txtKeyWord.Text, int.Parse(ddrCategory.SelectedValue), "nc_fatherid", lid, "l_id", ""));        
    }
    public string getTitle(int id)
    {
        if (id == 0)
        {
            return "此為主類別";
        }
        NewsCategoryInfo info = ncBLL.getAllById(id);
        return info.nc_name;
    }
    protected void Button2_Command(object sender, CommandEventArgs e)
    {
        ncBLL.Delete(int.Parse(e.CommandArgument.ToString()));
        GridView1.DataBind();
        ShowMessage("刪除成功");           
    }
}
