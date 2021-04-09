<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Manager/ManagerPage.master"
    AutoEventWireup="true" CodeFile="SuperAddSubItem.aspx.cs" Inherits="Manager_Admin_SuperAddItem"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenu">
        <ul>
            <li id="toplink1" title="文章欄位管理"><span><a href="SuperItemEditList2.aspx">列表</a></span></li><li
                id="toplink2active" title="增加文章"><span><a href="#">新增</a></span></li><li id="toplink3"
                    title="查看與修改文章"><span></li>
            <li id="toplink5" title="生成HTML文件"><a href="#"><span></span></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2">
        子功能-新增
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <div class="contentdiv4">
            <div class="contentdiv1left">
                類別: &nbsp;</div>
            <div class="contentdiv1right">
                <asp:DropDownList ID="DropDownList_No1" runat="server" DataSourceID="ObjectDataSource1"
                    DataTextField="ai1_name" DataValueField="ai1_id">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetData" TypeName="AdminTableAdapters.AdminItem1TableAdapter" DeleteMethod="Delete"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_ai1_id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ai1_sort" Type="Int32" />
                        <asp:Parameter Name="ai1_name" Type="String" />
                        <asp:Parameter Name="ai1_visible" Type="Boolean" />
                        <asp:Parameter Name="Original_ai1_id" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="contentdiv4">
            <div class="contentdiv1left">
                名稱:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="請填寫名稱!"
                    SetFocusOnError="True" ControlToValidate="TextBox_Name">*</asp:RequiredFieldValidator>
                &nbsp;</div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="TextBox_Name" runat="server" CssClass="input1"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="contentdiv4">
            <div class="contentdiv1left">
                URL:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請填寫URL!"
                    SetFocusOnError="True" ControlToValidate="TextBox_Url">*</asp:RequiredFieldValidator>
                &nbsp;</div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="TextBox_Url" runat="server" CssClass="input1"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="contentdiv3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>
