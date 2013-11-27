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
        public Icon icon;
        private string Path;

        Random rnd = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            Path = Server.MapPath("~/_img/layout/");
            if (!Directory.Exists(Path)) Directory.CreateDirectory(Path);
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
                    if (Logo != String.Empty)
                        uplLogo.PostedFile.SaveAs(Path + loja.Logo);

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