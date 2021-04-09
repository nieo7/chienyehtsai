<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="Add.aspx.cs" Inherits="Manager_Contact_Add" %>

<%@ Register TagName="AddressTag1" TagPrefix="AddressPre1" Src="~/UserControl/public/Address.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function clear1() {
            $("#RightTableTdContent").find(":text,textarea").each(function () {
                $(this).val("");
            });
        }
    </script>
    <div class="RightTableTdTopmenu">
        <ul>
            <li id="toplink1" title="文章欄位管理"><span><a href="List.aspx">列表</a></span></li><li
                id="toplink2active" title="增加文章"><span><a href="#">新增</a></span></li><li id="toplink3"
                    title="查看與修改文章"><span></span></li>
            <li id="toplink5" title="生成HTML文件"><a href="#"><span></span></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2">
        聯絡我們-新增
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phname" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    姓名:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請填寫姓名!"
                        SetFocusOnError="True" ControlToValidate="txtName" ValidationGroup="abc">*</asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtName" runat="server" CssClass="input1" MaxLength="254"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phsex" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    性別:</div>
                <div class="contentdiv1right">
                    <asp:RadioButtonList ID="rbSex" runat="server" Width="231px" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="男">男</asp:ListItem>
                        <asp:ListItem Value="女">女</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmail" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    信箱:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="請填寫信箱"
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
        <asp:PlaceHolder ID="phphone1" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    電話:<asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtTel"
                        Display="Static" ErrorMessage="請輸入9碼" OnServerValidate="CustomValidator1_ServerValidate"
                        ValidateEmptyText="true" ValidationGroup="abc">請輸入9碼</asp:CustomValidator>
                </div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtTel" runat="server" MaxLength="9" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                            onkeydown="this.value=this.value.replace(/[^0-9]/g,'')" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phphone2" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    手機:
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="txtPhone"
                        Display="Static" ErrorMessage="請輸入10~20碼之間" ValidateEmptyText="True" OnServerValidate="CustomValidator2_ServerValidate"
                        Text="*" ValidationGroup="abc"></asp:CustomValidator>
                </div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtPhone" runat="server" MaxLength="20" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                            onkeydown="this.value=this.value.replace(/[^0-9]/g,'')" CssClass="input1"></asp:TextBox>
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
        <asp:PlaceHolder ID="phsubject" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    標題:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="請填寫標題!"
                        SetFocusOnError="True" ControlToValidate="txtTitle" ValidationGroup="abc">*</asp:RequiredFieldValidator>
                    &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phdetail" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv2left">
                    内容:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="請填寫內容!"
                        SetFocusOnError="True" ControlToValidate="txtContent" ValidationGroup="abc">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator4" runat="server" ControlToValidate="txtContent"
                        ErrorMessage="輸入字數限於300以下" OnServerValidate="CustomValidator3_ServerValidate"
                        ValidationGroup="abc">*</asp:CustomValidator>
                </div>
                <div class="contentdiv2right">
                    <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="8"></asp:TextBox>
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
