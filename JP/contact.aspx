<%@ Page Title="" Language="C#" MasterPageFile="~/JP/MasterPageJP.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="JP_contact" %>

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
    
    <div id="center">
        	<div id="tital"><img src="img/contact/img_titallogo.jpg" alt="">　コンタクト</div>
          	<div id="content_about">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <p>建業法律事務所高雄所のホームページにご来訪ありがとうございます。如何なるご質問又はご意見がありましたら、以下のフォームにご記入ください。追って当所専任担当者よりご連絡差し上げます。</p><br>
                <p>
                <ul>
           	  	  	<li style="padding-top:10px;">　　　　お名前 :　<asp:TextBox ID="txtName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please input your name!" ControlToValidate="txtName" SetFocusOnError="true">*</asp:RequiredFieldValidator></li>
                    <li style="padding-top:10px;">　　　電話番号 :　<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please input the phone number!" ControlToValidate="txtPhone" SetFocusOnError="true">*</asp:RequiredFieldValidator></li>
                    <li style="padding-top:10px;">ファックス番号 :　<asp:TextBox ID="txtFax" runat="server"></asp:TextBox></li>
                    <li style="padding-top:10px;">メールアドレス :　<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Wrong mail format! Ex：xxx@xxx.com"
                                    ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></li>
                    <li style="padding-top:10px;">　お問合せ主旨 :　<asp:TextBox ID="txtSubject" runat="server"></asp:TextBox></li>
                    <li style="float:left; padding-top:10px;">　お問合せ內容 : &nbsp;&nbsp;&nbsp;<div style="width:550px; float:right;"><asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" Height="100px" Width="550px"></asp:TextBox></div></li>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please input the content!" ControlToValidate="txtDetail" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                    <li style="clear:both; text-indent:120px; padding-top:10px;">
                    <input type="image" src="img/contact/btn_reset.jpg" onMouseOver="this.src='img/contact/btn_reset_r.jpg'" onMouseOut="this.src='img/contact/btn_reset.jpg'" name="reset" id="reset" alt="Cancel" onclick="clear1()">　
                    <asp:ImageButton ID="ImgbtnSubmit" runat="server" 
                            ImageUrl="img/contact/btn_submit.jpg" 
                            onMouseover="this.src='img/contact/btn_submit_r.jpg'" 
                            onMouseout="this.src='img/contact/btn_submit.jpg'" 
                            onclick="ImgbtnSubmit_Click" />
                	<%--<input type="image" src="img/contact/btn_submit.jpg" onMouseOver="this.src='img/contact/btn_submit_r.jpg'" onMouseOut="this.src='img/contact/btn_submit.jpg'" name="send" id="send" alt="確認送出">--%>
                  </li>
                </ul>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </p>
            	<hr>
                <div id="location">
                <div class="map"><img src="img/contact/img_ksmap.jpg" alt="高雄所位置圖"></div>
                <span class="font_bold">建業高雄所 ( KCY )： </span><br>
                Add：高雄市前金区中正四路211号18階の5<br>
                Tel：(+886)7-2516879<br>
                Fax：(+886)7-2516700                
                </div>
               <%-- <div id="location">
                <div class="map"><img src="img/contact/img_tnmap.jpg" alt="南科育成辦公室位置圖"></div>
                <span class="font_bold">南科育成オフィス ： </span><br>
                Add：台南市台南科學園区南科二路12号304室<br>
                Tel：(+886)6-5051380<br>
                Fax：(+886)6-5051177                
                </div>--%>
                <div id="location">
                <div class="map"><img src="img/contact/img_ptmap.jpg" alt="屏東農科辦公室位置圖"></div>
                <span class="font_bold">屏東農科オフィス ： </span><br>
                Add：屏東県長治鄉德和村農科路23号3F-8<br>
                Tel：(+886)8-7620322               
                </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            	
			</div>
        <div class="top"><a href="#top"></a></div>
        </div>
</asp:Content>

