<%@ Control Language="C#" AutoEventWireup="true" CodeFile="categoria_nivel_2.ascx.cs" Inherits="loja.categoria_nivel_2" %>

<div id="migalha">
    <a href="~/" runat="server">E-Commerce.com.br</a> <% Migalha(Convert.ToInt32(Request["id"])); %>
</div>
<div id="principal">
	<div class="menu">
        <ul>
            <li class="tl"><a href="categoria.aspx?id=<%=categoria.IDCategoria%>"><%=categoria.Nome%></a></li>
            <li class="tl2"><a href="categoria.aspx?id=<%=subcategoria.IDCategoria%>"><%=subcategoria.Nome%></a></li>
            <% Menu(Convert.ToInt32(Request["id"])); %>
            <li class="tl2">Marca</li>
            <% Marcas(subcategoria.IDCategoria); %>
            <li class="tl2">Cor</li>
            <% Cores(subcategoria.IDCategoria); %>
        </ul>
    </div>
	<div class="conteudo">
        <h1><%=subcategoria.Nome%></h1>
        <hr />
		<div class="destaque"></div>
		<div class="vitrine">
            <div class="pagin">
                <% Paginacao(subcategoria.IDCategoria, Pagina, TotalPagina); %>
            </div>

            <ul class="linha">
                <asp:Repeater ID="rptProduto" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="prd">
                                <a href="produto.aspx?id=<%# Eval("IDProduto") %>" title="<%# Eval("Nome") %>">
                                <span class="productImage"><img src="_img/produto/<%# Eval("ImagemProduto") %>" width="130" style="display: inline" alt="<%# Eval("Nome") %>" /></span>
                                <span class="productFlag"></span>
                                <span class="productName"><%# Eval("Nome") %></span>
                                <span class="productDetails">
                                    <%# Precos(Eval("IDProduto")) %>
                                </span>
                                </a>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <br clear="all" />

            <div class="pagin">
                <% Paginacao(subcategoria.IDCategoria, Pagina, TotalPagina); %>
            </div>
        </div>
		<div class="extra"></div>
	</div>
</div>