<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="SystemConfigAdd.aspx.cs" Inherits="Manager_Admin_SystemConfigAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenu">
        <asp:HiddenField ID="hfLanguage" runat="server" />
        <ul>
            <li id="toplink1" title="產品類別欄位管理"><span><a href="SystemConfigList.aspx">列表</a></span></li><li
                id="toplink2active" title="增加產品類別"><span><a href="#">新增</a></span></li><li id="toplink3"
                    title="查看與修改產品類別"></li>
            <li id="toplink5" title="生成HTML文件"><a href="#"><span></span></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2">
        功能控制項-新增
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <div class="contentdiv4">
            <div class="contentdiv1left">
                主類別項目:&nbsp;</div>
            <div class="contentdiv1right">
                <asp:DropDownList ID="ddlCategory" runat="server">
                    <asp:ListItem Selected="True" Value="0">選擇主類別</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="contentdiv4">
            <div class="contentdiv1left">
                對控制項名稱:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請填寫名稱!"
                    SetFocusOnError="True" ControlToValidate="txtName">*</asp:RequiredFieldValidator>
                &nbsp;</div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="txtName" runat="server" CssClass="input1"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="contentdiv2">
            <div class="contentdiv2left">
                描述:
            </div>
            <div class="contentdiv2right">
                <asp:TextBox ID="txtdetail" runat="server" TextMode="MultiLine" Rows="8"></asp:TextBox>
            </div>
        </div>
        <div class="contentdiv4">
            <div class="contentdiv1left">
                開啟:</div>
            <div class="contentdiv1right">
                <asp:RadioButtonList ID="rbShow" runat="server" Width="231px" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="true">是</asp:ListItem>
                    <asp:ListItem Value="false">否</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="contentdiv3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>
