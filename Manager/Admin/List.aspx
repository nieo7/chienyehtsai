<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="List.aspx.cs" Inherits="Manager_Admin_List" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            //Examples of how to assign the ColorBox event to elements
            $(".colorbox").colorbox({ width: "70%", height: "90%", iframe: true });
        });
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="message" runat="server" class="OkMsg" visible="false" style="width: 95%;
        height: auto;">
    </div>
    <div class="RightTableTdTopmenublue">
        <ul>
            <li id="toplink1active" title="文章欄位管理"><a href="#">列表</a></li>
            <li id="toplink2"title="增加"><a href="Add.aspx">新增</a></li>
            <li id="toplink4" title="模板管理"><a href="#"></a></li>
            <li id="toplink5" title="生成HTML文件"><a href="#"></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2blue">
        <div class="radiodiv3">
            <span>請選擇 :</span>&nbsp;<asp:TextBox ID="txtKeyWord" CssClass="input4" runat="server"></asp:TextBox>
            &nbsp;</div>
        <div class="radiodiv">
            <asp:RadioButton ID="rbProductName" GroupName="rb" runat="server" Checked="True" /></div>
        <span>標題</span><div class="radiodiv">
            <asp:RadioButton ID="rbProductNum" GroupName="rb" runat="server" /></div>
        <span>編號</span><div class="radiodiv2">
            &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" CssClass="input5" Text="Search"
                OnClick="Button1_Click" /></div>
    </div>        
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

    <div class="RightTableTdContent">
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetData" 
            TypeName="AdminTableAdapters.AdminTableAdapter">
        </asp:ObjectDataSource>
        <br />
                <div id="dlg" class="panel" style="width: 786px">
                    <div class="header" style="cursor: default">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                    <span>全選:</span>
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
                                    <div style="text-align:center">
                                    <img src="../../img/loading.gif" />
                                    </div>
                                    </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        CssClass="grid" OnPageIndexChanged="GridView1_PageIndexChanged"
                                        DataKeyNames="a_id" OnRowDataBound="GridView1_RowDataBound" 
                                        DataSourceID="ObjectDataSource1" AllowSorting="True" 
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
                                            <asp:BoundField DataField="a_id" HeaderText="編號" SortExpression="a_id" Visible="false"></asp:BoundField>
                                            <asp:BoundField DataField="a_name" HeaderText="管理者名稱" SortExpression="a_name"></asp:BoundField>
                                            <asp:BoundField DataField="a_account" HeaderText="管理者帳號" SortExpression="a_account" />
                                            <asp:BoundField DataField="a_lastDate" HeaderText="最後登入時間" SortExpression="a_lastDate" DataFormatString="{0:yyyy-MM-dd}">
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="權限設定">
                                            <ItemTemplate>
                                            <asp:LinkButton ID="lkbtnPower" runat="server" ToolTip='<%#Eval("a_name") %>' visible='<%#Eval("a_id").ToString()=="1" ? bool.Parse("false") : bool.Parse("true") %>' href='<%#Eval("a_id","AdminItemList.aspx?id={0}") %>'>權限設定</asp:LinkButton>
                                            </ItemTemplate> 
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="詳細資訊">
                                            <ItemTemplate>
                                            <a class="colorbox" title='<%#Eval("a_name") %>' href='<%#Eval("a_id","View.aspx?id={0}") %>'>詳細資訊</a>
                                            </ItemTemplate>  
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="編輯">
                                                <ItemTemplate>
                                                <a id="btnedit" runat="server" visible='<%#Eval("a_id").ToString()=="1" ? bool.Parse("false") : bool.Parse("true") %>' href='<%#String.Format("Edit.aspx?id={0}",Eval("a_id")) %>' >編輯</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton2" visible='<%#Eval("a_id").ToString()=="1" ? bool.Parse("false") : bool.Parse("true") %>' runat="server" CommandArgument='<%# Eval("a_id") %>'
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
