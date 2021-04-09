using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class Manager_QA_Edit : BasePage
{
    QnaBLL qBLL = new QnaBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
        if (!IsPostBack)
        {
            Bind();
        }
    }
    private void InitPage()
    {
        phtitle.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Q&A", "phtitle"));
        phcontent.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Q&A", "phcontent"));
        phshow.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Q&A", "phshow"));
        phcreatedate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Q&A", "phcreatedate"));
        pheditdate.Visible = Tools.TryParseBoolMethod(SystemConfigBLL.getDataByClassWithName("Q&A", "pheditdate"));
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        QnaInfo info = qBLL.GetDataById(id);
        info.q_title = txtName.Text;
        info.q_content = cked1.Text;
        info.q_show = bool.Parse(rbShow.SelectedValue);
        info.q_EditDate = DateTime.Now;
        if (qBLL.Update(info) > 0)
        {
            Response.Redirect("List.aspx?header=" + Getmessage("30014"));
        }
    }
    protected void Bind()
    {
        if (id != 0)
        {
            if (Tools.TryParseMethod(id.ToString()) > 0)
            {
                QnaInfo info = qBLL.GetDataById(id);
                txtName.Text = info.q_title;
                cked1.Text = info.q_content;
                rbShow.SelectedValue = info.q_show.ToString();
                txtCreatedate.Text = info.q_CreateDate.ToShortDateString();
                txtEditdate.Text = info.q_EditDate.ToShortDateString();
            }
        }
    }
}