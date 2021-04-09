<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Manager/ManagerPage.master"
    AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Manager_News_Edit" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../UserControl/public/Ckeditorl.ascx" TagName="Ckeditorl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenuorange">
        <ul>
            <li id="toplink11" title="訊息列表"><a href="list.aspx">列表</a></li>
            <li id="toplink21" title="增加新訊息"><a href="add.aspx">新增</a></li>
            <li id="toplink31active" title="訊息查看與修改"><a href="#">修改</a></li>
            <li id="toplink41" title="查看與修改產品"><a href="#"></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2orange">
        最新消息-修改
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phcategory" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    發文者:&nbsp;</div>
                <div class="contentdiv1right">
                    <asp:DropDownList ID="ddrCategory" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phtitle" runat="server">
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
        <div class="contentdiv2">
            <asp:PlaceHolder ID="phshow" runat="server">
                <div class="contentdiv2left">
                    是否顯示:
                </div>
                <div class="contentdiv2right">
                    <asp:CheckBox ID="ChkVisible" runat="server" Font-Size="Small" Text="是:請點選" />
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phdetail" runat="server">
                <div class="contentdiv2left">
                    内容:
                </div>
                <div class="contentdiv2right">
                    <uc1:Ckeditorl ID="Ckeditorl1" runat="server" />
                </div>
            </asp:PlaceHolder>
        </div>
        <asp:PlaceHolder ID="phstartdate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    起始日期:&nbsp;</div>
                <asp:TextBox ID="txtStartDate" runat="server" AutoCompleteType="Disabled"></asp:TextBox>&nbsp;結束日期:<asp:TextBox
                    ID="txtEndDate" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="yyyy/MM/dd"
                    TargetControlID="txtStartDate">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" TargetControlID="txtEndDate">
                </cc1:CalendarExtender>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phcreatedate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    建立日期: &nbsp;</div>
                <div class="contentdiv1right">
                    <asp:TextBox ID="txtAddDate" runat="server" CssClass="input1"></asp:TextBox>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="pheditdate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    修改日期: &nbsp;</div>
                <div class="contentdiv1right">
                    <asp:TextBox ID="txtEditDate" runat="server" CssClass="input1"></asp:TextBox>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="phrpimage" runat="server">
                    <asp:HiddenField ID="hfImageIndex" runat="server" />
                    <div class="contentdiv4">
                        <div class="contentdiv1left">
                            附加圖片:&nbsp;</div>
                        <div class="contentdiv1right">
                            <asp:FileUpload ID="fuImage" runat="server" Height="19px" />
                            <asp:Button ID="btImage" CausesValidation="false" runat="server" Text="上傳" OnClick="btImage_Click" />
                        </div>
                    </div>
                    <div class="contentdiv2">
                        <div class="contentdiv2left">
                        </div>
                        <div class="contentdiv2right">
                            <table width="100" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="rpImage" runat="server" OnItemCommand="rpImage_ItemCommand" OnItemDataBound="rpImage_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbImageID" Visible="false" runat="server" Text='<%#Eval("np_id") %>'></asp:Label>
                                                <asp:Image ID="Image1" Width="100" AlternateText='<%#Eval("np_name") %>' runat="server"
                                                    ImageUrl='<%#Tools.GetAppSettings("NewsImageTruePath")+Eval("np_name") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbImage" runat="server" Text='<%#Eval("np_imagename") %>'></asp:Label>
                                                &nbsp;<asp:LinkButton ID="lkDelete" CommandArgument='<%#Eval("np_id") %>' CommandName="Delete"
                                                    runat="server">刪除</asp:LinkButton>
                                                <asp:LinkButton ID="lkUpdate" CommandArgument='<%#Eval("np_id") %>' CommandName="Update"
                                                    runat="server">設定首圖</asp:LinkButton>
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
        <div class="contentdiv3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <asp:Button ID="Button1" runat="server" Text="修改" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>
