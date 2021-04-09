using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Web.Configuration;
using System.Collections;

/// <summary>
/// Language 的摘要描述
/// </summary>
public class LanguageBLL
{
    OleDbConnection OBC = new OleDbConnection(WebConfigurationManager.ConnectionStrings["BaystarsConnectionString"].ConnectionString);        
    OleDbDataAdapter ODA;
    ArrayList AL = new ArrayList();
    DataSet DS = new DataSet();
    string str = "";
    public LanguageBLL()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}   
    
    public object SearchLanguage()
    {
        CheckConnection();
        str = "SELECT * FROM LanguageType WHERE l_show=true";
        DS = new DataSet();
        ODA =new OleDbDataAdapter(str, OBC);
        ODA.Fill(DS, "LanguageType");
        OBC.Close();
        return DS;
    }
    public void CheckConnection()
    {
        if (OBC.State != ConnectionState.Open)
        {
            OBC.Open();
        }
    }
}