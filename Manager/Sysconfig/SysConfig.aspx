<%@ Page Language="C#" ValidateRequest="false"  MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true" CodeFile="SysConfig.aspx.cs" Inherits="Manager_SysConfig_SysConfig" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main">
        <div id="message" runat="server" class="OkMsg" style="width: 95%; height: auto" visible="false">
        </div>
    </div>
    <div class="RightTableTdSubheader2red">
        網站基本資料設定&nbsp;</div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <div class="contentdiv1">
            <div class="contentdiv1left">
                網站標題:
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_Title" runat="server" Width="185px"></asp:TextBox>&nbsp;</div>
            </div>
        <div class="contentdiv1">
            <div class="contentdiv1left">
                負責人:
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_SName" runat="server" Width="185px"></asp:TextBox>&nbsp;</div>
            </div>
                <div class="contentdiv4">
            <div class="contentdiv1left">
                公司名稱:
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_CompanyName" runat="server" Width="185px"></asp:TextBox>&nbsp;</div>
            </div>
            <asp:PlaceHolder ID="PlaceHolder_EnCompanyName" runat="server">
            <div class="contentdiv1">
            <div class="contentdiv1left">
                公司名稱(EN):
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_EnCompanyName" runat="server" Width="185px"></asp:TextBox>&nbsp;</div>
            </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder_Code" runat="server">
            <div class="contentdiv4">
            <div class="contentdiv1left">
                郵遞區號:
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_Code" runat="server"  Width="187px"></asp:TextBox>&nbsp;</div>
            </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder_City" runat="server">
            <div class="contentdiv1">
            <div class="contentdiv1left">
                縣市:
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_City" runat="server" Width="185px"></asp:TextBox>&nbsp;</div>
            </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder_Address" runat="server">
            <div class="contentdiv4">
            <div class="contentdiv1left">
                地址:
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_Address" runat="server" Width="187px"></asp:TextBox>&nbsp;</div>
            </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder_EnAddress" runat="server">
            <div class="contentdiv1">
            <div class="contentdiv1left">
                地址(EN):
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_EnAddress" runat="server" Width="185px"></asp:TextBox>&nbsp;</div>
            </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder_Tel" runat="server">
            <div class="contentdiv4">
            <div class="contentdiv1left">
                電話:
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_Tel" runat="server" Width="187px"></asp:TextBox>&nbsp;</div>
            </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder_Fax" runat="server">
            <div class="contentdiv1">
            <div class="contentdiv1left">
                傳真:
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_Fax" runat="server" Width="185px"></asp:TextBox>&nbsp;</div>
            </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder_Email" runat="server">
            <div class="contentdiv4">
            <div class="contentdiv1left">
                信箱:
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_Email" runat="server" Width="187px"></asp:TextBox>&nbsp;</div>
            </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder_Email2" runat="server">
            <div class="contentdiv1">
            <div class="contentdiv1left">
                信箱2:
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_Email2" runat="server" Width="185px"></asp:TextBox>&nbsp;</div>
            </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder_Email3" runat="server">
            <div class="contentdiv4">
            <div class="contentdiv1left">
                信箱3:
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_Email3" runat="server" Width="187px"></asp:TextBox>&nbsp;</div>
            </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder_Url" runat="server">
            <div class="contentdiv1">
            <div class="contentdiv1left">
                網址:
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_Url" runat="server" Width="185px"></asp:TextBox>&nbsp;</div>
            </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder_UserName" runat="server">
            <div class="contentdiv4">
            <div class="contentdiv1left">
                寄件者信箱:
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_UserName" runat="server" Width="187px"></asp:TextBox>&nbsp;</div>
            </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder_Password" runat="server">
            <div class="contentdiv1">
            <div class="contentdiv1left">
                信箱密碼:
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_Password" runat="server" Width="185px"></asp:TextBox>&nbsp;</div>
            </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder_SMTP" runat="server">
            <div class="contentdiv4">
            <div class="contentdiv1left">
                SMTP伺服器:
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_SMTP" runat="server" Width="187px"></asp:TextBox>&nbsp;</div>
            </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder_Port" runat="server">
            <div class="contentdiv1">
            <div class="contentdiv1left">
                Port:
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_Port" runat="server" Width="185px"></asp:TextBox>&nbsp;</div>
            </div>
            </asp:PlaceHolder>
            <div class="contentdiv4">
            <div class="contentdiv1left">
                關鍵字:
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="TextBox_Keyword" runat="server" Width="185px"></asp:TextBox>&nbsp;</div>
            </div>
    <div class="contentdiv3">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="修改"></asp:Button>
    </div>
    </div>
</asp:Content>

