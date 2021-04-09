<%@ Page Language="C#"  ValidateRequest="false" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Manager_News_Edit" Title="Untitled Page" %>

<asp:Content ID="Content1"  ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="RightTableTdTopmenuorange">
		<ul>
			<li id="toplink11" title="新增"><a href="list.aspx">列表</a></li>
		    <li id="toplink21" title="產品類別查看與修改"><a href="add.aspx">新增</a></li>
		    <li id="toplink31active" title="增加產品"><a href="#">修改</a></li>
		    <li id="toplink41" title="查看與修改產品"><a href="#"></a></li></ul>
			</div>	
			<div class="RightTableTdSubheader2orange">
                修改
			</div>
        <div class="RightTableTdContent">

            <div class="cleandiv1">
            </div>
            <div class="contentdiv4">
            <div class="contentdiv1left">
                    部門: &nbsp;</div>
                <div class="contentdiv1right"><div class="specialdivfix1">
                    <asp:TextBox ID="txtName" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
                        <div class="contentdiv4">
            <div class="contentdiv1left">
                    名稱:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ErrorMessage="請填寫名稱!" SetFocusOnError="True" ControlToValidate="txtName">*</asp:RequiredFieldValidator>
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
                    建立日期: &nbsp;</div>
                <div class="contentdiv1right">
                        <asp:TextBox ID="txtEditeDate" runat="server" CssClass="input1"></asp:TextBox>
                </div>
            </div>
            <div class="contentdiv3">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="True" ShowSummary="False" />
                <asp:Button ID="Button1" runat="server" Text="修改" OnClick="Button1_Click" />
            </div>
                   </div>
</asp:Content>