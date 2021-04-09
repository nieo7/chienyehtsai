<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Manager_Order_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>訂單檢視頁面</title>
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
                    訂單編號:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbNumber" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phname" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    客戶姓名:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbTitle" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmail" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    客戶信箱:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbEmail" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phaddress" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    客戶地址:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbAddress" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phphone1" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    客戶電話:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbPhone" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
                <asp:PlaceHolder ID="phphone2" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    客戶電話2:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbPhone2" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phcheckread" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    是否閱讀:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbRead" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phcheckpay" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    是否付款:
                </div>
                <div class="contentdiv1right">
                    <asp:RadioButtonList ID="rbCheckPay" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="False" Selected="True">未付款</asp:ListItem>
                        <asp:ListItem Value="True">已付款</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phcheckout" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    是否出貨:
                </div>
                <div class="contentdiv1right">
                    <asp:RadioButtonList ID="rbCheckOut" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="False" Selected="True">未出貨</asp:ListItem>
                        <asp:ListItem Value="True">已出貨</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phsubtotal" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    小計:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbSubTotal" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phtranscost" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    運費:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbTransCost" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phgrandtotal" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    總計:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbGrandTotal" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phcreatedate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    下單日期:
                </div>
                <div class="contentdiv1right">
                    <asp:Label ID="lbCreateDate" runat="server"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phdetail" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv2left">
                    其他備註:
                </div>
                <div class="contentdiv1right">
                    <asp:Literal ID="litDetail" runat="server"></asp:Literal>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phshowproduct" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv2left">
                    產品:
                </div>
                <div class="contentdiv2right">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" Width="400px">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="p_name" HeaderText="產品名稱">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="od_unitPrice" HeaderText="單價">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="od_quantity" HeaderText="數量">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </div>
            </div>
        </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
