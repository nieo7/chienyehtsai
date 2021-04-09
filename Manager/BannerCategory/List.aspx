<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="List.aspx.cs" Inherits="Manager_BannerCategory_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                    SelectMethod="GetData" 
                    TypeName="BannerTableAdapters.BannerCategoryTableAdapter">
                </asp:ObjectDataSource>
                <br />
                <div id="dlg" class="panel" style="width: 786px">
                    <div class="header" style="cursor: default">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                    全選:
                                    <asp:Button ID="btnDel" runat="server" Text="全部刪除" OnClientClick="return confirm('確定刪除嗎?')"
                                        CssClass="input4" OnClick="btnDel_Click" />
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
                                    <div style="text-align: center;">
                                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            CssClass="grid" DataKeyNames="bc_id" DataSourceID="ObjectDataSource1" EmptyDataText="此次查詢資料庫沒有資料"
                                            EnableModelValidation="True" OnRowDataBound="GridView1_RowDataBound" PageSize="20"
                                            OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated">
                                            <Columns>
                                                <asp:TemplateField HeaderText="選擇" ItemStyle-Width="50px">
                                                    <EditItemTemplate>
                                                    </EditItemTemplate>
                                                    <HeaderTemplate>
                                                        全選
                                                        <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="True" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <%--<asp:BoundField DataField="gbc_sort" HeaderText="排序" ItemStyle-Width="30px"  HeaderStyle-HorizontalAlign="Center" SortExpression="gbc_sort">                                                    
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="排序變換" ShowHeader="False" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnUp" runat="server" CommandName="btnSortUp" Text="▲" />
                                                        <asp:Button ID="btnDown" runat="server" CommandName="btnSortDown" Text="▼" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:BoundField DataField="bc_id" HeaderText="編號" SortExpression="bc_id" Visible="false" />
                                                <asp:BoundField DataField="bc_title" HeaderText="標題" SortExpression="bc_title"/>                                                                                              
                                                <asp:TemplateField HeaderText="編輯" ItemStyle-Width="30px">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hyEdit" runat="server" NavigateUrl='<%# string.Format("Edit.aspx?id={0}",Eval("bc_id")) %>'
                                                            Text="編輯"></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="刪除" ShowHeader="False" ItemStyle-Width="30px">
                                                    <ItemTemplate>
                                                        <asp:Button ID="Button2" runat="server" CommandArgument='<%#Eval("bc_id") %>' CommandName="myDelete"
                                                            CssClass="inputx2" OnCommand="Button2_Command" />
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
                                                <asp:TextBox ID="txtGoToPage" runat="server" AutoPostBack="true" CssClass="gotopage"
                                                    OnTextChanged="GoToPage_TextChanged" />
                                                共
                                                <asp:Label ID="lblTotalNumberOfPages" runat="server" />
                                                &nbsp;頁&nbsp;
                                                <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument="First" CommandName="Page"
                                                    ImageUrl="~/_assets/img/first.gif" ToolTip="First Page" />
                                                <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument="Prev" CommandName="Page"
                                                    ImageUrl="~/_assets/img/prev.gif" ToolTip="Previous Page" />
                                                <asp:ImageButton ID="ImageButton3" runat="server" CommandArgument="Next" CommandName="Page"
                                                    ImageUrl="~/_assets/img/next.gif" ToolTip="Next Page" />
                                                <asp:ImageButton ID="ImageButton4" runat="server" CommandArgument="Last" CommandName="Page"
                                                    ImageUrl="~/_assets/img/last.gif" ToolTip="Last Page" />
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
