namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class _Admin_lojas_usuarios_listagem : System.Web.UI.Page
    {
        public Idioma.Loja.Usuario Idioma = new Idioma.Loja.Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                MontarListagem();
        }

        private void MontarListagem()
        {
            List<Entity.Usuario.Loja> usuarios = new Admin.Usuario.Loja().ListarUsuario(Convert.ToInt32(Request["loja"]));

            rptListagem.DataSource = usuarios;
            rptListagem.DataBind();
        }

        public string Cnpj(object cnpj)
        {
            string c = cnpj.ToString();
            return c.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
        }

        public string Status(object status)
        {
            if (Convert.ToBoolean(status))
                return "<span class='label label-success arrowed'>Ativo</span>";
            else
                return "<span class='label label-important arrowed-in'>Inativo</span>";
        }

        protected void btnExcluir_ServerClick(object sender, EventArgs e)
        {
            if (Request.Form["chkExcluir"] != null)
            {
                string[] Usuarios = Request.Form["chkExcluir"].Split(',');
                foreach (string IDUsuario in Usuarios)
                    new Admin.Usuario.Loja().ExcluirUsuario(IDUsuario);

                MontarListagem();
            }
        }
    }
}