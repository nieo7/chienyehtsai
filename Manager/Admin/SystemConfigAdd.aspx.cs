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


public partial class Manager_Admin_SystemConfigAdd : BasePage
{
    AdminItem1BLL ai1BLL = new AdminItem1BLL();
    SystemConfigBLL scBLL = new SystemConfigBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InsertDropdown();
        }
    }
    protected void InsertDropdown()
    {
        ddlCategory.DataSource = ai1BLL.getAll();
        ddlCategory.DataTextField = "ai1_nickname";
        ddlCategory.DataValueField = "ai1_nickname";
        //ddlCategory.DataValueField = "ai1_id";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("==請選擇項目==", "0"));
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedValue != "0")
        {
            SystemConfigInfo info = new SystemConfigInfo();
            info.sc_Class = ddlCategory.SelectedValue;
            info.sc_Name = txtName.Text;
            info.sc_Value = rbShow.SelectedValue;
            info.sc_Desc = txtdetail.Text;

            if (SystemConfigBLL.getDataByClassWithName(info.sc_Class, info.sc_Name) == string.Empty)
            {
                if (scBLL.Insert(info) > 0)
                {
                    ShowMessage("新增功能控制項:" + txtName.Text + " 成功");
                }
            }
            else
            {
                ShowMessage("資料表中已有此類別與功能紀錄");
            }
        }
        else
        {
            ShowMessage("請選擇主項目");
        }
    }
}