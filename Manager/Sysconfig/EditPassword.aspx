<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="EditPassword.aspx.cs" Inherits="Manager_Sysconfig_EditPassword" Debug="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHeader1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenuorange">
    </div>
    <div class="RightTableTdSubheader2orange">
        修改密碼:
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <div class="contentdiv2">
            <div class="contentdiv1left">
                帳號:</div>
            <div class="contentdiv1right">
                <asp:Label ID="lbaccount" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="contentdiv2">
            <div class="contentdiv1left">
                新密碼:</div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="txtEditPassword" runat="server" CssClass="input1" MaxLength="12"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtEditPassword" ErrorMessage="請設定密碼">*</asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="contentdiv2">
            <div class="contentdiv1left">
                確認密碼:</div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="txtCheckPassword" runat="server" CssClass="input1" MaxLength="12"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtCheckPassword" ControlToValidate="txtEditPassword" 
                        ErrorMessage="密碼不一致">*</asp:CompareValidator>
                </div>
            </div>
        </div>
        <div class="contentdiv2">
            <div class="contentdiv1left">
                修改日期:</div>
            <div class="contentdiv1right">                
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>                
            </div>
        </div>
        <div class="contentdiv3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" />
            <asp:Button ID="Button1" runat="server" Text="修改" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>
