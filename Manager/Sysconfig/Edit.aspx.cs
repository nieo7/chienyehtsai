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

public partial class Manager_SysConfig_Edit : BasePage
{
    SystemConfigBLL sysConfigBLL = new SystemConfigBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    private void Bind()
    {
        RepeaterSysConfig.DataSource = sysConfigBLL.getAll();
        RepeaterSysConfig.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool isEdit = false;
        foreach (RepeaterItem item in RepeaterSysConfig.Items)
        {
            CheckBox ckSelect = (CheckBox)item.FindControl("ckSelect");
            if (ckSelect.Checked)
            {
                Literal lId = (Literal)item.FindControl("lId");
                int id = int.Parse(lId.Text);
                SystemConfigInfo info = sysConfigBLL.getAll(id);

                TextBox txtClass = (TextBox)item.FindControl("txtCalss");
                TextBox txtName = (TextBox)item.FindControl("txtName");
                TextBox txtValue = (TextBox)item.FindControl("txtValue");
                TextBox txtDesc = (TextBox)item.FindControl("txtDesc");

                info.sc_Class = txtClass.Text;
                info.sc_Name = txtName.Text;
                info.sc_Value = txtValue.Text;
                info.sc_Desc = txtDesc.Text;

                if (sysConfigBLL.Update(info) > 0)
                    isEdit = true;
            }
        }
        if (isEdit)
            Tools.Show(this.Page, "修改完成!");
        else
            Tools.Show(this.Page, "修改失敗");
        Bind();
    }
}
