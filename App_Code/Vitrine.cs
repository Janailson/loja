using System;
using System.Collections.Generic;
using System.Web;

namespace loja
{
    public abstract class Vitrine : System.Web.UI.Page, IVitrine
    {
        // --
        public void Migalha(int IDCategoria)
        {
            Entity.Categoria categoria = new Business.Categoria().ConsultarCategoria(IDCategoria);

            if (categoria.parentId > 0) Migalha(categoria.parentId);
            Response.Write(" > <a href='categoria.aspx?id=" + categoria.IDCategoria + "'>" + categoria.Nome + "</a>");
        }

        // --
        public void Precos(int IDProduto)
        {
            List<Entity.Produto.Preco> precos = new Business.Produto.Preco().ListarPreco(IDProduto);

            if (Session[Constante.SESSAO] == null)
            {
                if (precos[0].Promocao > 0)
                {
                    Response.Write("<span class='vl1'>De: " + precos[0].Valor.ToString("c") + "</span>\n");
                    Response.Write("<span class='vl2'>Por: <strong>" + precos[0].Promocao.ToString("c") + "</strong></span>\n");
                    Response.Write("<span class='vl3'>em até <strong>12X</strong> de <strong>" + (precos[0].Promocao / 12).ToString("c") + "</strong></span>\n");
                }
                else
                {
                    Response.Write("<span class='vl2'>Por: <strong>" + precos[0].Valor.ToString("c") + "</strong></span>\n");
                    Response.Write("<span class='vl3'>em até <strong>12X</strong> de <strong>" + (precos[0].Valor / 12).ToString("c") + "</strong></span>\n");
                }
            }
        }

        public void Parcelamento(int IDProduto)
        {
            List<Entity.Produto.Preco> precos = new Business.Produto.Preco().ListarPreco(IDProduto);
            decimal Valor = 0;

            if (Session[Constante.SESSAO] == null)
            {
                if (precos[0].Promocao > 0)
                    Valor = precos[0].Promocao;
                else
                    Valor = precos[0].Valor;
            }

            Response.Write("<ul>\n");
            Response.Write("<li>à vista	" + (Valor / 1).ToString("c") + "</li>\n");
            Response.Write("<li>2x sem juros " + (Valor / 2).ToString("c") + "</li>\n");
            Response.Write("<li>3x sem juros " + (Valor / 3).ToString("c") + "</li>\n");
            Response.Write("<li>4x sem juros " + (Valor / 4).ToString("c") + "</li>\n");
            Response.Write("<li>5x sem juros " + (Valor / 5).ToString("c") + "</li>\n");
            Response.Write("<li>6x sem juros " + (Valor / 6).ToString("c") + "</li>\n");
            Response.Write("</ul>\n");

            Response.Write("<ul>\n");
            Response.Write("<li>7x sem juros " + (Valor / 7).ToString("c") + "</li>\n");
            Response.Write("<li>8x sem juros " + (Valor / 8).ToString("c") + "</li>\n");
            Response.Write("<li>9x sem juros " + (Valor / 9).ToString("c") + "</li>\n");
            Response.Write("<li>10x sem juros " + (Valor / 10).ToString("c") + "</li>\n");
            Response.Write("<li>11x sem juros " + (Valor / 11).ToString("c") + "</li>\n");
            Response.Write("<li>12x sem juros " + (Valor / 12).ToString("c") + "</li>\n");
            Response.Write("</ul>\n");
        }
    }
}