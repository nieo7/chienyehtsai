<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GBReport.aspx.cs" Inherits="Manager_GBMessage_GBReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../css/env/css/common.css" type="text/css" />
    <link rel="stylesheet" href="../../css/env/css/common-ie.css" type="text/css" />
    <link href="../../css/env/css/sample.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../js/humanmsg.js" type="text/javascript"></script>
    <link href="../../css/humanmsg.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="RightTableTdContent_view">
        <div class="cleandiv1">
        </div>
        <div class="contentdiv4">
            <div class="contentdiv1left">
            </div>
            <div class="contentdiv1right">
                <asp:PlaceHolder ID="phtoptitle" runat="server">標題:
                    <asp:Label ID="lbTitle" runat="server"></asp:Label>|</asp:PlaceHolder>
                <asp:PlaceHolder ID="phhits" runat="server">瀏覽數:
                    <asp:Label ID="lbHits" runat="server"></asp:Label>| </asp:PlaceHolder>
                <asp:PlaceHolder ID="phname" runat="server">發文者:<asp:Label ID="lbName" runat="server"></asp:Label></asp:PlaceHolder>
            </div>
        </div>
        <asp:PlaceHolder ID="phcontent" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv2left">
                    内容:
                </div>
                <div class="contentdiv2right">
                    <asp:Literal ID="litContent" runat="server"></asp:Literal>
                </div>
            </div>
        </asp:PlaceHolder>
        <div class="contentdiv4">
            <div class="contentdiv1left">
                時間
            </div>
            <div class="contentdiv1right">
                <asp:PlaceHolder ID="phcreatedate" runat="server">建立時間:
                    <asp:Label ID="lbCreateDate" runat="server"></asp:Label>
                    | </asp:PlaceHolder>
                <asp:PlaceHolder ID="pheditdate" runat="server">修改時間:
                    <asp:Label ID="lbEditDate" runat="server"></asp:Label></asp:PlaceHolder>
            </div>
        </div>
        <h1>
            回應</h1>
        <asp:PlaceHolder ID="phrpgbre" runat="server">
            <asp:Repeater ID="RpGBre" runat="server" OnItemDataBound="RpGBre_ItemDataBound">
                <ItemTemplate>
                    <hr />
                    <asp:HyperLink ID="hyName" runat="server" Text='<%#Eval("g_name")%>' NavigateUrl='<%#Eval("g_url") %>'
                        Target="_blank"></asp:HyperLink>&nbsp;
                    <asp:Literal ID="litAddDate" runat="server" Text='<%#Convert.ToDateTime(Eval("g_adddate").ToString()).ToString("yyyy/MM/dd/ hh:mm") %>'></asp:Literal><br />
                    <asp:Literal ID="litTitle" runat="server"></asp:Literal><br />
                    <div>
                        <asp:Literal ID="litGBreContent" runat="server" Text='<%#Eval("g_content") %>'></asp:Literal>
                    </div>
                    <br />
                    <hr />
                </ItemTemplate>
            </asp:Repeater>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phtitle" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    標題:
                </div>
                <div class="contentdiv1right">
                    <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phgbrename" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    名稱:
                </div>
                <div class="contentdiv1right">
                    <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" runat="server" ErrorMessage="請填寫名稱!" SetFocusOnError="True"
                        ControlToValidate="txtName">*</asp:RequiredFieldValidator>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phgbremail" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    Email:
                </div>
                <div class="contentdiv1right">
                    <asp:TextBox ID="txtMail" runat="server" Width="300px"></asp:TextBox>&nbsp;
                    <asp:CheckBox ID="chkReportMail" runat="server" Text="顯示" />
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phgbreurl" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    Url:
                </div>
                <div class="contentdiv1right">
                    <asp:TextBox ID="txtUrl" runat="server" Width="300px"></asp:TextBox>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phgbrecontent" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv2left">
                    內容:
                </div>
                <div class="contentdiv2right">
                    <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="6"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="請填寫內容!" SetFocusOnError="True"
                        ControlToValidate="txtContent">*</asp:RequiredFieldValidator>
                </div>
            </div>
        </asp:PlaceHolder>
        <div class="contentdiv4">
            <div class="contentdiv1left">
            </div>
            <div class="contentdiv1right">
                <img alt="" src="../../ashx/ImageValidator.ashx" onclick="this.src=this.src+'?'"
                    width="120px" />
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><font color="blue">請輸入驗證碼</font>
                <br />
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" /></div>
        </div>
        <div style="float: right">
            <a href='#' onclick='window.history.go(-1);return false;'>BACK</a>
        </div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" />
    </div>
    </form>
</body>
</html>
