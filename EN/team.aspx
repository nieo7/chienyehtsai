<%@ Page Title="" Language="C#" MasterPageFile="~/EN/MasterPageEN.master" AutoEventWireup="true" CodeFile="team.aspx.cs" Inherits="EN_team" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- InstanceBeginEditable name="EditRegion3" -->
            <div id="banner"><img src="img/team/img_bannerteam.jpg"></div>
			<!-- InstanceEndEditable -->
            
          <div id="bannershadow"><img src="img/home/img_bannershadow.png"></div>
          <div id="center">
        	<div id="tital"><img src="img/team/img_titallogo.jpg" alt="">　Professionals</div>
            <div id="content_about">
                <asp:Repeater ID="Rpteam" runat="server" onitemdatabound="Rpteam_ItemDataBound">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfid" runat="server" Value='<%#Eval("fc_id") %>' />
                        <div class="team">
                            <img src="img/home/dot.png"><%#Eval("fc_title") %><br>
                            <asp:Repeater ID="RpSub" runat="server">
                                <ItemTemplate>
                                    <div class="person"><a href='<%#String.Format("team_det.aspx?id={0}",Eval("f_id")) %>'><%#Eval("f_title") %> <%#Eval("f_name") %></a></div>
                                </ItemTemplate>
                            </asp:Repeater>
       	  	            </div>
                    </ItemTemplate>
                </asp:Repeater>
                <br><br><br><br><br><br><br><br><br><br><br><br>
		  </div>
        <div class="top"><a href="#top"></a></div>
        </div>
</asp:Content>

