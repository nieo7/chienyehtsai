using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class hire : BasePage
{
    ArticleBLL aBLL = new ArticleBLL();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            this.Page.Title = "建業法律事務所高雄所 ( KCY )";
            //Bind();
        }
    }
    //protected void Bind()
    //{
    //    ArticleInfo info = aBLL.GetDataByAid(7);
    //    if (info.a_detail == "")
    //    {
    //        litContent.Text = "暫無任何徵才訊息!";
    //    }
    //    else
    //    {
    //        litContent.Text = info.a_detail;
    //    }
    //}
}