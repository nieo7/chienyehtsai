using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL;
using Model;

public partial class Manager_Contact_List : BasePage
{
    ContactBLL cBLL = new ContactBLL(lid);
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
        gridView.Columns[2].Visible =Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Contact", "phname"));
        //gridView.Columns[3].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Contact", "phsex"));                
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("c_name", txtKeyWord.Text, ""));
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        int delcount = 0;
        for (int i = 0; i < gridView.Rows.Count; i++)
        {
            CheckBox chkSel = (CheckBox)gridView.Rows[i].Cells[0].FindControl("chkSelect");
            if (chkSel.Checked == true)
            {

                if (cBLL.Delete((int)gridView.DataKeys[i].Value) > 0)
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbRead = (Label)e.Row.FindControl("lbIsRead");
            lbRead.Text = lbRead.Text == "True" ? "O" : "<b>X</b>";
            //Label lbIsReply = (Label)e.Row.FindControl("lbIsReply");
            //lbIsReply.Text = lbIsReply.Text == "True" ? "O" : "<b>X</b>";            
        }
    }
    protected void Button2_Command(object sender, CommandEventArgs e)
    {
        cBLL.Delete(int.Parse(e.CommandArgument.ToString()));
        gridView.DataBind();
        ShowMessage("刪除成功");
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
    protected void FormView1_DataBound(object sender, EventArgs e)
    {

    }

    protected void btncheck_Command(object sender, CommandEventArgs e)
    {
        ContactInfo info = cBLL.GetDataById(int.Parse(e.CommandArgument.ToString()));
        info.c_check_read = true;
        cBLL.Update(info);        
        ObjectDataSource2.SelectParameters["c_id"].DefaultValue = e.CommandArgument.ToString();

        //特定Command按鈕
        LinkButton lnkCheck = (LinkButton)sender;
        if (lnkCheck.Text == "檢視")
        {
            FormView1.Visible = true;
            //文字全部改為:檢視
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                LinkButton lnkCheckText = (LinkButton)gridView.Rows[i].Cells[6].FindControl("btncheck");
                lnkCheckText.Text = "檢視";
            }
            lnkCheck.Text = "隱藏";
        }
        else
        {
            FormView1.Visible = false;
            lnkCheck.Text = "檢視";
            gridView.DataBind();
        }
        FormView1.DataBind();
    }
}