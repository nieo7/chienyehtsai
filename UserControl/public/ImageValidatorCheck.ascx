<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageValidatorCheck.ascx.cs" Inherits="UC_ImageValidatorCheck" %>
        <div>        
        <img alt="" src="../ashx/ImageValidator.ashx" onclick="this.src=this.src+'?'" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Check(Cookie)" 
            onclick="Button1_Click" /><br />
    <%--    <asp:Button ID="Button2" runat="server" Text="Check(Session)" 
            onclick="Button2_Click" />--%>
    </div>    