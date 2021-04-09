<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="List.aspx.cs" Inherits="Manager_GBMessage_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".colorbox").colorbox({ width: "90%", height: "100%", iframe: true });
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
                    SelectMethod="GetDataWithGBcategoryOrderCreateDate" TypeName="GBMessageTableAdapters.GBmessageTableAdapter">
                </asp:ObjectDataSource>
                <br />
                <div id="dlg" class="panel" style="width: 786px">
                    <div class="header" style="cursor: default">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                    全選:
                                    <asp:Button ID="btnDel" runat="server" Text="全部刪除" OnClientClick="return confirm('確定刪除嗎?')"
                                        CssClass="input4" OnClick="btnDel_Click" />&nbsp; 
                                    <asp:PlaceHolder ID="phcategory" runat="server">
                                    類型:
                                    <asp:DropDownList ID="ddrCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddrCategory_SelectedIndexChanged">
                                    </asp:DropDownList></asp:PlaceHolder>
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
                                        CssClass="grid" DataKeyNames="gb_ID" OnRowDataBound="GridView1_RowDataBound"
                                        DataSourceID="ObjectDataSource1" EnableModelValidation="True" EmptyDataText="此次查詢資料庫沒有資料">
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
                                            <asp:BoundField DataField="gb_ID" HeaderText="文章編號" Visible="false" SortExpression="gb_ID">
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="類型">
                                                <ItemTemplate>
                                                    <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("gbc_title") %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="gb_title" HeaderText="標題" SortExpression="gb_title"></asp:BoundField>
                                            <asp:BoundField DataField="gb_createdate" HeaderText="發佈時間" SortExpression="gb_createdate"
                                                DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                                            <asp:TemplateField HeaderText="詳細資訊">
                                                <ItemTemplate>
                                                    <a class="colorbox" title='<%#Eval("gb_title") %>' href='<%#Eval("gb_id","View.aspx?id={0}") %>'>
                                                        詳細資訊</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="回應資訊">
                                                <ItemTemplate>
                                                    <a class="colorbox" title='<%#Eval("gb_title") %>' href='<%#Eval("gb_id","ViewReport.aspx?id={0}") %>'>
                                                        詳細資訊</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="編輯">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyEdit" runat="server" NavigateUrl='<%# string.Format("Edit.aspx?id={0}",Eval("gb_id")) %>'
                                                        Text="編輯"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="回應">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lkbtnReport" runat="server" Text="回應" 
                                                        CommandArgument='<%#Eval("gb_id") %>' CommandName="GbReport" oncommand="lkbtnReport_Command"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:Button ID="Button2" runat="server" OnCommand="Button2_Command" CommandArgument='<%#Eval("gb_id") %>'
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
