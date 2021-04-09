using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
public partial class TinyURL : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string url = "http://tinyurl.com/api-create.php?url=" + TextBox1.Text;
        HttpWebRequest Wrequest = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse Wresponse = (HttpWebResponse)Wrequest.GetResponse();
        StreamReader tReader = new StreamReader(Wresponse.GetResponseStream());
        TextBox2.Text = tReader.ReadToEnd();
    }
}