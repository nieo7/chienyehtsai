<%@ Page Title="" Language="C#" MasterPageFile="~/JP/MasterPageJP.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="JP_news" %>
<%@ Register Src="~/JP/UserControl/Listnews.ascx" TagName="ucnews" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../js/jquery-1.6.2.min.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        $(".testcss4").mousemove(function () {
            var _this = $(this);
            _this.attr("src", "final_r.jpg");
        });
        $(".testcss4").mouseout(function () {
            var _this = $(this);
            _this.attr("src", "final.jpg");
        });
        $(".testcss3").mousemove(function () {
            var _this = $(this);
            _this.attr("src", "next_r.jpg");
        });
        $(".testcss3").mouseout(function () {
            var _this = $(this);
            _this.attr("src", "next.jpg");
        });
        $(".testcss2").mousemove(function () {
            var _this = $(this);
            _this.attr("src", "front_r.jpg");
        });
        $(".testcss2").mouseout(function () {
            var _this = $(this);
            _this.attr("src", "front.jpg");
        });
        $(".testcss").mousemove(function () {
            var _this = $(this);
            _this.attr("src", "previous_r.jpg");
        });
        $(".testcss").mouseout(function () {
            var _this = $(this);
            _this.attr("src", "previous.jpg");
        });

    });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="center">
        <div id="tital"><img src="img/news/img_titallogo.jpg" alt="">　最新消息</div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <uc:ucnews ID="listviewnews" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br><br><br><br><br><br><br><br><br><br><br><br>
        <div class="top"><a href="#top"></a></div>
    </div>
</asp:Content>

