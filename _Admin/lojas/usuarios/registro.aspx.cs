namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using System.IO;

    public partial class _Admin_lojas_usuarios_registro : System.Web.UI.Page
    {
        public Idioma.Migalha.Loja.Usuario Migalha = new Idioma.Migalha.Loja.Usuario();
        public Idioma.Loja.Usuario Idioma = new Idioma.Loja.Usuario();

        private decimal minDecimal = decimal.MinValue;
        private string Path;
        public Icon icon;
        public string migalha;

        Random rnd = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            Path = Server.MapPath("~/_img/layout/");
            if (!Directory.Exists(Path)) Directory.CreateDirectory(Path);

            migalha = Migalha.NovoUsuario;

            if (!IsPostBack)
            {
                perfis();
                if (Request["id"] != null)
                    PreencherCampos();
            }
        }


        /// <summary>
        /// Preenche lista de perfis cadastrado para essa loja
        /// </summary>
        private void perfis()
        {
            ddlPerfil.Items.Clear();
            ddlPerfil.Items.Add("");

            new Admin.Perfil.Loja().ListarPerfil(Convert.ToInt32(Request["loja"])).ForEach(delegate(Entity.Perfil.Loja perfil)
            {
                ddlPerfil.Items.Add(new ListItem(perfil.Nome, perfil.IDPerfil.ToString()));
            });
        }

        /// <summary>
        /// Requisita dados do usuário ao banco de dados e preenche o formulário
        /// </summary>
        private void PreencherCampos()
        {
            Entity.Usuario.Loja usuario = new Admin.Usuario.Loja().ConsultarUsuario(Request["id"]);

            // migalha
            migalha = usuario.Nome;

            // geral
            ddlPerfil.Items.FindByValue(usuario.Perfil_ID.ToString()).Selected = true;
            txtNome.Text = usuario.Nome;
            txtLogin.Text = usuario.Login;
            txtSenha.Text = usuario.Senha;
        }

        /// <summary>
        /// Ação do botão "salvar"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalvar_ServerClick(object sender, EventArgs e)
        {
            // recupera dados digitado no formulário
            string Perfil = ddlPerfil.SelectedValue;
            string Nome = txtNome.Text.Trim().Replace("'", "''");
            string Login = txtLogin.Text.Trim().Replace("'", "''");
            string Senha = txtSenha.Text.Trim().Replace("'", "''");
            bool Validar = true;

            // limpa mensagens de erro
            LimparLabel();

            // verifica consistência do formulário
            if (ddlPerfil.SelectedIndex==0)
            {
                Validar = false;
                new Constante().input_error(pnlPerfil, lblPerfil, "escolha o perfil");
            }
            if (Nome == String.Empty)
            {
                Validar = false;
                new Constante().input_error(pnlNome, lblNome, "campo obrigatório");
            }
            if (Login == String.Empty)
            {
                Validar = false;
                new Constante().input_error(pnlLogin, lblLogin, "campo obrigatório");
            }
            if (Senha == String.Empty)
            {
                Validar = false;
                new Constante().input_error(pnlSenha, lblSenha, "campo obrigatório");
            }

            // formulário validado
            if (Validar)
            {
                // instância objeto
                Entity.Usuario.Loja usuario = new Entity.Usuario.Loja();
                usuario.Perfil_ID = Convert.ToInt32(Perfil);
                usuario.Nome = Nome;
                usuario.Login = Login;
                usuario.Senha = Senha;

                // altera registro
                if (Request["id"] != null)
                {
                    usuario.IDUsuario = Convert.ToInt32(Request["id"]);

                    Entity.Retorno ret = new Admin.Usuario.Loja().AlterarUsuario(usuario);
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
                    Entity.Retorno ret = new Admin.Usuario.Loja().InserirUsuario(usuario);
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

            new Constante().input_error(pnlPerfil, lblPerfil);
            new Constante().input_error(pnlNome, lblNome);
            new Constante().input_error(pnlLogin, lblLogin);
            new Constante().input_error(pnlSenha, lblSenha);
        }

        /// <summary>
        /// Limpa os campos para um novo registro
        /// </summary>
        private void LimparCampos()
        {
            ddlPerfil.ClearSelection();
            txtNome.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
        }
    }
}