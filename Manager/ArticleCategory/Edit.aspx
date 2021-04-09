<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Manager/ManagerPage.master"
    AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Manager_ArticleCategory_Edit"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenuorange">
        <ul>
            <li id="toplink11" title="文章列表"><a href="list.aspx">列表</a></li>
            <li id="toplink21" title="增加新文章"><a href="add.aspx">新增</a></li>
            <li id="toplink31active" title="文章查看與修改"><a href="#">修改</a></li>
            <li id="toplink41" title="查看與修改文章"><a href="#"></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2orange">
        文章類別-修改
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phfather" runat="server">
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
        <asp:PlaceHolder ID="phtype" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    描述:</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtType" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <div class="contentdiv3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <asp:Button ID="Button1" runat="server" Text="修改" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>
