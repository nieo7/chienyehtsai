<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="Add.aspx.cs" Inherits="Manager_Member_Add" %>

<%@ Register TagName="AddressTag1" TagPrefix="AddressPre1" Src="~/UserControl/public/Address.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#<%=txtBirthday.ClientID %>").mask("9999/99/99");
            $("#<%=txtTel.ClientID %>").mask("(99)9999999");
            $("#<%=txtPhone.ClientID %>").mask("9999-999999");
            $("#<%=txtAccount.ClientID %>").blur(function () {
                var _this = $(this);
                if ($.trim(_this.val()) != "") {
                    $.ajax({
                        url: '<%=ResolveClientUrl("~/ashx/MemberAccountValitador.ashx") %>',
                        type: 'POST',
                        dataType: 'html',
                        data: { checkvar: _this.val(), checkOption: "account" },
                        success: function (response) {
                            if (response != "OK") {
                                $("#<%=lbAccountFail.ClientID %>").show();
                                $("#<%=lbAccountFail.ClientID %>").html('Fail');
                                $("#<%=btnSubmit.ClientID%>").attr('disabled', true);
                                alert("此名稱已有人使用");
                                _this.focus();
                            }
                            else {
                                $("#<%=lbAccountFail.ClientID %>").hide();
                                $("#<%=btnSubmit.ClientID %>").attr('disabled', false);
                            }
                        }
                    });
                }
            });
            $("#<%=txtNickname.ClientID %>").blur(function () {
                var _this = $(this);
                if ($.trim(_this.val()) != "") {
                    $.ajax({
                        url: '<%=ResolveClientUrl("~/ashx/MemberAccountValitador.ashx") %>',
                        type: 'POST',
                        dataType: 'html',
                        data: { checkvar: _this.val(), checkOption: "nickname" },
                        success: function (response) {
                            if (response != "OK") {
                                $("#<%=lbNickname.ClientID %>").show();
                                $("#<%=lbNickname.ClientID %>").html('Fail');
                                $("#<%=btnSubmit.ClientID%>").attr('disabled', true);
                                alert("此匿稱已有人使用");
                                _this.focus();
                            }
                            else {
                                $("#<%=lbNickname.ClientID %>").hide();
                                $("#<%=btnSubmit.ClientID %>").attr('disabled', false);
                            }
                        }
                    });
                }
            });
        });        
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
        會員資料-新增
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:PlaceHolder ID="phaccount" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                帳號:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請填寫帳號!"
                    SetFocusOnError="True" ControlToValidate="txtAccount" ValidationGroup="abc">*</asp:RequiredFieldValidator>
                &nbsp;</div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="txtAccount" runat="server" CssClass="input1"></asp:TextBox>
                    <font color="red">
                        <asp:Label ID="lbAccountFail" runat="server"></asp:Label></font>
                </div>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phfname" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                姓氏:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="請填寫姓氏!"
                    SetFocusOnError="True" ControlToValidate="txtFirstName" ValidationGroup="abc">*</asp:RequiredFieldValidator>
                &nbsp;</div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="input1"></asp:TextBox>
                </div>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phname" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                姓名:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="請填寫姓名!"
                    SetFocusOnError="True" ControlToValidate="txtname" ValidationGroup="abc">*</asp:RequiredFieldValidator>
                &nbsp;</div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="txtname" runat="server" CssClass="input1"></asp:TextBox>
                </div>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phnickname" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                匿稱:<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="請填寫匿稱!"
                    SetFocusOnError="True" ControlToValidate="txtNickname" ValidationGroup="abc">*</asp:RequiredFieldValidator>
                &nbsp;</div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="txtNickname" runat="server" CssClass="input1"></asp:TextBox>
                    <font color="red">
                        <asp:Label ID="lbNickname" runat="server"></asp:Label></font>
                </div>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phmail" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                信箱:<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="請填寫信箱"
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
        <asp:PlaceHolder ID="phbirthday" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                生日:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="請填寫生日!"
                    SetFocusOnError="True" ControlToValidate="txtBirthday" ValidationGroup="abc">*</asp:RequiredFieldValidator>
                &nbsp;</div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="txtBirthday" runat="server" CssClass="input1"></asp:TextBox>
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
        <asp:PlaceHolder ID="phphone1" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                聯絡電話:<asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtTel"
                    Display="Static" ErrorMessage="請輸入9碼" Text="*" OnServerValidate="CustomValidator1_ServerValidate"
                    ValidateEmptyText="true" ValidationGroup="abc"></asp:CustomValidator></div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="txtTel" runat="server" MaxLength="20" CssClass="input1"></asp:TextBox>
                </div>
            </div>
        </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phphone2" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                手機:
                <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtPhone"
                    Display="Static" ErrorMessage="請輸入10~20碼之間" ValidateEmptyText="True" OnServerValidate="CustomValidator2_ServerValidate"
                    Text="*" ValidationGroup="abc"></asp:CustomValidator>
            </div>
            <div class="contentdiv1right">
                <div class="specialdivfix1">
                    <asp:TextBox ID="txtPhone" runat="server" MaxLength="20" CssClass="input1"></asp:TextBox>
                </div>
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
        <asp:PlaceHolder ID="phSMTP" runat="server">
        <div class="contentdiv4">
            <div class="contentdiv1left">
                寄發信件:</div>
            <div class="contentdiv1right">
                <asp:RadioButtonList ID="rbSMTP" runat="server" Width="231px" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                    <asp:ListItem Value="1">是</asp:ListItem>
                </asp:RadioButtonList>
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
