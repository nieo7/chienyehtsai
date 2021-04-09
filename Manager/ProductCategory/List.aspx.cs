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
using System.Linq;
using BLL;
using Model;

public partial class Manager_ProductCategory_List : BasePage
{
    ProductCategoryBLL pcBLL = new ProductCategoryBLL(lid);
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
        phcategory.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("ProductCategory", "phcategory"));
        GridView1.Columns[3].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("ProductCategory", "phimg"));
        GridView1.Columns[4].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("ProductCategory", "phname"));
        GridView1.Columns[5].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("ProductCategory", "phcategory"));
        GridView1.Columns[6].Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("ProductCategory", "phshow"));
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("pc_name", txtKeyWord.Text, int.Parse(ddrCategory.SelectedValue), "pc_fatherid", lid, "l_id", ""));        
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
                pcBLL.Delete((int)GridView1.DataKeys[i].Value);
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("pc_name", txtKeyWord.Text, int.Parse(ddrCategory.SelectedValue), "pc_fatherid", lid, "l_id", ""));        
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
        pcBLL.Delete(int.Parse(e.CommandArgument.ToString()));        
        GridView1.DataBind();        
        ShowMessage("刪除成功");           
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
            AddMethodSystem.ShowBox(UpdatePanel1, this.GetType(), "valuebig", "alert('超出分頁最大值');window.location.href");
            ObjectDataSource1.FilterExpression = AddMethodSystem.DecodeHtml2(AddMethodSystem.SearchWHEREStringObject("pc_name", txtKeyWord.Text, int.Parse(ddrCategory.SelectedValue), "pc_fatherid", lid, "l_id", ""));        
        }
    }
    public void InsertDropdown()
    {
        ddrCategory.DataSource = pcBLL.getallSortData(0);        
        ddrCategory.DataTextField = "pc_name";
        ddrCategory.DataValueField = "pc_id";
        ddrCategory.DataBind();
        ddrCategory.Items.Insert(0, new ListItem("全部顯示", "0"));
    }
    public string getTitle(int id)
    {
        if (id == 0)
        {
            return "此項目為主類別";
        }
        ProductCategoryInfo info = pcBLL.getEditdata(id);
        return info.pc_name;
    }          
}