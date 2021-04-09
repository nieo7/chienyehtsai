<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerPage.master" AutoEventWireup="true"
    CodeFile="Edit.aspx.cs" Inherits="Manager_Products_Edit" ValidateRequest="false" %>

<%@ Register TagName="CKeditTag1" TagPrefix="CkeditPre" Src="~/UserControl/public/Ckeditorl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="RightTableTdTopmenuorange">
        <ul>
            <li id="toplink11" title="新增"><a href="list.aspx">列表</a></li>
            <li id="toplink21" title="產品類別查看與修改"><a href="add.aspx">新增</a></li>
            <li id="toplink31active" title="增加產品"><a href="#">修改</a></li>
            <li id="toplink41" title="查看與修改產品"><a href="#"></a></li>
        </ul>
    </div>
    <div class="RightTableTdSubheader2orange">
        產品-修改
    </div>
    <div class="RightTableTdContent">
        <div class="cleandiv1">
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <div style="text-align: center">
                            <img src="../../img/loading.gif" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:PlaceHolder ID="phpc" runat="server">
                    <div class="contentdiv4">
                        <div class="contentdiv1left">
                            類型:&nbsp;</div>
                        <div class="contentdiv1right">
                            <asp:DropDownList ID="ddrCategory" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="phname" runat="server">
                    <div class="contentdiv4">
                        <div class="contentdiv1left">
                            產品名稱:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請填寫標題!"
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
                        </div>
                    </div>
                    <div class="contentdiv2">
                        <div class="contentdiv1left">
                        </div>
                        <div class="contentdiv1right">
                            <asp:Repeater ID="rpFormat" runat="server" OnItemCommand="rpFormat_ItemCommand">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ckFormat" runat="server" Checked="true" />
                                    <asp:Label ID="lbFormatID" runat="server" Visible="false" Text='<%#Eval("psf_id") %>'></asp:Label>
                                    <asp:Label ID="lbFormat" runat="server" Text='<%#Eval("psf_name") %>'></asp:Label>
                                    &nbsp;
                                    <asp:TextBox ID="txtFormat" runat="server" Text='<%#Eval("psf_value") %>'></asp:TextBox>
                                    <asp:TextBox ID="txtSorting" Width="50" runat="server" Text='<%#Eval("psf_sorting") %>'></asp:TextBox>
                                    <asp:Button ID="btUP" runat="server" Text="▲" CommandName="btnSortUp" />
                                    <asp:Button ID="btDown" runat="server" Text="▼" CommandName="btnSortDown" />&nbsp;
                                    <asp:LinkButton ID="lkFormatDelete" CausesValidation="false" CommandName="Delete"
                                        OnClientClick="return confirm('您確定要刪除嗎?')" runat="server">刪除</asp:LinkButton><br />
                                </ItemTemplate>
                            </asp:Repeater>
                            <%--                            <asp:Button ID="btBig" CausesValidation="false" runat="server" Text="放大文字框" OnClick="btBig_Click" />
                            <asp:Button ID="btsmall" CausesValidation="false" Visible="false" runat="server"
                                Text="縮小文字框" OnClick="btsmall_Click" />--%>
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
                        <asp:ListItem Value="0">上架</asp:ListItem>
                        <asp:ListItem Value="1">缺貨</asp:ListItem>
                        <asp:ListItem Value="2">下架</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phdetail" runat="server">
            <div class="contentdiv2">
                <div class="contentdiv2left">
                    内容:
                </div>
                <div class="contentdiv2right">
                    <CkeditPre:CKeditTag1 ID="ckeditProduct" runat="server" />
                    <%--<asp:TextBox ID="txtNewsId" runat="server" Visible="False"></asp:TextBox>--%>
                </div>
            </div>
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
        <asp:PlaceHolder ID="phshow" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    是否顯示:&nbsp;
                </div>
                <div class="contentdiv1right">
                    <asp:RadioButtonList ID="rbShow" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="true">顯示</asp:ListItem>
                        <asp:ListItem Value="false">不顯示</asp:ListItem>
                    </asp:RadioButtonList>
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
                    原價:&nbsp;
                </div>
                <div class="contentdiv1right">
                    <div class="specialdivfix1">
                        <asp:TextBox ID="txtPrice1" runat="server" CssClass="input1"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phprice2" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    免費會員特價:&nbsp;
                </div>
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
                    <div id="divFile" runat="server" class="contentdiv4">
                        <div class="contentdiv1left">
                            建立附加檔案:&nbsp;</div>
                        <div class="contentdiv1right">
                            <asp:FileUpload ID="fuFile" runat="server" />
                            <asp:Button ID="btFile" CausesValidation="false" runat="server" Text="新增" OnClick="btFile_Click" />
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
                                    <asp:HyperLink ID="HyperLink1" Target="_blank" NavigateUrl='<%#Tools.GetAppSettings("ProductDLTruePath")+Eval("pd_type") %>'
                                        runat="server"><%#Eval("pd_name") %></asp:HyperLink>
                                    &nbsp;<asp:LinkButton ID="lkDelete" CommandArgument='<%#Eval("pd_id") %>' OnClientClick="return confirm('您確定要刪除嗎?')"
                                        CommandName="Delete" runat="server">刪除</asp:LinkButton>
                                    <asp:LinkButton ID="lnkUpdate" CommandArgument='<%#Eval("pd_id") %>' CommandName="Update"
                                        CausesValidation="false" runat="server">設定為產品主要檔案</asp:LinkButton><br />
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
                    <asp:HiddenField ID="hfImageIndex" runat="server" />
                    <div class="contentdiv2">
                        <div class="contentdiv1left">
                            建立附加圖片:&nbsp;</div>
                        <div class="contentdiv1right">
                            <asp:FileUpload ID="fuImage" runat="server" />
                            <asp:Button ID="btImage" CausesValidation="false" runat="server" Text="上傳" OnClick="btImage_Click" />
                        </div>
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
                                                <asp:Label ID="lbImageID" Visible="false" runat="server" Text='<%#Eval("pi_id") %>'></asp:Label>
                                                <asp:Image ID="Image1" Width="100" AlternateText='<%#Eval("pi_image") %>' runat="server"
                                                    ImageUrl='<%#Tools.GetAppSettings("ProductImageTruePath")+Eval("pi_image") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbImage" runat="server" Text='<%#Eval("pi_imageName") %>'></asp:Label>
                                                &nbsp;<asp:LinkButton ID="lkDelete" CommandArgument='<%#Eval("pi_id") %>' OnClientClick="return confirm('您確定要刪除嗎?')"
                                                    CommandName="Delete" runat="server">刪除</asp:LinkButton>
                                                <asp:LinkButton ID="lkUpdate" CommandArgument='<%#Eval("pi_id") %>' CommandName="Update"
                                                    runat="server">設定產品首圖</asp:LinkButton>
                                                <%--                          <a title='<%#Eval("pi_imageName") %>' href='<%#string.Format("../CropImage.aspx?pid={0}&id={1}",Eval("ProductId"),Eval("ProductImagesID")) %>'>
                                                裁剪圖片</a>--%>
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
        <asp:PlaceHolder ID="phcreatedate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    建立日期: &nbsp;</div>
                <div class="contentdiv1right">
                    <asp:TextBox ID="txtAddDate" runat="server" CssClass="input1"></asp:TextBox>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="pheditdate" runat="server">
            <div class="contentdiv4">
                <div class="contentdiv1left">
                    修改日期:</div>
                <div class="contentdiv1right">
                    <asp:TextBox ID="txtEditeDate" runat="server" CssClass="input1"></asp:TextBox>
                </div>
            </div>
        </asp:PlaceHolder>
        <div class="contentdiv3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <asp:Button ID="Button1" runat="server" Text="修改" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>
