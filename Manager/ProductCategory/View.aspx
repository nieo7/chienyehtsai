<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Manager_ProductCategory_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>產品類別檢視頁面</title>
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
                    類別:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbcategory" runat="server" Text="此為主類別"></asp:Label>
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
        <asp:PlaceHolder ID="phimg" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    展示圖片:
                </div>
                <div class="contentdiv1right">
                    <asp:Image ID="img1" runat="server" Style="border: 0px" />
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
