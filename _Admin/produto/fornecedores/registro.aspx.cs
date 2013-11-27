namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class _Admin_produto_fornecedores_registro : System.Web.UI.Page
    {
        public Idioma.Migalha.Fornecedor Migalha = new Idioma.Migalha.Fornecedor();
        public Idioma.Fornecedor Idioma = new Idioma.Fornecedor();

        public Entity.Usuario.Loja objUsuario;
        public Entity.Loja objLoja;

        private decimal minDecimal = decimal.MinValue;
        private string Path;
        public Icon icon;
        public string migalha;

        Random rnd = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            // verifica se existe sessão ativa
            if (Session[Constante.ADMLoja] == null) return;

            // migalha
            migalha = Migalha.NovoFornecedor;

            // recupera dados do usuário
            objUsuario = (Entity.Usuario.Loja)Session[Constante.ADMLoja];
            objLoja = new Admin.Loja().ConsultarLoja(objUsuario.Loja_ID);

            if (!IsPostBack)
            {
                if (Request["id"] != null)
                    PreencherCampos();
            }
        }

        /// <summary>
        /// Requisita dados do Fornecedor ao banco de dados e preenche o formulário
        /// </summary>
        private void PreencherCampos()
        {
            Entity.Fornecedor fornecedor = new Admin.Fornecedor().ConsultarFornecedor(Request["id"]);

            // migalha
            migalha = fornecedor.Nome;

            // geral
            txtNome.Text = fornecedor.Nome;
            chkStatus.Checked = fornecedor.Status;
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
                Entity.Fornecedor fornecedor = new Entity.Fornecedor();
                fornecedor.Loja_ID = objUsuario.Loja_ID;
                fornecedor.Nome = Nome;
                fornecedor.Status = Status;

                // altera registro
                if (Request["id"] != null)
                {
                    fornecedor.IDFornecedor = Convert.ToInt32(Request["id"]);

                    Entity.Retorno ret = new Admin.Fornecedor().AlterarFornecedor(fornecedor);
                    if (!ret.Status)
                    {
                        // exibe mensagem de erro
                        icon = Icon.remove;
                        new Constante().label_message(pnlMsg, Alert.error, labMsg, ret.Erro);
                        return;
                    }

                    // mensagem de sucesso
                    icon = Icon.ok;
                    new Constante().label_message(pnlMsg, Alert.success, labMsg, "Dados alterado com sucesso.");
                    PreencherCampos();
                }
                // adiciona novo registro
                else
                {
                    Entity.Retorno ret = new Admin.Fornecedor().InserirFornecedor(fornecedor);
                    if (!ret.Status)
                    {
                        // exibe mensagem de erro
                        icon = Icon.remove;
                        new Constante().label_message(pnlMsg, Alert.error, labMsg, ret.Erro);
                        return;
                    }

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
            chkStatus.Checked = true;
        }
    }
}