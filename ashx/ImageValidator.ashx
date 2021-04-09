<%@ WebHandler Language="C#" Class="ImageValidator" %>

using System;
using System.Web;
using System.Drawing;
using System.Web.SessionState;
public class ImageValidator : IHttpHandler,IRequiresSessionState
{    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        CreateImageStart(CreateCheckCode(context), context);
    }
    private string CreateCheckCode(HttpContext context)
    {
        int number;
        char code;
        string checkCode = string.Empty;
        System.Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            number = random.Next();
            if (number % 2 == 0)
            {
                code = (char)('0' + (char)(number % 10));
            }
            else
            {
                code = (char)('A' + (char)(number % 26));
            }
            checkCode += code.ToString();
        }       
        //儲存於Cookie
        context.Response.Cookies.Add(new HttpCookie("CheckCode", checkCode));
        //儲存於Session
        context.Session["CheckCode"] = checkCode;
        return checkCode;
    }
    private void CreateImageStart(string checkCode, HttpContext context)
    {
        if (checkCode == null || checkCode.Trim() == String.Empty)
            return;

        System.Drawing.Bitmap Image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 12.5)), 22);
        Graphics g = Graphics.FromImage(Image);
        try
        {
            Random random = new Random();
            g.Clear(Color.White);

            for (int i = 0; i < 25; i++)
            {
                int x1 = random.Next(Image.Width);
                int x2 = random.Next(Image.Width);
                int y1 = random.Next(Image.Height);
                int y2 = random.Next(Image.Height);

                g.DrawLine(new Pen(Color.Goldenrod), x1, y1, x2, y2);
            }

            Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, Image.Width, Image.Height), Color.Blue, Color.Green, 1.2f, true);
            g.DrawString(checkCode, font, brush, 2, 2);

            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(Image.Width);
                int y = random.Next(Image.Height);
                Image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, Image.Width - 1, Image.Height - 1);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            context.Response.ClearContent();
            context.Response.ContentType = "image/gif";
            context.Response.BinaryWrite(ms.ToArray());
        }
        finally
        {
            g.Dispose();
            Image.Dispose();
        }
    } 
    public bool IsReusable {
        get {
            return false;
        }
    }

}