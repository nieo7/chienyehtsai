<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="List.aspx.cs" Inherits="Manager_Member_List" %>

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
                        <asp:RadioButton ID="rbAccount" GroupName="rb" runat="server" Checked="True" /></div>
                    <span>帳號</span></asp:PlaceHolder>
                <asp:PlaceHolder ID="phnickname" runat="server">
                    <div class="radiodiv">
                        <asp:RadioButton ID="rbNickname" GroupName="rb" runat="server" /></div>
                    <span>匿稱</span></asp:PlaceHolder>
                <asp:PlaceHolder ID="phname" runat="server">
                    <div class="radiodiv">
                        <asp:RadioButton ID="rbName" GroupName="rb" runat="server" /></div>
                    <span>姓名</span></asp:PlaceHolder>
                <div class="radiodiv2">
                    &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" CssClass="input5" Text="Search"
                        OnClick="Button1_Click" /></div>
            </div>
            <div class="RightTableTdContent">
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetData" TypeName="MemberTableAdapters.MemberTableAdapter" DeleteMethod="Delete"
                    InsertMethod="Insert" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_m_id" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="m_level" Type="Int32" />
                        <asp:Parameter Name="m_account" Type="String" />
                        <asp:Parameter Name="m_fname" Type="String" />
                        <asp:Parameter Name="m_name" Type="String" />
                        <asp:Parameter Name="m_nickname" Type="String" />
                        <asp:Parameter Name="m_number" Type="String" />
                        <asp:Parameter Name="m_mail" Type="String" />
                        <asp:Parameter Name="m_pass" Type="String" />
                        <asp:Parameter Name="m_sex" Type="String" />
                        <asp:Parameter Name="m_birthday" Type="String" />
                        <asp:Parameter Name="m_zipcode" Type="String" />
                        <asp:Parameter Name="m_city" Type="String" />
                        <asp:Parameter Name="m_address" Type="String" />
                        <asp:Parameter Name="m_phone1" Type="String" />
                        <asp:Parameter Name="m_phone2" Type="String" />
                        <asp:Parameter Name="m_login_times" Type="Int32" />
                        <asp:Parameter Name="m_note" Type="String" />
                        <asp:Parameter Name="m_adddate" Type="DateTime" />
                        <asp:Parameter Name="m_editdate" Type="DateTime" />
                        <asp:Parameter Name="m_lastlogindate" Type="DateTime" />
                        <asp:Parameter Name="m_check_code" Type="String" />
                        <asp:Parameter Name="m_eaper" Type="Boolean" />
                        <asp:Parameter Name="m_block" Type="Boolean" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="m_level" Type="Int32" />
                        <asp:Parameter Name="m_account" Type="String" />
                        <asp:Parameter Name="m_fname" Type="String" />
                        <asp:Parameter Name="m_name" Type="String" />
                        <asp:Parameter Name="m_nickname" Type="String" />
                        <asp:Parameter Name="m_number" Type="String" />
                        <asp:Parameter Name="m_mail" Type="String" />
                        <asp:Parameter Name="m_pass" Type="String" />
                        <asp:Parameter Name="m_sex" Type="String" />
                        <asp:Parameter Name="m_birthday" Type="String" />
                        <asp:Parameter Name="m_zipcode" Type="String" />
                        <asp:Parameter Name="m_city" Type="String" />
                        <asp:Parameter Name="m_address" Type="String" />
                        <asp:Parameter Name="m_phone1" Type="String" />
                        <asp:Parameter Name="m_phone2" Type="String" />
                        <asp:Parameter Name="m_login_times" Type="Int32" />
                        <asp:Parameter Name="m_note" Type="String" />
                        <asp:Parameter Name="m_adddate" Type="DateTime" />
                        <asp:Parameter Name="m_editdate" Type="DateTime" />
                        <asp:Parameter Name="m_lastlogindate" Type="DateTime" />
                        <asp:Parameter Name="m_check_code" Type="String" />
                        <asp:Parameter Name="m_eaper" Type="Boolean" />
                        <asp:Parameter Name="m_block" Type="Boolean" />
                        <asp:Parameter Name="Original_m_id" Type="Int32" />
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
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        CssClass="grid" DataKeyNames="m_id" OnRowDataBound="GridView1_RowDataBound" EmptyDataText="目前資料庫沒有資料!"
                                        DataSourceID="ObjectDataSource1" AllowSorting="True" EnableModelValidation="True">
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
                                            <asp:BoundField DataField="m_id" HeaderText="會員編號" SortExpression="m_id" Visible="false" />
                                            <asp:BoundField DataField="m_account" HeaderText="會員帳號" SortExpression="m_account">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="m_nickname" HeaderText="會員匿稱" SortExpression="m_nickname">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="m_name" HeaderText="會員姓名" SortExpression="m_name"></asp:BoundField>
                                            <asp:TemplateField HeaderText="註冊" SortExpression="m_check_code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbIsRegist" runat="server" Text='<%# Eval("m_check_code") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="m_adddate" HeaderText="建立時間" SortExpression="m_adddate"
                                                DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                                            <asp:TemplateField HeaderText="會員卡">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lkbtnCreateCard" runat="server" CommandName="CreateCard" CommandArgument='<%#Eval("m_id") %>'
                                                        OnCommand="lkbtnCreateCard_Command">創建</asp:LinkButton>
                                                    <%--<asp:HyperLink ID="hyCreateCard" runat="server" NavigateUrl='<%#Eval("m_id","~/Manager/Member_card/add.aspx?id={0}") %>'>創建</asp:HyperLink>--%>&nbsp;
                                                    <asp:HyperLink ID="hyEditCard" runat="server" NavigateUrl='<%#Eval("m_id","~/Manager/Member_card/edit.aspx?id={0}") %>'>編輯</asp:HyperLink>&nbsp;
                                                    <asp:HyperLink ID="hymemberCard" runat="server" NavigateUrl='<%#Eval("m_id","~/Manager/Member_card/view.aspx?id={0}&TB_iframe=true&height=600&width=800") %>'
                                                        CssClass="colorbox" ToolTip='<%#Eval("m_account") %>'>檢視</asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="詳細資訊">
                                                <ItemTemplate>
                                                    <a id="btnShowPopup" runat="server" class="colorbox" title='<%#Eval("m_account") %>'
                                                        href='<%#Eval("m_id","View.aspx?ID={0}&TB_iframe=true&height=600&width=800") %>'>
                                                        詳細資訊</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField DataNavigateUrlFields="m_id" DataNavigateUrlFormatString="Edit.aspx?id={0}"
                                                HeaderText="修改" Text="修改" />
                                            <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("m_id") %>'
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
