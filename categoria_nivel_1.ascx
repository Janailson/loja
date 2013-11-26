<%@ Control Language="C#" AutoEventWireup="true" CodeFile="categoria_nivel_1.ascx.cs" Inherits="loja.categoria_nivel_1" %>

<div id="bannertv">
    <div class="banner"></div>
</div>
<div id="migalha">
    <a href="~/" runat="server">E-Commerce.com.br</a> <% Migalha(Convert.ToInt32(Request["id"])); %>
</div>        
<div id="principal">
    <div class="menu">
        <ul>
            <li class="tl"><a href="categoria.aspx?id=<%=categoria.IDCategoria%>"><%=categoria.Nome%></a></li>
            <% Menu(Convert.ToInt32(Request["id"])); %>
        </ul>
    </div>
    <div class="conteudo">
        <% Categorias(Convert.ToInt32(Request["id"]), true); %>
    </div>
    <br clear="all" />
</div>