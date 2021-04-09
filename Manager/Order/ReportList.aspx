<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="ReportList.aspx.cs" Inherits="Manager_Order_ReportList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler)
        }
        function EndRequestHandler() {
            $(function () {
                $(".colorbox").colorbox({ width: "80%", height: "90%", iframe: true });
            });
        }
        $(document).ready(function () {
            $(".colorbox").colorbox({ width: "80%", height: "90%", iframe: true });
        });
    </script>
    <link href="../../_assets/css/panel.css" rel="stylesheet" type="text/css" />
    <link href="../../_assets/css/filter.css" rel="stylesheet" type="text/css" />
    <link href="../../_assets/css/grid.css" rel="stylesheet" type="text/css" />
    <link href="../../_assets/css/pager.css" rel="stylesheet" type="text/css" />
    <link href="../../_assets/css/thickbox.css" rel="stylesheet" type="text/css" />
    <div id="message" runat="server" class="OkMsg" visible="false" style="width: 95%;
        height: auto;">
    </div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="RightTableTdSubheader2blue">
                <div class="radiodiv3">
                    <span>請選擇 :</span></div>
                <div class="radiodiv">
                    <asp:RadioButton ID="rbAll" GroupName="rb" runat="server" AutoPostBack="true" Checked="True"
                        OnCheckedChanged="rbAll_CheckedChanged" /></div>
                <span>全部資料</span>
                <div class="radiodiv">
                    <asp:RadioButton ID="rbMonth" GroupName="rb" runat="server" AutoPostBack="True" OnCheckedChanged="rbMonth_CheckedChanged" />
                    <br />
                    <div id="divMonth" runat="server" visible="false">
                        <asp:DropDownList ID="ddrMonthYear" runat="server">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddrMonthMonth" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <span>月報表</span>
                <div class="radiodiv">
                    <asp:RadioButton ID="rbYear" GroupName="rb" runat="server" AutoPostBack="True" OnCheckedChanged="rbYear_CheckedChanged" />
                    <div id="divYear" runat="server" visible="false">
                        <asp:DropDownList ID="ddrYear" runat="server" Height="16px">
                        </asp:DropDownList>
                    </div>
                </div>
                <span>年報表</span>
                <div class="radiodiv">
                    <asp:RadioButton ID="rbTimeThread" GroupName="rb" runat="server" AutoPostBack="true"
                        OnCheckedChanged="rbTimeThread_CheckedChanged" />
                    <br />
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate"
                        Format="yyyy/MM/dd">
                    </cc1:CalendarExtender>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate"
                        Format="yyyy/MM/dd">
                    </cc1:CalendarExtender>
                    <div id="divDate" runat="server" visible="false">
                        <asp:TextBox ID="txtStartDate" Width="80" runat="server"></asp:TextBox>～
                        <asp:TextBox ID="txtEndDate" Width="80" runat="server"></asp:TextBox>
                    </div>
                </div>
                <span>時間區間報表</span>
                <div class="radiodiv2">
                    &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" CssClass="input5" Text="Search"
                        OnClick="Button1_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="RightTableTdContent">
                <br />
                <div id="dlg" class="panel" style="width: 786px">
                    <div class="header" style="cursor: default">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                    <br />
                                    &nbsp;<asp:Label ID="lbTimeMessage" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="body">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                    <table class="grid" style="width: 100%">
                                        <tr style="background-color: Gray">
                                            <td>
                                                訂單統計項目
                                            </td>
                                            <td>
                                                筆數
                                            </td>
                                            <td>
                                                金額(不含運費)
                                            </td>
                                            <td>
                                                總金額
                                            </td>
                                        </tr>
                                        <tr class="altrow">
                                            <td>
                                                所有訂單金額
                                            </td>
                                            <td>
                                                <asp:Label ID="lbCount1" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbSubTotal1" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbGrandTotal1" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <%--           <tr class="row">
                                            <td>
                                                有效訂單總金額(扣除無效、已取消、未付款)
                                            </td>
                                            <td>
                                                <asp:Label ID="lbCount2" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbSubTotal2" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbGrandTotal2" runat="server"></asp:Label>
                                            </td>
                                        </tr>--%>
                                        <%--                                       <tr class="altrow">
                                            <td>
                                                無效訂單(格是錯誤或是LAG、BUG所產生)
                                            </td>
                                            <td>
                                                <asp:Label ID="lbCount3" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbSubTotal3" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbGrandTotal3" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="row">
                                            <td>
                                                已取消訂單總金額
                                            </td>
                                            <td>
                                                <asp:Label ID="lbCount4" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbSubTotal4" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbGrandTotal4" runat="server"></asp:Label>
                                            </td>
                                        </tr>--%>
                                        <tr class="altrow">
                                            <td>
                                                未付款有效訂單
                                            </td>
                                            <td>
                                                <asp:Label ID="lbCount5" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbSubTotal5" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbGrandTotal5" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="row">
                                            <td>
                                                已出貨有效訂單
                                            </td>
                                            <td>
                                                <asp:Label ID="lbCount6" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbSubTotal6" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbGrandTotal6" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                    <%--                    <tr style="background-color: Gray">
                                            <td>
                                                <span>會員統計項目</span>
                                            </td>
                                            <td>
                                                <span>筆數</span>
                                            </td>
                                            <td>
                                                <span>金額(不含運費)</span>
                                            </td>
                                            <td>
                                                <span>總金額</span>
                                            </td>
                                        </tr>--%>
                                        <%--                                      <tr class="altrow">
                                            <td>
                                                非會員有效消費金額
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr class="row">
                                            <td>
                                                免費會員消費有效金額
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>--%>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="footer">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
                                        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataOrderDate"
                                        TypeName="OrderTableAdapters.OrderTableAdapter" UpdateMethod="Update">
                                        <DeleteParameters>
                                            <asp:Parameter Name="Original_o_id" Type="Int32" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="o_number" Type="String" />
                                            <asp:Parameter Name="o_type" Type="String" />
                                            <asp:Parameter Name="otc_id" Type="Int32" />
                                            <asp:Parameter Name="p_cls_id" Type="Int32" />
                                            <asp:Parameter Name="m_id" Type="Int32" />
                                            <asp:Parameter Name="o_name" Type="String" />
                                            <asp:Parameter Name="o_mail" Type="String" />
                                            <asp:Parameter Name="o_account_number" Type="String" />
                                            <asp:Parameter Name="o_phone1" Type="String" />
                                            <asp:Parameter Name="o_phone2" Type="String" />
                                            <asp:Parameter Name="o_zipCode" Type="String" />
                                            <asp:Parameter Name="o_city" Type="String" />
                                            <asp:Parameter Name="o_address" Type="String" />
                                            <asp:Parameter Name="o_detail" Type="String" />
                                            <asp:Parameter Name="o_detail_date" Type="String" />
                                            <asp:Parameter Name="o_detail_time" Type="String" />
                                            <asp:Parameter Name="o_payMethod" Type="String" />
                                            <asp:Parameter Name="o_check_Order" Type="Boolean" />
                                            <asp:Parameter Name="o_check_Read" Type="Boolean" />
                                            <asp:Parameter Name="o_check_Pay" Type="Boolean" />
                                            <asp:Parameter Name="o_check_Out" Type="Boolean" />
                                            <asp:Parameter Name="o_out_Date" Type="String" />
                                            <asp:Parameter Name="o_cancel" Type="Boolean" />
                                            <asp:Parameter Name="o_order_info" Type="String" />
                                            <asp:Parameter Name="o_totalPrice" Type="Int32" />
                                            <asp:Parameter Name="o_ts" Type="DateTime" />
                                            <asp:Parameter Name="o_editDate" Type="DateTime" />
                                            <asp:Parameter Name="o_inv_chk" Type="String" />
                                            <asp:Parameter Name="o_inv_id" Type="String" />
                                            <asp:Parameter Name="o_inv_title" Type="String" />
                                        </InsertParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="o_number" Type="String" />
                                            <asp:Parameter Name="o_type" Type="String" />
                                            <asp:Parameter Name="otc_id" Type="Int32" />
                                            <asp:Parameter Name="p_cls_id" Type="Int32" />
                                            <asp:Parameter Name="m_id" Type="Int32" />
                                            <asp:Parameter Name="o_name" Type="String" />
                                            <asp:Parameter Name="o_mail" Type="String" />
                                            <asp:Parameter Name="o_account_number" Type="String" />
                                            <asp:Parameter Name="o_phone1" Type="String" />
                                            <asp:Parameter Name="o_phone2" Type="String" />
                                            <asp:Parameter Name="o_zipCode" Type="String" />
                                            <asp:Parameter Name="o_city" Type="String" />
                                            <asp:Parameter Name="o_address" Type="String" />
                                            <asp:Parameter Name="o_detail" Type="String" />
                                            <asp:Parameter Name="o_detail_date" Type="String" />
                                            <asp:Parameter Name="o_detail_time" Type="String" />
                                            <asp:Parameter Name="o_payMethod" Type="String" />
                                            <asp:Parameter Name="o_check_Order" Type="Boolean" />
                                            <asp:Parameter Name="o_check_Read" Type="Boolean" />
                                            <asp:Parameter Name="o_check_Pay" Type="Boolean" />
                                            <asp:Parameter Name="o_check_Out" Type="Boolean" />
                                            <asp:Parameter Name="o_out_Date" Type="String" />
                                            <asp:Parameter Name="o_cancel" Type="Boolean" />
                                            <asp:Parameter Name="o_order_info" Type="String" />
                                            <asp:Parameter Name="o_totalPrice" Type="Int32" />
                                            <asp:Parameter Name="o_ts" Type="DateTime" />
                                            <asp:Parameter Name="o_editDate" Type="DateTime" />
                                            <asp:Parameter Name="o_inv_chk" Type="String" />
                                            <asp:Parameter Name="o_inv_id" Type="String" />
                                            <asp:Parameter Name="o_inv_title" Type="String" />
                                            <asp:Parameter Name="Original_o_id" Type="Int32" />
                                        </UpdateParameters>
                                    </asp:ObjectDataSource>
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="Div1" class="panel" style="width: 786px">
                    <div class="header" style="cursor: default">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                    <br />
                                    <span>&nbsp;訂單資訊</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="body">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        CssClass="grid" OnPageIndexChanged="GridView1_PageIndexChanged" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                        DataKeyNames="o_id" OnRowDataBound="GridView1_RowDataBound" DataSourceID="ObjectDataSource1"
                                        AllowSorting="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="訂單編號" SortExpression="o_number">
                                                <ItemTemplate>
                                                    <a id="btnShowPopup" runat="server" class="colorbox" title='<%#Eval("o_name") %>'
                                                        href='<%#Eval("o_id","View.aspx?ID={0}&TB_iframe=true&height=600&width=800") %>'>
                                                        <%#Eval("o_number")%></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="o_totalPrice" HeaderText="金額(不含運費)" SortExpression="o_totalPrice" />
                                            <asp:TemplateField HeaderText="總金額" SortExpression="otc_id">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hfTranCost" runat="server" Value='<%#Eval("otc_cost") %>' />
                                                    <asp:Literal ID="litGrandTotal" runat="server" Text='<%#Eval("o_totalPrice")%>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="付款" SortExpression="o_check_Pay">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbPay" runat="server" Text='<%# Bind("o_check_Pay") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="出貨" SortExpression="o_check_Out">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbSendOut" runat="server" Text='<%# Bind("o_check_Out") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="o_ts" DataFormatString="{0:yyyy/MM/dd}" HeaderText="下單日期"
                                                SortExpression="o_ts" />
                                        </Columns>
                                        <PagerTemplate>
                                            <asp:Label ID="Label3" runat="server" Text="顯示幾筆:" />
                                            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="GvCustomers_SelectedIndexChanged">
                                                <asp:ListItem Value="5" />
                                                <asp:ListItem Value="10" />
                                                <asp:ListItem Value="15" />
                                                <asp:ListItem Value="20" />
                                            </asp:DropDownList>
                                            &nbsp; 目前頁數
                                            <asp:TextBox ID="txtGoToPage" runat="server" AutoPostBack="true" OnTextChanged="GoToPage_TextChanged"
                                                CssClass="gotopage" />
                                            共
                                            <asp:Label ID="lblTotalNumberOfPages" runat="server" />
                                            &nbsp;頁&nbsp;
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Page" ToolTip="First Page"
                                                CommandArgument="First" ImageUrl="~/_assets/img/first.gif" />
                                            <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Page" ToolTip="Previous Page"
                                                CommandArgument="Prev" ImageUrl="~/_assets/img/prev.gif" />
                                            <asp:ImageButton ID="ImageButton3" runat="server" CommandName="Page" ToolTip="Next Page"
                                                CommandArgument="Next" ImageUrl="~/_assets/img/next.gif" />
                                            <asp:ImageButton ID="ImageButton4" runat="server" CommandName="Page" ToolTip="Last Page"
                                                CommandArgument="Last" ImageUrl="~/_assets/img/last.gif" />
                                        </PagerTemplate>
                                        <HeaderStyle CssClass="filter" />
                                        <RowStyle CssClass="row" />
                                        <PagerStyle CssClass="pager" />
                                        <AlternatingRowStyle CssClass="altrow" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="footer">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
