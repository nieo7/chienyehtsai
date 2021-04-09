<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Manager_News_NewsView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>廣告檢視頁面</title>
    <link rel="stylesheet" href="../../css/env/css/common.css" type="text/css" />
    <link rel="stylesheet" href="../../css/env/css/common-ie.css" type="text/css" />
    <link href="../../css/env/css/sample.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">    
        <div class="RightTableTdContent_view">
            <div class="cleandiv1">
            </div>
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    廣告類別:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbCategory" runat="server"></asp:Label>
                </div>
            </div>
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    廣告位置:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbLocation" runat="server"></asp:Label>
                </div>
            </div>
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    廣告客戶:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbCustomer" runat="server"></asp:Label>
                </div>
            </div>
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    廣告標題:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbTitle" runat="server"></asp:Label>
                </div>
            </div>
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    廣告網址:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbWebUrl" runat="server"></asp:Label>
                </div>
            </div>
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    廣告價格:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbPrice" runat="server"></asp:Label>
                </div>
            </div>
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    顯示機率:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbProb" runat="server"></asp:Label>
                </div>
            </div>
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    連結顯示方式:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbTarget" runat="server"></asp:Label>
                </div>
            </div>
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    點擊數:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbHits" runat="server"></asp:Label>
                </div>
            </div>
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    建立日期:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbCreateDate" runat="server"></asp:Label>
                </div>
            </div>
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    修改日期:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbEditDate" runat="server"></asp:Label>
                </div>
            </div>
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    啟始日期:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbStartDate" runat="server"></asp:Label>
                </div>
            </div>
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    結束日期:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbEndDate" runat="server"></asp:Label>
                </div>
            </div>
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    附加圖片:
                </div>
                <div class="contentdiv1right">
                    <asp:Repeater ID="rpImage" runat="server">
                        <ItemTemplate>
                            <asp:Image ID="Image1" Width="100" runat="server" ImageUrl='<%#Tools.GetAppSettings("BannerImageTruePath")+Eval("bp_image")%>' />&nbsp;&nbsp;
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>    
    </form>
</body>
</html>
