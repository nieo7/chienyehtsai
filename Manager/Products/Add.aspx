<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="Add.aspx.cs" Inherits="Manager_Products_Add" ValidateRequest="false" %>

<%@ Register TagName="CKeditTag1" TagPrefix="CkeditPre" Src="~/UserControl/public/Ckeditorl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () { });
        function changeDisply() {
            var buttonObj = $("#btShow");
            var val = $("#btShow").attr("value");
            if (val == "關閉") {
                $("#ctl00_ContentPlaceHolder1_ddrFormat").hide();
                $("#ctl00_ContentPlaceHolder1_btFormat").hide();
                buttonObj.attr("value", "拷貝");
            }
            else {
                $("#ctl00_ContentPlaceHolder1_ddrFormat").show();
                $("#ctl00_ContentPlaceHolder1_btFormat").show();
                buttonObj.attr("value", "關閉");
            }
        }
    </script>
    <div class="RightTableTdTopmenu">
        <asp:HiddenField ID="hfLanguage" runat="server" />
        <ul>
            <li id="toplink1" title="產品類別欄位管理"><span><a href="List.aspx">列表</a></span></li><li
                id="toplink2active" title="增加產品類別"><span><a href="#">新增</a></span></li><li id="toplink3"
                    title="查看與修改產品類別"></li>
            <li id="toplink5" title="生成HTML文件"><a href="#"><span></span></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2">
        產品-新增
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="phpc" runat="server">
                    <div class="contentdiv4">
                        <div class="contentdiv1left">
                            產品類別:&nbsp;</div>
                        <div class="contentdiv1right">
                            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">選擇主產品類別</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="phname" runat="server">
                    <div class="contentdiv4">
                        <div class="contentdiv1left">
                            產品名稱:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請填寫產品標題!"
                                SetFocusOnError="True" ControlToValidate="txtName">*</asp:RequiredFieldValidator>
                            &nbsp;</div>
                        <div class="contentdiv1right">
                            <div class="specialdivfix1">
                                <asp:TextBox ID="txtName" runat="server" CssClass="input1"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="phformat" runat="server">
                    <div class="contentdiv4">
                        <div class="contentdiv1left">
                            建立規格:&nbsp;</div>
                        <div class="contentdiv1right">
                            <asp:TextBox ID="txtNewFormat" runat="server"></asp:TextBox>
                            <asp:Button ID="btNewFormat" CausesValidation="false" runat="server" Text="新增" OnClick="btNewFormat_Click" />
                            <input id="btShow" type="button" value="拷貝" onclick="changeDisply();" />
                            <asp:DropDownList ID="ddrFormat" runat="server" Style="display: none" DataTextField="pc_name"
                                DataValueField="pc_id" DataSourceID="ObjectDataSource1" OnDataBound="ddrFormat_DataBound">
                            </asp:DropDownList>
                            <asp:Button ID="btFormat" runat="server" Style="display: none" Text="拷背格式" OnClick="btFormat_Click"
                                CausesValidation="False" />
                        </div>
                    </div>
                    <div class="contentdiv2">
                        <div class="contentdiv1left">
                        </div>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="getallSortData" TypeName="BLL.ProductCategoryBLL">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="fatherId" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <div class="contentdiv1right">
                            <asp:Repeater ID="rpFormat" runat="server" OnItemCommand="rpFormat_ItemCommand">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ckFormat" runat="server" Checked="true" />
                                    <asp:Label ID="lbFormatID" runat="server" Visible="false" Text='<%#Eval("pf_id") %>'></asp:Label>
                                    <asp:Label ID="lbFormat" runat="server" Text='<%#Eval("pf_name") %>'></asp:Label>
                                    &nbsp;
                                    <asp:TextBox ID="txtFormatValue" runat="server" Text='<%#Eval("pf_value") %>'></asp:TextBox>
                                    <asp:TextBox ID="txtSorting" Width="50" runat="server" Text='<%#Eval("pf_sorting") %>'></asp:TextBox>
                                    <asp:Button ID="btUP" runat="server" CausesValidation="false" Text="▲" CommandName="btnSortUp" />
                                    <asp:Button ID="btDown" runat="server" CausesValidation="false" Text="▼" CommandName="btnSortDown" />&nbsp;
                                    <asp:LinkButton ID="lkFormatDelete" CausesValidation="false" CommandName="Delete"
                                        runat="server">刪除</asp:LinkButton><br />
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Button ID="btSave" CausesValidation="false" runat="server" Text="儲存" OnClick="btSave_Click" />
                        </div>
                    </div>
                </asp:PlaceHolder>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:PlaceHolder ID="phserial" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    產品型號: &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtSerial" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phstate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    產品狀態:</div>
                <div class="contentdiv1right">
                    <asp:DropDownList ID="ddrState" runat="server">
                        <asp:ListItem Value="1">上架</asp:ListItem>
                        <asp:ListItem Value="0">缺貨</asp:ListItem>
                        <asp:ListItem Value="2">下架</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phstock" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    庫存: &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtStock" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phstockunit" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    庫存單位: &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtStock_unit" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phprice1" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    原價格: &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtPrice1" runat="server" CssClass="input1" MaxLength="9"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phprice2" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    免費會員價格: &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtPrice2" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phprice3" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    等級1價格: &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtPrice3" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phprice4" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    等級2價格: &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtPrice4" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phprice5" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    等級3價格: &nbsp;</div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtPrice5" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phfile" runat="server">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:HiddenField ID="hfDownloadFile" runat="server" />
                    <div class="contentdiv4">
                        <div class="contentdiv1left">
                            建立附加檔案:&nbsp;</div>
                        <div class="contentdiv1right">
                            <asp:FileUpload ID="fuFile" runat="server" />
                            <asp:Button ID="btFile" CausesValidation="false" runat="server" Text="上傳" OnClick="btFile_Click" />
                        </div>
                    </div>
                    <div class="contentdiv2">
                        <div class="contentdiv1left">
                        </div>
                        <div class="contentdiv1right">
                            <asp:Repeater ID="rpDownload" runat="server" OnItemCommand="rpDownload_ItemCommand"
                                OnItemDataBound="rpDownload_ItemDataBound">
                                <ItemTemplate>
                                    <asp:Label ID="lbDownloadID" runat="server" Visible="false" Text='<%#Eval("pd_name") %>'></asp:Label>
                                    <asp:HyperLink ID="hytempPath" Target="_blank" NavigateUrl='<%#Tools.GetAppSettings("ProductDLTempPath")+Eval("pd_name") %>'
                                        runat="server" Text='<%#Eval("pd_name") %>'></asp:HyperLink>
                                    &nbsp;<asp:LinkButton ID="lkDelete" CommandArgument='<%#Eval("pd_id") %>' OnClientClick="return confirm('您確定要刪除嗎?')"
                                        CausesValidation="false" CommandName="Delete" runat="server">刪除</asp:LinkButton>
                                    <asp:LinkButton ID="lnkUpdate" CommandArgument='<%#Eval("pd_name") %>' CommandName="Update"
                                        CausesValidation="false" runat="server">設定為產品主頁檔案</asp:LinkButton><br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btFile" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phrpImage" runat="server">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:HiddenField ID="hfProductImage" runat="server" />
                    <div class="contentdiv4">
                        <div class="contentdiv1left">
                            建立附加圖片:</div>
                        <div class="contentdiv1right">
                            <asp:FileUpload ID="fuImage" runat="server" />&nbsp;
                            <asp:Button ID="btImage" CausesValidation="false" runat="server" Text="上傳" OnClick="btImage_Click" />
                            <strong>&nbsp;<span class="style1">(請勿超過2MB)</span></strong></div>
                    </div>
                    <div class="contentdiv2">
                        <div class="contentdiv1left">
                        </div>
                        <div class="contentdiv1right">
                            <table width="100" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="rpImage" runat="server" OnItemCommand="rpImage_ItemCommand" OnItemDataBound="rpImage_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbImageID" Visible="false" runat="server" Text='<%#Eval("pi_image") %>'></asp:Label>
                                                <asp:Image ID="Image1" Width="100" AlternateText='<%#Eval("pi_image") %>' runat="server"
                                                    ImageUrl='<%#Tools.GetAppSettings("ProductImageTempPath")+Eval("pi_image") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbImage" runat="server" Text='<%#Eval("pi_imageName") %>'></asp:Label>
                                                &nbsp;<asp:LinkButton ID="lkDelete" CommandArgument='<%#Eval("pi_image") %>' OnClientClick="return confirm('您確定要刪除嗎?')"
                                                    CommandName="Delete" CausesValidation="false" runat="server">刪除</asp:LinkButton>
                                                <asp:LinkButton ID="lkUpdate" CommandArgument='<%#Eval("pi_image") %>' CommandName="Update"
                                                    CausesValidation="false" runat="server">設定為產品首圖</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btImage" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phshowhot" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    首頁熱門商品:&nbsp;
                </div>
                <div class="contentdiv1right">
                    <asp:RadioButtonList ID="rbHotShow" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="true">顯示</asp:ListItem>
                        <asp:ListItem Selected="True" Value="false">不顯示</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phdetail" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv2left">
                    内容:
                </div>
                <div class="contentdiv2right">
                    <CkeditPre:CKeditTag1 runat="server" ID="CkeditPro1" />
                    <asp:TextBox ID="txtNewsId" runat="server" Visible="False"></asp:TextBox>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phshow" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    顯示於前台:</div>
                <div class="contentdiv1right">
                    <asp:RadioButtonList ID="rbShow" runat="server" Width="231px" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="true">是</asp:ListItem>
                        <asp:ListItem Value="false">否</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </asp:PlaceHolder>
        <div class="contentdiv3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>
