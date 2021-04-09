using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class UserControl_Address : System.Web.UI.UserControl
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }
    public string CodeId
    {
        set
        {
            HiddenField_ZipCode.Value = value;
            TextBox_ZipCode.Text = value;
        }
        get { return HiddenField_ZipCode.Value; }
    }
    public string Area
    {
        set
        {
            HiddenField_Area.Value = value;
        }
        get { return HiddenField_Area.Value; }
    }
    public string City
    {
        set
        {
            HiddenField_City.Value = value;
        }
        get { return HiddenField_City.Value; }
    }
    public string Address
    {
        get { return TextBox_Address.Text; }
        set { TextBox_Address.Text = value; }
    }
    public bool ZipcodeViable
    {
        get { return PlaceHolder_zipcode.Visible; }
        set { PlaceHolder_zipcode.Visible = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox_ZipCode.Attributes.Add("ReadOnly", "ReadOnly");
    }
}
