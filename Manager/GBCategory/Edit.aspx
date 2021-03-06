<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="Edit.aspx.cs" Inherits="Manager_GBCategory_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenu">
        <ul>
            <li id="toplink1" title="文章欄位管理"><span><a href="List.aspx">列表</a></span></li><li
                id="toplink2active" title="增加文章"><span><a href="#">編輯</a></span></li><li id="toplink3"
                    title="查看與修改文章"><span></span></li>
            <li id="toplink5" title="生成HTML文件"><a href="#"><span></span></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2">
        留言版類別-編輯
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phtitle" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                標題:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請填寫標題!"
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
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>
