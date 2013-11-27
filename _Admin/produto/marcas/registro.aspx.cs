namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class _Admin_produto_marcas_registro : System.Web.UI.Page
    {
        public Idioma.Migalha.Marca Migalha = new Idioma.Migalha.Marca();
        public Idioma.Marca Idioma = new Idioma.Marca();

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

            // caminho das imagens
            Path = Server.MapPath("~/_img/marca/");

            // migalha
            migalha = Migalha.NovaMarca;

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
        /// Requisita dados da Marca ao banco de dados e preenche o formulário
        /// </summary>
        private void PreencherCampos()
        {
            Entity.Marca marca = new Admin.Marca().ConsultarMarca(Request["id"]);

            // migalha
            migalha = marca.Nome;

            // geral
            txtNome.Text = marca.Nome;
            new Util.Imagem(imgLogo, hidLogo, "../../../_img/marca/", marca.Logo).Carregar();
            chkStatus.Checked = marca.Status;
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
            string Logo = uplLogo.FileName;
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
            if (Request["id"] == null && Logo == String.Empty)
            {
                Validar = false;
                new Constante().input_error(pnlLogo, lblLogo, "campo obrigatório");
            }
            if (Logo != String.Empty && !new Validacao().Imagem(Logo))
            {
                Validar = false;
                new Constante().input_error(pnlLogo, lblLogo, "imagem inválida");
            }

            // formulário validado
            if (Validar)
            {
                // instância objeto
                Entity.Marca marca = new Entity.Marca();
                marca.Loja_ID = objUsuario.Loja_ID;
                marca.Nome = Nome;
                marca.Logo = (Logo != String.Empty) ? rnd.Next(100000, 999999) + Logo.Remove(0, Logo.LastIndexOf(".")) : "";
                marca.Status = Status;

                // altera registro
                if (Request["id"] != null)
                {
                    marca.IDMarca = Convert.ToInt32(Request["id"]);

                    Entity.Retorno ret = new Admin.Marca().AlterarMarca(marca);
                    if (!ret.Status)
                    {
                        // exibe mensagem de erro
                        icon = Icon.remove;
                        new Constante().label_message(pnlMsg, Alert.error, labMsg, ret.Erro);
                        return;
                    }

                    // envia o logo
                    if (Logo != String.Empty)
                    {
                        new Util.Imagem(uplLogo, hidLogo, Path, marca.Logo).Upload();
                        new Admin.Marca().AlterarLogo(marca.IDMarca, "Logo", marca.Logo);
                    }

                    // mensagem de sucesso
                    icon = Icon.ok;
                    new Constante().label_message(pnlMsg, Alert.success, labMsg, "Dados alterado com sucesso.");
                    PreencherCampos();
                }
                // adiciona novo registro
                else
                {
                    Entity.Retorno ret = new Admin.Marca().InserirMarca(marca);
                    if (!ret.Status)
                    {
                        // exibe mensagem de erro
                        icon = Icon.remove;
                        new Constante().label_message(pnlMsg, Alert.error, labMsg, ret.Erro);
                        return;
                    }

                    // envia logo
                    if (Logo != String.Empty)
                        new Util.Imagem(uplLogo, Path, marca.Logo).Upload();

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
            new Constante().input_error(pnlLogo, lblLogo);
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