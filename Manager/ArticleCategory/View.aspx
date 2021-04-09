<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Manager_News_NewsView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>文章類別檢視頁面</title>
    	<link rel="stylesheet" href="../../css/env/css/common.css" type="text/css" />
	<link rel="stylesheet" href="../../css/env/css/common-ie.css" type="text/css" />
	<link href="../../css/env/css/sample.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="RightTableTdContent">
            <div class="cleandiv1">
            </div>
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    文章類別標題:
                </div>
                 <div class="contentdiv1right">
                <asp:Label ID="lbTitle" runat="server"></asp:Label>
                </div>
            </div>
                        <%--<div class="contentdiv1">
                <div class="contentdiv1left">
                    建立日期:
                </div>
                 <div class="contentdiv1right">
                <asp:Label ID="lbBuilddate" runat="server"></asp:Label>
                </div>
            </div>--%>
            <%--<div class="contentdiv2">
                <div class="contentdiv2left">
                   訊息類別描述:
                </div>
                <div class="contentdiv2right">

                  <asp:Label ID="lbContent" runat="server"></asp:Label>
                </div>
            </div>     --%>
            </div>
            </div>                    
    </form>
</body>
</html>
