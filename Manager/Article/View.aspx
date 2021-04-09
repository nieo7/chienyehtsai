<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Manager_News_NewsView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文章檢視頁面</title>
    <link rel="stylesheet" href="../../css/env/css/common.css" type="text/css" />
    <link rel="stylesheet" href="../../css/env/css/common-ie.css" type="text/css" />
    <link href="../../css/env/css/sample.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="RightTableTdContent_view">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phfather" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    類別:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbCategory" runat="server" Text="此為主類別"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phname" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    標題:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbTitle" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phdetail" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv2left">
                    内容:
                </div>
                <div class="contentdiv2right">
                    <asp:Literal ID="litContent" runat="server"></asp:Literal>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phhits" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    瀏覽數:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbhits" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phts" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    建立日期:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbBuilddate" runat="server"></asp:Label>
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
        <asp:PlaceHolder ID="phrpimage" runat="server">
            <div class="contentdiv4_Img">
                <div class="contentdiv1left">
                    首圖:
                </div>
                <div class="contentdiv1right">
                    <asp:Image ID="Image1" Width="100" runat="server" />&nbsp;&nbsp;
                </div>
            </div>
            <div class="contentdiv2">
                <div class="contentdiv2left">
                    附加圖片:
                </div>
                <div class="contentdiv2right">
                    <asp:Repeater ID="rpImage" runat="server">
                        <ItemTemplate>
                            <asp:Image ID="Image1" Width="100" runat="server" ImageUrl='<%#Tools.GetAppSettings("ArticleTruePath")+Eval("ap_imagename")%>' />&nbsp;&nbsp;
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phshow" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    顯示於前台:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbShow" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
