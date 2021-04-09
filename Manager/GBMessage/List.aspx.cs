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


public partial class Manager_GBMessage_List : BasePage
{
    GBcategoryBLL gbcBLL = new GBcategoryBLL();
    GBmessageBLL gbBLL = new GBmessageBLL();
    protected void Page_Init(object sender, EventArgs e)
    {
        InsertDropDown();
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
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phcategory"));
        GridView1.Columns[2].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phcategory"));
        GridView1.Columns[3].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("GBMessage", "phname"));
    }
    protected void InsertDropDown()
    {
        ddrCategory.DataSource = gbcBLL.GetData();
        ddrCategory.DataTextField = "gbc_title";
        ddrCategory.DataValueField = "gbc_id";
        ddrCategory.DataBind();
        ddrCategory.Items.Insert(0, new ListItem("全部顯示", "0"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("gb_title", txtKeyWord.Text,int.Parse(ddrCategory.SelectedValue),"gbc_id",""));
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
                gbBLL.Delete((int)GridView1.DataKeys[i].Value);
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
    protected void ddrCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("gb_title", txtKeyWord.Text, int.Parse(ddrCategory.SelectedValue), "gbc_id", ""));
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
        gbBLL.Delete(int.Parse(e.CommandArgument.ToString()));
        GridView1.DataBind();        
        ShowMessage("刪除成功");
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
    protected void lkbtnReport_Command(object sender, CommandEventArgs e)
    {
        GBmessageInfo info = gbBLL.GetDataById(int.Parse(e.CommandArgument.ToString()));
        info.gb_hits += 1;
        gbBLL.Update(info);
        Response.Redirect("GBReport.aspx?id=" + e.CommandArgument.ToString());
    }
}