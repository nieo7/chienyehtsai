<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="SystemConfigXml.aspx.cs" Inherits="Manager_Admin_SystemConfigXml" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdContent">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="width: 100%; text-align: center">
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="遞迴階層值設定" Font-Bold="True" Font-Names="Times New Roman"
                        Font-Size="15pt" ForeColor="Blue"></asp:Label>
                </div>
                <div style="margin: 0px auto 0px; text-align: center">
                    <table cellspacing="0" cellpadding="4" rules="all" border="1" id="FormView1" style="background-color: White;
                        border-color: #CC9966; border-width: 1px; border-style: None; border-collapse: collapse;
                        width: 100%">
                        <tr style="color: #663399; background-color: #FFCC66; font-weight: bold;">
                            <td>                                                                
                                    <div style="width: 100px; float: left; padding: 0px 0px 0px 250px;">
                                        ProductCategory:</div>
                                    <div style="width: 60%">
                                        <asp:DropDownList ID="ddlProductCategory" runat="server">
                                        </asp:DropDownList>
                                    </div>                                
                                <hr />
                                <div style="width: 100px; float: left; padding: 0px 0px 0px 250px;">
                                    ArticleCategory:</div>
                                <div style="width: 60%">
                                    <asp:DropDownList ID="ddlArticleCategory" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <hr />
                                <div style="width: 100px; float: left; padding: 0px 0px 0px 250px;">
                                    NewsCategory:</div>
                                <div style="width: 60%">
                                    <asp:DropDownList ID="ddlNewsCategory" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <hr />
                                <div style="width: 100px; float: left; padding: 0px 0px 0px 250px;">
                                    BannerLocation:</div>
                                <div style="width: 60%">
                                    <asp:DropDownList ID="ddlBannerLocation" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <hr />
                                <div style="width: 100%; text-align: center">
                                    <asp:Button ID="Button1" runat="server" Text="更新" OnClick="Button1_Click" />
                                    <asp:Button ID="Button2" runat="server" Text="還原" OnClick="Button2_Click" />
                                </div>
                                <div style="width: 100%; float: left">
                                    <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
