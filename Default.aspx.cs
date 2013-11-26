namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using System.Text;

    public partial class _Default : System.Web.UI.Page, ICatalogo
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Migalha(int n)
        {
            // not applied
        }

        public void Menu(int n)
        {
            // not applied
        }

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
                Produtos(categoria.IDCategoria, true);
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

        public void Produtos(int IDCategoria, bool Destaque)
        {
            new Business.Produto().ListarProduto(IDCategoria, Destaque).ForEach(delegate(Entity.Produto produto)
            {
                Response.Write("<li>\n");
                Response.Write("<div class='prd'>\n");
                Response.Write("<a href='produto.aspx?id=" + produto.IDProduto + "' title='" + produto.Nome + "'>\n");
                Response.Write("<span class='productImage'><img src='_img/produto/" + produto.ImagemProduto + "' width='130' style='display: inline' alt='" + produto.Nome + "' /></span>\n");
                Response.Write("<span class='productFlag'></span>\n");
                Response.Write("<span class='productName'>" + produto.Nome + "</span>\n");
                Response.Write("<span class='productDetails'>\n");

                // preço
                Precos(produto.IDProduto);

                Response.Write("</span>\n");
                Response.Write("</a>\n");
                Response.Write("</div>\n");
                Response.Write("</li>\n");
            });
        }

        public void Precos(int IDProduto)
        {
            List<Entity.Produto.Preco> precos = new Business.Produto.Preco().ListarPreco(IDProduto);

            if (Session[Constante.SESSAO] == null)
            {
                if (precos[0].Promocao > 0)
                {
                    Response.Write("<span class='promocao'>De: <strong>" + precos[0].Valor.ToString("c") + "</strong></span>\n");
                    Response.Write("<span class='preco'>Por: <strong>" + precos[0].Promocao.ToString("c") + "</strong></span>\n");
                    Response.Write("<span class='parcela'>em até 12X de " + (precos[0].Promocao / 12).ToString("c") + " sem juros</span>\n");
                }
                else
                {
                    Response.Write("<span class='preco'>Por: <strong>" + precos[0].Valor.ToString("c") + "</strong></span>\n");
                    Response.Write("<span class='parcela'>em até 12X de " + (precos[0].Valor / 12).ToString("c") + " sem juros</span>\n");
                }
            }
        }
    }
}