<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Manager_BannerCustomer_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>廣告客戶資料檢視頁面</title>
    <link rel="stylesheet" href="../../css/env/css/common.css" type="text/css" />
    <link rel="stylesheet" href="../../css/env/css/common-ie.css" type="text/css" />
    <link href="../../css/env/css/sample.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="RightTableTdContent_view">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phnumber" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    客戶編號:</div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbNumber" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phcompanyname" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    公司名稱:</div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbCompanyname" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phcompanytype" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    公司類型:</div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbType" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phcompanyphone" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    公司電話:</div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbCompanyPhone" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phfax" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    公司傳真:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbfax" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phname" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    連絡人姓名:</div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbname" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phsex" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    連絡人性別:</div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbSex" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phphone" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    連絡人電話:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbPhone" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmail" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    連絡人信箱:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbMail" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phaddress" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    地址:&nbsp;</div>
                <div class="contentdiv1right_ajaxfileupload">
                    <asp:Label ID="lbAddress" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phnote" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    備註:
                </div>
                <div class="contentdiv1right">
                    <asp:Literal ID="litNote" runat="server"></asp:Literal>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phts" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    建立日期:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbts" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="pheditdate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    修改日期:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbEdit" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
