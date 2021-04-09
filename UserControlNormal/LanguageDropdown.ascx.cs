using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
public partial class UserControlASP_LanguageDropdown : UserControlBase
{       
    LanguageBLL LUB = new LanguageBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        ddrLanguage.AutoPostBack = SetAutoPostBack;
        if (!IsPostBack)
        {
            FillDropdown();            
            if (lid!= 0)
            {
                ddrLanguage.SelectedValue = lid.ToString();
            }
            else
            {
                lid = 1;
            }
        }
        GetDropdownValue = ddrLanguage.SelectedValue;    
        //此Selected事件必須由使用頁面去設定           
    }    
    public void FillDropdown()
    {
        ddrLanguage.DataSource = LUB.SearchLanguage();
        ddrLanguage.DataTextField = "l_name";
        ddrLanguage.DataValueField = "l_id";
        ddrLanguage.DataBind();
    }
    
    public string GetDropdownValue { get; set; } //寫入Insert或Read時
    public string EditDropdownValue { get; set; } //編輯Update
    private bool setAutopostback = false;             //是否發生Postback,預設false
    public bool SetAutoPostBack
    {
        get
        {
            return setAutopostback;
        }
        set
        {
            setAutopostback = value;
        }
    }
    protected void ddrLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        lid = int.Parse(ddrLanguage.SelectedValue);
        Response.Redirect(Request.Url.ToString());
    }
}