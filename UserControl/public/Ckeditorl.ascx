<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Ckeditorl.ascx.cs" Inherits="UserControl_public_Ckeditorl" %>
<script language="javascript" type="text/javascript" src='<%=ResolveUrl("~/ckeditor/ckeditor.js")%>'></script> 
<asp:TextBox ID="txtEditor" runat="server" TextMode="MultiLine"></asp:TextBox> 
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
 
<script type="text/javascript"> 
//<![CDATA[
CKEDITOR.replace('<%=txtEditor.ClientID %>',
{
    language : 'zh',
    enterMode : Number( 2),//设置enter键的输入1.<p>2为<br/>3为<div> 
    filebrowserBrowseUrl: '<%=ResolveUrl("~/ckeditor/ckfinder/ckfinder.html")%>',
    filebrowserImageBrowseUrl: '<%=ResolveUrl("~/ckeditor/ckfinder/ckfinder.html?Type=Images")%>',
    filebrowserFlashBrowseUrl: '<%=ResolveUrl("~/ckeditor/ckfinder/ckfinder.html?Type=Flash")%>',
    filebrowserUploadUrl: '<%=ResolveUrl("~/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files")%>',
    filebrowserImageUploadUrl: '<%=ResolveUrl("~/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images")%>',
    filebrowserFlashUploadUrl: '<%=ResolveUrl("~/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash")%>'
}); 
//]]> 
</script>