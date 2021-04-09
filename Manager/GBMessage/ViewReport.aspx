<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewReport.aspx.cs" Inherits="Manager_GBMessage_ViewReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../css/env/css/common.css" type="text/css" />
    <link rel="stylesheet" href="../../css/env/css/common-ie.css" type="text/css" />
    <link href="../../css/env/css/sample.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../js/humanmsg.js" type="text/javascript"></script>
    <link href="../../css/humanmsg.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="RightTableTdContent_view">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phcategory" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    文章類別:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbCategory" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phtitle" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    標題:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbTitle" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phrpgbre" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv2left">
                    文章回應:
                </div>
                <div class="contentdiv2right">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table id="bi_table" width="100%" border="1" cellpadding="0" cellspacing="0" bordercolor="#FF99CC">
                                <tr>
                                    <th bgcolor="#eb88b5" width="60%">
                                        內容
                                    </th>
                                    <th bgcolor="#eb88b5" width="10%">
                                        姓名
                                    </th>
                                    <th bgcolor="#eb88b5" width="20%">
                                        發佈時間
                                    </th>
                                    <th bgcolor="#eb8a8b5" width="10%">
                                        刪除
                                    </th>
                                </tr>
                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
                                    OnItemDataBound="Repeater1_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="60%">
                                                <asp:Literal ID="litTitle" runat="server" Text='<%#Eval("g_content") %>'></asp:Literal>
                                            </td>
                                            <td width="10%" align="right">
                                                <asp:Literal ID="litSubtotal" runat="server" Text='<%#Eval("g_name") %>'></asp:Literal>
                                            </td>
                                            <td width="10%" align="right">
                                                <asp:Literal ID="litDate" runat="server" Text='<%#Eval("g_adddate") %>'></asp:Literal>
                                            </td>
                                            <td width="10%" align="center">
                                                <asp:Button ID="Button2" runat="server" CommandArgument='<%#Eval("g_id") %>' CommandName="myDelete"
                                                    CssClass="inputx2" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <hr />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
