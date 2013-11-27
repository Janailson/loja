namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class _Admin_loja_categorias_listagem : System.Web.UI.Page
    {
        public Idioma.Migalha.Categoria Migalha = new Idioma.Migalha.Categoria();
        public Idioma.Categoria Idioma = new Idioma.Categoria();

        public Entity.Usuario.Loja objUsuario;
        public Entity.Loja objLoja;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Constante.ADMLoja] != null)
            {
                objUsuario = (Entity.Usuario.Loja)Session[Constante.ADMLoja];
                objLoja = new Admin.Loja().ConsultarLoja(objUsuario.Loja_ID);
            }
        }

        public void MontarCategorias(int parentId, int pad)
        {
            List<Entity.Categoria> categorias = new Admin.Categoria().ListarCategoria(objLoja.IDLoja, parentId);
            categorias.ForEach(delegate(Entity.Categoria categoria)
            {
                Response.Write("<tr>\n");
                Response.Write("<td class='center' style='width: 30px'>\n");
                Response.Write("<label>\n");
                Response.Write("<input type='checkbox' name='chkExcluir' value='" + categoria.IDCategoria + "' />\n");
                Response.Write("<span class='lbl'></span>\n");
                Response.Write("</label>\n");
                Response.Write("</td>\n");
                Response.Write("<td style='padding-left: " + pad + "px'>\n");
                Response.Write("<a href='registro.aspx?id=" + categoria.IDCategoria + "'>- " + categoria.Nome + "</a>\n");
                Response.Write("</td>\n");
                Response.Write("<td>\n");
                Response.Write("<button class='btn btn-minier btn-info' onclick=\"window.location='registro.aspx?parentId=" + categoria.IDCategoria + "'; return false;\">\n");
                Response.Write("[+] adicionar\n");
                Response.Write("</button>\n");
                Response.Write("</td>\n");
                Response.Write("</tr>\n");
                MontarCategorias(categoria.IDCategoria, pad + 25);
            });
        }

        public string Nome(object IDCategoria)
        {
            return "";
        }

        public string Status(object status)
        {
            if (Convert.ToBoolean(status))
                return "<span class='label label-success arrowed'>Ativo</span>";
            else
                return "<span class='label label-important arrowed-in'>Inativo</span>";
        }
    }
}