<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SMTPSet.aspx.cs" Inherits="webs_SMTPSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .SYN_ROW
        {
            background: silver;
        }
        .SYN_TXT
        {
            border-left: 1px solid;
            position: relative;
            left: 4.5em;
            background: white;
            font-family: monospace;
            margin-right: 4.5em;
        }
        
        .HTML_TXT
        {
            color: #000000;
        }
        .HTML_TAG
        {
            color: #0000ff;
        }
        .HTML_ELM
        {
            color: #800000;
        }
        .HTML_ATR
        {
            color: #ff0000;
        }
        .HTML_VAL
        {
            color: #0000ff;
        }
        .SYN_LNB
        {
            position: absolute;
            left: 0;
        }
        .SYN_LNN
        {
            padding: 0;
            color: black;
            border: 0;
            text-align: right;
            width: 3.5em;
            height: 1em;
            font-family: monospace;
            background: transparent;
            cursor: default;
            font-size: 100%;
        }
        .SYN_BCH
        {
            display: none;
        }
        .HTML_CHA
        {
            color: #ff0000;
        }
        input
        {
            margin-top: 5px;
        }
        .RightTableTdContent_view
        {          
            vertical-align:middle;
            margin: 0px auto;
            padding-left:25%;
                    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width: 100%; text-align: center">
                <br />
                <asp:Label ID="Label1" runat="server" Text="SMTP系統設置" Font-Bold="True" Font-Names="Times New Roman"
                    Font-Size="15pt" ForeColor="Blue"></asp:Label>
            </div>
            <div class="RightTableTdContent_view">
                <table cellspacing="0" cellpadding="4" rules="all" border="1" id="FormView1" style="background-color: White;
                    border-color: #CC9966; border-width: 1px; border-style: None; border-collapse: collapse;">
                    <tr style="color: #663399; background-color: #FFCC66; font-weight: bold;">
                        <td>
                            <br />
                            信件主旨:
                            <asp:TextBox ID="subjectTxt" runat="server"></asp:TextBox>
                            <br />
                            收件人1: &nbsp;
                            <asp:TextBox ID="mail1TextBox" runat="server"></asp:TextBox>
                            <br />
                            收件人2: &nbsp;
                            <asp:TextBox ID="mail2TextBox" runat="server"></asp:TextBox>
                            <br />
                            收件人3: &nbsp;
                            <asp:TextBox ID="mail3TextBox" runat="server"></asp:TextBox>
                            <br />
                            收件人4: &nbsp;
                            <asp:TextBox ID="mail4TextBox" runat="server"></asp:TextBox>
                            <br />
                            收件人5: &nbsp;
                            <asp:TextBox ID="mail5TextBox" runat="server"></asp:TextBox>
                            <br />
                            發件者信箱:
                            <asp:TextBox ID="hostmailTextBox" runat="server"></asp:TextBox>
                            <br />
                            發件者名稱:
                            <asp:TextBox ID="hostnameTextBox" runat="server"></asp:TextBox>
                            <br />
                            Port: &nbsp;
                            <asp:TextBox ID="portTextBox" runat="server"></asp:TextBox>
                            <br />
                            主機 :
                            <asp:TextBox ID="ServerTxt" runat="server"></asp:TextBox>
                            <br />
                            <div style="width: 100%; text-align: center">
                                <asp:Button ID="Button1" runat="server" Text="更新" OnClick="Button1_Click" />
                                <asp:Button ID="Button2" runat="server" Text="預設" OnClick="Button2_Click" />
                            </div>
                            <div style="width: 100%; float: left">
                                <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
