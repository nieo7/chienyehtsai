<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Manager/ManagerPage.master"
    AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="Manager_News_List" Title="Untitled Page" %>

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
                <div class="radiodiv2">
                    &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" CssClass="input5" Text="Search"
                        OnClick="Button1_Click" /></div>
            </div>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetDataByLidWithFriendLink" TypeName="NewsTableAdapters.NewsTableAdapter"
                DeleteMethod="Delete">
                <DeleteParameters>
                    <asp:Parameter Name="Original_n_id" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="l_id" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
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
                                    <asp:PlaceHolder ID="phcategory" runat="server">
                                    <span>選擇發文者:</span>
                                    <asp:DropDownList ID="ddrCategory" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                        AutoPostBack="True">
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
                                        CssClass="grid" OnPageIndexChanged="GridView1_PageIndexChanged" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                        EmptyDataText="目前資料庫沒有資料!" DataKeyNames="n_id" OnRowDataBound="GridView1_RowDataBound"
                                        AllowSorting="True" DataSourceID="ObjectDataSource1" EnableModelValidation="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="選擇" ItemStyle-Width="50px">
                                                <EditItemTemplate>
                                                </EditItemTemplate>
                                                <HeaderTemplate>
                                                    全選<br />
                                                    <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle Width="30px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="n_id" Visible="false" HeaderText="文章編號" SortExpression="n_id">
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="首圖">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyImg" runat="server">
                                                        <asp:Image ID="Image1" runat="server" Width="50px" ImageUrl='<%#Tools.GetAppSettings("NewsImageTruePath")+Eval("n_image").ToString() %>' /></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="發文者">
                                                <ItemTemplate>
                                                    <asp:Literal ID="litFriendLink" runat="server" Text='<%#Eval("f_title") %>'></asp:Literal>
                                                    <%--<%#getTitle(int.Parse(Eval("f_id").ToString()))%>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="n_title" HeaderText="標題" ItemStyle-Width="240px" SortExpression="n_title"
                                                ItemStyle-CssClass="fixedwidth">
                                            <ItemStyle CssClass="fixedwidth" Width="240px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="n_ts" HeaderText="發佈時間" SortExpression="addDate" DataFormatString="{0:yyyy-MM-dd}">
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="詳細資訊">
                                                <ItemTemplate>
                                                    <a class="colorbox" title='<%#Eval("n_title") %>' href='<%#Eval("n_id","View.aspx?ID={0}") %>'>
                                                        詳細資訊</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField DataNavigateUrlFields="n_id" DataNavigateUrlFormatString="Edit.aspx?id={0}"
                                                HeaderText="編輯" Text="編輯"></asp:HyperLinkField>
                                            <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("n_id") %>'
                                                        CommandName="Delete" OnClientClick="return confirm('您確定要刪除嗎?')" OnCommand="Delete">刪除</asp:LinkButton>
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
                                            <asp:TextBox ID="txtGoToPage" runat="server" AutoPostBack="true" OnTextChanged="GoToPage_TextChanged"
                                                CssClass="gotopage" />
                                            共
                                            <asp:Label ID="lblTotalNumberOfPages" runat="server" />
                                            &nbsp;頁&nbsp;
                                            <asp:ImageButton runat="server" CommandName="Page" ToolTip="First Page" CommandArgument="First"
                                                ImageUrl="~/_assets/img/first.gif" />
                                            <asp:ImageButton runat="server" CommandName="Page" ToolTip="Previous Page" CommandArgument="Prev"
                                                ImageUrl="~/_assets/img/prev.gif" />
                                            <asp:ImageButton runat="server" CommandName="Page" ToolTip="Next Page" CommandArgument="Next"
                                                ImageUrl="~/_assets/img/next.gif" />
                                            <asp:ImageButton runat="server" CommandName="Page" ToolTip="Last Page" CommandArgument="Last"
                                                ImageUrl="~/_assets/img/last.gif" /><asp:UpdateProgress ID="UpdateProgress2" runat="server">
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
