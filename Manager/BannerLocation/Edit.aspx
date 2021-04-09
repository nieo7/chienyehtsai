<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Manager_BannerLocation_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="RightTableTdTopmenuorange">
        <ul>
            <li id="toplink11" title="訊息列表"><a href="list.aspx">列表</a></li>
            <li id="toplink21" title="增加新訊息"><a href="add.aspx">新增</a></li>
            <li id="toplink31active" title="訊息查看與修改"><a href="#">修改</a></li>
            <li id="toplink41" title="查看與修改產品"><a href="#"></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2orange">
        最新消息類別-修改
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phfather" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    類別:&nbsp;</div>
                <div class="contentdiv1right">
                    <asp:DropDownList ID="ddlCategory" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phname" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    標題:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請輸入標題或頁面名稱!"
                        SetFocusOnError="True" ControlToValidate="txtName">*</asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtName" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phshow" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    顯示於前台:</div>
                <div class="contentdiv1right">
                    <asp:RadioButtonList ID="rbShow" runat="server" Width="231px" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="true">是</asp:ListItem>
                        <asp:ListItem Value="false">否</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </asp:PlaceHolder>
        <div class="contentdiv3">
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <asp:Button ID="Button2" runat="server" Text="提交" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>

