<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="Add.aspx.cs" Inherits="Manager_GBMessage_Add" ValidateRequest="false" %>

<%@ Register Src="../../UserControl/public/Ckeditorl.ascx" TagName="Ckeditorl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenu">
        <ul>
            <li id="toplink1" title="文章欄位管理"><span><a href="List.aspx">列表</a></span></li><li
                id="toplink2active" title="增加文章"><span><a href="#">新增</a></span></li><li id="toplink3"
                    title="查看與修改文章"><span></span></li>
            <li id="toplink5" title="生成HTML文件"><a href="#"><span></span></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2">
        留言版文章-新增
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phcategory" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    文章類別:&nbsp;</div>
                <div class="contentdiv1right">
                    <asp:DropDownList ID="ddlCategory" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phname" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    姓名:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="請填寫標題!"
                        SetFocusOnError="True" ControlToValidate="txtName">*</asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtName" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmail" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    信箱:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="請填寫標題!"
                        SetFocusOnError="True" ControlToValidate="txtName">*</asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtMail" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phtitle" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    標題:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="請填寫標題!"
                        SetFocusOnError="True" ControlToValidate="txtName">*</asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <div class="contentdiv2">
            <asp:PlaceHolder ID="phshowmail" runat="server">
                <div class="contentdiv2left">
                    是否顯示:
                </div>
                <div class="contentdiv2right">
                    <asp:CheckBox ID="ChkVisible" runat="server" Font-Size="Small" Text="是:請點選" />
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phcontent" runat="server">
                <div class="contentdiv2left">
                    内容:
                </div>
                <div class="contentdiv2right">
                    <uc1:Ckeditorl ID="Ckeditorl1" runat="server" />
                </div>
            </asp:PlaceHolder>
        </div>
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
