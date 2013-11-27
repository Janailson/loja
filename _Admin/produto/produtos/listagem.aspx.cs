namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class _Admin_produto_produtos_listagem : System.Web.UI.Page
    {
        public Idioma.Migalha.Produto Migalha = new Idioma.Migalha.Produto();
        public Idioma.Produto Idioma = new Idioma.Produto();

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
            List<Entity.Produto> produtos = new Admin.Produto().ListarProduto(objLoja.IDLoja);

            rptListagem.DataSource = produtos;
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
                string[] Produtos = Request.Form["chkExcluir"].Split(',');
                foreach (string IDProduto in Produtos)
                    new Admin.Produto().ExcluirProduto(IDProduto);
            }

            MontarListagem();
        }
    }
}