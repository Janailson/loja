namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Collections;

    public partial class _Admin_produto_produtos_registro : System.Web.UI.Page
    {
        public Idioma.Migalha.Produto Migalha = new Idioma.Migalha.Produto();
        public Idioma.Produto Idioma = new Idioma.Produto();

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
            Path = Server.MapPath("~/_arquivos/produto/");

            // migalha
            migalha = Migalha.NovoProduto;

            // recupera dados do usuário
            objUsuario = (Entity.Usuario.Loja)Session[Constante.ADMLoja];
            objLoja = new Admin.Loja().ConsultarLoja(objUsuario.Loja_ID);

            // idiomas
            imgNome.ImageUrl = "~/_Admin/assets/icons/" + objLoja.Idiomas[0].Codigo + ".png";
            imgNome.Attributes.Add("title", objLoja.Idiomas[0].Nome);

            if (!IsPostBack)
            {
                marcas();
                fornecedores();
<<<<<<< HEAD
                cores();
                categorias();
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
                if (Request["id"] != null)
                    PreencherCampos();
            }
        }

        /// <summary>
        /// Preenche Dropdown com as marcas cadastradas
        /// </summary>
        private void marcas()
        {
            ddlMarca.Items.Clear();
            ddlMarca.Items.Add(new ListItem("", "0"));
            new Admin.Marca().ListarMarca(objLoja.IDLoja).ForEach(delegate(Entity.Marca marca)
            {
                ddlMarca.Items.Add(new ListItem(marca.Nome, marca.IDMarca.ToString()));
            });
        }

        /// <summary>
        /// Preenche Dropdown com os fornecedores cadastrados
        /// </summary>
        private void fornecedores()
        {
            ddlFornecedor.Items.Clear();
            ddlFornecedor.Items.Add(new ListItem("", "0"));
            new Admin.Fornecedor().ListarFornecedor(objLoja.IDLoja).ForEach(delegate(Entity.Fornecedor fornecedor)
            {
                ddlFornecedor.Items.Add(new ListItem(fornecedor.Nome, fornecedor.IDFornecedor.ToString()));
            });
        }

        /// <summary>
