using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace loja
{
    public abstract class Catalogo : System.Web.UI.UserControl, ICatalogo
    {
        public Entity.Categoria pai;
        public Entity.Categoria categoria;
        public Entity.Categoria subcategoria;

        public int Pagina;
        public int TotalPagina = 20;

        // --
        public void Migalha(int IDCategoria)
        {
            Entity.Categoria categoria = new Business.Categoria().ConsultarCategoria(IDCategoria);

            if (categoria.parentId > 0) Migalha(categoria.parentId);
            Response.Write(" > <a href='categoria.aspx?id=" + categoria.IDCategoria + "'>" + categoria.Nome + "</a>");
        }

        public void Menu(int IDCategoria)
        {
            new Business.Categoria().ListarCategoria(Constante.IDLoja, IDCategoria).ForEach(delegate(Entity.Categoria categoria)
            {
                if (categoria.Nivel == categoria.MinNivel)
                    Response.Write("<li class='tl'><a href='categoria.aspx?id=" + categoria.IDCategoria + "'>" + categoria.Nome + "</a></li>\n");
                else if (categoria.Nivel == categoria.MaxNivel)
                    Response.Write("<li><a href='categoria.aspx?id=" + categoria.IDCategoria + "'>" + categoria.Nome + " (" + categoria.Produtos + ")</a></li>\n");
                else
                    Response.Write("<li class='tl2'><a href='categoria.aspx?id=" + categoria.IDCategoria + "'>" + categoria.Nome + "</a></li>\n");

                Menu(categoria.IDCategoria);
            });
        }

        // --
        public void Categorias(int parentId, bool Destaque)
        {
            new Business.Categoria().ListarCategoria(Constante.IDLoja, parentId).ForEach(delegate(Entity.Categoria categoria)
            {
                Response.Write("<div class='categoria'>\n");
                Response.Write("<h2><a href='categoria.aspx?id=" + categoria.IDCategoria + "'>" + categoria.Nome + "</a></h2>\n");
                Response.Write("<ul class='subcategoria'>\n");

                // lista subcategorias
                Subcategorias(categoria.IDCategoria, Destaque);

                Response.Write("</ul>\n");
                Response.Write("<hr />\n");
                Response.Write("<ul class='jcarousel-skin carousel'>\n");
                Vitrine(categoria.IDCategoria);
                Response.Write("</ul>\n");
                Response.Write("<br clear='all' />\n");
                Response.Write("</div>\n");
            });
        }

        public void Subcategorias(int parentId, bool Destaque)
        {
            new Business.Categoria().ListarCategoria(Constante.IDLoja, parentId).ForEach(delegate(Entity.Categoria categoria)
            {
                Response.Write("<li><a href='categoria.aspx?id=" + categoria.IDCategoria + "'>" + categoria.Nome + "</a></li>\n");
            });
        }

        // --
        public void Paginacao(int IDCategoria, int Pagina, decimal TotalPagina)
        {
            int Produtos = new Business.Produto().ListarProduto(IDCategoria, false).Count;
            decimal Paginas = Math.Ceiling(Produtos / TotalPagina);

            if (Pagina == 1)
            {
                Response.Write("<span>primeira</span> |\n");
                Response.Write("<span>anterior</span> |\n");
            }
            else
            {
                Response.Write("<a href='categoria.aspx?id=" + IDCategoria + "'>primeira</a> |\n");
                Response.Write("<a href='categoria.aspx?id=" + IDCategoria + "&pagina=" + (Pagina - 1).ToString() + "'>anterior</a> |\n");
            }

            for (decimal i = 1; i <= Paginas; i++)
            {
                if (i.ToString() == Pagina.ToString())
                    Response.Write("<a href='categoria.aspx?id=" + IDCategoria + "&pagina=" + i.ToString() + "' class='atual'>" + i.ToString() + "</a> |\n");
                else
                    Response.Write("<a href='categoria.aspx?id=" + IDCategoria + "&pagina=" + i.ToString() + "'>" + i.ToString() + "</a> |\n");
            }

            if (Pagina != Paginas)
            {
                Response.Write("<a href='categoria.aspx?id=" + IDCategoria + "&pagina=" + (Pagina + 1).ToString() + "'>próxima</a> |\n");
                Response.Write("<a href='categoria.aspx?id=" + IDCategoria + "&pagina=" + Paginas.ToString() + "'>última</a>\n");
            }
            else
            {
                Response.Write("<span>próxima</span> |\n");
                Response.Write("<span>última</span>\n");
            }
        }

        // --
        public void Vitrine(int IDCategoria)
        {
            new Business.Produto().ListarProduto(IDCategoria, true).ForEach(delegate(Entity.Produto produto)
            {
                Response.Write("<li>\n");
                Response.Write("<div class='prd'>\n");
                Response.Write("<a href='produto.aspx?id=" + produto.IDProduto + "' title='" + produto.Nome + "'>\n");
                Response.Write("<span class='productImage'><img src='_img/produto/" + produto.ImagemProduto + "' width='130' style='display: inline' alt='" + produto.Nome + "' /></span>\n");
                Response.Write("<span class='productFlag'></span>\n");
                Response.Write("<span class='productName'>" + produto.Nome + "</span>\n");
                Response.Write("<span class='productDetails'>\n");

                // preço
                Response.Write(Precos(produto.IDProduto));

                Response.Write("</span>\n");
                Response.Write("</a>\n");
                Response.Write("</div>\n");
                Response.Write("</li>\n");
            });
        }

        public abstract void Produtos();

        public string Precos(object IDProduto)
        {
            List<Entity.Produto.Preco> precos = new Business.Produto.Preco().ListarPreco(Convert.ToInt32(IDProduto));
            StringBuilder sb = new StringBuilder();

            if (Session[Constante.SESSAO] == null)
            {
                if (precos[0].Promocao > 0)
                {
                    sb.Append("<span class='promocao'>De: <strong>" + precos[0].Valor.ToString("c") + "</strong></span>\n");
                    sb.Append("<span class='preco'>Por: <strong>" + precos[0].Promocao.ToString("c") + "</strong></span>\n");
                    sb.Append("<span class='parcela'>em até 12X de " + (precos[0].Promocao / 12).ToString("c") + " sem juros</span>\n");
                }
                else
                {
                    sb.Append("<span class='preco'>Por: <strong>" + precos[0].Valor.ToString("c") + "</strong></span>\n");
                    sb.Append("<span class='parcela'>em até 12X de " + (precos[0].Valor / 12).ToString("c") + " sem juros</span>\n");
                }
            }

            return sb.ToString();
        }

        // --
        public void Marcas(int IDCategoria)
        {
            new Business.Marca().ListarMarca(IDCategoria).ForEach(delegate(Entity.Marca marca)
            {
                Response.Write("<li><a href='categoria.aspx?id=" + IDCategoria + (Request["pagina"] != null ? "&pagina=" + Request["pagina"] : "") + "&marca=" + marca.IDMarca + "'>" + marca.Nome + " (" + marca.Produtos + ")</a></li>\n");
            });
        }

        public void Cores(int IDCategoria)
        {
            new Business.Cor().ListarCor(IDCategoria).ForEach(delegate(Entity.Cor cor)
            {
                Response.Write("<li><a href='categoria.aspx?id=" + IDCategoria + (Request["pagina"] != null ? "&pagina=" + Request["pagina"] : "") + "&cor=" + cor.IDCor + "'>" + cor.Nome + " (" + cor.Produtos + ")</a></li>\n");
            });
        }
    }
}