<%@ Page Title="" Language="C#" MasterPageFile="~/EN/MasterPageEN.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="EN_index" %>

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
<img src="img/home/img_bannerhome1.jpg" width="730" height="280">
            
          <div id="bannershadow"><img src="img/home/img_bannershadow.png"></div>
          <div id="center">
        	<div id="motto"><img src="img/home/img_motto.png" alt="motto"></div>
            <div id="news">
            	<div class="tital_sign">News　　　　　　　　　　　<span class="news_more"><a href="news.aspx">MORE+</a></span></div>
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
            	<div class="tital_sign2">Practice Areas</div>
                <div class="services_event">
                <ul>
                	<li><img src="img/home/dot.png">　Arbitration and Litigation Practice(Civil, Criminal, <br>　&nbsp; and Administrative Litigation)</li>
                    <li><img src="img/home/dot.png">　Corporate Legal Consultation</li>
                    <li><img src="img/home/dot.png">　Legal Due Diligence Review</li>
                    <li><img src="img/home/dot.png">　Contract Drafting, Review, and Counseling</li>
                    <li><img src="img/home/dot.png">　Public Construction and BOT/PPP</li>
                    <li><img src="img/home/dot.png">　Government Procurement Disputes</li>
                    <li><img src="img/home/dot.png">　Initial Public Offering ("IPO"), Including <br>　&nbsp; overseas companies listed in Taiwan.</li>
                </ul>
				</div>

            </div>
        </div>

        <%--<script type="text/javascript">
            var Marquee2 = new Marquee("newsplay")
            Marquee2.Direction = 0;
            Marquee2.Step = 2;
            Marquee2.Width = 350;
            Marquee2.Height = 200;
            Marquee2.Timer = 100;
            Marquee2.DelayTime = 0;
            Marquee2.WaitTime = 0;
            Marquee2.ScrollStep = 52;
            Marquee2.Start();
    </script>--%>
</asp:Content>

