<%@ Page Title="" Language="C#" MasterPageFile="~/JP/MasterPageJP.master" AutoEventWireup="true" CodeFile="sitemap.aspx.cs" Inherits="JP_sitemap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="center">
        	<div id="tital"><img src="img/sitemap/img_titallogo.jpg" alt="">　網站導覽</div>
            <div id="content_about">
           	  <ul class="font_bold">
               	  <li><a href="index.html">首頁</a></li>
                        <hr>
                        <li>当事務所の概要
                        	<div>
                       	  	<ul>
                           		<li class="ulli"><img src="img/home/dot.png">　<a href="about.aspx">建業高雄所の沿革</a></li>
								<li class="ulli"><img src="img/home/dot.png">　<a href="about_logo.aspx">高雄所のロゴ</a></li>
                            	<li class="ulli"><img src="img/home/dot.png">　<a href="about_feature.aspx">特徴</a></li>
                            	<li class="ulli"><img src="img/home/dot.png">　<a href="about_area.aspx">サービスエリア</a></li>
                            	<li class="ulli"><img src="img/home/dot.png">　<a href="about_patriarch.aspx">飲水思源</a></li>
                          	</ul>
                          	</div><br>
                        </li>
                        <hr>
                  		<li style="clear:left;"><a href="services.aspx">業務分野</a></li>
                        <hr>
                        <li><a href="team.aspx">プロフェッショナルチーム</a></li>
                        <hr>
                        <li><a href="hire.aspx">社員採用情報</a></li>
                        <hr>
                        <li><a href="news.aspx">最新消息</a></li>
                        <hr>
                        <li><a href="contact.aspx">联络我们</a></li>
                        <hr>
                		<li><a href="sitemap.aspx">網站導覽</a></li>
              </ul>
			</div>
        <div class="top"><a href="#top"></a></div>
        </div>
</asp:Content>

