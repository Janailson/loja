<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="categoria.aspx.cs" Inherits="loja.categoria" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
    <!-- specific styles -->
    <link href="css/<%=style%>.css" rel="stylesheet" />
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

    <asp:PlaceHolder ID="placeHolder" runat="server"></asp:PlaceHolder>

</asp:Content>