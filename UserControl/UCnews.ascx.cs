using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class UserControl_UCnews : System.Web.UI.UserControl
{
    NewsBLL nBLL = new NewsBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        LVnews.DataSource = nBLL.GetDataByLid(1);  //1為繁體中文語系
        if (!IsPostBack)
        {
            LVnews.DataBind();
        }
    }
    protected void LVnews_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        ListView newsListView = sender as ListView;
        this.DataPagerNews.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        newsListView.DataBind();
    }
}