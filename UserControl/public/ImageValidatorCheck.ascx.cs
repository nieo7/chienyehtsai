using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_ImageValidatorCheck : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (string.Compare(Request.Cookies["CheckCode"].Value, this.TextBox1.Text, true) == 0)
        {
            Response.Write("That`s Right for Cookie");
        }
        else
        {
            Response.Write("This is failure");
        }
        Response.Cookies.Remove("CheckCode");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (string.Compare(Session["CheckCode"].ToString(), this.TextBox1.Text, true) == 0)
        {
            Response.Write("That`s Right for Session");
        }
        else
        {
            Response.Write("This is failure");
        }
        Session.Remove("CheckCode");
    }
}