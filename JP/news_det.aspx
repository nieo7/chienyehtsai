<%@ Page Title="" Language="C#" MasterPageFile="~/JP/MasterPageJP.master" AutoEventWireup="true" CodeFile="news_det.aspx.cs" Inherits="JP_news_det" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="center">
        	<div id="tital"><img src="img/news/img_titallogo.jpg" alt="">　最新消息</div>
            <div id="content_about">
            <asp:Repeater ID="Rpnews" runat="server">
                <ItemTemplate>
                    <div id="news_top">
            	        <div class="date"><%#Eval("n_ts","{0:yyyy.MM.dd}") %></div>
            	        <div id="news_tit"><%#Eval("n_title") %></div>
                    </div>
                    <div id="news_txt"><%#Eval("n_detail") %></div>
                </ItemTemplate>
            </asp:Repeater>
            <div id="pageback">
            	<ul>
                	<li class="ulli"><a href='#' onClick='window.history.go(-1);return false;'><img src="img/news/img_backarrow.jpg"> Back</a></li>
                	<li class="ulli"><asp:HyperLink ID="HyPre" runat="server">&#8249; Previous</asp:HyperLink></li>
                  	<li class="ulli"><a href="news.aspx">News list</a></li>
                    <li class="ulli"><asp:HyperLink ID="HyNext" runat="server">Next &#8250;</asp:HyperLink></li>
              	</ul>
            </div>
            </div>
        <div class="top"><a href="#top"></a></div>
        </div>
</asp:Content>

