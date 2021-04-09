<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Manager_Member_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>會員詳細資訊</title>
    <link rel="stylesheet" href="../../css/env/css/common.css" type="text/css" />
    <link rel="stylesheet" href="../../css/env/css/common-ie.css" type="text/css" />
    <link href="../../css/env/css/sample.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="RightTableTdContent_view">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phaccount" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    會員帳號:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbaccount" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phlevel" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    等級:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lblevel" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phname" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    姓名:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbName" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phsex" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    性別:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbsex" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phbirthday" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    生日:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbbirthday" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phaddress" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    地址:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbAddress" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phphone1" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    電話1:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbPhone1" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phphone2" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    電話2:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbPhone2" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phnickname" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    匿稱:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbnickname" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phnumber" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    編號:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbnumber" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmail" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    信箱:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbmail" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phlogintime" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    造訪數:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbLoginCount" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phnote" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    備註:
                </div>
                <div class="contentdiv1right">
                    <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phcreatedate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    建立時間:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbCreateDate" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="pheditdate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    修改時間:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbEditDate" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phlastlogindate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    最後登入時間:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbLastlogindate" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phcheckcode" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    註冊:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbregist" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="pheaper" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    訂閱電子報:</div>
                <div class="contentdiv1right">
                    <asp:RadioButtonList ID="rbEaper" runat="server" Width="231px" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="true">是</asp:ListItem>
                        <asp:ListItem Value="false">否</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phblock" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    停權:</div>
                <div class="contentdiv1right">
                    <asp:RadioButtonList ID="rbBlock" runat="server" Width="231px" RepeatDirection="Horizontal">
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
