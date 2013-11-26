<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="produto.aspx.cs" Inherits="loja.produto" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
    <!-- specific styles -->
    <link href="css/produto.css" rel="stylesheet" />
    <link href="css/skin.css" rel="stylesheet" />

    <!-- specific scripts -->
    <script src="js/jquery.jcarousel.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".carousel").jcarousel();
        });
    </script>
</asp:Content>

<asp:Content ID="conteudo" runat="server" ContentPlaceHolderID="conteudo">
    <div id="migalha">
        <a href="~/" runat="server">E-Commerce.com.br</a> <% Migalha(Convert.ToInt32(Request["id"])); %>
    </div>

    <div id="principal">
        <div class="colEsq">
            <div class="foto-media"><img src="_img/produto/<%=objProduto.Imagens[0].Arquivo%>" height="292" alt="" /></div>
            <div class="foto_thumb">
                <ul>
                    <li class="prev"></li>
                    <% imagens(); %>
                    <li class="next"></li>
                </ul>
            </div>
            <div class="compartilhe">
                <span>Compartilhe</span>
            </div>
        </div>
        <div class="colDir">
            <h1><%=objProduto.Nome%></h1>
            <span class="codigo">(Cód. Item: <%=objProduto.Codigo%>)</span>
            <span class="marca">Outros produtos <a href="#"><%=objProduto.Marca%></a></span>
            <br clear="all" />
            <ul class="avaliacao">
                <li class="r4"></li>
                <li>(11 avaliações)</li>
                <li>Leia 11 avaliações</li>
                <li>Faça uma avaliação</li>
            </ul>
            <div class="valor">
                <div class="valores">
                    <% Precos(objProduto.IDProduto); %>
                </div>
                <img src="img/btn/comprar.png" class="comprar" alt="" />
                <br clear="all" />
            </div>
            <div class="cx-frete">
                <div class="frete">
                    <span>Calcule o frete e o prazo de entrega estimados para sua região.</span>
                    <span>Informe seu CEP: <input type="text" size="5" maxlength="5" />-<input type="text" size="3" maxlength="3" /> <input type="button" value="ok" /></span>
                        
                </div>
            </div>
            <br clear="all" />
            <div class="cx-parcela">
                <span><b>Parcelamento</b></span>
                <% Parcelamento(objProduto.IDProduto); %>
                <br clear="all" />
            </div>
        </div>
        <br clear="all" />
    </div>

    <div class="descricao">
        <h2>Detalhes do produto</h2>
        <hr />
        <div>
            <%=objProduto.Detalhe%>
        </div>
    </div>

    <div class="descricao">
        <h2>Características</h2>
        <hr />
        <div>
            <table cellspacing="0">
                <% caracteristicas(); %>
            </table>
        </div>
    </div>

    <div class="descricao">
        <h2>Especificações Técnicas</h2>
        <hr />
        <div>
            <table cellspacing="0">
                <% especificacoes(); %>
            </table>
        </div>
    </div>
</asp:Content>