namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class _Admin_produto_cores_registro : System.Web.UI.Page
    {
        public Idioma.Migalha.Cor Migalha = new Idioma.Migalha.Cor();
        public Idioma.Cor Idioma = new Idioma.Cor();

        public Entity.Usuario.Loja objUsuario;
        public Entity.Loja objLoja;

        private decimal minDecimal = decimal.MinValue;
        public Icon icon;
        public string migalha;

        Random rnd = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            // verifica se existe sessão ativa
            if (Session[Constante.ADMLoja] == null) return;

            // migalha
            migalha = Migalha.NovaCor;

            // recupera dados do usuário
            objUsuario = (Entity.Usuario.Loja)Session[Constante.ADMLoja];
            objLoja = new Admin.Loja().ConsultarLoja(objUsuario.Loja_ID);

            // idiomas
            imgBandeira.ImageUrl = "~/_Admin/assets/icons/" + objLoja.Idiomas[0].Codigo + ".png";
            imgBandeira.Attributes.Add("title", objLoja.Idiomas[0].Nome);

            if (!IsPostBack)
            {
                if (Request["id"] != null)
                    PreencherCampos();
            }
        }

        /// <summary>
        /// Cria campo para cada idioma adicional
        /// </summary>
        /// <param name="Campo"></param>
        public void multidioma(string Campo)
        {
            for (int i = 1; i < objLoja.Idiomas.Count; i++)
            {
                Response.Write("<br />\n");
                Response.Write("<div class='controls'>\n");
                Response.Write("<span class='input-icon input-icon-right span3'>\n");
                Response.Write("<input type='text' name='txtNome" + objLoja.Idiomas[i].IDIdioma + "' value='" + PreencherIdioma("Nome", objLoja.Idiomas[i].IDIdioma) + "' class='tooltip-error span12' MaxLength='50' />\n");
                if (lblNome.Visible) { Response.Write("<i class='icon-remove-sign'></i>\n"); }
                Response.Write("</span>\n");
                Response.Write("<asp:Image ID='Image1' runat='server' style='margin-left: 10px' />\n");
                Response.Write("<img src='../../assets/icons/" + objLoja.Idiomas[i].Codigo + ".png' alt='' title='" + objLoja.Idiomas[i].Nome + "' />\n");
                Response.Write("</div>\n");
            }
        }

        /// <summary>
        /// Recupera os dados de cada campo de idioma adicional
        /// </summary>
        /// <param name="Campo"></param>
        private string PreencherIdioma(string Campo, int Id)
        {
            if (Request["id"] != null)
            {
                Entity.Cor cor = new Admin.Cor().ConsultarCor(Request["id"]);
                switch (Campo)
                {
                    case "Nome":
                        Entity.Dicionario nome = cor.Dicionarios.Find(delegate(Entity.Dicionario p1) { return (p1.Idioma_ID == Id && p1.Descricao == "Nome"); });
                        return nome.Valor;
                }
            }

            return "";
        }

        /// <summary>
        /// Requisita dados da Cor ao banco de dados e preenche o formulário
        /// </summary>
        private void PreencherCampos()
        {
            Entity.Cor cor = new Admin.Cor().ConsultarCor(Request["id"]);

            // dicionario
            List<Entity.Dicionario> nomes = cor.Dicionarios.FindAll(delegate(Entity.Dicionario p1) { return (p1.Descricao == "Nome"); });

            // migalha
            migalha = nomes[0].Valor;

            // geral
            txtNome.Text = nomes[0].Valor;
            chkStatus.Checked = cor.Status;
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
            if (Nome == String.Empty || !ValidaCampo("Nome"))
            {
                Validar = false;
                new Constante().input_error(pnlNome, lblNome, "campo obrigatório");
            }

            // formulário validado
            if (Validar)
            {
                // instância objeto
                Entity.Cor cor = new Entity.Cor();
                cor.Loja_ID = objUsuario.Loja_ID;
                cor.Status = Status;

                // altera registro
                if (Request["id"] != null)
                {
                    cor.IDCor = Convert.ToInt32(Request["id"]);

                    Entity.Retorno ret = new Admin.Cor().AlterarCor(cor);
                    if (!ret.Status)
                    {
                        // exibe mensagem de erro
                        icon = Icon.remove;
                        new Constante().label_message(pnlMsg, Alert.error, labMsg, ret.Erro);
                        return;
                    }

                    // altera dicionário de palavras
                    new Admin.Dicionario().AlterarDicionario(new Entity.Dicionario(objLoja.Idiomas[0].IDIdioma, "Cor", cor.IDCor, "Nome", Nome));
                    for (int i = 1; i < objLoja.Idiomas.Count; i++)
                    {
                        // nome
                        new Admin.Dicionario().AlterarDicionario(new Entity.Dicionario(objLoja.Idiomas[i].IDIdioma, "Cor", cor.IDCor, "Nome", Request.Form["txtNome" + objLoja.Idiomas[i].IDIdioma]));
                    }

                    // mensagem de sucesso
                    icon = Icon.ok;
                    new Constante().label_message(pnlMsg, Alert.success, labMsg, "Dados alterado com sucesso.");
                    PreencherCampos();
                }
                // adiciona novo registro
                else
                {
                    Entity.Retorno ret = new Admin.Cor().InserirCor(cor);
                    if (!ret.Status)
                    {
                        // exibe mensagem de erro
                        icon = Icon.remove;
                        new Constante().label_message(pnlMsg, Alert.error, labMsg, ret.Erro);
                        return;
                    }

                    // adiciona dicionário de palavras
                    new Admin.Dicionario().InserirDicionario(new Entity.Dicionario(objLoja.Idiomas[0].IDIdioma, "Cor", ret.Identity, "Nome", Nome));
                    for (int i = 1; i < objLoja.Idiomas.Count; i++)
                    {
                        // nome
                        new Admin.Dicionario().InserirDicionario(new Entity.Dicionario(objLoja.Idiomas[i].IDIdioma, "Cor", ret.Identity, "Nome", Request.Form["txtNome" + objLoja.Idiomas[i].IDIdioma]));
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