<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Address.ascx.cs" Inherits="UserControl_Address" %>

<script type="text/javascript" language="JavaScript" src='<%=ResolveClientUrl("~/js/twZipcodeJson.js")%>'></script>  
<%--<script src="https://www.google.com/jsapi?key=ABQIAAAAFgmU6cM3y9JjHpPgkd_UVRRi_j0U6kJrkFvY4-OX2XYmEAa76BTFYUVYlVZCMZPpvCDcP5BwnN5m3A" type="text/javascript"></script>  
<script language="Javascript" type="text/javascript">  
//<![CDATA[  
//請使用1.4.1以上之版本  
//Chrome,Ie,FF測試成功  
google.load("jquery", "1.4.1");  
//]]> 
</script>  --%>
<script type="text/javascript" language="JavaScript" src='<%=ResolveClientUrl("~/js/twZipCode.js")%>'></script>  
<select name="City" id="City">  
    <option value="0">請選擇</option>     
</select>  
<asp:HiddenField id="HiddenField_City" runat="server"></asp:HiddenField>
<select name="CityArea" id="CityArea" >  
   <option value="0">請選擇</option>  
</select>
<asp:HiddenField ID="HiddenField_Area" runat="server"></asp:HiddenField>
<asp:PlaceHolder ID="PlaceHolder_zipcode" runat="server">
郵遞區號:<asp:TextBox ID="TextBox_ZipCode"  runat="server" size="7" Enabled="false"></asp:TextBox>
<asp:HiddenField ID="HiddenField_ZipCode" runat="server"></asp:HiddenField>
</asp:PlaceHolder>
地址:<asp:TextBox ID="TextBox_Address"  runat="server"></asp:TextBox>
<script type="text/javascript">
    $(function () {
        $("#City").zipCode({
            CityArea: 'CityArea',
            CityHidd: '<%=HiddenField_City.ClientID %>',
            AreaHidd: '<%=HiddenField_Area.ClientID %>',
            ZipCode: '<%=HiddenField_ZipCode.ClientID %>',
            ZipCodeTextBox: '<%=TextBox_ZipCode.ClientID %>'
        });
        
    });
    $(function () {
        $("#City").zipCode({
        CityDefaul: '<%=HiddenField_City.Value %>',
        CityAreaDefault: '<%=HiddenField_Area.Value %>'
    });
});
</script>  
