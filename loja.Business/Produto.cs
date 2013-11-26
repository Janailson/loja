using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Business
{
    public class Produto
    {
        #region SELECT

        public List<Entity.Produto> ListarProduto(int IDCategoria, bool Destaque)
        {
            string Sql = "p_Produtos " + IDCategoria + ",'" + Destaque.ToString() + "'";
            return new Data.Produto().Listar(Sql);
        }

        public Entity.Produto ConsultarProduto(object IDProduto)
        {
            string Sql = "SELECT IDProduto, Loja_ID, dbo.f_Idioma(Produto.Loja_ID,'','Produto',Produto.IDProduto,'Nome') as Nome, Marca_ID, (SELECT Nome FROM Marca WHERE IDMarca=Produto.Marca_ID) as Marca, Fornecedor_ID, (SELECT Nome FROM Fornecedor WHERE IDFornecedor=Produto.Fornecedor_ID) as Fornecedor, Codigo, dbo.f_Idioma(Produto.Loja_ID,'','Produto',Produto.IDProduto,'Detalhe') as Detalhe, Destaque, Lancamento, Status, Manual, Video, DataInclusao FROM Produto WHERE IDProduto=" + IDProduto;
            return new Data.Produto().Consultar(Sql);
        }

        #endregion

        public class Imagem
        {
            public List<Entity.Produto.Imagem> ListarImagem(int IDProduto)
            {
                string Sql = "SELECT IDProdutoImagem, Arquivo FROM ProdutoImagem WHERE Produto_ID=" + IDProduto + " ORDER BY Ordem ASC";
                return new Data.Produto.Imagem().Listar(Sql);
            }
        }

        public class Preco
        {
            #region SELECT

            public List<Entity.Produto.Preco> ListarPreco(int IDProduto)
            {
                string Sql = "SELECT IDProdutoPreco, Produto_ID, TipoPessoa_ID, (SELECT Nome FROM loja.TipoPessoa WHERE IDTipoPessoa=ProdutoPreco.TipoPessoa_ID) as TipoPessoa, Valor, Promocao FROM ProdutoPreco WHERE Produto_ID=" + IDProduto;
                return new Data.Produto.Preco().Listar(Sql);
            }

            #endregion
        }
    }
}