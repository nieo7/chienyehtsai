<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="List.aspx.cs" Inherits="Manager_BannerCustomer_List" %>

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
            //Examples of how to assign the ColorBox event to elements
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
                <asp:PlaceHolder ID="phaccount" runat="server">
                    <div class="radiodiv">
                        <asp:RadioButton ID="rbCompanyName" GroupName="rb" runat="server" Checked="True" /></div>
                    <span>公司名稱</span></asp:PlaceHolder>
                <asp:PlaceHolder ID="phnickname" runat="server">
                    <div class="radiodiv">
                        <asp:RadioButton ID="rbName" GroupName="rb" runat="server" /></div>
                    <span>連絡人姓名</span></asp:PlaceHolder>
                <asp:PlaceHolder ID="phname" runat="server">
                    <div class="radiodiv">
                        <asp:RadioButton ID="rbkEy" GroupName="rb" runat="server" /></div>
                    <span>編號</span></asp:PlaceHolder>
                <div class="radiodiv2">
                    &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" CssClass="input5" Text="Search"
                        OnClick="Button1_Click" /></div>
            </div>
            <div class="RightTableTdContent">
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetData" TypeName="BannerTableAdapters.BannerCustomerTableAdapter">
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
                                    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        CssClass="grid" DataKeyNames="bcs_id" OnRowDataBound="GridView1_RowDataBound"
                                        EmptyDataText="目前資料庫沒有資料!" DataSourceID="ObjectDataSource1" AllowSorting="True"
                                        EnableModelValidation="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="選擇" ItemStyle-Width="50px">
                                                <EditItemTemplate>
                                                </EditItemTemplate>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged" />
                                                    全選
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="True" />
                                                </ItemTemplate>
                                                <ItemStyle Width="50px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="bcs_id" HeaderText="編號" SortExpression="bcs_id" Visible="false" />
                                            <asp:BoundField DataField="bcs_company_name" HeaderText="公司名稱" SortExpression="bcs_company_name">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bcs_company_type" HeaderText="公司類型" SortExpression="bcs_company_type">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bcs_company_phone" HeaderText="公司電話" SortExpression="bcs_company_phone">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bcs_name" HeaderText="連絡人姓名" SortExpression="bcs_name">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bcs_sex" HeaderText="連絡人性別" SortExpression="bcs_sex">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bcs_phone" HeaderText="連絡人電話" SortExpression="bcs_phone">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bcs_mail" HeaderText="連絡人信箱" SortExpression="bcs_mail">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bcs_fax" HeaderText="傳真" SortExpression="bcs_fax"></asp:BoundField>
                                            <asp:BoundField DataField="bcs_ts" HeaderText="建立時間" SortExpression="bcs_ts" DataFormatString="{0:yyyy-MM-dd}">
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="詳細資訊">
                                                <ItemTemplate>
                                                    <a id="btnShowPopup" runat="server" class="colorbox" title='<%#Eval("bcs_company_name") %>'
                                                        href='<%#Eval("bcs_id","View.aspx?ID={0}&TB_iframe=true&height=600&width=800") %>'>
                                                        詳細資訊</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField DataNavigateUrlFields="bcs_id" DataNavigateUrlFormatString="Edit.aspx?id={0}"
                                                HeaderText="修改" Text="修改" />
                                            <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("bcs_id") %>'
                                                        CommandName="Delete" OnClientClick="return confirm('您確定要刪除嗎?')" OnCommand="Delete">刪除</asp:LinkButton>
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
