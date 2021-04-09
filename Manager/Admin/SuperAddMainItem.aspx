<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Manager/ManagerPage.master"
    AutoEventWireup="true" CodeFile="SuperAddMainItem.aspx.cs" Inherits="Manager_Admin_SuperAddMainItem"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenu">
        <ul>
            <li id="toplink1" title="主項目列表"><span><a href="SuperItemEditList.aspx">列表</a></span></li><li
                id="toplink2active" title="增加文章"><span><a href="SuperAddSubItem.aspx">新增子功能</a></span></li><li
                    id="toplink3" title="查看與修改文章"></li>
            <li id="toplink5" title="生成HTML文件"><a href="#"><span></span></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2">
        主項目-新增
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <div class="contentdiv1">
            <div class="contentdiv1left">
                主項目名稱:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="請填寫名稱!"
                    SetFocusOnError="True" ControlToValidate="TextBox_Name">*</asp:RequiredFieldValidator>
                &nbsp;</div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="TextBox_Name" runat="server" CssClass="input1"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="contentdiv1">
            <div class="contentdiv1left">
                別名:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請填寫別名!"
                    SetFocusOnError="True" ControlToValidate="txtNickname">*</asp:RequiredFieldValidator>
                &nbsp;</div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="txtNickname" runat="server" CssClass="input1"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="contentdiv3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>
