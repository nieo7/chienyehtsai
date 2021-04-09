<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCH.master" AutoEventWireup="true" CodeFile="news_det.aspx.cs" Inherits="news_det" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- InstanceBeginEditable name="EditRegion3" -->
            <div id="banner"><img src="img/home/img_bannerhome1.jpg"></div>
			<!-- InstanceEndEditable -->

            <div id="bannershadow"><img src="img/home/img_bannershadow.png"></div>

             <!-- InstanceBeginEditable name="EditRegion4" -->
        <div id="center">
        	<div id="tital"><img src="img/news/img_titallogo.jpg" alt="">　最新消息</div>
            <div id="content_about">
                <asp:Repeater ID="RpNews" runat="server">
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
                	<li class="ulli"><a href='#' onclick='window.history.go(-1);return false;'><img src="img/news/img_backarrow.jpg"> 回上頁</a></li>
                	<li class="ulli"><asp:HyperLink ID="HyPre" runat="server">&#8249; 上一則</asp:HyperLink></li>
                  	<li class="ulli"><a href="news.aspx">回列表</a></li>
                    <li class="ulli"><asp:HyperLink ID="HyNext" runat="server">下一則 &#8250;</asp:HyperLink></li>
              	</ul>
            </div>
            </div>
        <div class="top"><a href="#top"></a></div>
        </div>
        <!-- InstanceEndEditable -->
</asp:Content>

