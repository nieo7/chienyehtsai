using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// ButtonAdapter 的摘要描述
/// </summary>
public class ButtonAdapter : System.Web.UI.WebControls.Adapters.WebControlAdapter
{
    public ButtonAdapter()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }
    protected override void OnPreRender(EventArgs e)
    {
        //定義指定的按鈕屬性與介面
        IButtonControl IBC = Control as IButtonControl;
        if (IBC.CommandName == "Delete" || IBC.CommandName == "myDelete")
        {
            Control.Attributes["onclick"] = "if(!confirm('您確定要刪除嗎?')) return false;";                                 
        }
        base.OnPreRender(e);

    }

}
         
