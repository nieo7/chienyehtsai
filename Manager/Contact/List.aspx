<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="List.aspx.cs" Inherits="Manager_Contact_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenublue">
        <ul>
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
                    SelectMethod="GetDataByLidOrderDate" TypeName="ContactTableAdapters.ContactTableAdapter"
                    DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_c_id" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="c_name" Type="String" />
                        <asp:Parameter Name="c_subject" Type="String" />
                        <asp:Parameter Name="c_sex" Type="String" />
                        <asp:Parameter Name="c_phone1" Type="String" />
                        <asp:Parameter Name="c_phone2" Type="String" />
                        <asp:Parameter Name="c_mail" Type="String" />
                        <asp:Parameter Name="c_address" Type="String" />
                        <asp:Parameter Name="c_detail" Type="String" />
                        <asp:Parameter Name="c_check_read" Type="Boolean" />
                        <asp:Parameter Name="c_check_reply" Type="Boolean" />
                        <asp:Parameter Name="c_pose_date" Type="DateTime" />
                        <asp:Parameter Name="c_reply_date" Type="DateTime" />
                        <asp:Parameter Name="c_ip" Type="String" />
                        <asp:Parameter Name="l_id" Type="Int32" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="l_id" Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="c_name" Type="String" />
                        <asp:Parameter Name="c_subject" Type="String" />
                        <asp:Parameter Name="c_sex" Type="String" />
                        <asp:Parameter Name="c_phone1" Type="String" />
                        <asp:Parameter Name="c_phone2" Type="String" />
                        <asp:Parameter Name="c_mail" Type="String" />
                        <asp:Parameter Name="c_address" Type="String" />
                        <asp:Parameter Name="c_detail" Type="String" />
                        <asp:Parameter Name="c_check_read" Type="Boolean" />
                        <asp:Parameter Name="c_check_reply" Type="Boolean" />
                        <asp:Parameter Name="c_pose_date" Type="DateTime" />
                        <asp:Parameter Name="c_reply_date" Type="DateTime" />
                        <asp:Parameter Name="c_ip" Type="String" />
                        <asp:Parameter Name="l_id" Type="Int32" />
                        <asp:Parameter Name="Original_c_id" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DeleteMethod="Delete"
                    InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByID"
                    TypeName="ContactTableAdapters.ContactTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_c_id" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="c_name" Type="String" />
                        <asp:Parameter Name="c_subject" Type="String" />
                        <asp:Parameter Name="c_sex" Type="String" />
                        <asp:Parameter Name="c_phone1" Type="String" />
                        <asp:Parameter Name="c_phone2" Type="String" />
                        <asp:Parameter Name="c_mail" Type="String" />
                        <asp:Parameter Name="c_address" Type="String" />
                        <asp:Parameter Name="c_detail" Type="String" />
                        <asp:Parameter Name="c_check_read" Type="Boolean" />
                        <asp:Parameter Name="c_check_reply" Type="Boolean" />
                        <asp:Parameter Name="c_pose_date" Type="DateTime" />
                        <asp:Parameter Name="c_reply_date" Type="DateTime" />
                        <asp:Parameter Name="c_ip" Type="String" />
                        <asp:Parameter Name="l_id" Type="Int32" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gridView" Name="c_id" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="c_name" Type="String" />
                        <asp:Parameter Name="c_subject" Type="String" />
                        <asp:Parameter Name="c_sex" Type="String" />
                        <asp:Parameter Name="c_phone1" Type="String" />
                        <asp:Parameter Name="c_phone2" Type="String" />
                        <asp:Parameter Name="c_mail" Type="String" />
                        <asp:Parameter Name="c_address" Type="String" />
                        <asp:Parameter Name="c_detail" Type="String" />
                        <asp:Parameter Name="c_check_read" Type="Boolean" />
                        <asp:Parameter Name="c_check_reply" Type="Boolean" />
                        <asp:Parameter Name="c_pose_date" Type="DateTime" />
                        <asp:Parameter Name="c_reply_date" Type="DateTime" />
                        <asp:Parameter Name="c_ip" Type="String" />
                        <asp:Parameter Name="l_id" Type="Int32" />
                        <asp:Parameter Name="Original_c_id" Type="Int32" />
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
                                    <%--<asp:DropDownList ID="ddrCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddrCategory_SelectedIndexChanged">
                                    </asp:DropDownList>--%>
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
                                        <asp:GridView ID="gridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            CssClass="grid" DataKeyNames="c_id" DataSourceID="ObjectDataSource1" EmptyDataText="此次查詢資料庫沒有資料"
                                            EnableModelValidation="True" OnRowDataBound="GridView1_RowDataBound" PageSize="20">
                                            <Columns>
                                                <asp:TemplateField HeaderText="選擇" ItemStyle-Width="50px">
                                                    <EditItemTemplate>
                                                    </EditItemTemplate>
                                                    <HeaderTemplate>
                                                        <%--<input id="ckAll" type="checkbox" onclick="return ckAll_onclick()" />--%>全選
                                                        <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="True" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="c_id" HeaderText="文章編號" SortExpression="c_id" Visible="false" />
                                                <asp:BoundField DataField="c_name" HeaderText="姓名" SortExpression="c_name" />
                                                <%--<asp:BoundField DataField="c_sex" HeaderText="性別" SortExpression="c_sex" />--%>
                                                <asp:BoundField DataField="c_pose_date" DataFormatString="{0:yyyy-MM-dd}" HeaderText="發佈時間"
                                                    SortExpression="c_pose_date" />
                                                <asp:TemplateField HeaderText="是否閱讀" SortExpression="c_check_read">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbIsRead" runat="server" Text='<%# Eval("c_check_read") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="是否回覆" SortExpression="c_check_reply">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbIsReply" runat="server" Text='<%# Eval("c_check_reply") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="檢視資料" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btncheck" runat="server" CommandArgument='<%#Eval("c_id") %>'
                                                            CommandName="lnkcheck" OnCommand="btncheck_Command">檢視</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="回覆信件">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hyReply" runat="server" NavigateUrl='<%# string.Format("Reply.aspx?id={0}",Eval("c_id")) %>'
                                                            Text="回覆" Target="_blank"></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:Button ID="Button2" runat="server" CommandArgument='<%#Eval("c_id") %>' CommandName="myDelete"
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
                                            CssClass="grid" DataKeyNames="c_id" EnableModelValidation="True" OnDataBound="FormView1_DataBound">
                                            <EditRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                            <FooterStyle BackColor="White" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                            <ItemTemplate>
                                                <asp:Label ID="c_idLabel" runat="server" Text='<%# Eval("c_id") %>' Visible="false" />
                                                <div style="background: skyblue">
                                                    <div>
                                                        <span>姓名:</span>
                                                        <asp:Label ID="c_subjectLabel" runat="server" Text='<%# Bind("c_name") %>' /></div>
                                                </div>
                                                <div style="background: skyblue">
                                                    <div>
                                                        <span>性別:</span>
                                                        <asp:Label ID="lbSex" runat="server" Text='<%# Bind("c_sex") %>' /></div>
                                                </div>
                                                <div style="background: skyblue">
                                                    電話:
                                                    <asp:Label ID="lbTel" runat="server" Text='<%# Bind("c_phone1") %>' />
                                                </div>
                                                <div style="background: skyblue">
                                                    信箱:
                                                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("c_mail") %>' />
                                                </div>
                                                <div style="background: skyblue">
                                                    標題:
                                                    <asp:Label ID="lbTitle" runat="server" Text='<%# Bind("c_subject") %>' />
                                                </div>
                                                <div>
                                                    內容:<br />
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("c_detail") %>' TextMode="MultiLine"
                                                        Style="width: 100%; height: 200px"></asp:TextBox>
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
