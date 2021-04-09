using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class JP_team : BasePage
{
    FriendLinkBLL fBLL = new FriendLinkBLL();
    FriendLinkCategoryBLL fcBLL = new FriendLinkCategoryBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Page.Title = "建業法律事務所高雄所 ( KCY )";
            Bind();
        }
    }
    protected void Bind()
    {
        Rpteam.DataSource = fcBLL.GetDataByLid(3);
        Rpteam.DataBind();
    }
    protected void Rpteam_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HiddenField hf = (HiddenField)e.Item.FindControl("hfid");
        Repeater rpsub = (Repeater)e.Item.FindControl("RpSub");
        rpsub.DataSource = fBLL.GetDataByCategoryAndLid(int.Parse(hf.Value), 3);
        rpsub.DataBind();
    }
}