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
<<<<<<< HEAD
            string Sql = "SELECT IDProduto, Loja_ID, dbo.f_Idioma(Produto.Loja_ID,'','Produto',Produto.IDProduto,'Nome') as Nome, Marca_ID, (SELECT Nome FROM Marca WHERE IDMarca=Produto.Marca_ID) as Marca, Fornecedor_ID, (SELECT Nome FROM Fornecedor WHERE IDFornecedor=Produto.Fornecedor_ID) as Fornecedor, dbo.f_Idioma(Produto.Loja_ID,'','Produto',Produto.IDProduto,'Detalhe') as Detalhe, Lancamento, Status, Manual, Video, DataInclusao FROM Produto WHERE Loja_ID=" + IDLoja;
=======
            string Sql = "SELECT IDProduto, Loja_ID, dbo.f_Idioma(Produto.Loja_ID,'','Produto',Produto.IDProduto,'Nome') as Nome, Marca_ID, (SELECT Nome FROM Marca WHERE IDMarca=Produto.Marca_ID) as Marca, Fornecedor_ID, (SELECT Nome FROM Fornecedor WHERE IDFornecedor=Produto.Fornecedor_ID) as Fornecedor, dbo.f_Idioma(Produto.Loja_ID,'','Produto',Produto.IDProduto,'Detalhe') as Detalhe, Destaque, Lancamento, Status, Manual, Video, DataInclusao FROM Produto WHERE Loja_ID=" + IDLoja;
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
            return new Data.Produto().Listar(Sql);
        }

        public Entity.Produto ConsultarProduto(object IDProduto)
        {
<<<<<<< HEAD
            string Sql = "SELECT IDProduto, Loja_ID, dbo.f_Idioma(Produto.Loja_ID,'','Produto',Produto.IDProduto,'Nome') as Nome, Marca_ID, Fornecedor_ID, Cor_ID, Codigo, Destaque, Lancamento, Status, Manual, Video, DataInclusao FROM Produto WHERE IDProduto=" + IDProduto;
=======
            string Sql = "SELECT IDProduto, Loja_ID, Marca_ID, Fornecedor_ID, Destaque, Lancamento, Status, Manual, Video, DataInclusao FROM Produto WHERE IDProduto=" + IDProduto;
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
            return new Data.Produto().Consultar(Sql);
        }

        #endregion

        #region INSERT, UPDATE, DELETE

        public Entity.Retorno InserirProduto(Entity.Produto produto)
        {
<<<<<<< HEAD
            string Sql = "INSERT INTO Produto (Loja_ID,Marca_ID,Fornecedor_ID,Cor_ID,Codigo,Destaque,Lancamento,Status,Manual,Video) VALUES ('" + produto.Loja_ID + "','" + produto.Marca_ID + "','" + produto.Fornecedor_ID + "','" + produto.Cor_ID + "','" + produto.Codigo + "','" + produto.Destaque + "','" + produto.Lancamento + "','" + produto.Status + "','" + produto.Manual + "','" + produto.Video + "')";
=======
            string Sql = "INSERT INTO Produto (Loja_ID,Marca_ID,Fornecedor_ID,Destaque,Lancamento,Status,Manual,Video) VALUES ('" + produto.Loja_ID + "','" + produto.Marca_ID + "','" + produto.Fornecedor_ID + "','" + produto.Destaque + "','" + produto.Lancamento + "','" + produto.Status + "','" + produto.Manual + "','" + produto.Video + "')";
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
            return new Data.Produto().Inserir(Sql);
        }

        public Entity.Retorno AlterarProduto(Entity.Produto produto)
        {
<<<<<<< HEAD
            string Sql = "UPDATE Produto SET Marca_ID=" + produto.Marca_ID + ", Fornecedor_ID=" + produto.Fornecedor_ID + ", Lancamento='" + produto.Lancamento + "', Status='" + produto.Status + "', Video='" + produto.Video + "' WHERE IDProduto=" + produto.IDProduto;
=======
            string Sql = "UPDATE Produto SET Marca_ID=" + produto.Marca_ID + ", Fornecedor_ID=" + produto.Fornecedor_ID + ", Destaque='" + produto.Destaque + "', Lancamento='" + produto.Lancamento + "', Status='" + produto.Status + "', Video='" + produto.Video + "' WHERE IDProduto=" + produto.IDProduto;
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
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
<<<<<<< HEAD

        public class Vitrine
        {
            #region SELECT

            public List<Entity.Produto.Vitrine> ListarVitrine(object IDProduto)
            {
                string Sql = "SELECT IDVitrine, Produto_ID, Tamanho_ID, Peso, Altura, Largura, Profundidade, Estoque, Status, DataInclusao FROM Vitrine WHERE Produto_ID=" + IDProduto;
                return new Data.Produto.Vitrine().Listar(Sql);
            }

            public Entity.Produto.Vitrine ConsultarVitrine(object IDVitrine)
            {
                string Sql = "SELECT IDVitrine, Produto_ID, Tamanho_ID, Peso, Altura, Largura, Profundidade, Estoque, Status, DataInclusao FROM Vitrine WHERE IDVitrine=" + IDVitrine;
                return new Data.Produto.Vitrine().Consultar(Sql);
            }

            #endregion

            #region INSERT, UPDATE, DELETE

            public Entity.Retorno InserirVitrine(Entity.Produto.Vitrine vitrine)
            {
                string Sql = "INSERT INTO Vitrine (Produto_ID,Tamanho_ID,Peso,Altura,Largura,Profundidade,Estoque,Status) VALUES ('" + vitrine.Produto_ID + "','" + vitrine.Tamanho_ID + "','" + vitrine.Peso + "','" + vitrine.Altura + "','" + vitrine.Largura + "','" + vitrine.Profundidade + "','" + vitrine.Estoque + "','" + vitrine.Status + "')";
                return new Data.Produto.Vitrine().Inserir(Sql);
            }

            public Entity.Retorno AlterarVitrine(Entity.Produto.Vitrine vitrine)
            {
                string Sql = "UPDATE Vitrine SET Tamanho_ID=" + vitrine.Tamanho_ID + ", Peso=" + vitrine.Peso.ToString().Replace(",", ".") + ", Altura=" + vitrine.Altura.ToString().Replace(",", ".") + ", Largura=" + vitrine.Largura.ToString().Replace(",", ".") + ", Profundidade=" + vitrine.Profundidade.ToString().Replace(",", ".") + ", Estoque=" + vitrine.Estoque + ", Status='" + vitrine.Status + "' WHERE IDVitrine=" + vitrine.IDVitrine;
                return new Data.Produto.Vitrine().Alterar(Sql);
            }

            public Entity.Retorno ExcluirVitrine(object IDVitrine)
            {
                string Sql = "DELETE FROM Vitrine WHERE IDVitrine=" + IDVitrine;
                return new Data.Produto.Vitrine().Alterar(Sql);
            }

            #endregion
        }

        public class Caracteristica
        {
            #region SELECT

            public List<Entity.Produto.Caracteristica> ListarCaracteristica(object IDProduto)
            {
                string Sql = "SELECT IDCaracteristica, Produto_ID, Nome, Valor, Filtro FROM Caracteristica WHERE Produto_ID=" + IDProduto;
                return new Data.Produto.Caracteristica().Listar(Sql);
            }

            public Entity.Produto.Caracteristica ConsultarCaracteristica(object IDCaracteristica)
            {
                string Sql = "SELECT IDCaracteristica, Produto_ID, Nome, Valor, Filtro FROM Caracteristica WHERE IDCaracteristica=" + IDCaracteristica;
                return new Data.Produto.Caracteristica().Consultar(Sql);
            }

            #endregion

            #region INSERT, UPDATE, DELETE

            public Entity.Retorno InserirCaracteristica(Entity.Produto.Caracteristica caracteristica)
            {
                string Sql = "INSERT INTO Caracteristica (Produto_ID,Nome,Valor,Filtro) VALUES ('" + caracteristica.Produto_ID + "','" + caracteristica.Nome + "','" + caracteristica.Valor + "','" + caracteristica.Filtro + "')";
                return new Data.Produto.Caracteristica().Inserir(Sql);
            }

            public Entity.Retorno AlterarCaracteristica(Entity.Produto.Caracteristica caracteristica)
            {
                string Sql = "UPDATE Caracteristica SET Nome='" + caracteristica.Nome + "', Valor='" + caracteristica.Valor + "', Filtro='" + caracteristica.Filtro + "' WHERE IDCaracteristica=" + caracteristica.IDCaracteristica;
                return new Data.Produto.Caracteristica().Alterar(Sql);
            }

            public Entity.Retorno ExcluirCaracteristica(object IDCaracteristica)
            {
                string Sql = "DELETE FROM Caracteristica WHERE IDCaracteristica=" + IDCaracteristica;
                return new Data.Produto.Caracteristica().Alterar(Sql);
            }

            #endregion
        }

        public class Especificacao
        {
            #region SELECT

            public List<Entity.Produto.Especificacao> ListarEspecificacao(object IDProduto)
            {
                string Sql = "SELECT IDEspecificacao, Produto_ID, Nome, Valor, Filtro FROM Especificacao WHERE Produto_ID=" + IDProduto;
                return new Data.Produto.Especificacao().Listar(Sql);
            }

            public Entity.Produto.Especificacao ConsultarEspecificacao(object IDEspecificacao)
            {
                string Sql = "SELECT IDEspecificacao, Produto_ID, Nome, Valor, Filtro FROM Especificacao WHERE IDEspecificacao=" + IDEspecificacao;
                return new Data.Produto.Especificacao().Consultar(Sql);
            }

            #endregion

            #region INSERT, UPDATE, DELETE

            public Entity.Retorno InserirEspecificacao(Entity.Produto.Especificacao especificacao)
            {
                string Sql = "INSERT INTO Especificacao (Produto_ID,Nome,Valor,Filtro) VALUES ('" + especificacao.Produto_ID + "','" + especificacao.Nome + "','" + especificacao.Valor + "','" + especificacao.Filtro + "')";
                return new Data.Produto.Especificacao().Inserir(Sql);
            }

            public Entity.Retorno AlterarEspecificacao(Entity.Produto.Especificacao especificacao)
            {
                string Sql = "UPDATE Especificacao SET Nome='" + especificacao.Nome + "', Valor='" + especificacao.Valor + "', Filtro='" + especificacao.Filtro + "' WHERE IDEspecificacao=" + especificacao.IDEspecificacao;
                return new Data.Produto.Especificacao().Alterar(Sql);
            }

            public Entity.Retorno ExcluirEspecificacao(object IDEspecificacao)
            {
                string Sql = "DELETE FROM Especificacao WHERE IDEspecificacao=" + IDEspecificacao;
                return new Data.Produto.Especificacao().Alterar(Sql);
            }

            #endregion
        }
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
    }
}