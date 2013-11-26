namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Newtonsoft.Json;

    public partial class api_produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string str_lookup = Request["lookup"];
            string str_itens = Request["itens"];
            string str_page = Request["page"];
            string str_shop = Request["shop"];
            string str_filters = Request["filters"];

            if (str_lookup == null || str_lookup == String.Empty)
                throw new Exception("lookup not found");

            if (str_itens == null || str_itens == String.Empty)
                throw new Exception("itens not found");

            if (str_page == null || str_page == String.Empty)
                throw new Exception("page not found");

            if (str_shop == null || str_shop == String.Empty)
                throw new Exception("shop not found");

            int IDCategoria = Convert.ToInt32(str_lookup);
            int IDLoja = Convert.ToInt32(str_shop);
            int Itens = Convert.ToInt32(str_itens);
            int Page = Convert.ToInt32(str_page);

            Root root = new Root();
            List<Rest.Produto> produtos = new List<Rest.Produto>();

            List<Entity.Produto.Vitrine> products = new Business.Produto().ListarProduto(IDLoja, IDCategoria, false);
            for (int i = 0; i < Itens; i++)
            {
                Rest.Produto produto = new Rest.Produto();
                // produto
                produto.nome_produto = products[i].Nome;
                produto.marca = products[i].Marca;
                produto.lojaid = products[i].Loja_ID;
                produto.fornecedor = products[i].Fornecedor;
                produto.lancamento = products[i].Lancamento.ToString();
                produto.manual = products[i].Manual;
                produto.video = products[i].Video;
                // vitrine
                produto.id = products[i].IDVitrine;
                produto.tamanho = products[i].Tamanho;
                produto.cor = products[i].Cor;
                produto.destaque = products[i].Destaque.ToString();
                produto.peso = products[i].Peso;
                produto.largura = products[i].Largura;
                produto.altura = products[i].Altura;
                produto.profundidade = products[i].Profundidade;
                produto.estoque = products[i].Estoque;
                produto.imagens = new List<String>();
                produto.precos = new List<Rest.Produto.Preco>();

                new Business.Produto.Imagem().ListarImagem(products[i].IDVitrine).ForEach(delegate(Entity.Produto.Vitrine.Imagem image)
                {
                    produto.imagens.Add(image.Arquivo);
                });

                new Business.Produto.Preco().ListarPreco(products[i].IDVitrine).ForEach(delegate(Entity.Produto.Vitrine.Preco price)
                {
                    Rest.Produto.Preco preco = new Rest.Produto.Preco();
                    preco.tipo_pessoa = price.TipoPessoa;
                    preco.valor = price.Valor;
                    preco.promocao = price.Promocao;
                    produto.precos.Add(preco);
                });

                produtos.Add(produto);
            }

            root.produtos = produtos;
            root.totals = products.Count;

            Root.Filters filters = new Root.Filters();

            List<Rest.Categoria> categorias = new List<Rest.Categoria>();
            new Business.Categoria().ListarCategoria(IDLoja, IDCategoria).ForEach(delegate(Entity.Categoria category)
            {
                Rest.Categoria categoria = new Rest.Categoria();
                categoria.id = category.IDCategoria;
                categoria.parentId = category.parentId;
                categoria.nome = category.Nome;
                categoria.total_produtos = category.Produtos;
                categorias.Add(categoria);
            });
            filters.categorias = categorias;

            List<Rest.Marca> marcas = new List<Rest.Marca>();
            new Business.Marca().ListarMarca(IDLoja, IDCategoria).ForEach(delegate(Entity.Marca brand)
            {
                Rest.Marca marca = new Rest.Marca();
                marca.id = brand.IDMarca;
                marca.nome = brand.Nome;
                marca.imagem = brand.Logo;
                marcas.Add(marca);
            });
            filters.marcas = marcas;

            List<String> tamanhos = new List<string>();
            new Business.Tamanhos().ListarTamanho(IDLoja, IDCategoria).ForEach(delegate(Entity.Tamanho size)
            {
                tamanhos.Add(size.Nome);
            });
            filters.tamanhos = tamanhos;

            List<String> cores = new List<string>();
            new Business.Cor().ListarCor(IDLoja, IDCategoria).ForEach(delegate(Entity.Cor color)
            {
                cores.Add(color.Nome);
            });
            filters.cores = cores;

            root.filters = filters;

            string json = JsonConvert.SerializeObject(root);
            Response.Write(json);
        }

        public class Root
        {
            public List<Rest.Produto> produtos { get; set; }
            public int totals { get; set; }
            public Root.Filters filters { get; set; }

            public class Filters
            {
                public List<Rest.Categoria> categorias { get; set; }
                public List<Rest.Marca> marcas { get; set; }
                public List<String> tamanhos { get; set; }
                public List<String> cores { get; set; }
            }
        }
    }
}