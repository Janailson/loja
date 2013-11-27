namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class _Admin_produto_cores_listagem : System.Web.UI.Page
    {
        public Idioma.Migalha.Cor Migalha = new Idioma.Migalha.Cor();
        public Idioma.Cor Idioma = new Idioma.Cor();

        public Entity.Usuario.Loja objUsuario;
        public Entity.Loja objLoja;

        protected void Page_Load(object sender, EventArgs e)
        {
            // verifica se existe sessão ativa
            if (Session[Constante.ADMLoja] == null) return;

            // recupera dados do usuário
            objUsuario = (Entity.Usuario.Loja)Session[Constante.ADMLoja];
            objLoja = new Admin.Loja().ConsultarLoja(objUsuario.Loja_ID);

            if (!IsPostBack)
                MontarListagem();
        }

        private void MontarListagem()
        {
            List<Entity.Cor> cores = new Admin.Cor().ListarCor(objLoja.IDLoja);

            rptListagem.DataSource = cores;
            rptListagem.DataBind();
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
                string[] Cores = Request.Form["chkExcluir"].Split(',');
                foreach (string IDCor in Cores)
                    new Admin.Cor().ExcluirCor(IDCor);
            }

            MontarListagem();
        }
    }
}