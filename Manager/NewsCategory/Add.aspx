<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Manager/ManagerPage.master"
    AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Manager_NewsCategory_Add"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenu">
        <ul>
            <li id="toplink1" title="文章類別欄位管理"><span><a href="List.aspx">列表</a></span></li><li
                id="toplink2active" title="增加文章類別"><span><a href="#">新增</a></span></li><li id="toplink3"
                    title="查看與修改文章類別"><span></span></li>
            <li id="toplink5" title="生成HTML文件"><a href="#"><span></span></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2">
        最新消息類別-新增
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
                    標題:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請填寫文章標題!"
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
