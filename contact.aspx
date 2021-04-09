<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCH.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
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
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    </asp:UpdatePanel>
 <!-- InstanceBeginEditable name="EditRegion3" -->
            <div id="banner"><img src="img/home/img_bannerhome1.jpg"></div>
			<!-- InstanceEndEditable -->
            
          <div id="bannershadow"><img src="img/home/img_bannershadow.png"></div>

          <!-- InstanceBeginEditable name="EditRegion4" -->
        <div id="center">
        	<div id="tital"><img src="img/contact/img_titallogo.jpg" alt="">　聯絡我們</div>
          	<div id="content_about">
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <p>感謝您光臨建業法律事務所高雄所網站，如果您有任何的問題或建議，請您不吝賜教，將您寶貴的意見填寫於下列表單，我們將派專員為您服務。</p><br>
                <p>
                <ul>
           	  	  	<li style="padding-top:10px;">　　姓名 :　<asp:TextBox ID="txtName" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                               ID="RequiredFieldValidator1" runat="server" ErrorMessage="請填寫姓名" ControlToValidate="txtName" SetFocusOnError="true">*</asp:RequiredFieldValidator></li>
                    <li style="padding-top:10px;">　　電話 :　<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" runat="server" ErrorMessage="請填寫電話" ControlToValidate="txtPhone" SetFocusOnError="true">*</asp:RequiredFieldValidator><asp:CustomValidator
        ID="CustomValidator1" runat="server" ErrorMessage="請輸入9~20碼之間" Display="Static" ValidateEmptyText="true" OnServerValidate="CustomValidator1_ServerValidate" Text="*"></asp:CustomValidator></li>
                    <li style="padding-top:10px;">　　傳真 :　<asp:TextBox ID="txtFax" runat="server"></asp:TextBox></li>
                    <li style="padding-top:10px;">　e-mail :　<asp:TextBox ID="txtEmail" runat="server" Width="300"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="請輸入正確的信箱格式，正確格式如：xxx@xxx.com"
                                    ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></li>
                    <li style="padding-top:10px;">　　主旨 :　<asp:TextBox ID="txtSubject" runat="server" Width="400"></asp:TextBox></li>
                    <li style="float:left; padding-top:10px;">諮詢內容 : &nbsp;&nbsp;&nbsp;<div style="width:550px;float:right;"><asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" Height="50px" Width="550px"></asp:TextBox></div>
                        </li>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="請填寫內容" ControlToValidate="txtDetail" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                    <li style="clear:both; text-indent:75px; padding-top:20px;">
                    <img style="float:left;margin-left:75px;" src="img/contact/btn_reset.jpg" onMouseOver="this.src='img/contact/btn_reset_r.jpg'" onMouseOut="this.src='img/contact/btn_reset.jpg'" alt="取消重填" onclick="clear1()">
                    <%--<asp:ImageButton ID="ImgbtnCancel" runat="server" 
                            ImageUrl="img/contact/btn_reset.jpg" 
                            onMouseover="this.src='this.src='img/contact/btn_reset_r.jpg'" 
                            onMouseout="this.src='img/contact/btn_reset.jpg'" 
                            onclick="ImgbtnCancel_Click" />&nbsp;&nbsp;&nbsp;&nbsp;--%>
                    <asp:ImageButton ID="ImgbtnSubmit" runat="server" 
                            ImageUrl="img/contact/btn_submit.jpg" 
                            onMouseover="this.src='img/contact/btn_submit_r.jpg'" 
                            onMouseout="this.src='img/contact/btn_submit.jpg'" 
                            onclick="ImgbtnSubmit_Click" />
                	<%--<img src="img/contact/btn_submit.jpg" onMouseOver="this.src='img/contact/btn_submit_r.jpg'" onMouseOut="this.src='img/contact/btn_submit.jpg'" name="send" id="send" alt="確認送出">--%>
                    
                  </li>
                </ul>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" />
                    <p>
                    </p>
                    <hr>
                    <div id="location">
                <div class="map"><img src="img/contact/img_ksmap.jpg" alt="高雄所位置圖"></div>
                <span class="font_bold">建業高雄所 ( KCY )： </span><br>
                高雄市前金區中正四路211號18樓之5<br>
                Tel ： (+886)7-2516879<br>
                Fax ： (+886)7-2516700                
                </div>
                <%--<div id="location">
                <div class="map"><img src="img/contact/img_tnmap.jpg" alt="南科育成辦公室位置圖"></div>
                <span class="font_bold">南科育成辦公室 ： </span><br>
                台南市台南科學園區南科二路12號304室<br>
                Tel ： (+886)6-5051380<br>
                Fax ： (+886)6-5051177                
                </div>--%>
                <div id="location">
                <div class="map"><img src="img/contact/img_ptmap.jpg" alt="屏東農科辦公室位置圖"></div>
                <span class="font_bold">屏東農科辦公室 ： </span><br>
                Add：屏東縣長治鄉德和村農科路23號3F-8<br>
                Tel：(+886)8-7620322               
                </div>
            	    </ContentTemplate>
                  </asp:UpdatePanel>
			</div>
        <div class="top"><a href="#top"></a></div>
        </div>
        <!-- InstanceEndEditable -->
</asp:Content>

