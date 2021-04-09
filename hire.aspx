<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCH.master" AutoEventWireup="true" CodeFile="hire.aspx.cs" Inherits="hire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- InstanceBeginEditable name="EditRegion3" -->
            <div id="banner"><img src="img/hire/img_bannerhire.jpg"></div>
			<!-- InstanceEndEditable -->
            
          <div id="bannershadow"><img src="img/home/img_bannershadow.png"></div>

          <!-- InstanceBeginEditable name="EditRegion4" -->
        <div id="center">
        	<div id="tital"><img src="img/hire/img_titallogo.jpg" alt="">　徵才</div>
            <div id="content_about">
                應徵方式 ：<br><br>
                請備履歷、自傳email予本所 ： joanna@chienyehtsai.com.tw<br>
                或以紙本郵寄至本所 （ 地址 ： 高雄市前金區中正四路 211 號 18 樓之 5 ）<br><br><br>
            	<%--<div id="content_hire">
                    
                    <asp:Literal ID="litContent" runat="server"></asp:Literal>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <%#Eval("a_detail") %>
                        </ItemTemplate>
                    </asp:Repeater>
                    暫無徵才活動<br><br><br><br><br></div>--%>
			</div>
        
        </div>
        <div class="top"><a href="#top"></a></div>
        <!-- InstanceEndEditable -->
</asp:Content>

