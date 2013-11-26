namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Collections;

    public partial class _Admin_produto_produtos_vitrines_registro : System.Web.UI.Page
    {
        public Idioma.Migalha.Produto.Vitrine Migalha = new Idioma.Migalha.Produto.Vitrine();
        public Idioma.Produto.Vitrine Idioma = new Idioma.Produto.Vitrine();

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
            migalha = Migalha.NovaVitrine;

            // recupera dados do usuário
            objUsuario = (Entity.Usuario.Loja)Session[Constante.ADMLoja];
            objLoja = new Admin.Loja().ConsultarLoja(objUsuario.Loja_ID);

            if (!IsPostBack)
            {
                tamanhos();
                if (Request["id"] != null)
                    PreencherCampos();
            }
        }

        /// <summary>
        /// Preenche Dropdown com os tamanhos cadastradas
        /// </summary>
        private void tamanhos()
        {
            ddlTamanho.Items.Clear();
            ddlTamanho.Items.Add(new ListItem("", "0"));
            new Admin.Tamanho().ListarTamanho(objLoja.IDLoja).ForEach(delegate(Entity.Tamanho tamanho)
            {
                ddlTamanho.Items.Add(new ListItem(tamanho.Nome, tamanho.IDTamanho.ToString()));
            });
        }

        /// <summary>
        /// Requisita dados do Produto ao banco de dados e preenche o formulário
        /// </summary>
        private void PreencherCampos()
        {
            Entity.Produto.Vitrine vitrine = new Admin.Produto.Vitrine().ConsultarVitrine(Request["id"]);

            // geral
            ddlTamanho.Items.FindByValue(vitrine.Tamanho_ID.ToString()).Selected = true;
            txtPeso.Text = vitrine.Peso.ToString();
            txtAltura.Text = vitrine.Altura.ToString();
            txtLargura.Text = vitrine.Largura.ToString();
            txtProfundidade.Text = vitrine.Profundidade.ToString();
            txtEstoque.Text = vitrine.Estoque.ToString();
            chkStatus.Checked = vitrine.Status;
        }

        /// <summary>
        /// Ação do botão "salvar"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalvar_ServerClick(object sender, EventArgs e)
        {
            // recupera dados digitado no formulário
            string Tamanho = ddlTamanho.SelectedValue;
            string Peso = txtPeso.Text.Trim();
            string Altura = txtAltura.Text.Trim();
            string Largura = txtLargura.Text.Trim();
            string Profundidade = txtProfundidade.Text.Trim();
            string Estoque = txtEstoque.Text.Trim();
            bool Status = chkStatus.Checked;
            bool Validar = true;

            // limpa mensagens de erro
            LimparLabel();

            // verifica consistência do formulário
            if (ddlTamanho.SelectedIndex == 0)
            {
                Validar = false;
                new Constante().input_error(pnlTamanho, lblTamanho, "selecione o tamanho");
            }

            // formulário validado
            if (Validar)
            {
                // instância objeto
                Entity.Produto.Vitrine vitrine = new Entity.Produto.Vitrine();
                vitrine.Produto_ID = Convert.ToInt32(Request["produto"]);
                vitrine.Tamanho_ID = Convert.ToInt32(Tamanho);
                vitrine.Peso = Convert.ToDecimal(Peso);
                vitrine.Altura = Convert.ToDecimal(Altura);
                vitrine.Largura = Convert.ToDecimal(Largura);
                vitrine.Profundidade = Convert.ToDecimal(Profundidade);
                vitrine.Estoque = Convert.ToInt32(Estoque);
                vitrine.Status = Status;

                // altera registro
                if (Request["id"] != null)
                {
                    vitrine.IDVitrine = Convert.ToInt32(Request["id"]);

                    Entity.Retorno ret = new Admin.Produto.Vitrine().AlterarVitrine(vitrine);
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
                    Entity.Retorno ret = new Admin.Produto.Vitrine().InserirVitrine(vitrine);
                    if (!ret.Status)
                    {
                        // exibe mensagem de erro
                        icon = Icon.remove;
                        new Constante().label_message(pnlMsg, Alert.error, labMsg, "Vitrine: " + ret.Erro);
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

            new Constante().input_error(pnlTamanho, lblTamanho);
            new Constante().input_error(pnlPeso, lblPeso);
            new Constante().input_error(pnlAltura, lblAltura);
            new Constante().input_error(pnlLargura, lblLargura);
            new Constante().input_error(pnlProfundidade, lblProfundidade);
        }

        /// <summary>
        /// Limpa os campos para um novo registro
        /// </summary>
        private void LimparCampos()
        {
            ddlTamanho.ClearSelection();
            txtPeso.Text = "";
            txtAltura.Text = "";
            txtLargura.Text = "";
            txtProfundidade.Text = "";
            chkStatus.Checked = true;
        }
    }
}