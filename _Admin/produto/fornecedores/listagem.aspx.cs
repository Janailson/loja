namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class _Admin_produto_fornecedores_listagem : System.Web.UI.Page
    {
        public Idioma.Migalha.Fornecedor Migalha = new Idioma.Migalha.Fornecedor();
        public Idioma.Fornecedor Idioma = new Idioma.Fornecedor();

        public Entity.Usuario.Loja objUsuario;
        public Entity.Loja objLoja;

        protected void Page_Load(object sender, EventArgs e)
        {
            // verifica se a sessão está ativa
            if (Session[Constante.ADMLoja] == null)
                return;

            // recupera os dados da sessão do usuário
            objUsuario = (Entity.Usuario.Loja)Session[Constante.ADMLoja];
            objLoja = new Admin.Loja().ConsultarLoja(objUsuario.Loja_ID);

            if (!IsPostBack)
                MontarListagem();
        }

        private void MontarListagem()
        {
            List<Entity.Fornecedor> fornecedores = new Admin.Fornecedor().ListarFornecedor(objLoja.IDLoja);

            rptListagem.DataSource = fornecedores;
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
                string[] Fornecedores = Request.Form["chkExcluir"].Split(',');
                foreach (string IDFornecedor in Fornecedores)
                    new Admin.Fornecedor().ExcluirFornecedor(IDFornecedor);
            }

            MontarListagem();
        }
    }
}