<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Manager_OrderTransCost_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>運費項目詳細資訊</title>
    <link rel="stylesheet" href="../../css/env/css/common.css" type="text/css" />
    <link rel="stylesheet" href="../../css/env/css/common-ie.css" type="text/css" />
    <link href="../../css/env/css/sample.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="RightTableTdContent_view">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phname" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    名稱:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbName" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phcost" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    費用:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbPrice" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phdetail" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv2left">
                    内容:
                </div>
                <div class="contentdiv2right">
                    <asp:Literal ID="litDetail" runat="server"></asp:Literal>
                </div>
            </div>
        </asp:PlaceHolder>
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
    </div>
    </form>
</body>
</html>
