namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Collections;

    public partial class _Admin_produto_produtos_caracteristicas_registro : System.Web.UI.Page
    {
        public Idioma.Migalha.Produto.Caracteristica Migalha = new Idioma.Migalha.Produto.Caracteristica();
        public Idioma.Produto.Caracteristica Idioma = new Idioma.Produto.Caracteristica();

        public Entity.Usuario.Loja objUsuario;
        public Entity.Loja objLoja;

        private decimal minDecimal = decimal.MinValue;
        public Icon icon;
        public string migalha;

        protected void Page_Load(object sender, EventArgs e)
        {
            // verifica se existe sessão ativa
            if (Session[Constante.ADMLoja] == null) return;

            // migalha
            migalha = Migalha.NovaCaracteristica;

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
        /// Requisita dados do Produto ao banco de dados e preenche o formulário
        /// </summary>
        private void PreencherCampos()
        {
            Entity.Produto.Caracteristica caracteristica = new Admin.Produto.Caracteristica().ConsultarCaracteristica(Request["id"]);

            // geral
            txtNome.Text = caracteristica.Nome;
            txtValor.Text = caracteristica.Valor;
            chkFiltro.Checked = caracteristica.Filtro;
        }

        /// <summary>
        /// Ação do botão "salvar"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalvar_ServerClick(object sender, EventArgs e)
        {
            // recupera dados digitado no formulário
            string Nome = txtNome.Text.Trim();
            string Valor = txtValor.Text.Trim();
            bool Filtro = chkFiltro.Checked;
            bool Validar = true;

            // limpa mensagens de erro
            LimparLabel();

            // verifica consistência do formulário
            if (Nome == String.Empty)
            {

            }

            // formulário validado
            if (Validar)
            {
                // instância objeto
                Entity.Produto.Caracteristica caracteristica = new Entity.Produto.Caracteristica();
                caracteristica.Produto_ID = Convert.ToInt32(Request["produto"]);
                caracteristica.Nome = Nome;
                caracteristica.Valor = Valor.Replace("\n", "<br />");
                caracteristica.Filtro = Filtro;

                // altera registro
                if (Request["id"] != null)
                {
                    caracteristica.IDCaracteristica = Convert.ToInt32(Request["id"]);

                    Entity.Retorno ret = new Admin.Produto.Caracteristica().AlterarCaracteristica(caracteristica);
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
                    Entity.Retorno ret = new Admin.Produto.Caracteristica().InserirCaracteristica(caracteristica);
                    if (!ret.Status)
                    {
                        // exibe mensagem de erro
                        icon = Icon.remove;
                        new Constante().label_message(pnlMsg, Alert.error, labMsg, "Característica: " + ret.Erro);
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
        /// Valida consistência dos campos dos idiomas adicionais
        /// </summary>
        /// <param name="Campo"></param>
        /// <returns></returns>
        private bool ValidaCampo(string Campo)
        {
            bool saida = true;

            for (int i = 1; i < objLoja.Idiomas.Count; i++)
                saida = (Request.Form["txt" + Campo + objLoja.Idiomas[i].IDIdioma].Trim() != String.Empty);

            return saida;
        }

        /// <summary>
        /// Limpa mensagens de erro
        /// </summary>
        private void LimparLabel()
        {
            pnlMsg.Visible = false;
            labMsg.Text = "";

            new Constante().input_error(pnlNome, lblNome);
            new Constante().input_error(pnlValor, lblValor);
        }

        /// <summary>
        /// Limpa os campos para um novo registro
        /// </summary>
        private void LimparCampos()
        {
            txtNome.Text = "";
            txtValor.Text = "";
            chkFiltro.Checked = true;
        }
    }
}