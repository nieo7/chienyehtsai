<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="SuperItemEditList2.aspx.cs" Inherits="Manager_Admin_SuperAdminItemEditList2" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader1" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
    <div id="message" runat="server" class="OkMsg" visible="false" style="width: 95%;
        height: auto;">
    </div>
    <div class="RightTableTdTopmenublue">
        <ul>
            <li id="toplink1active" title="文章欄位管理"><a href="#">列表</a></li>
            <li id="toplink2"title="返回"><a href='<%="SuperItemEditList.aspx?id="+id %>'>返回</a></li>
            <li id="toplink4" title="新增"><a href="<%="SuperAddSubItem.aspx?id="+id %>">新增</a></li>
            <li id="toplink5" title="生成HTML文件"><a href="#"></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2blue">
        <div class="radiodiv3">
        </div>
    </div>        
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
    <div class="RightTableTdContent">
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAllItem2WithItem1" 
            TypeName="AdminTableAdapters.AdminItem2TableAdapter" DeleteMethod="Delete" 
            InsertMethod="Insert" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_ai2_id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ai2_name" Type="String" />
                <asp:Parameter Name="ai2_sort" Type="Int32" />
                <asp:Parameter Name="ai2_visible" Type="Boolean" />
                <asp:Parameter Name="ai2_no1" Type="Int32" />
                <asp:Parameter Name="ai2_url" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ai2_name" Type="String" />
                <asp:Parameter Name="ai2_sort" Type="Int32" />
                <asp:Parameter Name="ai2_visible" Type="Boolean" />
                <asp:Parameter Name="ai2_no1" Type="Int32" />
                <asp:Parameter Name="ai2_url" Type="String" />
                <asp:Parameter Name="Original_ai2_id" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <br />
                <div id="dlg" class="panel" style="width: 786px">
                    <div class="header" style="cursor: default">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                    <span>全選:</span>
                                    <asp:Button ID="btnDel" runat="server" Text="全部開放" CssClass="input4" 
                                        onclick="btnDel_Click"  />
                                    <asp:Button ID="Button2" runat="server" Text="全部禁止" CssClass="input4" 
                                        onclick="Button2_Click" />
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
                                    <div style="text-align:center">
                                    <img src="../../img/loading.gif" />
                                    </div>
                                    </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        CssClass="grid" OnPageIndexChanged="GridView1_PageIndexChanged" 
                                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" 
                                        DataSourceID="ObjectDataSource1" AllowSorting="True" PageSize="100" 
                                        ShowFooter="True" EnableModelValidation="True">
                                        <Columns>
                                            <asp:BoundField DataField="ai2_id" HeaderText="ai2_id" Visible="false" SortExpression="ai2_id"></asp:BoundField>
                                            <asp:BoundField DataField="ai1_name" HeaderText="主功能" SortExpression="ai1_name"></asp:BoundField>
                                            <asp:BoundField DataField="ai2_name" HeaderText="子功能" SortExpression="ai2_name"></asp:BoundField>                                           
                                            <asp:TemplateField HeaderText="URL" SortExpression="ai2_url">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox_Url" runat="server" Text='<%# Bind("ai2_url") %>' Width="400px"></asp:TextBox>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="權限設定" SortExpression="ai2_visible">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ai2_visible") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                    <ProgressTemplate>
                                    <img src="../../img/loading.gif" />
                                    </ProgressTemplate>
                                    </asp:UpdateProgress>
                                                    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="確認" />
                                                </FooterTemplate>
                                                <ItemTemplate>
                                     <%--               <asp:Label ID="lbfi_no1" runat="server" Text='<%# Eval("fi_no1") %>' 
                                                        Visible="False"></asp:Label>--%>
                                                    <asp:Label ID="lbfi_no2" runat="server" Text='<%# Eval("ai2_id") %>' 
                                                        Visible="False"></asp:Label>
                                                    <asp:RadioButtonList ID="raIsVisable" runat="server" 
                                                        RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="True">開放</asp:ListItem>
                                                        <asp:ListItem Value="False" Selected="True">禁止</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerTemplate>
                            <asp:Label runat="server" Text="顯示幾筆:" />
                            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="GvCustomers_SelectedIndexChanged">
                                <asp:ListItem Value="5" />
                                <asp:ListItem Value="10" />
                                <asp:ListItem Value="15" />
                                <asp:ListItem Value="20" />
                            </asp:DropDownList>
                                            &nbsp; 目前頁數
                            <asp:TextBox ID="txtGoToPage" runat="server" AutoPostBack="true" OnTextChanged="GoToPage_TextChanged" CssClass="gotopage" />
                                            共
                            <asp:Label ID="lblTotalNumberOfPages" runat="server" />
                                            &nbsp;頁&nbsp;
                            <asp:ImageButton runat="server" CommandName="Page" ToolTip="First Page" CommandArgument="First" ImageUrl="~/_assets/img/first.gif" />
                            <asp:ImageButton runat="server" CommandName="Page" ToolTip="Previous Page" CommandArgument="Prev" ImageUrl="~/_assets/img/prev.gif" />
                            <asp:ImageButton runat="server" CommandName="Page" ToolTip="Next Page" CommandArgument="Next" ImageUrl="~/_assets/img/next.gif"/>
                            <asp:ImageButton runat="server" CommandName="Page" ToolTip="Last Page" CommandArgument="Last" ImageUrl="~/_assets/img/last.gif" /><asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                    <ProgressTemplate>
                                    <div style="text-align:center">
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
