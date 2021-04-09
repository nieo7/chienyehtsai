<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Manager/ManagerPage.master"
    AutoEventWireup="true" CodeFile="SystemConfigList.aspx.cs" Inherits="Manager_Admin_SystemConfigList"
    Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader1" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="message" runat="server" class="OkMsg" visible="false" style="width: 95%;
        height: auto;">
    </div>
    <div class="RightTableTdTopmenublue">
        <ul>
            <li id="toplink1active" title="文章欄位管理"><a href="#">列表</a></li>
            <li id="toplink2" title="新增"><a href="SystemConfigAdd.aspx">新增</a></li>
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
            <div class="RightTableTdContent">
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetData" TypeName="SystemConfigTableAdapters.SystemConfigTableAdapter"
                    InsertMethod="Insert">
                    <InsertParameters>
                        <asp:Parameter Name="sc_Class" Type="String" />
                        <asp:Parameter Name="sc_Name" Type="String" />
                        <asp:Parameter Name="sc_Value" Type="String" />
                        <asp:Parameter Name="sc_DefaultValue" Type="String" />
                        <asp:Parameter Name="sc_Desc" Type="String" />
                        <asp:Parameter Name="sc_Admin" Type="Int32" />
                        <asp:Parameter Name="sc_enable" Type="Boolean" />
                        <asp:Parameter Name="sc_adminenable" Type="Boolean" />
                        <asp:Parameter Name="sc_ts" Type="DateTime" />
                    </InsertParameters>
                </asp:ObjectDataSource>
                <br />
                <div id="dlg" class="panel" style="width: 786px">
                    <div class="header" style="cursor: default">
                        <div class="outer">
                            <div class="inner">
                                <div class="content">
                                    <span>選擇類別:</span>
                                    <asp:DropDownList ID="ddrCategory" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
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
                                        OnRowDataBound="GridView1_RowDataBound" DataSourceID="ObjectDataSource1" AllowSorting="True"
                                        PageSize="100" ShowFooter="True" EnableModelValidation="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="類型">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HiddenField_Id" Value='<%#Eval("sc_Id") %>' runat="server" />
                                                    <asp:TextBox ID="TextBox_Class" Width="100px" Enabled="false" Text='<%#Eval("sc_Class") %>'
                                                        runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="名稱">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TextBox_Name" Width="100px" Enabled="false" Text='<%#Eval("sc_Name") %>'
                                                        runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="設定值" SortExpression="sc_enable">
                                                <FooterTemplate>
                                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                                        <ProgressTemplate>
                                                            <img src="../../img/loading.gif" />
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="確認" />
                                                </FooterTemplate>
                                                <ItemTemplate>                                                    
                                                    <asp:CheckBox ID="chk_value" runat="server" Checked='<%#bool.Parse(Eval("sc_Value").ToString()) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="預設值">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TextBox_DefaultValue" Width="100px" Enabled="false" Text='<%#Eval("sc_DefaultValue") %>'
                                                        runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="說明">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TextBox_Desc" Text='<%#Eval("sc_Desc") %>' runat="server"></asp:TextBox>
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