<<<<<<< HEAD
        /// Preenche Dropdown com as cores cadastradas
        /// </summary>
        private void cores()
        {
            ddlCor.Items.Clear();
            ddlCor.Items.Add(new ListItem("", "0"));
            new Admin.Cor().ListarCor(objLoja.IDLoja).ForEach(delegate(Entity.Cor cor)
            {
                ddlCor.Items.Add(new ListItem(cor.Nome, cor.IDCor.ToString()));
            });
        }

        /// <summary>
        /// Preenche Dropdown com as categorias cadastradas
        /// </summary>
        private void categorias()
        {
            ddlCategoria.Items.Clear();
            ddlCategoria.Items.Add(new ListItem("", "0"));
            new Admin.Categoria().ListarCategoria(objLoja.IDLoja).ForEach(delegate(Entity.Categoria categoria)
            {
                ddlCategoria.Items.Add(new ListItem(categoria.Nome, categoria.IDCategoria.ToString()));
            });
        }

        /// <summary>
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
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
        /// Cria link para editor de texto para cada idioma adicional
        /// </summary>
        /// <param name="Campo"></param>
        public void editortexto(string Campo)
        {
            ArrayList arr = new ArrayList();
            arr.Add("");
            arr.Add("");

            if (Session[Constante.ADMProduto] != null) arr = (ArrayList)Session[Constante.ADMProduto];

            for (int i = 0; i < objLoja.Idiomas.Count; i++)
            {
<<<<<<< HEAD
                if (Request["id"] != null)
                    arr[i] = PreencherIdioma("Detalhe", objLoja.Idiomas[i].IDIdioma);

=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
                Response.Write("<div class='controls' style='border: solid #ccc 1px; padding: 5px; margin-bottom: 10px; background-color: #fee'>\n");
                Response.Write("<p><img src='../../assets/icons/" + objLoja.Idiomas[i].Codigo + ".png' alt='' title='" + objLoja.Idiomas[i].Nome + "' /></p>\n");
                Response.Write("<div style='height: 180px; overflow: auto; background-color: #fff'>" + arr[i] + "</div>\n");
                Response.Write("<p><a href='editor.aspx?n=" + i + "' class='_modal'>[editar]</a></p>\n");
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
                Entity.Produto produto = new Admin.Produto().ConsultarProduto(Request["id"]);
                switch (Campo)
                {
                    case "Nome":
                        Entity.Dicionario nome = produto.Dicionarios.Find(delegate(Entity.Dicionario p1) { return (p1.Idioma_ID == Id && p1.Descricao == "Nome"); });
                        return nome.Valor;
<<<<<<< HEAD
                    case "Detalhe":
                        Entity.Dicionario detalhe = produto.Dicionarios.Find(delegate(Entity.Dicionario p1) { return (p1.Idioma_ID == Id && p1.Descricao == "Detalhe"); });
                        if (detalhe == null || detalhe.Valor == null) return "";
                        return detalhe.Valor;
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
                }
            }

            return "";
        }

        /// <summary>
        /// Requisita dados do Produto ao banco de dados e preenche o formulário
        /// </summary>
        private void PreencherCampos()
        {
            Entity.Produto produto = new Admin.Produto().ConsultarProduto(Request["id"]);

            // dicionario
            List<Entity.Dicionario> nomes = produto.Dicionarios.FindAll(delegate(Entity.Dicionario p1) { return (p1.Descricao == "Nome"); });

            // migalha
            migalha = nomes[0].Valor;

            // geral
            txtNome.Text = nomes[0].Valor;
            ddlMarca.Items.FindByValue(produto.Marca_ID.ToString()).Selected = true;
<<<<<<< HEAD
            ddlFornecedor.Items.FindByValue(produto.Fornecedor_ID.ToString()).Selected = true;
            ddlCor.Items.FindByValue(produto.Cor_ID.ToString()).Selected = true;
            txtCodigo.Text = produto.Codigo;

            chkDestaque.Checked = produto.Destaque;
            chkLancamento.Checked = produto.Lancamento;
            chkStatus.Checked = produto.Status;
            txtVideo.Text = produto.Video;

            // painéis vitrine, características, específicações do produto e comentários
            pnl.Visible = true;
=======
            chkStatus.Checked = produto.Status;
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
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
            string Marca = ddlMarca.SelectedValue;
            string Fornecedor = ddlFornecedor.SelectedValue;
<<<<<<< HEAD
            string Cor = ddlCor.SelectedValue;
            string Codigo = txtCodigo.Text.Trim().Replace("'", "''");
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
            bool Destaque = chkDestaque.Checked;
            bool Lancamento = chkLancamento.Checked;
            bool Status = chkStatus.Checked;
            string Manual = uplManual.FileName;
            string Video = txtVideo.Text.Trim().Replace("'", "''");
            bool Validar = true;

            // limpa mensagens de erro
            LimparLabel();

            // verifica consistência do formulário
            if (Nome == String.Empty || !ValidaCampo("Nome"))
            {
                Validar = false;
                new Constante().input_error(pnlNome, lblNome, "campo obrigatório");
            }
            if (ddlMarca.SelectedIndex == 0)
            {
                Validar = false;
                new Constante().input_error(pnlMarca, lblMarca, "selecione a marca");
            }

            // formulário validado
            if (Validar)
            {
                // instância objeto
                Entity.Produto produto = new Entity.Produto();
                produto.Loja_ID = objUsuario.Loja_ID;
                produto.Marca_ID = Convert.ToInt32(Marca);
                produto.Fornecedor_ID = Convert.ToInt32(Fornecedor);
<<<<<<< HEAD
                produto.Cor_ID = Convert.ToInt32(Cor);
                produto.Codigo = Codigo;
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
                produto.Destaque = Destaque;
                produto.Lancamento = Lancamento;
                produto.Status = Status;
                produto.Manual = (Manual != String.Empty) ? "manual_" + rnd.Next(0, 999999).ToString("d6") + Manual.Remove(0, Manual.LastIndexOf(".")) : "";
                produto.Video = Video;

                // altera registro
                if (Request["id"] != null)
                {
                    produto.IDProduto = Convert.ToInt32(Request["id"]);

                    Entity.Retorno ret = new Admin.Produto().AlterarProduto(produto);
                    if (!ret.Status)
                    {
                        // exibe mensagem de erro
                        icon = Icon.remove;
                        new Constante().label_message(pnlMsg, Alert.error, labMsg, ret.Erro);
                        return;
                    }

                    // altera dicionário de palavras
                    new Admin.Dicionario().AlterarDicionario(new Entity.Dicionario(objLoja.Idiomas[0].IDIdioma, "Produto", produto.IDProduto, "Nome", Nome));
                    for (int i = 1; i < objLoja.Idiomas.Count; i++)
                    {
                        // nome
                        new Admin.Dicionario().AlterarDicionario(new Entity.Dicionario(objLoja.Idiomas[i].IDIdioma, "Produto", produto.IDProduto, "Nome", Request.Form["txtNome" + objLoja.Idiomas[i].IDIdioma]));
                    }

                    // mensagem de sucesso
                    icon = Icon.ok;
                    new Constante().label_message(pnlMsg, Alert.success, labMsg, "Dados alterado com sucesso.");
                    PreencherCampos();
                }
                // adiciona novo registro
                else
                {
                    Entity.Retorno ret = new Admin.Produto().InserirProduto(produto);
                    if (!ret.Status)
                    {
                        // exibe mensagem de erro
                        icon = Icon.remove;
                        new Constante().label_message(pnlMsg, Alert.error, labMsg, ret.Erro);
                        return;
                    }

                    // adiciona dicionário de palavras
                    new Admin.Dicionario().InserirDicionario(new Entity.Dicionario(objLoja.Idiomas[0].IDIdioma, "Produto", ret.Identity, "Nome", Nome));
                    for (int i = 1; i < objLoja.Idiomas.Count; i++)
                    {
                        // nome
                        new Admin.Dicionario().InserirDicionario(new Entity.Dicionario(objLoja.Idiomas[i].IDIdioma, "Produto", ret.Identity, "Nome", Request.Form["txtNome" + objLoja.Idiomas[i].IDIdioma]));
                    }
                    ArrayList arr = (ArrayList)Session[Constante.ADMProduto];
                    for (int i = 0; i < objLoja.Idiomas.Count; i++)
                    {
                        // detalhes do produto
                        new Admin.Dicionario().InserirDicionario(new Entity.Dicionario(objLoja.Idiomas[i].IDIdioma, "Produto", ret.Identity, "Detalhe", arr[i].ToString()));
                    }

                    // mensagem de sucesso
                    icon = Icon.ok;
                    new Constante().label_message(pnlMsg, Alert.success, labMsg, "Cadastro realizado com sucesso.");
                    LimparCampos();
<<<<<<< HEAD
                    Response.Redirect("registro.aspx?id=" + ret.Identity);
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
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
<<<<<<< HEAD
            new Constante().input_error(pnlMarca, lblMarca);
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
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