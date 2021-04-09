using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class index : System.Web.UI.Page
{
    NewsBLL nBLL = new NewsBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    protected void Bind()
    {
        RpIndexNews.DataSource = nBLL.GetTOP3DataByLid(1);
        RpIndexNews.DataBind();
    }
}