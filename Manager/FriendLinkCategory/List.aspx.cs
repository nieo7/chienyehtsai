using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL;

public partial class Manager_FriendLinkCategory_List : BasePage
{
    FriendLinkCategoryBLL fcBLL = new FriendLinkCategoryBLL();
    FriendLinkBLL fBLL = new FriendLinkBLL(lid);
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
            string headers = Tools.GetStringSafeFromQueryString(this.Page, "header");
            if (headers != null && headers.Trim() != "")
            {
                this.ShowMessage(headers);
            }
        }
    }
    protected void InitPage()
    {
        GridView1.Columns[2].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("FriendLinkCategory", "phname"));
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
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
    protected void btnDel_Click(object sender, EventArgs e)
    {
        int delcount = 0;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox chkSel = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("chkSelect");
            if (chkSel.Checked == true)
            {
                delcount++;                
                fcBLL.Delete((int)GridView1.DataKeys[i].Value);
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
        fcBLL.Delete(int.Parse(e.CommandArgument.ToString()));
        GridView1.DataBind();        
        ShowMessage("刪除成功");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("fc_title", txtKeyWord.Text, ""));
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
}