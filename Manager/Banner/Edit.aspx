<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Manager/ManagerPage.master"
    AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Manager_News_Edit" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../UserControl/public/Ckeditorl.ascx" TagName="Ckeditorl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenuorange">
        <ul>
            <li id="toplink11" title="廣告列表"><a href="list.aspx">列表</a></li>
            <li id="toplink21" title="增加新廣告"><a href="add.aspx">新增</a></li>
            <li id="toplink31active" title="廣告查看與修改"><a href="#">修改</a></li>
            <li id="toplink41" title="查看與修改廣告"><a href="#"></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2orange">
        廣告-修改
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phcategory" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    類別:&nbsp;</div>
                <div class="contentdiv1right">
                    <asp:DropDownList ID="ddrBannerCategory" runat="server">
                    </asp:DropDownList>
                    <br />
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phlocation" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    位置:&nbsp;</div>
                <div class="contentdiv1right">
                    <asp:DropDownList ID="ddrBannerLocation" runat="server">
                    </asp:DropDownList>
                    <br />
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phcustomer" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    客戶:&nbsp;</div>
                <div class="contentdiv1right">
                    <asp:DropDownList ID="ddrBannerCustomer" runat="server">
                    </asp:DropDownList>
                    <br />
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
        <asp:PlaceHolder ID="phurl" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    網址:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="請填寫網址!"
                        SetFocusOnError="True" ControlToValidate="txtWebUrl">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="請輸入正確網址"
                        Text="*" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"
                        ControlToValidate="txtWebUrl"></asp:RegularExpressionValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtWebUrl" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phprice" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    價格:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="請輸入價格!"
                        SetFocusOnError="True" ControlToValidate="txtPrice">*</asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="input1" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                            onkeydown="this.value=this.value.replace(/[^0-9]/g,'')"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phprob" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    顯示機率:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="請輸入機率值!"
                        SetFocusOnError="True" ControlToValidate="txtProb">*</asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtProb" runat="server" CssClass="input1" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                            onkeydown="this.value=this.value.replace(/[^0-9]/g,'')"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phtarget" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    網頁顯示方式:&nbsp;</div>
                <div class="contentdiv1right">
                    <asp:DropDownList ID="ddlTarget" runat="server">
                        <asp:ListItem Text="本頁顯示" Value="_self"></asp:ListItem>
                        <asp:ListItem Text="子頁顯示" Value="_parent"></asp:ListItem>
                        <asp:ListItem Selected="True" Text="開新頁顯示" Value="_blank"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phstartdate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    起始日期:&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ErrorMessage="請輸入起始日期" SetFocusOnError="True" ControlToValidate="txtStartDate">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="請輸入正確日期"
                        Text="*" ControlToValidate="txtStartDate" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                </div>
                <asp:TextBox ID="txtStartDate" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="yyyy/MM/dd"
                    TargetControlID="txtStartDate">
                </cc1:CalendarExtender>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phenddate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    結束日期:&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                        ErrorMessage="請輸入結束日期" SetFocusOnError="True" ControlToValidate="txtEndDate">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="請輸入正確日期"
                        Text="*" ControlToValidate="txtEndDate" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator></div>
                <asp:TextBox ID="txtEndDate" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy/MM/dd" TargetControlID="txtEndDate">
                </cc1:CalendarExtender>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phcreatedate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    建立日期:</div>
                <asp:TextBox ID="txtCreatedate" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="pheditdate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    修改日期:</div>
                <asp:TextBox ID="txtEditDate" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phimg" runat="server">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:HiddenField ID="hfImageIndex" runat="server" />
                    <div class="contentdiv4">
                        <div class="contentdiv1left">
                            <span>列表圖片：</span></div>
                        <div class="contentdiv1right">
                            <asp:FileUpload ID="fuImage" runat="server" />
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
                                                <asp:Label ID="lbImageID" Visible="false" runat="server" Text='<%#Eval("bp_image") %>'></asp:Label>
                                                <asp:Image ID="Image1" Width="100" AlternateText='<%#Eval("bp_image") %>' runat="server"
                                                    ImageUrl='<%#Tools.GetAppSettings("ProductImageTempPath")+Eval("bp_image") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbImage" runat="server" Text='<%#Eval("bp_imagename") %>'></asp:Label>
                                                &nbsp;<asp:LinkButton ID="lkDelete" CommandArgument='<%#Eval("bp_image") %>' CommandName="Delete"
                                                    CausesValidation="false" runat="server">刪除</asp:LinkButton>
                                                <asp:LinkButton ID="lkUpdate" CommandArgument='<%#Eval("bp_image") %>' CommandName="Update"
                                                    runat="server" CausesValidation="false">設定首圖</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btImage" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:PlaceHolder>
        <div class="contentdiv3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>
