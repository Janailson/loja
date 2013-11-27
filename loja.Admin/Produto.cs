using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Admin
{
    public class Produto
    {
        #region SELECT

        public List<Entity.Produto> ListarProduto(int IDLoja)
        {
            string Sql = "SELECT IDProduto, Loja_ID, dbo.f_Idioma(Produto.Loja_ID,'','Produto',Produto.IDProduto,'Nome') as Nome, Marca_ID, (SELECT Nome FROM Marca WHERE IDMarca=Produto.Marca_ID) as Marca, Fornecedor_ID, (SELECT Nome FROM Fornecedor WHERE IDFornecedor=Produto.Fornecedor_ID) as Fornecedor, dbo.f_Idioma(Produto.Loja_ID,'','Produto',Produto.IDProduto,'Detalhe') as Detalhe, Destaque, Lancamento, Status, Manual, Video, DataInclusao FROM Produto WHERE Loja_ID=" + IDLoja;
            return new Data.Produto().Listar(Sql);
        }

        public Entity.Produto ConsultarProduto(object IDProduto)
        {
            string Sql = "SELECT IDProduto, Loja_ID, Marca_ID, Fornecedor_ID, Destaque, Lancamento, Status, Manual, Video, DataInclusao FROM Produto WHERE IDProduto=" + IDProduto;
            return new Data.Produto().Consultar(Sql);
        }

        #endregion

        #region INSERT, UPDATE, DELETE

        public Entity.Retorno InserirProduto(Entity.Produto produto)
        {
            string Sql = "INSERT INTO Produto (Loja_ID,Marca_ID,Fornecedor_ID,Destaque,Lancamento,Status,Manual,Video) VALUES ('" + produto.Loja_ID + "','" + produto.Marca_ID + "','" + produto.Fornecedor_ID + "','" + produto.Destaque + "','" + produto.Lancamento + "','" + produto.Status + "','" + produto.Manual + "','" + produto.Video + "')";
            return new Data.Produto().Inserir(Sql);
        }

        public Entity.Retorno AlterarProduto(Entity.Produto produto)
        {
            string Sql = "UPDATE Produto SET Marca_ID=" + produto.Marca_ID + ", Fornecedor_ID=" + produto.Fornecedor_ID + ", Destaque='" + produto.Destaque + "', Lancamento='" + produto.Lancamento + "', Status='" + produto.Status + "', Video='" + produto.Video + "' WHERE IDProduto=" + produto.IDProduto;
            return new Data.Produto().Alterar(Sql);
        }

        public Entity.Retorno AlterarManual(object IDProduto, string Campo, string Valor)
        {
            string Sql = "UPDATE Produto SET " + Campo + "='" + Valor + "' WHERE IDProduto=" + IDProduto;
            return new Data.Produto().Alterar(Sql);
        }

        public Entity.Retorno ExcluirProduto(object IDProduto)
        {
            string Sql = "DELETE FROM Produto WHERE IDProduto=" + IDProduto;
            return new Data.Produto().Alterar(Sql);
        }

        #endregion

        public class Vitrine
        {
            #region SELECT

            public List<Entity.Produto.Vitrine> ListarVitrine(object IDProduto)
            {
                string Sql = "SELECT IDVitrine, Produto_ID, Tamanho_ID, Cor_ID, Codigo, Peso, Altura, Largura, Profundidade, Estoque, Status, DataInclusao FROM Vitrine WHERE Produto_ID=" + IDProduto;
                return new Data.Produto.Vitrine().Listar(Sql);
            }

            public Entity.Produto.Vitrine ConsultarVitrine(object IDVitrine)
            {
                string Sql = "SELECT IDVitrine, Produto_ID, Tamanho_ID, Cor_ID, Codigo, Peso, Altura, Largura, Profundidade, Estoque, Status, DataInclusao FROM Vitrine WHERE IDVitrine=" + IDVitrine;
                return new Data.Produto.Vitrine().Consultar(Sql);
            }

            #endregion

            #region INSERT, UPDATE, DELETE

            public Entity.Retorno InserirVitrine(Entity.Produto.Vitrine vitrine)
            {
                string Sql = "INSERT INTO Vitrine (Produto_ID,Tamanho_ID,Cor_ID,Codigo,Peso,Altura,Largura,Profundidade,Estoque,Status) VALUES ('" + vitrine.Produto_ID + "','" + vitrine.Tamanho_ID + "','" + vitrine.Cor_ID + "','" + vitrine.Codigo + "','" + vitrine.Peso + "','" + vitrine.Altura + "','" + vitrine.Largura + "','" + vitrine.Profundidade + "','" + vitrine.Estoque + "','" + vitrine.Status + "')";
                return new Data.Produto.Vitrine().Inserir(Sql);
            }

            public Entity.Retorno AlterarVitrine(Entity.Produto.Vitrine vitrine)
            {
                string Sql = "UPDATE Vitrine SET Tamanho_ID=" + vitrine.Tamanho_ID + ", Cor_ID=" + vitrine.Cor_ID + ", Codigo='" + vitrine.Codigo + "', Peso=" + vitrine.Peso.ToString().Replace(",", ".") + ", Altura=" + vitrine.Altura.ToString().Replace(",", ".") + ", Largura=" + vitrine.Largura.ToString().Replace(",", ".") + ", Profundidade=" + vitrine.Profundidade.ToString().Replace(",", ".") + ", Estoque=" + vitrine.Estoque + ", Status='" + vitrine.Status + "' WHERE IDVitrine=" + vitrine.IDVitrine;
                return new Data.Produto.Vitrine().Alterar(Sql);
            }

            public Entity.Retorno ExcluirVitrine(object IDVitrine)
            {
                string Sql = "DELETE FROM Vitrine WHERE IDVitrine=" + IDVitrine;
                return new Data.Produto.Vitrine().Alterar(Sql);
            }

            #endregion

            public class Imagem
            {
                #region INSERT, UPDATE, DELETE

                public Entity.Retorno InserirImagem(Entity.Produto.Vitrine.Imagem imagem)
                {
                    string Sql = "INSERT INTO VitrineImagem (Vitrine_ID,Arquivo,Ordem) VALUES ('" + imagem.Vitrine_ID + "','" + imagem.Arquivo + "','" + imagem.Ordem + "')";
                    return new Data.Produto.Vitrine.Imagem().Inserir(Sql);
                }

                public Entity.Retorno AlterarImagem(Entity.Produto.Vitrine.Imagem imagem)
                {
                    string Sql = "UPDATE VitrineImagem SET Ordem=" + imagem.Ordem + " WHERE IDVitrineImagem=" + imagem.IDVitrineImagem;
                    return new Data.Produto.Vitrine.Imagem().Alterar(Sql);
                }

                public Entity.Retorno ExcluirImagem(object IDVitrineImagem)
                {
                    string Sql = "DELETE FROM VitrineImagem WHERE IDVitrineImagem=" + IDVitrineImagem;
                    return new Data.Produto.Vitrine.Imagem().Alterar(Sql);
                }

                #endregion
            }

            public class Preco
            {
                #region INSERT, UPDATE, DELETE

                public Entity.Retorno InserirPreco(Entity.Produto.Vitrine.Preco preco)
                {
                    string Sql = "INSERT INTO VitrinePreco (Vitrine_ID,TipoPessoa_ID,Valor,Promocao) VALUES ('" + preco.Vitrine_ID + "','" + preco.TipoPessoa_ID + "','" + preco.Valor + "','" + preco.Promocao + "')";
                    return new Data.Produto.Vitrine.Preco().Inserir(Sql);
                }

                public Entity.Retorno AlterarPreco(Entity.Produto.Vitrine.Preco preco)
                {
                    string Sql = "UPDATE VitrinePreco SET Valor=" + preco.Valor.ToString().Replace(",", ".") + "`, Promocao=" + preco.Promocao.ToString().Replace(",", ".") + " WHERE IDVitrinePreco=" + preco.IDVitrinePreco;
                    return new Data.Produto.Vitrine.Preco().Alterar(Sql);
                }

                public Entity.Retorno ExcluirPreco(object IDVitrinePreco)
                {
                    string Sql = "DELETE FROM VitrinePreco WHERE IDVitrinePreco=" + IDVitrinePreco;
                    return new Data.Produto.Vitrine.Preco().Alterar(Sql);
                }

                #endregion
            }
        }
    }
}