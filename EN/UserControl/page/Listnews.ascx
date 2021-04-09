<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Listnews.ascx.cs" Inherits="EN_UserControl_page_Listnews" %>
<!--ListView-->
<div id="content_about">
<ul>
    <asp:ListView ID="LVnews" runat="server" OnPagePropertiesChanging="LVnews_PagePropertiesChanging" ItemPlaceholderID="itemPlaceHolder">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <li><img src="img/home/dot.png">　<%#Eval("n_ts","{0:yyyy.MM.dd}") %><br><span class="news"><a href='<%#String.Format("news_det.aspx?id={0}",Eval("n_id")) %>'><%#Eval("n_title") %></a></span></li><hr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div>No Data!</div>
        </EmptyDataTemplate>
    </asp:ListView>
</ul>
</div>
<asp:PlaceHolder ID="PlaceHolder_Page" runat="server">
    <div class="pagination">
                    <asp:DataPager ID="DataPagerNews" runat="server" PagedControlID="LVnews" PageSize="5">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" ShowLastPageButton="False" FirstPageText="&laquo; First" />
            <asp:NextPreviousPagerField ShowPreviousPageButton="True" ShowNextPageButton="False" ShowFirstPageButton="False" ShowLastPageButton="False" PreviousPageText="&#8249; Previous"  />
            <asp:NumericPagerField CurrentPageLabelCssClass="seleted" />
            <asp:NextPreviousPagerField ShowNextPageButton="True" ShowPreviousPageButton="False" ShowFirstPageButton="False" ShowLastPageButton="False" NextPageText="Next &#8250;" />
            <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False" ShowFirstPageButton="False" ShowNextPageButton="False" LastPageText="Last &raquo;"/>
                        </Fields>
                    </asp:DataPager>
            </div>
</asp:PlaceHolder>