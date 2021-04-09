using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class Manager_Member_MemberCheckPage : System.Web.UI.Page
{
    MemberBLL mBLL = new MemberBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["name"] != null && Request.QueryString["checkcode"] != null)
        {
            MemberInfo info=mBLL.GetDataByAccountAndCheckcode(Request.QueryString["name"].ToString(),Request.QueryString["checkcode"].ToString());
            if (info.m_id != 0)
            {
                mBLL.Update(info);
                AddMethodSystem.ShowBox(UpdatePanel1, this.GetType(), "CheckSuccess", "alert('驗證成功');window.location.href='List.aspx';");
            }
            else
            {
                AddMethodSystem.ShowBox(UpdatePanel1, this.GetType(), "fail", "alert('查無此人');");
            }
        }
        else
        {
            Response.Redirect("List.aspx");
            Response.End();
        }
    }
}