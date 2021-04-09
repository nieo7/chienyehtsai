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
                                                ����
                                            </td>
                                            <td>
                                                ������
                                            </td>
                                        </tr>
                                        <tr class="altrow">
                                            <td>
                                                �ϥΪ̱b��
                                            </td>
                                            <td>
                                                <asp:Label ID="lbAcc" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="row">
                                            <td>
                                                �ϥΪ̳��
                                            </td>
                                            <td>
                                                <asp:Label ID="lbName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="altrow">
                                            <td>
                                                �ϥΪ̼ʺ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lbNickName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="row">
                                            <td>
                                                �n�JIP
                                            </td>
                                            <td>
                                                <asp:Label ID="lbIp" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="altrow">
                                            <td>
                                                �̫�ק�ɶ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lbEditTime" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="row">
                                            <td>
                                                �̫�n�J�ɶ�
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
