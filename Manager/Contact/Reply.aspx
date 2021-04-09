<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="Reply.aspx.cs" Inherits="Manager_Contact_Reply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenu">
        <ul>
            <li id="toplink11" title="新增"><a href="list.aspx">列表</a></li>
            <li id="toplink21" title=""><a href="#"></a></li>
            <li id="toplink31active" title="回覆信件"><a href="#">回覆</a></li>
            <li id="toplink41" title=""><a href="#"></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2">
        聯絡我們-回覆信件
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phsubject" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                標題:</div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input1" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phname" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                寄件人:</div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="txtName" runat="server" CssClass="input1" MaxLength="254" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmail" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                寄件人信箱:</div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="txtMail" runat="server" CssClass="input1" MaxLength="254" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phsex" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                性別:</div>
            <div class="contentdiv1right">
                <asp:Literal ID="litSex" runat="server"></asp:Literal>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                電話:</div>
            <div class="contentdiv1right">
                <asp:Literal ID="litPhone" runat="server"></asp:Literal>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                傳真:</div>
            <div class="contentdiv1right">
                <asp:Literal ID="litFax" runat="server"></asp:Literal>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phdetail" runat="server">
        <div class="contentdiv2">
            <div class="contentdiv2left">
                内容:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="請填寫內容!"
                    SetFocusOnError="True" ControlToValidate="txtContent" ValidationGroup="abc">*</asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator4" runat="server" ControlToValidate="txtContent"
                    ErrorMessage="輸入字數限於300以下" OnServerValidate="CustomValidator3_ServerValidate"
                    ValidationGroup="abc">*</asp:CustomValidator>
            </div>
            <div class="contentdiv2right">
                <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="8"></asp:TextBox>
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
