using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Web.UI.HtmlControls;
public partial class Manager_QA_Add : BasePage
{
    QnaBLL qBLL = new QnaBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
    }
    private void InitPage()
    {
        phtitle.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Q&A", "phtitle"));
        phcontent.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Q&A", "phcontent"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Q&A", "phshow"));
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        QnaInfo info = new QnaInfo();
        info.q_title = txtName.Text;
        info.q_content = cked1.Text;
        info.q_show = bool.Parse( rbShow.SelectedValue);
        info.q_CreateDate = DateTime.Now;
        info.q_EditDate = DateTime.Now;
        if (qBLL.Insert(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30009"));
        }
    }
}