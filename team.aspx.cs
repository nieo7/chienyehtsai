using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class team : BasePage
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
        Rpteam.DataSource = fcBLL.GetDataByLid(1);
        Rpteam.DataBind();
        //RpDirector.DataSource = fBLL.getDataById(17);
        //RpDirector.DataBind();
        //Rpadviser.DataSource = fBLL.GetDataByCategoryAndLid(7);//顧問類別
        //Rpadviser.DataBind();
        //RpPartner.DataSource = fBLL.GetDataByCategoryAndLid(8);//合夥律師類別
        //RpPartner.DataBind();
        //RpLawyer.DataSource = fBLL.GetDataByCategoryAndLid(10);//律師類別
        //RpLawyer.DataBind();
        //RpAgent.DataSource = fBLL.GetDataByCategoryAndLid(11);//專案經理類別
        //RpAgent.DataBind();
        //RpAdministrator.DataSource = fBLL.GetDataByCategoryAndLid(12);//行政組類別
        //RpAdministrator.DataBind();
    }

    protected void Rpteam_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HiddenField hf = (HiddenField)e.Item.FindControl("hfid");
        Repeater rpsub = (Repeater)e.Item.FindControl("RpSub");
        rpsub.DataSource = fBLL.GetDataByCategoryAndLid(int.Parse(hf.Value),1);
        rpsub.DataBind();
    }
}