namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class produto : Vitrine
    {
        public Entity.Produto objProduto;

        protected void Page_Load(object sender, EventArgs e)
        {
            objProduto = new Business.Produto().ConsultarProduto(Request["id"]);
        }

        public void imagens()
        {
            objProduto.Imagens.ForEach(delegate(Entity.Produto.Imagem imagem)
            {
                Response.Write("<li><img src='_img/produto/" + imagem.Arquivo + "' height='45' alt='' /></li>\n");
            });
        }

        public void caracteristicas()
        {
            int n = 0;
            objProduto.Caracteristicas.ForEach(delegate(Entity.Produto.Caracteristica caracteristica)
            {
                n++;
                Response.Write("<tr style='background-color: #" + (n % 2 == 0 ? "eee" : "fff") + "'>\n");
                Response.Write("<th>" + caracteristica.Nome + "</th>\n");
                Response.Write("<td>" + caracteristica.Valor + "</td>\n");
                Response.Write("</tr>\n");
            });
        }

        public void especificacoes()
        {
            int n = 0;
            objProduto.Especificacoes.ForEach(delegate(Entity.Produto.Especificacao especificacao)
            {
                Response.Write("<tr>\n");
                Response.Write("<th>" + especificacao.Nome + "</th>\n");
                Response.Write("<td>" + especificacao.Valor + "</td>\n");
                Response.Write("</tr>\n");
            });
        }
    }
}