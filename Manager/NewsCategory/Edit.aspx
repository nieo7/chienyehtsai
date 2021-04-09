<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Manager/ManagerPage.master"
    AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Manager_NewsCategory_Edit"
    Title="Untitled Page" %>

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
        最新消息類別-修改
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phcategory" runat="server">
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
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="phimg" runat="server">
                    <div class="contentdiv4">
                        <div class="contentdiv1left">
                            建立附加圖片:</div>
                        <div class="contentdiv1right">
                            <asp:FileUpload ID="fuImage" runat="server" />&nbsp;<asp:Button ID="btImage" CausesValidation="false"
                                runat="server" Text="上傳" OnClick="btImage_Click" />
                            <strong>&nbsp; <font style="color: red"><span class="style1">(請勿超過2MB)</span></font></strong></div>
                        <asp:HiddenField ID="hfImg" runat="server" />
                        <br />
                    </div>
                    <div class="contentdiv4_ajaxFileupload">
                        <div class="contentdiv1left_ajaxfileupload">
                            圖片:</div>
                        <div class="contentdiv1right_ajaxfileupload">
                            <asp:Image ID="Image1" Width="100px" runat="server" /></div>
                    </div>
                </asp:PlaceHolder>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btImage" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:PlaceHolder ID="phshow" runat="server">
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
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <asp:Button ID="Button2" runat="server" Text="提交" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>
