using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class EN_news_det : BasePage
{
    NewsBLL nBLL = new NewsBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Page.Title = "Chien Yeh Law Offices Kaohsiung Office(KCY)";
            Bind();
            List<NewsInfo> newsinfos = new List<NewsInfo>();
            newsinfos = nBLL.getAllForEN();
            if (newsinfos.Count > 0)
            {
                NewsInfo hitsinfo = nBLL.getAllById(id);
                int index = newsinfos.FindIndex(p => p.n_id == id);

                int count = hitsinfo.n_hits;
                count += 1;//增加瀏覽數
                nBLL.UpdateHits(count, id);

                //前往上下篇文章內容頁的方法
                if ((index + 1) < newsinfos.Count)//當該頁index+1少於總資料數
                {
                    NewsInfo preInfo = newsinfos[index + 1];
                    if (preInfo != null)
                        HyPre.NavigateUrl = string.Format("news_det.aspx?id={0}", preInfo.n_id);
                }
                else
                    HyPre.Attributes.Add("onClick", "alert('Already the first news!')");
                if (index > 0)
                {
                    NewsInfo nextInfo = newsinfos[index - 1];
                    if (nextInfo != null)
                        HyNext.NavigateUrl = string.Format("news_det.aspx?id={0}", nextInfo.n_id);
                }
                else
                    HyNext.Attributes.Add("onClick", "alert('Already the last news!')");
            } 
        }
    }
    protected void Bind()
    {
        Rpnews.DataSource = nBLL.GetDataByIdAndLid(id,2);
        Rpnews.DataBind();
    }
}
