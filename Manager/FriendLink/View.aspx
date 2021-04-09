<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Manager_FriendLink_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>專業團隊檢視頁面</title>
    <link rel="stylesheet" href="../../css/env/css/common.css" type="text/css" />
    <link rel="stylesheet" href="../../css/env/css/common-ie.css" type="text/css" />
    <link href="../../css/env/css/sample.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="RightTableTdContent_view">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phcategory" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    職稱:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbcategory" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phtitle" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    姓名:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbTitle" runat="server"></asp:Label>&nbsp;&nbsp;<asp:Label ID="lbName" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    學歷:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbDegree" runat="server" Width="500" Height="150"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    經歷:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbHistory" runat="server" Width="500" Height="150"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder3" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    著作:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbBooks" runat="server" Width="300" Height="150"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder4" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    法律專長:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbSpecialty" runat="server" Width="300" Height="150"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder5" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    E-mail:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbEmail" runat="server" Width="300" Height="150"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder6" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    分機號碼:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbPhone" runat="server" Width="300" Height="150"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <%--<asp:PlaceHolder ID="phurl" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    Url:
                </div>
                <div class="contentdiv1right">
                    <asp:HyperLink ID="hyUrl" runat="server"></asp:HyperLink>
                </div>
        </asp:PlaceHolder>--%>
         <asp:PlaceHolder ID="phstartdate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    建立日期:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbStartdate" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="pheditdate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    修改日期:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbEditDate" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phimage" runat="server">
            <div class="contentdiv4_Img">
                <div class="contentdiv1left">
                    圖片:
                </div>
                <div class="contentdiv1right">
                    <asp:Image ID="Image1" Width="100" runat="server" />&nbsp;&nbsp;
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
    </div>
    </div>
    </form>
</body>
</html>
