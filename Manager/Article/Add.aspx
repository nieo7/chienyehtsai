<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Manager/ManagerPage.master"
    AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Manager_News_Add" Title="Untitled Page" %>

<%@ Register Src="../../UserControl/public/Ckeditorl.ascx" TagName="Ckeditorl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenu">
        <ul>
            <li id="toplink1" title="文章欄位管理"><span><a href="List.aspx">列表</a></span></li><li
                id="toplink2active" title="增加文章"><span><a href="#">新增</a></span></li><li id="toplink3"
                    title="查看與修改文章"><span></span></li>
            <li id="toplink5" title="生成HTML文件"><a href="#"><span></span></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2">
        文章-新增
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phfather" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    類別:&nbsp;</div>
                <div class="contentdiv1right">
                    <asp:DropDownList ID="ddlCategory" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phname" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    標題:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請填寫標題!"
                        SetFocusOnError="True" ControlToValidate="txtName">*</asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtName" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phdetail">
            <div class="contentdiv2">
                <div class="contentdiv2left">
                    内容:
                </div>
                <div class="contentdiv2right">
                    <uc1:Ckeditorl ID="Ckeditorl1" runat="server" />
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="phrpimage" runat="server">
                    <asp:HiddenField ID="hfProductImage" runat="server" />
                    <div class="contentdiv4">
                        <div class="contentdiv1left">
                            建立附加圖片:</div>
                        <div class="contentdiv1right">
                            <asp:FileUpload ID="fuImage" runat="server" />&nbsp;
                            <asp:Button ID="btImage" CausesValidation="false" runat="server" Text="上傳" OnClick="btImage_Click" />
                            <strong>&nbsp;<span class="style1">(請勿超過2MB)</span></strong></div>
                    </div>
                    <div class="contentdiv2">
                        <div class="contentdiv1left">
                        </div>
                        <div class="contentdiv1right">
                            <table width="100" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="rpImage" runat="server" OnItemCommand="rpImage_ItemCommand" OnItemDataBound="rpImage_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbImageID" Visible="false" runat="server" Text='<%#Eval("ap_imagename") %>'></asp:Label>
                                                <asp:Image ID="Image1" Width="100" AlternateText='<%#Eval("ap_imagename") %>' runat="server"
                                                    ImageUrl='<%#Tools.GetAppSettings("ProductImageTempPath")+Eval("ap_imagename") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbImage" runat="server" Text='<%#Eval("ap_imagename") %>'></asp:Label>
                                                &nbsp;<asp:LinkButton ID="lkDelete" CommandArgument='<%#Eval("ap_imagename") %>'
                                                    OnClientClick="return confirm('您確定要刪除嗎?')" CommandName="Delete" CausesValidation="false"
                                                    runat="server">刪除</asp:LinkButton>
                                                <asp:LinkButton ID="lkUpdate" CommandArgument='<%#Eval("ap_imagename") %>' CommandName="Update"
                                                    CausesValidation="false" runat="server">設定為文章首圖</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                </asp:PlaceHolder>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btImage" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:PlaceHolder runat="server" ID="phshow">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    顯示於前台:</div>
                <div class="contentdiv1right">
                    <asp:RadioButtonList ID="rbShow" runat="server" Width="231px" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="true">是</asp:ListItem>
                        <asp:ListItem Value="false">否</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </asp:PlaceHolder>
        <div class="contentdiv3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>
