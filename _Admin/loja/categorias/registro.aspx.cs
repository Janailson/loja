namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class _Admin_loja_categorias_registro : System.Web.UI.Page
    {
        public Idioma.Migalha.Categoria Migalha = new Idioma.Migalha.Categoria();
        public Idioma.Categoria Idioma = new Idioma.Categoria();

        public Entity.Usuario.Loja objUsuario;
        public Entity.Loja objLoja;

        private decimal minDecimal = decimal.MinValue;
        private string Path;
        public Icon icon;
        public string migalha;

        Random rnd = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            migalha = Migalha.NovaCategoria;
            if (Session[Constante.ADMLoja] != null)
            {
                objUsuario = (Entity.Usuario.Loja)Session[Constante.ADMLoja];
                objLoja = new Admin.Loja().ConsultarLoja(objUsuario.Loja_ID);
            }

            if (!IsPostBack)
            {
                if (Request["id"] != null)
                    PreencherCampos();
            }
        }

        /// <summary>
        /// Requisita dados da Categoria ao banco de dados e preenche o formulário
        /// </summary>
        private void PreencherCampos()
        {
            Entity.Categoria categoria = new Admin.Categoria().ConsultarCategoria(Request["id"]);

            // dicionario
            List<Entity.Dicionario> nomes = categoria.Dicionarios.FindAll(delegate(Entity.Dicionario p1) { return (p1.Descricao == "Nome"); });

            // migalha
            migalha = nomes[0].Valor;

            // geral
            txtNome.Text = nomes[0].Valor;
            chkSite.Checked = categoria.Site;
            chkStatus.Checked = categoria.Status;
        }

        /// <summary>
        /// Ação do botão "salvar"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalvar_ServerClick(object sender, EventArgs e)
        {
            // recupera dados digitado no formulário
            string Nome = txtNome.Text.Trim().Replace("'", "''");
            bool Site = chkSite.Checked;
            bool Status = chkStatus.Checked;
            bool Validar = true;

            // limpa mensagens de erro
            LimparLabel();

            // verifica consistência do formulário
            if (Nome == String.Empty)
            {
                Validar = false;
                new Constante().input_error(pnlNome, lblNome, "campo obrigatório");
            }

            // formulário validado
            if (Validar)
            {
                // instância objeto
                Entity.Categoria categoria = new Entity.Categoria();
                categoria.Loja_ID = objUsuario.Loja_ID;
                categoria.parentId = Convert.ToInt32(Request["parentId"]);
                categoria.Site = Site;
                categoria.Status = Status;

                // altera registro
                if (Request["id"] != null)
                {
                    categoria.IDCategoria = Convert.ToInt32(Request["id"]);

                    Entity.Retorno ret = new Admin.Categoria().AlterarCategoria(categoria);
                    if (!ret.Status)
                    {
                        // exibe mensagem de erro
                        icon = Icon.remove;
                        new Constante().label_message(pnlMsg, Alert.error, labMsg, ret.Erro);
                        return;
                    }

                    // altera dicionário de palavras
                    new Admin.Dicionario().AlterarDicionario(new Entity.Dicionario(1, "Categoria", categoria.IDCategoria, "Nome", Nome));

                    // mensagem de sucesso
                    icon = Icon.ok;
                    new Constante().label_message(pnlMsg, Alert.success, labMsg, "Dados alterado com sucesso.");
                    PreencherCampos();
                }
                // adiciona novo registro
                else
                {
                    Entity.Retorno ret = new Admin.Categoria().InserirCategoria(categoria);
                    if (!ret.Status)
                    {
                        // exibe mensagem de erro
                        icon = Icon.remove;
                        new Constante().label_message(pnlMsg, Alert.error, labMsg, ret.Erro);
                        return;
                    }
                    
                    // adiciona dicionário de palavras
                    new Admin.Dicionario().InserirDicionario(new Entity.Dicionario(1, "Categoria", ret.Identity, "Nome", Nome));

                    // mensagem de sucesso
                    icon = Icon.ok;
                    new Constante().label_message(pnlMsg, Alert.success, labMsg, "Cadastro realizado com sucesso.");
                    LimparCampos();
                }
            }
        }

        /// <summary>
        /// Limpa mensagens de erro
        /// </summary>
        private void LimparLabel()
        {
            pnlMsg.Visible = false;
            labMsg.Text = "";

            new Constante().input_error(pnlNome, lblNome);
        }

        /// <summary>
        /// Limpa os campos para um novo registro
        /// </summary>
        private void LimparCampos()
        {
            txtNome.Text = "";
        }
    }
}