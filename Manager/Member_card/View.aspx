<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Manager_Member_card_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>會員卡詳細資訊</title>
    <link rel="stylesheet" href="../../css/env/css/common.css" type="text/css" />
    <link rel="stylesheet" href="../../css/env/css/common-ie.css" type="text/css" />
    <link href="../../css/env/css/sample.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="RightTableTdContent_view">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phmcnumber" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    卡片編號:</div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbCardNumber" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmcpassword" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    卡片密碼:</div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbPAss" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmcstatus" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    開卡狀態:</div>
                <div class="contentdiv1right">
                    <asp:DropDownList ID="ddlLevel" runat="server">
                        <asp:ListItem Text="未開通" Value="1"></asp:ListItem>
                        <asp:ListItem Text="已開通" Value="2"></asp:ListItem>
                        <asp:ListItem Text="已註銷" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmcnote" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    備註:
                </div>
                <div class="contentdiv1right">
                    <asp:TextBox ID="txtContact" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmcadddate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    建立時間:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbCreateDate" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmceditdate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    修改時間:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbEditDate" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
