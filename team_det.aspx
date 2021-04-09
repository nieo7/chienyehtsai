<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCH.master" AutoEventWireup="true" CodeFile="team_det.aspx.cs" Inherits="team_det" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- InstanceBeginEditable name="EditRegion3" -->
            <div id="banner"><img src="img/team/img_bannerteam.jpg"></div>
			<!-- InstanceEndEditable -->
            
          <div id="bannershadow"><img src="img/home/img_bannershadow.png"></div>

          <!-- InstanceBeginEditable name="EditRegion4" -->
        <div id="center">
        	<div id="tital"><img src="img/team/img_titallogo.jpg" alt="">　專業團隊</div>
            <div id="content_about">
            	<div id="team_pic">
                    <asp:Image ID="Image1" runat="server" Width="120" Height="184" /><br><img src="img/team/img_photoshadow.png" width="120" height="13"></div>
                <div id="team_info">
                <div id="team_item">
                	<div class="team_titL"><asp:Literal ID="litName" runat="server"></asp:Literal></div>
                    <div class="team_txt"><asp:Literal ID="litTitle" runat="server"></asp:Literal></div>
                </div>
                <div id="team_item">
                	<div class="team_tit">學歷</div>
                    <div class="team_txt">
                        <asp:Literal ID="litDegree" runat="server"></asp:Literal>
                    	<%--<ul>
                    		<li>國立中正大學法律研究所法學碩士（LL.M.）</li>
                        	<li>國立中興大學法律學系法學士（LL.B.）</li>
                        	<li>中華民國律師高考及格</li>
                    	</ul>--%>
                    </div>
                </div>
                <div id="team_item">
                	<div class="team_tit">經歷</div>
                    <div class="team_txt">
                        <asp:Literal ID="litHistory" runat="server"></asp:Literal>
                    </div>
                </div>
                <div id="team_item">
                	<div class="team_tit">著作</div>
                    <div class="team_txt">
                        <asp:Literal ID="litBooks" runat="server"></asp:Literal>
                    	<%--<ul>
                    		<li>金融資產證券化條例有關特殊目的信託之研究</li>
                    	</ul>--%>
                    </div>
                </div>
                <div id="team_item">
                	<div class="team_tit">法律專長</div>
                    <div class="team_txt">
                        <asp:Literal ID="litSpecialty" runat="server"></asp:Literal>
                    </div>
                </div>
                <%--<div id="team_item">
                	<div class="team_tit">E-mail</div>
                    <div class="team_txt">
                        <asp:Literal ID="litEmail" runat="server"></asp:Literal>
                    	<ul>
                    		<li>&nbsp;</li>
                    	</ul>
                    </div>
                </div>
                <div id="team_item">
                	<div class="team_tit">分機號碼</div>
                    <div class="team_txt">
                        <asp:Literal ID="litPhone" runat="server"></asp:Literal>
                    	<ul>
                    		<li>&nbsp;</li>
                    	</ul>
                    </div>
                </div>--%>
                <div id="team_item">
                    <asp:Repeater ID="Rpnews" runat="server">
                        <ItemTemplate>
                            <div class="font_bold"><span style="float:right;"><a href='<%#String.Format("news_det.aspx?id={0}",Eval("n_id")) %>'>相關文章 &raquo;</a></span></div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="team_item">
                	<ul>
                		<li class="ulli2">　　　　　　　　<a href='#' onClick='window.history.go(-1);return false;'><img src="img/news/img_backarrow.jpg"> 回上頁</a></li>
                    </ul>
                </div>
                </div>
            </div>
        <div class="top"><a href="#top"></a></div>
        </div>
        <!-- InstanceEndEditable -->
</asp:Content>

