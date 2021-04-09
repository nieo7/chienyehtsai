<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCnews.ascx.cs" Inherits="UserControl_UCnews" %>
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
            <div>無任何資料!</div>
        </EmptyDataTemplate>
    </asp:ListView>
</ul>
    

</div>
<asp:PlaceHolder ID="PlaceHolder_Page" runat="server">
    <div class="pagination">
                    <asp:DataPager ID="DataPagerNews" runat="server" PagedControlID="LVnews" PageSize="5">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" ShowLastPageButton="False" FirstPageText="最前頁 &laquo;" />
            <asp:NextPreviousPagerField ShowPreviousPageButton="True" ShowNextPageButton="False" ShowFirstPageButton="False" ShowLastPageButton="False" PreviousPageText="上一頁 &#8249;"  />
            <asp:NumericPagerField CurrentPageLabelCssClass="seleted" />
            <asp:NextPreviousPagerField ShowNextPageButton="True" ShowPreviousPageButton="False" ShowFirstPageButton="False" ShowLastPageButton="False" NextPageText="&#8250; 下一頁" />
            <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False" ShowFirstPageButton="False" ShowNextPageButton="False" LastPageText="&raquo; 最末頁"/>
                        </Fields>
                    </asp:DataPager>
            </div>
</asp:PlaceHolder>
