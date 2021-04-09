<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Manager/ManagerPage.master"
    AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="Manager_News_List" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="message" runat="server" class="OkMsg" visible="false" style="width: 95%;
                height: auto;">
            </div>
            <div class="RightTableTdTopmenublue">
                <ul>
                    <li id="toplink1active" title="文章欄位管理"><a href="#">列表</a></li>
                    <li id="toplink2" title="增加"><a href="Add.aspx">新增</a></li>
                    <li id="toplink3" title="列表"><a href="../News/List.aspx">最新消息列表</a></li>
                    <li id="toplink5" title="生成HTML文件"><a href="#"></a></li>
                </ul>
            </div>
            <div class="RightTableTdSubheader2blue">
                <div class="radiodiv3">
                    <span>請選擇 :</span>&nbsp;<asp:TextBox ID="txtKeyWord" CssClass="input4" runat="server"></asp:TextBox>
                    &nbsp;</div>
                <div class="radiodiv">
                    <div class="radiodiv2">
                        &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" CssClass="input5" Text="Search"
                            OnClick="Button1_Click" /></div>
                </div>
            </div>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetDataByLidOrderFidAndSort" TypeName="NewsTableAdapters.NewsCategoryTableAdapter">
                <SelectParameters>
                    <asp:Parameter Name="l_id" Type="Int32" DefaultValue="1" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="RightTableTdContent">
                <br />
                <div id="dlg" class="panel" style="width: 786px">
                    <div class="header" style="cursor: default">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                    <span>全選:</span>
                                    <asp:Button ID="btnDel" runat="server" CssClass="input4" OnClick="btnDel_Click" OnClientClick="return confirm('確定刪除嗎?')"
                                        Text="全部刪除" />
                                    &nbsp
                                    <asp:PlaceHolder ID="phcategory" runat="server"><span>選擇父類別:</span>
                                        <asp:DropDownList ID="ddrCategory" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                            AutoPostBack="True">
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
                                        CssClass="grid" EmptyDataText="此次查詢資料庫沒有資料!" DataKeyNames="nc_id" OnRowDataBound="GridView1_RowDataBound"
                                        AllowSorting="True" DataSourceID="ObjectDataSource1" EnableModelValidation="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="選擇" ItemStyle-Width="50px">
                                                <HeaderTemplate>
                                                    全選<br />
                                                    <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle Width="30px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="nc_id" Visible="false" HeaderText="編號" SortExpression="nc_id">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="nc_sorting" HeaderText="排序" ItemStyle-Width="320px" SortExpression="pc_sorting">
                                                <ItemStyle Width="50px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="首圖">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyImg" runat="server">
                                                        <asp:Image ID="Image1" runat="server" Width="50px" ImageUrl='<%#Tools.GetAppSettings("NewsImageTruePath")+Eval("nc_image").ToString() %>' /></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="nc_name" HeaderText="標題" ItemStyle-Width="320px" SortExpression="pc_name">
                                                <ItemStyle Width="200px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="主類別">
                                                <ItemTemplate>
                                                    <%#getTitle(int.Parse(Eval("nc_fatherid").ToString()))%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CheckBoxField DataField="nc_show" HeaderText="是否顯示">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:CheckBoxField>
                                            <asp:TemplateField HeaderText="詳細資訊" ItemStyle-Width="50px">
                                                <ItemTemplate>
                                                    <a class="colorbox" title='<%#Eval("nc_name") %>' href='<%#Eval("nc_id","View.aspx?id={0}") %>'>
                                                        詳細資訊</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField DataNavigateUrlFields="nc_id" DataNavigateUrlFormatString="Edit.aspx?id={0}"
                                                HeaderText="編輯" Text="編輯"></asp:HyperLinkField>
                                            <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:Button ID="Button2" runat="server" OnCommand="Button2_Command" CommandArgument='<%#Eval("nc_id") %>'
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
