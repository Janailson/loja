namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class cadastro : Login
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEmail.Text = Request["email"];
                new Util.Estado(ddlEstado);
            }
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            string Tipo = radTipo.SelectedValue;
            string Nome = txtNome.Text.Trim();
            string Sobrenome = txtSobrenome.Text.Trim();
            string Cpf = txtCpf.Text.Trim();
            string Rg = txtRg.Text.Trim();
            string Sexo = radSexo.SelectedValue;
            string Nascimento = txtNascimento.Text.Trim();
            string Telefone1 = txtTelefone1.Text.Trim();
            string Telefone2 = txtTelefone2.Text.Trim();
            string Email = txtEmail.Text.Trim();
            string Senha = txtSenha.Text.Trim();
            string Cep = txtCep.Text.Trim();
            string Endereco = txtEndereco.Text.Trim();
            string Numero = txtNumero.Text.Trim();
            string Complemento = txtComplemento.Text.Trim();
            string Bairro = txtBairro.Text.Trim();
            string Cidade = txtCidade.Text.Trim();
            string Estado = ddlEstado.SelectedValue;
            string Referencia = txtReferencia.Text.Trim();
            bool Validar = true;

            if (Validar)
            {
                Entity.Cliente cliente = new Entity.Cliente();
                cliente.Loja_ID = IDLoja;
                cliente.TipoPessoa_ID = 3;
                cliente.Tipo = Tipo;
                cliente.Nome = Nome;
                cliente.Sobrenome = Sobrenome;
                cliente.Cpf = Cpf.Replace(".", "").Replace("-", "");
                cliente.Rg = Rg;
                cliente.Sexo = Sexo;
                cliente.Nascimento = Convert.ToDateTime(Nascimento);
                cliente.Telefone1 = Telefone1;
                cliente.Telefone2 = Telefone2;
                cliente.Email = Email;
                cliente.Senha = Senha;
                cliente.Cep = Cep.Replace("-", "");
                cliente.Endereco = Endereco;
                cliente.Numero = Numero;
                cliente.Complemento = Complemento;
                cliente.Bairro = Bairro;
                cliente.Cidade = Cidade;
                cliente.Estado = Estado;
                cliente.Referencia = Referencia;

                Entity.Retorno ret = new Business.Cliente().InserirCliente(cliente);
                if (!ret.Status)
                {
                    Response.Write(ret.Erro);
                    return;
                }

                Entity.Cliente.Entrega entrega = new Entity.Cliente.Entrega();
                entrega.Cliente_ID = ret.Identity;
                entrega.Nome = "Principal";
                entrega.Cep = Cep.Replace("-", "");
                entrega.Endereco = Endereco;
                entrega.Numero = Numero;
                entrega.Complemento = Complemento;
                entrega.Bairro = Bairro;
                entrega.Cidade = Cidade;
                entrega.Estado = Estado;
                entrega.Referencia = Referencia;

                ret = new Business.Cliente.Entrega().InserirEntrega(entrega);
                if (!ret.Status)
                {
                    Response.Write(ret.Erro);
                    return;
                }

                toRedirect();
            }
        }
    }
}