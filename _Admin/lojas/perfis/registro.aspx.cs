namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using System.IO;

    public partial class _Admin_lojas_perfis_registro : System.Web.UI.Page
    {
        public Idioma.Loja.Perfil Idioma = new Idioma.Loja.Perfil();

        private decimal minDecimal = decimal.MinValue;
        private string Path;
        public Icon icon;
        public string migalha;

        Random rnd = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            Path = Server.MapPath("~/_img/layout/");
            if (!Directory.Exists(Path)) Directory.CreateDirectory(Path);

            migalha = Resources.Migalha.NovaLoja;

            if (!IsPostBack)
            {
                if (Request["id"] != null)
                    PreencherCampos();
            }
        }

        /// <summary>
        /// Requisita dados do perfil ao banco de dados e preenche o formulário
        /// </summary>
        private void PreencherCampos()
        {
            Entity.Perfil.Loja perfil = new Admin.Perfil.Loja().ConsultarPerfil(Request["id"]);

            // migalha
            migalha = perfil.Nome;

            // geral
            txtNome.Text = perfil.Nome;
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
                Entity.Perfil.Loja perfil = new Entity.Perfil.Loja();
                perfil.Loja_ID = Convert.ToInt32(Request["loja"]);
                perfil.Nome = Nome;

                // altera registro
                if (Request["id"] != null)
                {
                    perfil.IDPerfil = Convert.ToInt32(Request["id"]);

                    Entity.Retorno ret = new Admin.Perfil.Loja().AlterarPerfil(perfil);
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
                    Entity.Retorno ret = new Admin.Perfil.Loja().InserirPerfil(perfil);
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
        }
    }
}