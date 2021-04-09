<%@ WebHandler Language="C#" Class="MaekThumbImage" %>

using System;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
public class MaekThumbImage : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        string url = context.Server.MapPath(context.Request.QueryString["img"]);
        string w = context.Request.QueryString["w"];
        string h = context.Request.QueryString["h"];
        string ap = "";
        if (context.Request.QueryString["ap"] != null)
            ap = context.Request.QueryString["ap"];
        //設定要截圖的寬高
        int cuth = 0;
        if (context.Request.QueryString["cuth"] != null)
            cuth = int.Parse(context.Request.QueryString["cuth"]);
        int cutw = 0;
        if (context.Request.QueryString["cutw"] != null)
            cutw = int.Parse(context.Request.QueryString["cutw"]);

        //設定要截圖的寬高
        int cropx = 0;
        if (context.Request.QueryString["cropx"] != null)
            cropx = int.Parse(context.Request.QueryString["cropx"]);
        int cropy = 0;
        if (context.Request.QueryString["cropy"] != null)
            cropy = int.Parse(context.Request.QueryString["cropy"]);

        //string notimg = context.Server.MapPath(context.Request.QueryString["notimg"]);
        if (!System.IO.File.Exists(url))
        {
            url = context.Server.MapPath(context.Request.QueryString["notimg"]);
        }
        if (cuth > 0 && cutw > 0)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromStream(new System.IO.MemoryStream(new System.Net.WebClient().DownloadData(url)));
            if (ap != "")
            {
                switch (ap)
                {
                    case "Center": Crop(originalImage, cutw, cuth, AnchorPosition.Center); break;
                    case "Bottom": Crop(originalImage, cutw, cuth, AnchorPosition.Bottom); break;
                }
            }
            else
                Crop(originalImage, cutw, cuth, AnchorPosition.Top);
        }
        else
            MakeAlbumImages(url, int.Parse(w), int.Parse(h));

    }

    public void MakeAlbumImages(string url, int maxWidth, int maxHeight)
    {
        //從指定URL取得圖片資源轉為Stream
        System.Drawing.Image originalImage = System.Drawing.Image.FromStream(new System.IO.MemoryStream(new System.Net.WebClient().DownloadData(url)));
        using (originalImage)
        {
            //Resize的比例計算
            Size thumbSize = ResizeImage(originalImage.Width, originalImage.Height, maxWidth, maxHeight);
            //產生縮圖處理
            using (System.Drawing.Image thumbImage = new Bitmap(thumbSize.Width, thumbSize.Height))
            {
                using (Graphics thumbGraphic = Graphics.FromImage(thumbImage))
                {
                    thumbGraphic.CompositingQuality = CompositingQuality.HighQuality;
                    thumbGraphic.SmoothingMode = SmoothingMode.HighQuality;
                    thumbGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    Rectangle thumbRectangle = new Rectangle(0, 0, thumbSize.Width, thumbSize.Height);

                    thumbGraphic.DrawImage(originalImage, thumbRectangle);
                    
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    
                    thumbImage.Save(ms, originalImage.RawFormat);
                    
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ContentType = "images/jpeg";
                    HttpContext.Current.Response.BinaryWrite(ms.ToArray());

                }
            }
        }
    }

    public Bitmap CropImage(Bitmap OrignaImage, Point TopLeft, Point BottomRight)
    {
        Bitmap btmCropped = new Bitmap((BottomRight.Y - TopLeft.Y), (BottomRight.X - TopLeft.X));

        Graphics grpOriginal = Graphics.FromImage(btmCropped);

        grpOriginal.DrawImage(OrignaImage, new Rectangle(0, 0, btmCropped.Width, btmCropped.Height), TopLeft.X, TopLeft.Y, btmCropped.Width, btmCropped.Height, GraphicsUnit.Pixel);
        
        return btmCropped;
    }
    enum AnchorPosition
    {
        Top,
        Center,
        Bottom,
        Left,
        Right
    }
    static void Crop(Image imgPhoto, int Width, int Height, AnchorPosition Anchor)
    {
        int sourceWidth = imgPhoto.Width;
        int sourceHeight = imgPhoto.Height;
        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;

        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;

        nPercentW = ((float)Width / (float)sourceWidth);
        nPercentH = ((float)Height / (float)sourceHeight);

        if (nPercentH < nPercentW)
        {
            nPercent = nPercentW;
            switch (Anchor)
            {
                case AnchorPosition.Top:
                    destY = 0;
                    break;
                case AnchorPosition.Bottom:
                    destY = (int)(Height - (sourceHeight * nPercent));
                    break;
                default:
                    destY = (int)((Height - (sourceHeight * nPercent)) / 2);
                    break;
            }
        }
        else
        {
            nPercent = nPercentH;
            switch (Anchor)
            {
                case AnchorPosition.Left:
                    destX = 0;
                    break;
                case AnchorPosition.Right:
                    destX = (int)(Width - (sourceWidth * nPercent));
                    break;
                default:
                    destX = (int)((Width - (sourceWidth * nPercent)) / 2);
                    break;
            }
        }

        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = (int)(sourceHeight * nPercent);

        Bitmap bmPhoto = new Bitmap(Width, Height);
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

        Graphics grPhoto = Graphics.FromImage(bmPhoto);
        grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

        grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);

        

        System.IO.MemoryStream ms = new System.IO.MemoryStream();

        bmPhoto.Save(ms, imgPhoto.RawFormat);

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "images/jpeg";
        HttpContext.Current.Response.BinaryWrite(ms.ToArray());
        grPhoto.Dispose();
    }
    static void FixedSize(Image imgPhoto, int Width, int Height)
    {
        int sourceWidth = imgPhoto.Width;
        int sourceHeight = imgPhoto.Height;
        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;

        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;

        nPercentW = ((float)Width / (float)sourceWidth);
        nPercentH = ((float)Height / (float)sourceHeight);

        //if we have to pad the height pad both the top and the bottom
        //with the difference between the scaled height and the desired height
        if (nPercentH < nPercentW)
        {
            nPercent = nPercentH;
            destX = (int)((Width - (sourceWidth * nPercent)) / 2);
        }
        else
        {
            nPercent = nPercentW;
            destY = (int)((Height - (sourceHeight * nPercent)) / 2);
        }

        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = (int)(sourceHeight * nPercent);

        Bitmap bmPhoto = new Bitmap(Width, Height);
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

        Graphics grPhoto = Graphics.FromImage(bmPhoto);
        grPhoto.Clear(Color.Red);
        grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

        grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);
        
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        bmPhoto.Save(ms, imgPhoto.RawFormat);

        HttpContext.Current.Response.Clear();
        //HttpContext.Current.Response.ContentType = "images/jpeg";
        HttpContext.Current.Response.BinaryWrite(ms.ToArray());
        
        grPhoto.Dispose();
        
    }
    public Size ResizeImage(int width, int height, int maxWidth, int maxHeight)
    {
        decimal MAX_WIDTH = maxWidth;
        decimal MAX_HEIGHT = maxHeight;
        decimal ASPECT_RATIO = MAX_WIDTH / MAX_HEIGHT;

        int newWidth, newHeight;

        decimal originalWidth = width;
        decimal originalHeight = height;
        //當來源圖的寬與高大於限制大小進行比例調整 
        if (originalWidth > MAX_WIDTH || originalHeight > MAX_HEIGHT)
        {
            decimal factor;
            // determine the largest factor 
            if (originalWidth / originalHeight > ASPECT_RATIO)
            {
                factor = originalWidth / MAX_WIDTH;
                newWidth = Convert.ToInt32(originalWidth / factor);
                newHeight = Convert.ToInt32(originalHeight / factor);
            }
            else
            {
                factor = originalHeight / MAX_HEIGHT;
                newWidth = Convert.ToInt32(originalWidth / factor);
                newHeight = Convert.ToInt32(originalHeight / factor);
               
            }
        }
        else
        {
            newWidth = width;
            newHeight = height;
        }

        return new Size(newWidth, newHeight);

    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}