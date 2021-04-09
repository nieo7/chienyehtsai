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

public partial class Manager_News_NewsView : BasePage
{
    ArticleCategoryBLL acBLL = new ArticleCategoryBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    //Check_Power(1, 33, true);
        //    Bind();
        //}
    }
    protected void Bind()
    {
        ArticleCategoryInfo info = acBLL.getAllById(id);
        if (info.ac_id != 0)
        {
            lbTitle.Text = info.ac_name;
        }
    }
}
