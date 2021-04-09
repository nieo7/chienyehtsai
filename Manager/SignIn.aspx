<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="Manager_SignIn" EnableEventValidation="false" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title><%=UserInfoConfig.GetUserConfig("title") %></title>
<meta name="description" content=""/>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="author" content="(c) 1999-2008 Baystars Design, URL: http://www.baystars.com.tw" />
	<link rel="stylesheet" href="../css/env/css/common.css" type="text/css" />
	<link rel="stylesheet" href="../css/env/css/common_red.css" type="text/css" />
	<!--[if IE]>
	<link rel="StyleSheet" href="../env/css/common-ie.css" type="text/css" />
	<![endif]-->  
</head>
<body>
<form id="form1" runat="server">
<div id="Rootdiv2">	
	<div id="centerdiv">
			<div id="part1">&nbsp;
			</div>
			<div id="part2">管理員登入
			 
                <asp:Label ID="message" runat="server" ForeColor="Red"></asp:Label>
			</div>
			<div id="part3">
				<div class="part3left">
						用戶名：
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請輸入帳號"
                        Text="*" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                         				</div>
				<div class="part3right">
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
				</div>
			</div>
			<div id="part4">
					<div class="part3left">
						密碼：<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="請輸入密碼"
                        Text="*" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
				</div>
				<div class="part3right">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
				</div>
			</div>
			<div id="part5">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" />
                <asp:Button ID="BtLogin" runat="server" Text="登入" OnClick="BtLogin_Click" />
			</div>
	</div> 
	</div>
 </form>
</body>

</html>
