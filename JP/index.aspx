<%@ Page Title="" Language="C#" MasterPageFile="~/JP/MasterPageJP.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="JP_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
<script type="text/javascript" src="../scripts/jquery.badBrowser.js" charset="big5"></script>
<script type="text/javascript" src="../scripts/swfobject.js"></script>
<script type="text/javascript" src="../scripts/smartRollover.js"></script>
<script type="text/javascript" src="../scripts/jcarousellite_1.0.1.min.js"></script>
<script type="text/javascript" src="../Scripts/jquery.cycle.all.js"></script>
<script type="text/javascript" src="../Scripts/jquery.totemticker.js"></script>
<script type="text/javascript" src="../Scripts/jquery.li-scroller.1.0.js"></script>
<script type="text/javascript" src="../Scripts/MSClass1.65.js"></script>
<script type="text/javascript" src="../Scripts/MSClass.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="center">
        	<div id="motto"><img src="img/home/img_motto.png" alt="motto"></div>
            <div id="news">
            	<div class="tital_sign">最新消息　　　　　　　　　　<span class="news_more"><a href="news.aspx">MORE+</a></span></div>
                <div class="news_event">
                	<div id="newsplay">
                        <ul>
                            <asp:Repeater ID="RpIndexNews" runat="server">
                                <ItemTemplate>
                                    <li><img src="img/home/dot.png">　<%#Eval("n_ts","{0:yyyy.MM.dd}") %><br><span class="news"><a href='<%#String.Format("news_det.aspx?id={0}",Eval("n_id")) %>'><%#Eval("n_title") %></a></span></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
				</div>
            </div>
            <div style="float:left"><img src="img/home/img_homeVline.jpg"></div>
            <div id="services">
            	<div class="tital_sign">專業服務</div>
                <div class="services_event">
                <ul>
                	<li><img src="img/home/dot.png">　仲裁及び訴訟案件の取り扱い (民事、刑事、行政訴<br>　 &nbsp; 訟)</li>
                    <li><img src="img/home/dot.png">　法律顧問</li>
                    <li><img src="img/home/dot.png">　法的監査</li>
                    <li><img src="img/home/dot.png">　商事契約の立案/レビュー/交渉</li>
                    <li><img src="img/home/dot.png">　参入促進案件</li>
                    <li><img src="img/home/dot.png">　政府調達に関する紛議</li>
                    <li><img src="img/home/dot.png">　会社の上場や店頭公開(海外企業の台湾での上場や<br>　 &nbsp; 店頭公開を含む)</li>
                </ul>
				</div>

            </div>
        </div>
</asp:Content>

