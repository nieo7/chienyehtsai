using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL;
using Model;
public partial class Manager_Member_List : BasePage
{
    MemberBLL mBLL = new MemberBLL();
    Member_cardBLL mcBLL = new Member_cardBLL();
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
        phaccount.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phaccount"));
        phname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phname"));
        phnickname.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phnickname"));
        GridView1.Columns[2].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phaccount"));
        GridView1.Columns[3].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phnickname"));
        GridView1.Columns[4].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Member", "phname"));
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
                mBLL.Delete((int)GridView1.DataKeys[i].Value);
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (rbAccount.Checked)
        {
            ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("m_account", txtKeyWord.Text,""));
        }
        else if (rbNickname.Checked)
        {
            ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("m_nickname", txtKeyWord.Text, ""));
        }
        else
        {
            ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("m_name", txtKeyWord.Text, ""));
        }
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbIsRegist = (Label)e.Row.FindControl("lbIsRegist");            
            lbIsRegist.Text = lbIsRegist.Text == "OK" ? "O" : "<b>X</b>";            
        }
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
    protected void Delete(object sender, CommandEventArgs e)
    {
        mBLL.Delete(int.Parse(e.CommandArgument.ToString()));
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
    protected void lkbtnCreateCard_Command(object sender, CommandEventArgs e)
    {
        if (mcBLL.GetDataByMid(int.Parse(e.CommandArgument.ToString())).m_id == 0)
        {
            MemberInfo minfo = mBLL.GetDataById(int.Parse(e.CommandArgument.ToString()));
            Member_cardInfo info = new Member_cardInfo();
            info.mc_number = "MC" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + minfo.m_level + string.Format("{00000:00000}", mcBLL.Getall().Rows.Count + 1);
            info.mc_pass = Tools.GetRandomString(12);
            info.mc_status = 0;
            info.m_id = int.Parse(e.CommandArgument.ToString());
            info.mc_adddate = DateTime.Now;
            info.mc_editdate = DateTime.Now;
            if (mcBLL.Insert(info) > 0)
            {
                ShowMessage("創建會員卡成功");
            }
        }
        else
        {
            ShowMessage("此帳號已創建會員卡");
        }
    }
}