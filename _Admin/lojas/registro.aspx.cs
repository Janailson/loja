namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using System.IO;

    public partial class _Admin_lojas_registro : System.Web.UI.Page
    {
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

        public void multiidioma()
        {
            new Admin.Idioma().ListarIdioma().ForEach(delegate(Entity.Idioma idioma)
            {
                Response.Write("<label>\n");
                Response.Write("<input type='checkbox' name='chkMultiidioma' value='" + idioma.Codigo + "' />\n");
                Response.Write("<span class='lbl'> " + idioma.Nome + "</span>\n");
                Response.Write("</label>\n");
            });
        }

        /// <summary>
        /// Requisita dados da loja ao banco de dados e preenche o formulário
        /// </summary>
        private void PreencherCampos()
        {
            Entity.Loja loja = new Admin.Loja().ConsultarLoja(Request["id"]);

            // migalha
            migalha = loja.Fantasia;

<<<<<<< HEAD
            // botões
            pnlBotao.Visible = true;

=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
            // geral
            txtFantasia.Text = loja.Fantasia;
            txtRazaoSocial.Text = loja.RazaoSocial;
            txtCnpj.Text = loja.Cnpj;
            txtIe.Text = loja.Ie;
            txtTelefone.Text = loja.Telefone;
            txtEmail.Text = loja.Email;
            new Util.Imagem(imgLogo, hidLogo, "../../_img/layout/", loja.Logo).Carregar();
            ddlCor.Items.FindByValue(loja.Cor).Selected = true;
            txtChat.Text = loja.Chat;
            chkStatus.Checked = loja.Status;
            // idiomas
            chkMultiidioma.Checked = loja.Multiidioma;
            // parcelamento
            txtParcela.Text = loja.Parcela.ToString();
            txtValorMinimo.Text = loja.ValorMinimo.ToString();
            // redes sociais
            txtFacebook.Text = loja.Facebook;
            txtTwitter.Text = loja.Twitter;
            txtGooglePlus.Text = loja.GooglePlus;
        }

        /// <summary>
        /// Ação do botão "salvar"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalvar_ServerClick(object sender, EventArgs e)
        {
            // recupera dados digitado no formulário
            string Fantasia = txtFantasia.Text.Trim().Replace("'", "''");
            string RazaoSocial = txtRazaoSocial.Text.Trim().Replace("'", "''");
            string Cnpj = txtCnpj.Text.Trim().Replace("'", "''");
            string Ie = txtIe.Text.Trim().Replace("'", "''");
            string Telefone = txtTelefone.Text.Trim().Replace("'", "''");
            string Email = txtEmail.Text.Trim().Replace("'", "''");
            string Logo = uplLogo.FileName;
            bool Multiidioma = chkMultiidioma.Checked;
            string Cor = ddlCor.SelectedValue;
            string Parcela = txtParcela.Text.Trim().Replace("'", "''");
            string ValorMinimo = txtValorMinimo.Text.Trim().Replace("'", "''");
            string Facebook = txtFacebook.Text.Trim().Replace("'", "''");
            string Twitter = txtTwitter.Text.Trim().Replace("'", "''");
            string GooglePlus = txtGooglePlus.Text.Trim().Replace("'", "''");
            string Chat = txtChat.Text.Trim().Replace("'", "''");
            bool Status = chkStatus.Checked;
            bool Validar = true;

            // limpa mensagens de erro
            LimparLabel();

            // verifica consistência do formulário
            if (Fantasia == String.Empty)
            {
                Validar = false;
                new Constante().input_error(pnlFantasia, lblFantasia, "campo obrigatório");
            }
            if (Cnpj == String.Empty)
            {
                Validar = false;
                new Constante().input_error(pnlCnpj, lblCnpj, "campo obrigatório");
            }
            if (Cnpj != String.Empty && !new Validacao().Cnpj(Cnpj))
            {
                Validar = false;
                new Constante().input_error(pnlCnpj, lblCnpj, "cnpj inválido");
            }
            if (Telefone == String.Empty)
            {
                Validar = false;
                new Constante().input_error(pnlTelefone, lblTelefone, "campo obrigatório");
            }
            if (Email == String.Empty)
            {
                Validar = false;
                new Constante().input_error(pnlEmail, lblEmail, "campo obrigatório");
            }
            if (Email != String.Empty && !new Validacao().Email(Email))
            {
                Validar = false;
                new Constante().input_error(pnlEmail, lblEmail, "e-mail inválido");
            }
            if (Request["id"] == null && Logo == String.Empty)
            {
                Validar = false;
                new Constante().input_error(pnlLogo, lblLogo, "campo obrigatório");
            }
            if (Request["id"] == null && Logo == String.Empty)
            {
                Validar = false;
                new Constante().input_error(pnlLogo, lblLogo, "campo obrigatório");
            }
            if (Logo != String.Empty && !new Validacao().Imagem(Logo))
            {
                Validar = false;
                new Constante().input_error(pnlLogo, lblLogo, "arquivo inválido");
            }
            if (ValorMinimo == String.Empty)
            {
                Validar = false;
                new Constante().input_error(pnlValorMinimo, lblValorMinimo, "campo obrigatório");
            }
            if (ValorMinimo != String.Empty && !decimal.TryParse(ValorMinimo, out minDecimal))
            {
                Validar = false;
                new Constante().input_error(pnlValorMinimo, lblValorMinimo, "valor inválido");
            }
            if (ValorMinimo != String.Empty && decimal.TryParse(ValorMinimo, out minDecimal) && Convert.ToDecimal(ValorMinimo) < 0)
            {
                Validar = false;
                new Constante().input_error(pnlValorMinimo, lblValorMinimo, "valor não pode ser inferior a 0");
            }

            // formulário validado
            if (Validar)
            {
                // instância objeto
                Entity.Loja loja = new Entity.Loja();
                loja.Fantasia = Fantasia;
                loja.RazaoSocial = RazaoSocial;
                loja.Cnpj = Cnpj;
                loja.Ie = Ie;
                loja.Telefone = Telefone;
                loja.Email = Email;
                loja.Logo = (Logo != String.Empty) ? "logo_" + rnd.Next(0, 99999).ToString("d5") + Logo.Remove(0, Logo.LastIndexOf(".")) : "";
                loja.Multiidioma = Multiidioma;
                loja.Cor = Cor;
                loja.Parcela = Convert.ToInt32(Parcela);
                loja.ValorMinimo = Convert.ToDecimal(ValorMinimo);
                loja.Facebook = Facebook;
                loja.Twitter = Twitter;
                loja.GooglePlus = GooglePlus;
                loja.Chat = Chat;
                loja.Status = Status;

                // altera registro
                if (Request["id"] != null)
                {
                    loja.IDLoja = Convert.ToInt32(Request["id"]);

                    Entity.Retorno ret = new Admin.Loja().AlterarLoja(loja);
                    if (!ret.Status)
                    {
                        // exibe mensagem de erro
                        icon = Icon.remove;
                        new Constante().label_message(pnlMsg, Alert.error, labMsg, ret.Erro);
                        return;
                    }

                    // envia logo para o servidor
                    if (loja.Logo != String.Empty)
                    {
                        new Util.Imagem(uplLogo, hidLogo, Path, loja.Logo).Upload();
                        new Admin.Loja().AlterarLogo(loja);
                    }

                    // idiomas
                    GravarIdioma(loja.IDLoja);

                    // mensagem de sucesso
                    icon = Icon.ok;
                    new Constante().label_message(pnlMsg, Alert.success, labMsg, "Dados alterado com sucesso.");
                    PreencherCampos();
                }
                // adiciona novo registro
                else
                {
                    Entity.Retorno ret = new Admin.Loja().InserirLoja(loja);
                    if (!ret.Status)
                    {
                        // exibe mensagem de erro
                        icon = Icon.remove;
                        new Constante().label_message(pnlMsg, Alert.error, labMsg, ret.Erro);
                        return;
                    }

                    // envia logo para o servidor
                    new Util.Imagem(uplLogo, Path, loja.Logo).Upload();

                    // idiomas
                    GravarIdioma(ret.Identity);

                    // mensagem de sucesso
                    icon = Icon.ok;
                    new Constante().label_message(pnlMsg, Alert.success, labMsg, "Cadastro realizado com sucesso.");
                    LimparCampos();
                }
            }
        }

        /// <summary>
        /// Armazena idiomas selecionados
        /// </summary>
        /// <param name="IDLoja"></param>
        private void GravarIdioma(object IDLoja)
        {
            new Admin.Loja.Idioma().ExcluirIdioma(IDLoja);
            if (!chkMultiidioma.Checked)
            {
                // somente português
                new Admin.Loja.Idioma().InserirIdioma(IDLoja, 1);
            }
            else
            {
                // definido pelo administrador
                if (Request.Form["chkMultiidioma"] != null)
                {
                    string[] Idiomas = Request.Form["chkMultiidioma"].Split(',');
                    foreach (string IDIdioma in Idiomas)
                        new Admin.Loja.Idioma().InserirIdioma(IDLoja, IDIdioma);
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

            new Constante().input_error(pnlFantasia, lblFantasia);
            new Constante().input_error(pnlRazaoSocial, lblRazaoSocial);
            new Constante().input_error(pnlCnpj, lblCnpj);
            new Constante().input_error(pnlTelefone, lblTelefone);
            new Constante().input_error(pnlEmail, lblEmail);
            new Constante().input_error(pnlLogo, lblLogo);
            new Constante().input_error(pnlCor, lblCor);
            new Constante().input_error(pnlValorMinimo, lblValorMinimo);
        }

        /// <summary>
        /// Limpa os campos para um novo registro
        /// </summary>
        private void LimparCampos()
        {
            txtFantasia.Text = "";
            txtRazaoSocial.Text = "";
            txtCnpj.Text = "";
            txtIe.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            ddlCor.ClearSelection();
            txtChat.Text = "";
            chkStatus.Checked = true;
            chkMultiidioma.Checked = false;
            txtParcela.Text = "1";
            txtValorMinimo.Text = "0";
            txtFacebook.Text = "";
            txtTwitter.Text = "";
            txtGooglePlus.Text = "";
        }
    }
}