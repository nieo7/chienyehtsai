<%@ Page Title="" Language="C#" MasterPageFile="~/JP/MasterPageJP.master" AutoEventWireup="true" CodeFile="team.aspx.cs" Inherits="JP_team" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
    .team
    {
        width:730px;
	    float:left;
	    margin: 5px 0px;
	    font-size:1.2em;
	    font-weight:bold;
	    border-bottom:1px solid #e7dcc9;
    }
    .person {
	width:200px;
	float:left;
	margin:5px 5px 5px 15px;
	font-size:.75em;
	font-weight:normal;
    }
.person a {
	color: #59493f;
	text-decoration:none;
}
.person a:hover {
	color:#74644c;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="center">
        <div id="tital"><img src="img/team/img_titallogo.jpg" alt="">　専門家チーム</div>
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

