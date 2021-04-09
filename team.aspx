<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCH.master" AutoEventWireup="true" CodeFile="team.aspx.cs" Inherits="team" %>

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
<style type="text/css">
    #slider{
        clear:both;
        height:280px;
        width:730px;
        padding:0;
        margin:0 auto;
        z-index:0;
        display:block;
        }
</style>
<script type="text/javascript">
    $(function () {
        $('#slider').cycle({
            fx: 'fade',
            speed: 2000,
            timeout: 1000,
            random: 1
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- InstanceBeginEditable name="EditRegion3" -->
            <div id="banner">
                <img src="img/team/img_bannerteam.jpg">
                <%--<div id="slider">
                <img src="img/services/img_bannerservices1.jpg" />
                <img src="img/services/img_bannerservices2.jpg" />
                <img src="img/team/img_bannerteam.jpg" />
                </div>--%>
            </div>
			<!-- InstanceEndEditable -->
            
          <div id="bannershadow"><img src="img/home/img_bannershadow.png"></div>

          <!-- InstanceBeginEditable name="EditRegion4" -->
        <div id="center">
        	<div id="tital"><img src="img/team/img_titallogo.jpg" alt="">　專業團隊</div>
            <div id="content_about">
               
                <asp:Repeater ID="Rpteam" runat="server" onitemdatabound="Rpteam_ItemDataBound">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfid" runat="server" Value='<%#Eval("fc_id") %>' />
                        <div class="team">
                        <img src="img/home/dot.png"> <%#Eval("fc_title") %><br>
                            <asp:Repeater ID="RpSub" runat="server">
                                <ItemTemplate>
                                    <div class="person"><a href='<%#String.Format("team_det.aspx?id={0}",Eval("f_id")) %>'><%#Eval("f_title") %> <%#Eval("f_name") %></a></div>
                                </ItemTemplate>
                            </asp:Repeater>
       	  	            </div>
                    </ItemTemplate>
                </asp:Repeater>
               
				<%--<div class="team">
                <img src="img/home/dot.png"> 所長<br>
                    <asp:Repeater ID="RpDirector" runat="server">
                        <ItemTemplate>
                            <div class="person"><a href='<%#String.Format("team_det.aspx?id={0}",Eval("f_id")) %>'><%#Eval("f_title") %></a></div>
                        </ItemTemplate>
                    </asp:Repeater>
                
       	  	  </div>
                <div class="team">
                <img src="img/home/dot.png"> 顧問律師<br>
                    <asp:Repeater ID="Rpadviser" runat="server">
                        <ItemTemplate>
                            <div class="person"><a href='<%#String.Format("team_det.aspx?id={0}",Eval("f_id")) %>'><%#Eval("f_title") %></a></div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                
                <div class="team">
                <img src="img/home/dot.png"> 合夥律師<br>
                    <asp:Repeater ID="RpPartner" runat="server">
                        <ItemTemplate>
                            <div class="person"><a href='<%#String.Format("team_det.aspx?id={0}",Eval("f_id")) %>'><%#Eval("f_title") %></a></div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                
                <div class="team">
                <img src="img/home/dot.png"> 資深律師<br>
                <asp:Repeater ID="RpLawyer" runat="server">
                        <ItemTemplate>
                            <div class="person"><a href='<%#String.Format("team_det.aspx?id={0}",Eval("f_id")) %>'><%#Eval("f_title") %></a></div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                
                <div class="team">
                <img src="img/home/dot.png"> 專案經理<br>
                <asp:Repeater ID="RpAgent" runat="server">
                        <ItemTemplate>
                            <div class="person"><a href='<%#String.Format("team_det.aspx?id={0}",Eval("f_id")) %>'><%#Eval("f_title") %></a></div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                
                <div class="team">
                <img src="img/home/dot.png"> 行政組<br>
                <asp:Repeater ID="RpAdministrator" runat="server">
                        <ItemTemplate>
                            <div class="person"><a href='<%#String.Format("team_det.aspx?id={0}",Eval("f_id")) %>'><%#Eval("f_title") %></a></div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>--%>
		  </div>
        <div class="top"><a href="#top"></a></div>
        </div>
        <!-- InstanceEndEditable -->
</asp:Content>

