<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Manager_Products_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>產品檢視頁面</title>
    <link rel="stylesheet" href="../../css/env/css/common.css" type="text/css" />
    <link rel="stylesheet" href="../../css/env/css/common-ie.css" type="text/css" />
    <link href="../../css/env/css/sample.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="RightTableTdContent_view">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phpc" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    產品類別:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbcategory" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phstate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    狀態:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbState" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phstock" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    庫存:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbstock" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phstockunit" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    庫存單位:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbstockunit" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phserial" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    型號:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbserial" runat="server"></asp:Label>
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
                    介紹內容:
                </div>
                <div class="contentdiv2right">
                    <asp:Label ID="lbContent" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phshowhot" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    設定為熱門商品:
                </div>
                <div class="contentdiv1right">
                    <asp:CheckBox ID="chkshowhot" runat="server" Enabled="false" />
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phprice1" runat="server">
            <div id="divPrice1" runat="server" class="contentdiv4">
                <div class="contentdiv1left">
                    原價:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbPrice1" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phprice2" runat="server">
            <div id="divPrice2" runat="server" class="contentdiv4">
                <div class="contentdiv1left">
                    售價:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbPrice2" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phprice3" runat="server">
            <div id="div1" runat="server" class="contentdiv4">
                <div class="contentdiv1left">
                    等級1:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbprice3" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phprice4" runat="server">
            <div id="div2" runat="server" class="contentdiv4">
                <div class="contentdiv1left">
                    等級2:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbprice4" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phprice5" runat="server">
            <div id="div3" runat="server" class="contentdiv4">
                <div class="contentdiv1left">
                    等級3:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbprice5" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phformat" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv2left">
                    產品規格:
                </div>
                <div class="contentdiv2right">
                    <asp:Repeater ID="rpFormat" runat="server">
                        <ItemTemplate>
                            <br />
                            <%#Eval("psf_name")+":"+Eval("psf_value") %><br />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phfile" runat="server">
            <div id="divFile1" runat="server" class="contentdiv2">
                <div class="contentdiv2left">
                    附加檔案:
                </div>
                <div class="contentdiv2right">
                    <asp:Repeater ID="rpDownload" runat="server">
                        <ItemTemplate>
                            <%#Eval("pd_name")%>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phrpImage" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv2left">
                    附加圖片:
                </div>
                <div class="contentdiv2right">
                    <asp:Repeater ID="rpImage" runat="server">
                        <ItemTemplate>
                            <asp:Image ID="Image1" Width="100" runat="server" ImageUrl='<%#Tools.GetAppSettings("ProductImageTruePath")+Eval("pi_image")%>' />&nbsp;&nbsp;
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phcreatedate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    發表日期:
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
                    <asp:Label ID="lbeditdate" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phshow" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    顯示於前台:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbshow" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
