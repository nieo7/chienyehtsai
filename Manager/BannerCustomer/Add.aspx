<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="Add.aspx.cs" Inherits="Manager_BannerCustomer_Add" %>

<%@ Register TagName="AddressTag1" TagPrefix="AddressPre1" Src="~/UserControl/public/Address.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenu">
        <ul>
            <li id="toplink1" title="文章欄位管理"><span><a href="List.aspx">列表</a></span></li><li
                id="toplink2active" title="增加"><span><a href="#">新增</a></span></li><li id="toplink3"
                    title="查看與修改文章"><span></span></li>
            <li id="toplink5" title="生成HTML文件"><a href="#"><span></span></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2">
        廣告客戶-新增
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phcompanyname" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    公司名稱:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請填寫企業名稱!"
                        SetFocusOnError="True" ControlToValidate="txtcompanyname" ValidationGroup="abc">*</asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtcompanyname" runat="server" CssClass="input1"></asp:TextBox>
                        <font color="red">
                            <asp:Label ID="lbAccountFail" runat="server"></asp:Label></font>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phcompanytype" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    公司類型:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="請填寫類型!"
                        SetFocusOnError="True" ControlToValidate="txtcompanytype" ValidationGroup="abc">*</asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtcompanytype" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phcompanyphone" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    公司電話:</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtCompanyPhone" runat="server" MaxLength="20" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phfax" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    公司傳真:
                </div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtCompanyfax" runat="server" MaxLength="9" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                            onkeydown="this.value=this.value.replace(/[^0-9]/g,'')" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phname" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    連絡人姓名:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="請填寫姓名!"
                        SetFocusOnError="True" ControlToValidate="txtname" ValidationGroup="abc">*</asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtname" runat="server" CssClass="input1" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phsex" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    連絡人性別:</div>
                <div class="contentdiv1right">
                    <asp:RadioButtonList ID="rbSex" runat="server" Width="231px" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="男">男</asp:ListItem>
                        <asp:ListItem Value="女">女</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phphone" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    連絡人電話:
                </div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtPhone" runat="server" MaxLength="20" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                            onkeydown="this.value=this.value.replace(/[^0-9]/g,'')" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmail" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    連絡人信箱:<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="請填寫信箱"
                        Text="*" ControlToValidate="txtMail" ValidationGroup="abc"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="請輸入正確的信箱格式"
                        ControlToValidate="txtMail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ValidationGroup="abc">*</asp:RegularExpressionValidator>
                </div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtMail" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phaddress" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    地址:&nbsp;</div>
                <div class="contentdiv1right_ajaxfileupload">
                    <AddressPre1:AddressTag1 runat="server" ID="address1" />
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phnote" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv1left">
                    備註:
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="txtContact"
                        ErrorMessage="輸入字數限於300以下" OnServerValidate="CustomValidator3_ServerValidate"
                        ValidationGroup="abc">*</asp:CustomValidator>
                </div>
                <div class="contentdiv1right">
                    <asp:TextBox ID="txtContact" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox>
                </div>
            </div>
        </asp:PlaceHolder>
        <div class="contentdiv3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="abc" />
            <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" ValidationGroup="abc" />
        </div>
    </div>
</asp:Content>
