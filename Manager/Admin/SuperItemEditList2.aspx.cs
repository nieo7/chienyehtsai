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

public partial class Manager_Admin_SuperAdminItemEditList2 : BasePage
{
    AdminBLL adBLL = new AdminBLL();
    AdminPowerBLL apBLL = new AdminPowerBLL();
    AdminItem2BLL ai2BLL = new AdminItem2BLL();
    List<AdminPowerInfo> adPowerInfos = new List<AdminPowerInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlHead header = (HtmlHead)this.Master.FindControl("head1");
        header.Title = UserInfoConfig.GetUserConfig("title");
        //if (id == 0)
        //    Response.Redirect("SuperItemEditList.aspx", true);
        if (!IsPostBack)
        {
            //Check_Power(17, 76, true);
            string headers = Request["header"];
            if (headers != null && headers.Trim() != "")
            {
                message.Visible = true;
                message.InnerHtml = "&nbsp;文章：<b style='color:red;'>" + headers.Trim() + "&nbsp;&nbsp;</b>修改已完成!";
            }
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
        Label lbfi_no1 = (Label)e.Row.FindControl("lbfi_no1");
        Label lbfi_no2 = (Label)e.Row.FindControl("lbfi_no2");
        if (rdList != null && lbfi_no2 != null)
        {
            AdminItem2Info info = ai2BLL.getAll(int.Parse(lbfi_no2.Text));
            rdList.SelectedValue = info.ai2_visible.ToString();
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
        bool isOk = false;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            RadioButtonList rdList = (RadioButtonList)GridView1.Rows[i].FindControl("raIsVisable");
            TextBox txt_Url = (TextBox)GridView1.Rows[i].FindControl("TextBox_Url");
            Label lbfi_no1 = (Label)GridView1.Rows[i].FindControl("lbfi_no1");
            Label lbfi_no2 = (Label)GridView1.Rows[i].FindControl("lbfi_no2");
            AdminItem2Info info = ai2BLL.getAll(int.Parse(lbfi_no2.Text));
            info.ai2_visible = bool.Parse(rdList.SelectedValue);
            info.ai2_url = txt_Url.Text;
            if (ai2BLL.Update(info.ai2_id, info) > 0)
                isOk = true;
        }
        if (isOk == true)
            Response.Redirect("SuperItemEditList.aspx?header=修改成功!", true);
        else
            Response.Redirect("SuperItemEditList.aspx?header=修改失敗!", true);
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
