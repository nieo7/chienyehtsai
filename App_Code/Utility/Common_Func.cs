//---------------------------------------------------------------------------- 
//程式功能	公用函數
//程式名稱	/App_Code/Common_Func.cs
//---------------------------------------------------------------------------- 
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.Configuration;

public class Common_Func
{
	// CleanSQL() 清除字串中有 SQL 隱碼攻擊的字串 「'」「 」「;」「--」 「|」「\t」「\n」
	public string CleanSQL(string mString)
	{
		if (mString == null)
			mString = "";
		else
		{
			mString = mString.Replace("'", "''");
			mString = mString.Replace(" ", "");
			mString = mString.Replace(";", "");
			mString = mString.Replace("--", "");
			mString = mString.Replace("|", "");
			mString = mString.Replace("\t", "");
			mString = mString.Replace("\n", "");
		}
		return mString;
	}

	// CheckSQL() 檢查字串中有 SQL 隱碼攻擊的字串 「'」「;」「--」「|」「\t」「\n」
	public bool CheckSQL(string mString)
	{
		bool mfg = false;

		if (mString == null)
			mfg = true;
		else
		{
			mfg = (mString.Contains("'")
				|| mString.Contains(" ")
				|| mString.Contains(";")
				|| mString.Contains("--")
				|| mString.Contains("|")
				|| mString.Contains("\t")
				|| mString.Contains("\n"));
		}

		return mfg;
	}

	// 心情圖示
	// 輸入參數：int	code	心情代碼
	// 傳回數值：string	image	圖示路徑
	//			 string name	圖示名稱
	public struct ImageSymbol
	{
		private int _code;
		private string _image;
		private string _name;

		public int code
		{
			set
			{
				SetCode(value);
			}
			get
			{
				return _code;
			}
		}

		public string image
		{
			get
			{
				return _image;
			}
		}

		public string name
		{
			get
			{
				return _name;
			}
		}

		private void SetCode(int code)
		{
			_code = code;
			_image = "~/images/symbol/";

			switch (code)
			{
				case 0:
					_image += "S00.gif";
					_name = "微笑";
					break;
				case 1:
					_image += "S01.gif";
					_name = "俏皮";
					break;
				case 2:
					_image += "S02.gif";
					_name = "得意";
					break;
				case 3:
					_image += "S03.gif";
					_name = "害羞";
					break;
				case 4:
					_image += "S04.gif";
					_name = "哭泣";
					break;
				case 5:
					_image += "S05.gif";
					_name = "禁言";
					break;
				case 6:
					_image += "S06.gif";
					_name = "氣憤";
					break;
				case 7:
					_image += "S07.gif";
					_name = "鄙視";
					break;
				case 8:
					_image += "S08.gif";
					_name = "無言";
					break;
				case 9:
					_image += "S09.gif";
					_name = "害怕";
					break;
				case 10:
					_image += "S10.gif";
					_name = "真棒";
					break;
				case 11:
					_image += "S11.gif";
					_name = "傷心";
					break;
				case 12:
					_image += "S12.gif";
					_name = "握手";
					break;
				case 13:
					_image += "S13.gif";
					_name = "豬頭";
					break;
				case 14:
					_image += "S14.gif";
					_name = "大便";
					break;
				case 15:
					_image += "S15.gif";
					_name = "電話連絡";
					break;
				case 16:
					_image += "S16.gif";
					_name = "OK";
					break;
				case 17:
					_image += "S17.gif";
					_name = "禮物";
					break;
				default:
					_image += "S00.gif";
					_name = "微笑";
					break;
			}
		}
	}
}