<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="Edit.aspx.cs" Inherits="Manager_FriendLinkCategory_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenuorange">
        <ul>
            <li id="toplink11" title="列表"><a href="list.aspx">列表</a></li>
            <li id="toplink21" title="新增"><a href="add.aspx">新增</a></li>
            <li id="toplink31active" title="增加產品"><a href="#">修改</a></li>
            <%--<li id="toplink41" title="查看與修改產品"><a href="#"></a></li>--%>
        </ul>
    </div>
    <div class="RightTableTdSubheader2orange">
        職稱-修改
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <div style="text-align: center">
                            <img src="../../img/loading.gif" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:PlaceHolder ID="phname" runat="server">
                    <div class="contentdiv4">
                        <div class="contentdiv1left">
                            職稱:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請填寫職稱!"
                                SetFocusOnError="True" ControlToValidate="txtName">*</asp:RequiredFieldValidator>
                            &nbsp;</div>
                        <div class="contentdiv1right">
                            <div class="specialdivfix1">
                                <asp:TextBox ID="txtName" runat="server" CssClass="input1"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </asp:PlaceHolder>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:PlaceHolder ID="phcreatedate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    建立日期: &nbsp;</div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbCreate" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <%--<asp:PlaceHolder ID="phshow" runat="server">
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
        </asp:PlaceHolder>--%>
        <div class="contentdiv3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <asp:Button ID="Button1" runat="server" Text="修改" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>
