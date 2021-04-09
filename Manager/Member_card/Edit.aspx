<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="Edit.aspx.cs" Inherits="Manager_Member_card_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenu">
        <ul>
            <li id="toplink1" title="文章欄位管理"><span><a href="#"></a></span></li><li
                id="toplink2active" title="增加文章"><span><a href="#">新增</a></span></li><li id="toplink3"
                    title="查看與修改文章"><span></span></li>
            <li id="toplink5" title="生成HTML文件"><a href="#"><span></span></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2">
        會員卡資料-編輯
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phaccount" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                帳號:</div>
            <div class="contentdiv1right">
                <asp:Label ID="lbAccount" runat="server"></asp:Label>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmcnumber" runat="server">
                <div class="contentdiv4">
            <div class="contentdiv1left">
                卡片編號:</div>
            <div class="contentdiv1right">
                <asp:Label ID="lbCardNumber" runat="server"></asp:Label>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmcpassword" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                密碼:</div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="txtPass" runat="server" CssClass="input1"></asp:TextBox>
                </div>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmcstatus" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                開卡狀態:</div>
            <div class="contentdiv1right">
                <asp:DropDownList ID="ddlLevel" runat="server">
                    <asp:ListItem Text="未開通" Value="1"></asp:ListItem>
                    <asp:ListItem Text="已開通" Value="2"></asp:ListItem>
                    <asp:ListItem Text="已註銷" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmcnote" runat="server">
        <div class="contentdiv2">
            <div class="contentdiv1left">
                備註:
                <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="txtContact"
                    ErrorMessage="輸入字數限於300以下" OnServerValidate="CustomValidator3_ServerValidate"
                    ValidationGroup="abc">*</asp:CustomValidator>
            </div>
            <div class="contentdiv1right">
                <asp:TextBox ID="txtContact" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmcadddate" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                建立時間:
            </div>
            <div class="contentdiv1right">
                <asp:Label ID="lbCreateDate" runat="server"></asp:Label>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmceditdate" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                修改時間:
            </div>
            <div class="contentdiv1right">
                <asp:Label ID="lbEditDate" runat="server"></asp:Label>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmcSMTP" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                寄發信件:</div>
            <div class="contentdiv1right">
                <asp:RadioButtonList ID="rbSMTP" runat="server" Width="231px" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                    <asp:ListItem Value="1">是</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        </asp:PlaceHolder>
        <div class="contentdiv3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="abc" />
            <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" ValidationGroup="abc" />
        </div>
    </div>
</asp:Content>
