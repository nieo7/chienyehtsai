using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class UserControl_Public_Counter : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //宣告檔案讀取案例。(讀取指定位置文字檔案)
        StreamReader objStreamReader = new StreamReader(Page.MapPath("~/Resource/Counter.txt"));
        //宣告長整數。(用來讀取文字檔案，列的資料)
        long lngCounter = Convert.ToInt32(objStreamReader.ReadLine());

        //關閉物件案例。
        objStreamReader.Close();

        //如果個人變數是第一次產生時。
        if (Session.IsNewSession)
        {
            //累加長整數值。
            lngCounter += 1;
            //宣告檔案寫入案例。(寫入指定位置文字檔案)
            StreamWriter objStreamWriter = new StreamWriter(Page.MapPath("~/Resource/Counter.txt"), false);
            //寫入文字檔案，列的資料。
            objStreamWriter.WriteLine(lngCounter);
            //關閉物件案例。
            objStreamWriter.Close();
        }
        //輸出結果。
        string count = lngCounter.ToString("0000000000");
        for (int i = 0; i < count.Length; ++i)
        {
            int n = count.Length;
            Image img = new Image();

            img.ImageUrl = "~\\img\\count\\" + count[i] + ".gif";
            ph1.Controls.Add(img);
        }

    }
}