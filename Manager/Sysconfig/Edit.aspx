<%@ Page Language="C#" ValidateRequest="false"  MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Manager_SysConfig_Edit" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main">
        <div id="message" runat="server" class="OkMsg" style="width: 95%; height: auto" visible="false">
        </div>
    </div>
    <div class="RightTableTdSubheader2red">
        網站參數設定&nbsp;</div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:Repeater ID="RepeaterSysConfig" runat="server">
        <ItemTemplate>
        <div class="contentdiv2">
            <div class="contentdiv2left">
                <asp:Literal ID="lId" runat="server" Text='<%#Eval("sc_Id") %>' ></asp:Literal><asp:CheckBox ID="ckSelect" runat="server" />
            </div>
            <div class="contentdiv2right">
                類別:<asp:TextBox ID="txtCalss" runat="server" Text='<%#Eval("sc_Class") %>'></asp:TextBox><br />
                名稱:<asp:TextBox ID="txtName" runat="server" Text='<%#Eval("sc_Name") %>'></asp:TextBox><br />
                值:<asp:TextBox ID="txtValue" runat="server" Text='<%#Eval("sc_Value") %>'></asp:TextBox><br />
                備註:<asp:TextBox ID="txtDesc" TextMode="MultiLine" runat="server" Text='<%#Eval("sc_Desc") %>'></asp:TextBox>
            </div>
        </div>
        <br />
        </ItemTemplate>
        </asp:Repeater>
    <div class="contentdiv3">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="修改"></asp:Button>
    </div>
    </div>
</asp:Content>

