<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="List.aspx.cs" Inherits="Manager_FriendLinkCategory_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
            <div class="RightTableTdSubheader2blue">
                <div class="radiodiv3">
                    <span>請選擇 :</span>&nbsp;<asp:TextBox ID="txtKeyWord" CssClass="input4" runat="server"></asp:TextBox>
                    &nbsp;</div>
                <div class="radiodiv">
                    &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" CssClass="input5" Text="Search"
                        OnClick="Button1_Click" /></div>
            </div>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetDataByLidOrderTs" TypeName="FriendLinkTableAdapters.FriendLinkCategoryTableAdapter"
                DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_fc_id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="fc_title" Type="String" />
                    <asp:Parameter Name="fc_CreateDate" Type="DateTime" />
                    <asp:Parameter Name="fc_show" Type="Boolean" />
                    <asp:Parameter Name="l_id" Type="Int32" />
                </InsertParameters>
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="l_id" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="fc_title" Type="String" />
                    <asp:Parameter Name="fc_CreateDate" Type="DateTime" />
                    <asp:Parameter Name="fc_show" Type="Boolean" />
                    <asp:Parameter Name="l_id" Type="Int32" />
                    <asp:Parameter Name="Original_fc_id" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <div class="RightTableTdContent">
                <%--<br />--%>
                <div id="dlg" class="panel" style="width: 786px">
                    <%--<div class="header" style="cursor: default">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                    <span>全選:</span>
                                    <asp:Button ID="btnDel" runat="server" CssClass="input4" OnClick="btnDel_Click" OnClientClick="return confirm('確定刪除嗎?')"
                                        Text="全部刪除" />
                                </div>
                            </div>
                        </div>
                    </div>--%>
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
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="fc_id"
                                        CssClass="grid" EmptyDataText="目前資料庫沒有資料!" OnRowDataBound="GridView1_RowDataBound" DataSourceID="ObjectDataSource1"
                                        EnableModelValidation="True">
                                        <Columns>
                                            <%--<asp:TemplateField HeaderText="選擇" ItemStyle-Width="50px">
                                                <HeaderTemplate>
                                                    全選<br />
                                                    <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle Width="30px" />
                                            </asp:TemplateField>--%>
                                            <asp:BoundField DataField="fc_id" HeaderText="編號" Visible="false" SortExpression="fc_id">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="fc_title" HeaderText="職稱" ItemStyle-Width="320px" SortExpression="fc_title">
                                                <ItemStyle Width="320px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="fc_CreateDate" HeaderText="建立時間" SortExpression="fc_CreateDate"
                                                DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                                            <asp:HyperLinkField HeaderText="編輯" DataNavigateUrlFields="fc_id" DataNavigateUrlFormatString="Edit.aspx?id={0}"
                                                Text="編輯" />
                                            <%--<asp:TemplateField HeaderText="刪除">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("fc_id") %>'
                                                        CommandName="Delete" OnClientClick="return confirm('您確定要刪除嗎?')" OnCommand="Delete">刪除</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
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
                                                CommandArgument="Last" ImageUrl="~/_assets/img/last.gif" /><asp:UpdateProgress ID="UpdateProgress2"
                                                    runat="server">
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
