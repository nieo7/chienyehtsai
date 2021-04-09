<%@ Page Title="" Language="C#" MasterPageFile="~/EN/MasterPageEN.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="EN_contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="../js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function clear1() {
            $("#content_about").find(":text,textarea").each(function () {
                $(this).val("");
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    </asp:UpdatePanel>
    <div id="banner"><img src="img/home/img_bannerhome1.jpg"></div>
			<!-- InstanceEndEditable -->
            
          <div id="bannershadow"><img src="img/home/img_bannershadow.png"></div>

          <div id="center">
        	<div id="tital"><img src="img/contact/img_titallogo.jpg" alt="">　Contact Us</div>
          	<div id="content_about">
            	<p>Thank you for visiting the Chien Yeh Law Offices Kaohsiung Office website.　Please feel free to fill in the following form.　Your comments will be appreciated.</p><br>
                <p>
                <ul>
           	  	  	<li style="padding-top:10px;">　Name :　<asp:TextBox ID="txtName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please input your name!" ControlToValidate="txtName" SetFocusOnError="true">*</asp:RequiredFieldValidator></li>
                    <li style="padding-top:10px;">　　 Tel :　<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please input the phone number!" ControlToValidate="txtPhone" SetFocusOnError="true">*</asp:RequiredFieldValidator><asp:CustomValidator
        ID="CustomValidator1" runat="server" ErrorMessage="At least input 9~20 numbers!" Display="Static" ValidateEmptyText="true" OnServerValidate="CustomValidator1_ServerValidate" Text="*"></asp:CustomValidator></li>
                    <li style="padding-top:10px;">　　 Fax :　<asp:TextBox ID="txtFax" runat="server"></asp:TextBox></li>
                    <li style="padding-top:10px;">&nbsp; &nbsp;e-mail :　<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Wrong mail format! Ex：xxx@xxx.com"
                                    ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></li>
                    <li style="padding-top:10px;">&nbsp;Subject :　<asp:TextBox ID="txtSubject" runat="server"></asp:TextBox></li>
                    <li style="float:left; padding-top:10px;">Content : &nbsp;&nbsp;&nbsp;<div style="width:550px; float:right;"><asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" Height="100px" Width="550px"></asp:TextBox></div></li>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please input the content!" ControlToValidate="txtDetail" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                    <li style="clear:both; text-indent:75px; padding-top:10px;">
                    <input type="image" src="img/contact/btn_reset.jpg" onMouseOver="this.src='img/contact/btn_reset_r.jpg'" onMouseOut="this.src='img/contact/btn_reset.jpg'" name="reset" id="reset" alt="Cancel" onclick="clear1()">　
                	<%--<input type="image" src="img/contact/btn_submit.jpg" onMouseOver="this.src='img/contact/btn_submit_r.jpg'" onMouseOut="this.src='img/contact/btn_submit.jpg'" name="send" id="send" alt="OK">--%>
                    <asp:ImageButton ID="ImgbtnSubmit" runat="server" 
                            ImageUrl="img/contact/btn_submit.jpg" 
                            onMouseover="this.src='img/contact/btn_submit_r.jpg'" 
                            onMouseout="this.src='img/contact/btn_submit.jpg'" 
                            onclick="ImgbtnSubmit_Click" />
                  </li>
                </ul>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </p>
            	<hr>
                <div id="location">
                <div class="map"><img src="img/contact/img_ksmap.jpg" alt="高雄所位置圖"></div>
                <span class="font_bold">CHIEN YEH Law Offices Kaohsiung Office (KCY)： </span><br>
                Add：18F-5,211 Chung Cheng 4th Rd.,<br>
				　　　Kaohsiung 80147, Taiwan<br>
                Tel：(+886)7-2516879<br>
                Fax：(+886)7-2516700                
                </div>
                <%--<div id="location">
                <div class="map"><img src="img/contact/img_tnmap.jpg" alt="南科育成辦公室位置圖"></div>
                <span class="font_bold">Tainan Office ： </span><br>
                Add：F304, NO.12,Nan Ke 2nd Rd.,<br>
                　　　Tainan Science Park, Tainan City, <br>
                　　　Taiwan<br>
                Tel：(+886)6-5051380<br>
                Fax：(+886)6-5051177                
                </div>--%>
                <div id="location">
                <div class="map"><img src="img/contact/img_ptmap.jpg" alt="屏東農科辦公室位置圖"></div>
                <span class="font_bold">Pingtung Office ： </span><br>
                Add：3F-8., No.23, Nongka Rd.,<br>　　　　&nbsp; Changzhi Township,Pingtung Country 908, Taiwan<br>
                Tel：(+886)8-7620322               
                </div>
			</div>
        <div class="top"><a href="#top"></a></div>
        </div>
</asp:Content>

