<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Manager_News_NewsView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>訊息檢視頁面</title>
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
                   發文者:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbCategory" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phtitle" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    標題:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbTitle" runat="server" Width="400"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phhits" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    瀏覽數:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbHits" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phdetail" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv2left">
                    內容:
                </div>
                <div class="contentdiv2right">
                    <asp:Label ID="litContent" runat="server" Text="" Width="200" Height="200"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phimg" runat="server">
            <div class="contentdiv4_Img">
                <div class="contentdiv1left">
                    展示圖片:
                </div>
                <div class="contentdiv1right">
                    <asp:Image ID="img1" runat="server" Style="border: 0px; width: 150px;" />
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phcreatedate" runat="server">
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
        <asp:PlaceHolder ID="phstartdate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    發佈日期:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbStartdate" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phenddate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    結束日期:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbEnddate" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phrpimage" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv2left">
                    附加圖片:
                </div>
                <div class="contentdiv2right">
                    <asp:Repeater ID="rpImage" runat="server">
                        <ItemTemplate>
                            <asp:Image ID="Image1" Width="100" runat="server" ImageUrl='<%#Tools.GetAppSettings("NewsImageTruePath")+Eval("np_name")%>' />&nbsp;&nbsp;
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
