<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="Add.aspx.cs" Inherits="Manager_FriendLink_Add" %>
<%@ Register Src="~/UserControl/public/Ckeditorl.ascx" TagName="ckeditor" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenu">
        <asp:HiddenField ID="hfLanguage" runat="server" />
        <ul>
            <li id="toplink1" title="列表"><span><a href="List.aspx">列表</a></span></li><li id="toplink2active"
                title="增加"><span><a href="#">新增</a></span></li><li id="toplink3" title="查看與修改產品類別">
            </li>
            <%--            <li id="toplink5" title="生成HTML文件"><a href="#"><span></span></a></li>--%>
        </ul>
    </div>
    <div class="RightTableTdSubheader2">
        專業團隊-新增
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phcategory" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    職稱:&nbsp;</div>
                <div class="contentdiv1right">
                    <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="false">
                        <asp:ListItem Selected="True" Value="0">選擇職稱</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phtitle" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    姓名:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請填寫姓名!"
                        SetFocusOnError="True" ControlToValidate="txtName">*</asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder7" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    稱謂:
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtName" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    學歷:
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <uc:ckeditor ID="uc1" runat="server" />
                        <%--<asp:TextBox ID="txtDegree" runat="server" CssClass="input1" TextMode="MultiLine" Width="500" Height="150"></asp:TextBox>--%>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    經歷:
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <uc:ckeditor ID="uc2" runat="server" />
                        <%--<asp:TextBox ID="txtHistory" runat="server" CssClass="input1" TextMode="MultiLine" Width="500" Height="150"></asp:TextBox>--%>
                    
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder3" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    著作:
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <uc:ckeditor ID="uc3" runat="server" />
                        <%--<asp:TextBox ID="txtBooks" runat="server" CssClass="input1" TextMode="MultiLine" Width="300" Height="150"></asp:TextBox>--%>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder4" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    法律專長:
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <uc:ckeditor ID="uc4" runat="server" />
                        <%--<asp:TextBox ID="txtSpecialty" runat="server" CssClass="input1" TextMode="MultiLine" Width="300" Height="150"></asp:TextBox>--%>
                    
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder5" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    Email:
                    &nbsp;</div>
                    <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
                        <%--<asp:TextBox ID="txtLicense" runat="server" CssClass="input1" TextMode="MultiLine" Width="300" Height="150"></asp:TextBox>--%>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder6" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    分機號碼:
                    &nbsp;</div>
                    <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
                        <%--<asp:TextBox ID="txtField" runat="server" CssClass="input1" TextMode="MultiLine" Width="300" Height="150"></asp:TextBox>--%>
            </div>
        </asp:PlaceHolder>
        <%--<asp:PlaceHolder ID="phurl" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    連結URL: &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtUrl" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>--%>
        <asp:PlaceHolder ID="phcreatedate" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    建立日期:&nbsp;</div>
                <div class="contentdiv1right">
                    <asp:TextBox ID="txtDate" Enabled="false" runat="server"></asp:TextBox>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="phimage" runat="server">
                    <div class="contentdiv4">
                        <div class="contentdiv1left">
                            建立附加圖片:</div>
                        <div class="contentdiv1right">
                            <asp:FileUpload ID="fuImage" runat="server" />&nbsp;<asp:Button ID="btImage" CausesValidation="false"
                                runat="server" Text="上傳" OnClick="btImage_Click" />
                            <strong>&nbsp; <font style="color: red"><span class="style1">(請勿超過2MB；圖片建議尺寸：寬180高276)</span></font></strong></div>
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
        <%--<asp:PlaceHolder ID="phshow" runat="server">
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
        </asp:PlaceHolder>--%>
        <div class="contentdiv3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>
