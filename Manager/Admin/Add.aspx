<%@ Page Language="C#" ValidateRequest="false"  MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Manager_Admin_Add" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="RightTableTdTopmenu">
            <ul>
                <li id="toplink1" title="文章欄位管理"><span><a href="List.aspx">列表</a></span></li>
                <li id="toplink2active" title="增加文章"><span><a href="#">新增</a></span></li>
                <li id="toplink3"  title="查看與修改文章"><span></li>
                <li id="toplink5" title="生成HTML文件"><a href="#"><span></span></a></li>
            </ul>
    </div>
    <div class="RightTableTdSubheader2">
        新增
    </div>
        <div class="RightTableTdContent">

            <div class="cleandiv1">
            </div>
            <div class="contentdiv4">
            <div class="contentdiv1left">
                    部門:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ErrorMessage="請填寫部門!" SetFocusOnError="True" ControlToValidate="txtName">*</asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtName" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="contentdiv4">
            <div class="contentdiv1left">
                    名稱:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ErrorMessage="請填寫名稱!" SetFocusOnError="True" ControlToValidate="txtNickName">*</asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtNickName" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="contentdiv4">
            <div class="contentdiv1left">
                    帳號:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="請填寫帳號!" SetFocusOnError="True" ControlToValidate="txtAccount">*</asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtAccount" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="contentdiv4">
            <div class="contentdiv1left">
                    密碼:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ErrorMessage="請填寫密碼!" SetFocusOnError="True" ControlToValidate="txtPass">*</asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtPass" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    建立日期:&nbsp;</div>
                <div class="contentdiv1right">
                <asp:TextBox ID="txtDate" Enabled="false" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="contentdiv3">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="True" ShowSummary="False" />
                <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
            </div>
                   </div>
</asp:Content>