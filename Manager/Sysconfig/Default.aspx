<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Manager/ManagerPage.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Manager_SysConfig_Default"
    Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader1" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="message" runat="server" class="OkMsg" visible="false" style="width: 95%;
        height: auto;">
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="RightTableTdContent">
                <br />
                <div id="dlg" class="panel" style="width: 786px">
                    <div class="header" style="cursor: default">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                    <br />
                                    &nbsp;<asp:Label ID="lbTimeMessage" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="body">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                    <table class="grid" style="width: 100%">
                                        <tr style="background-color: Gray">
                                            <td>
                                                項目
                                            </td>
                                            <td>
                                                次項目
                                            </td>
                                        </tr>
                                        <tr class="altrow">
                                            <td>
                                                使用者帳號
                                            </td>
                                            <td>
                                                <asp:Label ID="lbAcc" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="row">
                                            <td>
                                                使用者單位
                                            </td>
                                            <td>
                                                <asp:Label ID="lbName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="altrow">
                                            <td>
                                                使用者暱稱
                                            </td>
                                            <td>
                                                <asp:Label ID="lbNickName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="row">
                                            <td>
                                                登入IP
                                            </td>
                                            <td>
                                                <asp:Label ID="lbIp" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="altrow">
                                            <td>
                                                最後修改時間
                                            </td>
                                            <td>
                                                <asp:Label ID="lbEditTime" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="row">
                                            <td>
                                                最後登入時間
                                            </td>
                                            <td>
                                                <asp:Label ID="lbinit_time" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="footer">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
