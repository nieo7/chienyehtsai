<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="List.aspx.cs" Inherits="Manager_Products_List" %>

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
    <div id="message" runat="server" class="OkMsg" visible="false" style="width: 95%;
        height: auto;">
    </div>
    <div class="RightTableTdTopmenublue">
        <ul>
            <li id="toplink1active" title="文章欄位管理"><a href="#">列表</a></li>
            <li id="toplink2" title="增加"><a href="Add.aspx">新增</a></li>
            <li id="toplink4" title="模板管理"><a href="#"></a></li>
            <li id="toplink5" title="生成HTML文件"><a href="#"></a></li>
        </ul>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="RightTableTdSubheader2blue">
                <div class="radiodiv3">
                    <span>請選擇 :</span>&nbsp;<asp:TextBox ID="txtKeyWord" CssClass="input4" runat="server"></asp:TextBox>
                    &nbsp;</div>
                <div class="radiodiv">
                    <asp:Button ID="Button1" runat="server" CssClass="input5" Text="Search" OnClick="Button1_Click" /></div>
            </div>
            <div class="RightTableTdContent">
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetProductWithCategoryBylidOrderSortingAndPcID" TypeName="ProductsTableAdapters.ProductTableAdapter"
                    DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_p_id" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="pc_id" Type="Int32" />
                        <asp:Parameter Name="pcs_id" Type="Int32" />
                        <asp:Parameter Name="p_name" Type="String" />
                        <asp:Parameter Name="p_serial" Type="String" />
                        <asp:Parameter Name="p_status" Type="Int32" />
                        <asp:Parameter Name="p_show" Type="Boolean" />
                        <asp:Parameter Name="p_show_hot" Type="Boolean" />
                        <asp:Parameter Name="p_detail" Type="String" />
                        <asp:Parameter Name="p_stock" Type="Int32" />
                        <asp:Parameter Name="p_stock_unit" Type="String" />
                        <asp:Parameter Name="p_price1" Type="Int32" />
                        <asp:Parameter Name="p_price2" Type="String" />
                        <asp:Parameter Name="p_price3" Type="String" />
                        <asp:Parameter Name="p_price4" Type="String" />
                        <asp:Parameter Name="p_price5" Type="String" />
                        <asp:Parameter Name="p_createDate" Type="DateTime" />
                        <asp:Parameter Name="p_editDate" Type="DateTime" />
                        <asp:Parameter Name="p_hits" Type="Int32" />
                        <asp:Parameter Name="p_sorting" Type="Int32" />
                        <asp:Parameter Name="p_img" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:Parameter Name="l_id" Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="pc_id" Type="Int32" />
                        <asp:Parameter Name="pcs_id" Type="Int32" />
                        <asp:Parameter Name="p_name" Type="String" />
                        <asp:Parameter Name="p_serial" Type="String" />
                        <asp:Parameter Name="p_status" Type="Int32" />
                        <asp:Parameter Name="p_show" Type="Boolean" />
                        <asp:Parameter Name="p_show_hot" Type="Boolean" />
                        <asp:Parameter Name="p_detail" Type="String" />
                        <asp:Parameter Name="p_stock" Type="Int32" />
                        <asp:Parameter Name="p_stock_unit" Type="String" />
                        <asp:Parameter Name="p_price1" Type="Int32" />
                        <asp:Parameter Name="p_price2" Type="String" />
                        <asp:Parameter Name="p_price3" Type="String" />
                        <asp:Parameter Name="p_price4" Type="String" />
                        <asp:Parameter Name="p_price5" Type="String" />
                        <asp:Parameter Name="p_createDate" Type="DateTime" />
                        <asp:Parameter Name="p_editDate" Type="DateTime" />
                        <asp:Parameter Name="p_hits" Type="Int32" />
                        <asp:Parameter Name="p_sorting" Type="Int32" />
                        <asp:Parameter Name="p_img" Type="String" />
                        <asp:Parameter Name="Original_p_id" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <br />
                <div id="dlg" class="panel" style="width: 786px">
                    <div class="header" style="cursor: default">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                    全選:
                                    <asp:Button ID="btnDel" runat="server" Text="全部刪除" OnClientClick="return confirm('確定刪除嗎?')"
                                        CssClass="input4" OnClick="btnDel_Click" /><asp:PlaceHolder ID="phpc" runat="server">&nbsp;
                                            類別:
                                            <asp:DropDownList ID="ddrCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddrCategory_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </asp:PlaceHolder>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="body">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                        <ProgressTemplate>
                                            <div style="text-align: center">
                                                <img src="../../img/loading.gif" />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        CssClass="grid" DataKeyNames="p_id" OnRowDataBound="GridView1_RowDataBound" DataSourceID="ObjectDataSource1"
                                        EnableModelValidation="True" EmptyDataText="此次查詢資料庫沒有資料">
                                        <Columns>
                                            <asp:TemplateField HeaderText="選擇" ItemStyle-Width="50px">
                                                <EditItemTemplate>
                                                </EditItemTemplate>
                                                <HeaderTemplate>
                                                    全選<br />
                                                    <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="True" />
                                                </ItemTemplate>
                                                <ItemStyle Width="50px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="p_id" HeaderText="文章編號" Visible="false" SortExpression="p_id">
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="產品首圖">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyImg" runat="server">
                                                        <asp:Image ID="Image1" runat="server" Width="50px" ImageUrl='<%#Tools.GetAppSettings("ProductImageTruePath")+Eval("p_img").ToString() %>' /></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="類型">
                                                <ItemTemplate>
                                                    <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("pc_name") %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="p_name" HeaderText="標題" SortExpression="p_name"></asp:BoundField>
                                            <asp:BoundField DataField="p_createDate" HeaderText="發佈時間" SortExpression="p_createDate"
                                                DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                                            <asp:TemplateField HeaderText="詳細資訊">
                                                <ItemTemplate>
                                                    <a class="colorbox" title='<%#Eval("p_name") %>' href='<%#Eval("p_id","View.aspx?id={0}") %>'>
                                                        詳細資訊</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="編輯">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyEdit" runat="server" NavigateUrl='<%# string.Format("Edit.aspx?id={0}",Eval("p_id")) %>'
                                                        Text="編輯"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:Button ID="Button2" runat="server" OnCommand="Button2_Command" CommandArgument='<%#Eval("p_id") %>'
                                                        CommandName="myDelete" CssClass="inputx2" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="顯示幾筆:" />
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
                                            <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                                <ProgressTemplate>
                                                    <div style="text-align: center">
                                                        <img src="../../img/loading.gif" />
                                                    </div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
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
