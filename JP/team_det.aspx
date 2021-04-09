<%@ Page Title="" Language="C#" MasterPageFile="~/JP/MasterPageJP.master" AutoEventWireup="true" CodeFile="team_det.aspx.cs" Inherits="JP_team_det" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="center">
        	<div id="tital"><img src="img/team/img_titallogo.jpg" alt="">　專業團隊</div>
            <div id="content_about">
            	<div id="team_pic">
                <asp:Image ID="Image1" runat="server" Width="120" Height="184" /><br><img src="img/team/img_photoshadow.png" width="120" height="13"></div>
           	  <div id="team_info">
                <div id="team_item">
                	<div style="width:590px; float:left; border-bottom: solid 2px #e7dcc9;margin-bottom:10px;">
                        <div class="team_titL"><asp:Literal ID="litName" runat="server"></asp:Literal></div>
                        <div class="team_tittxt"><asp:Literal ID="litTitle" runat="server"></asp:Literal></div>
                    </div>
                </div>
                <div id="team_item">
                	<div class="team_tit">學歷</div>
                    <div class="team_txt">
                        <asp:Literal ID="litDegree" runat="server"></asp:Literal>
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
                    </div>
                </div>
                <div id="team_item">
                	<div class="team_tit">法律專長</div>
                    <div class="team_txt">
                        <asp:Literal ID="litSpecialty" runat="server"></asp:Literal>
                    </div>
                </div>
                <%--<div id="team_item">
                	<div class="team_tit">e-mail</div>
                    <div class="team_txt">
                    	<ul>
                    		<li>wuhy@chienyehtsai.com.tw</li>
                    	</ul>
                    </div>
                </div>
                <div id="team_item">
                	<div class="team_tit">分機</div>
                    <div class="team_txt">
                    	<ul>
                    		<li>15</li>
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
                		<li class="ulli">　　　　　　　　　　　　<a href='#' onClick='window.history.go(-1);return false;'><img src="img/news/img_backarrow.jpg"> 回上頁</a></li>
                    </ul>
                </div>
                </div>
            </div>
        <div class="top"><a href="#top"></a></div>
        </div>
</asp:Content>

