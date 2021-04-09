using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;
using Model;

public partial class Manager_FriendLink_List : BasePage
{
    FriendLinkCategoryBLL fcBLL = new FriendLinkCategoryBLL(lid);
    FriendLinkBLL fBLL = new FriendLinkBLL(lid);
    protected void Page_Init(object sender, EventArgs e)
    {
        ObjectDataSource1.SelectParameters["l_id"].DefaultValue = lid.ToString();
        //FriendLinkCategoryBLL.lidValue = lid;
        InsertDropdown();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        HtmlHead header = (HtmlHead)this.Master.FindControl("head1");
        header.Title = UserInfoConfig.GetUserConfig("title");
        if (!IsPostBack)
        {
            string headers = Tools.GetStringSafeFromQueryString(this.Page, "header");
            if (headers != null && headers.Trim() !="")
            {
                this.ShowMessage(headers);
            }            
        }        
    }
    protected void InitPage()
    {
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLink", "phcategory"));
        GridView1.Columns[4].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLink", "phimage"));
        GridView1.Columns[5].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLink", "phcategory"));
        GridView1.Columns[6].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLink", "phtitle"));
    }
    public void InsertDropdown()
    {
        ddrCategory.DataSource = fcBLL.GetDataByLid(lid);
        ddrCategory.DataTextField = "fc_title";
        ddrCategory.DataValueField = "fc_id";
        ddrCategory.DataBind();
        ddrCategory.Items.Insert(0, new ListItem("全部顯示", "0"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("f_title", txtKeyWord.Text, int.Parse(ddrCategory.SelectedValue), "fc_id", ""));
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
                fBLL.Delete((int)GridView1.DataKeys[i].Value);
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
    }
    protected void ddrCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("f_title", txtKeyWord.Text, int.Parse(ddrCategory.SelectedValue), "fc_id", ""));
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //CheckSortFunction();
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
    protected void Button2_Command(object sender, CommandEventArgs e)
    {
        findGridValue = 0;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (int.Parse(GridView1.DataKeys[i].Value.ToString()) == int.Parse(e.CommandArgument.ToString()))
            {
                saveGridValue = findGridValue;
            }
            else
            {
                findGridValue++;
            }
        }
        if (fBLL.Delete(int.Parse(e.CommandArgument.ToString())) > 0)
        {
            ShowMessage("刪除成功");
        }
        GridView1.DataBind();        
        
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
    protected void GvCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dropdown = (DropDownList)sender;
        this.GridView1.PageSize = int.Parse(dropdown.SelectedValue);
        if (GridView1.PageCount == 0)
        {
            Response.Redirect(Request.Url.ToString());
        }
    }
    //protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        Button btUp = (Button)e.Row.FindControl("btnUp");
    //        btUp.CommandArgument = e.Row.RowIndex.ToString();
    //        Button btDown = (Button)e.Row.FindControl("btnDown");
    //        btDown.CommandArgument = e.Row.RowIndex.ToString();
    //    }
    //}
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int ClickNowSort = 0;
        int RdyChangeSort = 0;
        int i = 0;
        Button btnClick;
        Button btnRdyChange;
        if (e.CommandName == "btnSortUp")
        {
            if (int.Parse(e.CommandArgument.ToString()) > 0)
            {
                btnClick = (Button)GridView1.Rows[int.Parse(e.CommandArgument.ToString())].FindControl("Button2");
                btnRdyChange = (Button)GridView1.Rows[int.Parse(e.CommandArgument.ToString()) - 1].FindControl("Button2");
                FriendLinkInfo pdClick = fBLL.GetDataById(int.Parse(btnClick.CommandArgument.ToString()));
                FriendLinkInfo pdChange = fBLL.GetDataById(int.Parse(btnRdyChange.CommandArgument.ToString()));
                ClickNowSort = pdClick.f_sorting;
                RdyChangeSort = pdChange.f_sorting;
                pdClick.f_sorting = RdyChangeSort;
                pdChange.f_sorting = ClickNowSort;
                if ((i = fBLL.Update(pdClick) + fBLL.Update(pdChange)) > 1)
                {
                    ShowMessage("排序成功");
                    ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("f_title", txtKeyWord.Text, int.Parse(ddrCategory.SelectedValue), "fc_id", ""));
                }
            }
            else { ShowMessage("此項目排序已是第一位"); }
        }
        if (e.CommandName == "btnSortDown")
        {
            if (int.Parse(e.CommandArgument.ToString()) < GridView1.Rows.Count - 1)
            {
                btnClick = (Button)GridView1.Rows[int.Parse(e.CommandArgument.ToString())].FindControl("Button2");
                btnRdyChange = (Button)GridView1.Rows[int.Parse(e.CommandArgument.ToString()) + 1].FindControl("Button2");
                FriendLinkInfo pdClick = fBLL.GetDataById(int.Parse(btnClick.CommandArgument.ToString()));
                FriendLinkInfo pdChange = fBLL.GetDataById(int.Parse(btnRdyChange.CommandArgument.ToString()));
                ClickNowSort = pdClick.f_sorting;
                RdyChangeSort = pdChange.f_sorting;
                pdClick.f_sorting = RdyChangeSort;
                pdChange.f_sorting = ClickNowSort;
                if ((i = fBLL.Update(pdClick) + fBLL.Update(pdChange)) > 1)
                {
                    ShowMessage("排序成功");
                    ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("f_title", txtKeyWord.Text, int.Parse(ddrCategory.SelectedValue), "fc_id", ""));
                }
            }
            else
            {
                ShowMessage("此項目排序已是最後一位");
            }
        }
    }
    //public void CheckSortFunction()
    //{
    //    if ((txtKeyWord.Text.Trim() == string.Empty || txtKeyWord.Text.ToLower() == "all") && ddrCategory.SelectedValue != "0")
    //    {
    //        foreach (GridViewRow row in GridView1.Rows)
    //        {
    //            ((Button)row.FindControl("btnUp")).Enabled = true;
    //            ((Button)row.FindControl("btnDown")).Enabled = true;
    //        }
    //    }
    //    else
    //    {
    //        foreach (GridViewRow row in GridView1.Rows)
    //        {
    //            ((Button)row.FindControl("btnUp")).Enabled = false;
    //            ((Button)row.FindControl("btnDown")).Enabled = false;
    //        }
    //    }
    //}
}