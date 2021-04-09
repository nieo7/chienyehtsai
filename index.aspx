<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCH.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
<script type="text/javascript" src="scripts/jquery.badBrowser.js" charset="big5"></script>
<script type="text/javascript" src="scripts/swfobject.js"></script>
<script type="text/javascript" src="scripts/smartRollover.js"></script>
<script type="text/javascript" src="scripts/jcarousellite_1.0.1.min.js"></script>
<script type="text/javascript" src="Scripts/jquery.cycle.all.js"></script>
<script type="text/javascript" src="Scripts/jquery.totemticker.js"></script>
<script type="text/javascript" src="Scripts/jquery.li-scroller.1.0.js"></script>
<script type="text/javascript" src="Scripts/MSClass1.65.js"></script>
<script type="text/javascript" src="Scripts/MSClass.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<img src="img/home/img_bannerhome1.jpg" width="730" height="280">
          <div id="bannershadow"><img src="img/home/img_bannershadow.png"></div>

          <!-- InstanceBeginEditable name="EditRegion4" -->
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
                	<%--<ul>
					  	<li><img src="img/home/dot.png">　2012.05.20<br><span class="news"><a href="news_det.html">建業高雄所網站 (http://www.chienyehtsai.com.tw)定2012. 5 / 20 正式啟用</a></span></li>
                		<li><img src="img/home/dot.png">　2012.05.20<br><span class="news"><a href="#">本所胡高誠律師及李榮唐律師於2012.5.25至經濟部工業局高雄臨海工業區服務中心講授「個人資料保護法...</a></span></li>
                		<li><img src="img/home/dot.png">　2012.05.20<br><span class="news"><a href="#">高市府經發局委託本所協助審核「民間自行規劃參與高雄市左營區灣市2市場用地及停2停車場用地BOT公...</a></span></li>
           		    </ul>--%>
				</div>
                </div>
            </div>
            <div style="float:left"><img src="img/home/img_homeVline.jpg"></div>
            <div id="services">
            	<div class="tital_sign">專業服務</div>
                <div class="services_event">
                <ul>
                	<li><img src="img/home/dot.png">　仲裁及訴訟(民、刑、行政)</li>
                    <li><img src="img/home/dot.png">　公司法顧</li>
                    <li><img src="img/home/dot.png">　法律查核</li>
                    <li><img src="img/home/dot.png">　商務契約之研擬/審閱/議定</li>
                    <li><img src="img/home/dot.png">　促參案</li>
                    <li><img src="img/home/dot.png">　政府採購</li>
                    <li><img src="img/home/dot.png">　公司上市櫃</li>
                </ul>
				</div>

            </div>
        </div>
        <!-- InstanceEndEditable -->
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

