<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="loja._Default" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
    <!-- specific styles -->
    <link href="css/index.css" rel="stylesheet" />
    <link href="css/skin.css" rel="stylesheet" />

    <!-- specific scripts -->
    <script src="js/jquery.jcarousel.min.js" type="text/javascript"></script>

    <!-- inline scripts -->
    <script type="text/javascript">
        $(document).ready(function () {
            $(".carousel").jcarousel();
        });
    </script>
</asp:Content>

<asp:Content ID="conteudo" runat="server" ContentPlaceHolderID="conteudo">
    <div id="bannertv">
        <div class="banner"></div>
    </div>

    <div id="regua"></div>
        
    <div class="conteudo">
        <% Categorias(0, true); %>
    </div>
</asp:Content>