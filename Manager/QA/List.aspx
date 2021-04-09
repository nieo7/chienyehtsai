<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="List.aspx.cs" Inherits="Manager_QA_List" ValidateRequest="false" %>

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
                    SelectMethod="GetData" TypeName="QnaTableAdapters.QnaTableAdapter"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetDataById" TypeName="QnaTableAdapters.QnaTableAdapter" DeleteMethod="Delete"
                    InsertMethod="Insert" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_q_id" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="q_title" Type="String" />
                        <asp:Parameter Name="q_content" Type="String" />
                        <asp:Parameter Name="q_sort" Type="Int32" />
                        <asp:Parameter Name="q_show" Type="Boolean" />
                        <asp:Parameter Name="q_CreateDate" Type="DateTime" />
                        <asp:Parameter Name="q_EditDate" Type="DateTime" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="GridView1" Name="q_id" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="q_title" Type="String" />
                        <asp:Parameter Name="q_content" Type="String" />
                        <asp:Parameter Name="q_sort" Type="Int32" />
                        <asp:Parameter Name="q_show" Type="Boolean" />
                        <asp:Parameter Name="q_CreateDate" Type="DateTime" />
                        <asp:Parameter Name="q_EditDate" Type="DateTime" />
                        <asp:Parameter Name="Original_q_id" Type="Int32" />
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
                                            CssClass="grid" DataKeyNames="q_id" DataSourceID="ObjectDataSource1" EmptyDataText="此次查詢資料庫沒有資料"
                                            EnableModelValidation="True" OnRowDataBound="GridView1_RowDataBound" PageSize="20"
                                            OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated">
                                            <Columns>
                                                <asp:TemplateField HeaderText="選擇" ItemStyle-Width="50px">                              
                                                    <HeaderTemplate>
                                                        全選
                                                        <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="True" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="q_sort" HeaderText="排序" ItemStyle-Width="50px" SortExpression="q_sort">
                                                    <ItemStyle Width="30px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="排序變換" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnUp" runat="server" CommandName="btnSortUp" Text="▲" />
                                                        <asp:Button ID="btnDown" runat="server" CommandName="btnSortDown" Text="▼" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="q_id" HeaderText="文章編號" SortExpression="q_id" Visible="false" />
                                                <asp:BoundField DataField="q_title" HeaderText="標題" SortExpression="q_title" />
                                                <asp:BoundField DataField="q_CreateDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="發佈時間"
                                                    SortExpression="q_CreateDate" />
                                                <asp:CommandField HeaderText="檢視資料" SelectText="檢視" ShowSelectButton="True" />
                                                <asp:TemplateField HeaderText="編輯">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hyEdit" runat="server" NavigateUrl='<%# string.Format("Edit.aspx?id={0}",Eval("q_id")) %>'
                                                            Text="編輯"></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:Button ID="Button2" runat="server" CommandArgument='<%#Eval("q_id") %>' CommandName="myDelete"
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
                                        <br />
                                        <asp:FormView ID="FormView1" runat="server" BackColor="White" BorderColor="#336666"
                                            BorderStyle="Double" BorderWidth="3px" CellPadding="4" DataSourceID="ObjectDataSource2"
                                            GridLines="Horizontal" CssClass="grid" DataKeyNames="q_id" EnableModelValidation="True">
                                            <EditRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                            <FooterStyle BackColor="White" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                            <ItemTemplate>
                                                <asp:Label ID="c_idLabel" runat="server" Text='<%# Eval("q_id") %>' Visible="false" />
                                                <div style="background: skyblue">
                                                    標題(Title):
                                                    <asp:Label ID="c_subjectLabel" runat="server" Text='<%# Bind("q_title") %>' />
                                                </div>
                                                <br />
                                                <div>
                                                    內容:<br />
                                                    <asp:Literal ID="Literal1" runat="server" Text='<%#Bind("q_content") %>'></asp:Literal>
                                                </div>
                                            </ItemTemplate>
                                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="White" ForeColor="#333333" />
                                        </asp:FormView>
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
