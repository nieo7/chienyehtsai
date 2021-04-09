<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="Edit.aspx.cs" Inherits="Manager_Order_Edit" %>

<%@ Register TagName="address1Tag" TagPrefix="address1Pre" Src="~/UserControl/public/Address.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenuorange">
        <ul>
            <li id="toplink11" title="新增"><a href="list.aspx">列表</a></li>
            <li id="toplink41" title="查看與修改產品"><a href="#"></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2orange">
        訂單-修改
    </div>
    <div class="RightTableTdContent">
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
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmail" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    客戶信箱:
                </div>
                <div class="contentdiv1right">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phaddress" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    客戶地址:
                </div>
                <div class="contentdiv1right_ajaxfileupload">
                    <address1Pre:address1Tag runat="server" ID="address1" />
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phphone1" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    客戶電話:
                </div>
                <div class="contentdiv1right">
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phphone2" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    客戶電話2:
                </div>
                <div class="contentdiv1right">
                    <asp:TextBox ID="txtPhone2" runat="server"></asp:TextBox>
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
                    <asp:Label ID="lbPS" runat="server"></asp:Label>
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
        <div class="contentdiv3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <asp:Button ID="Button1" runat="server" Text="修改" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>
