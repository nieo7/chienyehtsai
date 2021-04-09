<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TempfileSet.aspx.cs" Inherits="Manager_Sysconfig_TempfileSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>暫存檔系統設定</title>
    <link rel="stylesheet" href="../../css/env/css/common.css" type="text/css" />
    <link rel="stylesheet" href="../../css/env/css/common-ie.css" type="text/css" />
    <link href="../../css/env/css/sample.css" rel="stylesheet" type="text/css" />
    <link href="../../_assets/css/thickbox.css" rel="stylesheet" type="text/css" />
    <link href="../../_assets/css/grid.css" rel="stylesheet" type="text/css" />
    <link href="../../_assets/css/pager.css" rel="stylesheet" type="text/css" />
    <link href="../../_assets/css/panel.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #tt1 tr
        {
            color: #663399;
            background-color: #FFCC66;
            font-weight: bold;
            height: 50px;
            text-align: center;
        }
        #tt1 td
        {
            text-align: center;
        }
        .View1
        {
            width: 286px;
            margin: 0px auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width: 100%; text-align: center">
                <br />
                <asp:Label ID="Label1" runat="server" Text="暫存檔系統設定" Font-Bold="True" Font-Names="Times New Roman"
                    Font-Size="15pt" ForeColor="Blue"></asp:Label>
            </div>
            <div class="View1">
                <table id="tt1" cellspacing="0" cellpadding="4" rules="all" border="1" id="FormView1"
                    style="background-color: White; border-color: #CC9966; border-width: 1px; border-style: None;
                    border-collapse: collapse; width: 100%;">
                    <tr>
                        <td>
                            啟動自動刪除:
                            <asp:CheckBox ID="chkSet" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            設定檔案過期時程: &nbsp;
                            <asp:DropDownList ID="ddrTime" runat="server">
                                <asp:ListItem Text="一星期" Value="7"></asp:ListItem>
                                <asp:ListItem Text="一個月" Value="30"></asp:ListItem>
                                <asp:ListItem Text="三個月" Value="90"></asp:ListItem>
                                <asp:ListItem Text="半年" Value="180"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            檢視暫存:
                            <asp:Button ID="btnShow" runat="server" Text="檢視" OnClick="btnShow_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="width: 100%; text-align: center">
                                <asp:Button ID="Button1" runat="server" Text="更新" OnClick="Button1_Click" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="width: 100%; float: left">
                                <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <asp:PlaceHolder ID="phShow" runat="server" Visible="false">
                <div style="text-align: center">
                    <h3>
                        暫存檔</h3>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
                        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData"
                        TypeName="TempfilestableTableAdapters.TempfilestableTableAdapter" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_tf_id" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="tf_title" Type="String" />
                            <asp:Parameter Name="tf_path" Type="String" />
                            <asp:Parameter Name="tf_date" Type="DateTime" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="tf_title" Type="String" />
                            <asp:Parameter Name="tf_path" Type="String" />
                            <asp:Parameter Name="tf_date" Type="DateTime" />
                            <asp:Parameter Name="Original_tf_id" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="tf_id"
                        DataSourceID="ObjectDataSource1" CssClass="grid" EnableModelValidation="True"
                        Width="50%" Style="margin: 0 auto 0 auto;">
                        <Columns>
                            <asp:BoundField DataField="tf_id" HeaderText="tf_id" InsertVisible="False" ReadOnly="True"
                                SortExpression="tf_id" Visible="false" />
                            <asp:BoundField DataField="tf_title" HeaderText="類型" SortExpression="tf_title" />
                            <asp:TemplateField HeaderText="詳細資訊">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl='<%#Eval("tf_path") %>'>詳細資訊</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="tf_date" HeaderText="建立日期" SortExpression="tf_date" DataFormatString="{0:yyyy-MM-dd}" />
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:PlaceHolder>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
