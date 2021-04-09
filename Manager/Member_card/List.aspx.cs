using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_Member_card_List : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("~/Manager/Member/List.aspx");
    }
}