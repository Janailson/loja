using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace loja.Data
{
<<<<<<< HEAD
    /// <summary>
    /// Produto
    /// </summary>
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
    public class Produto : Generica
    {
        /// <summary>
        /// Lista os registros da tabela Produto
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public List<Entity.Produto> Listar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            List<Entity.Produto> produtos = new List<Entity.Produto>();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    Entity.Produto produto = new Entity.Produto();
                    if (Coluna(oDr, "IDProduto")) produto.IDProduto = (int)oDr["IDProduto"];
                    if (Coluna(oDr, "Loja_ID")) produto.Loja_ID = (int)oDr["Loja_ID"];
                    if (Coluna(oDr, "Marca_ID")) produto.Marca_ID = (int)oDr["Marca_ID"];
                    if (Coluna(oDr, "Fornecedor_ID")) produto.Fornecedor_ID = (int)oDr["Fornecedor_ID"];
<<<<<<< HEAD
                    if (Coluna(oDr, "Cor_ID")) produto.Cor_ID = (int)oDr["Cor_ID"];
                    if (Coluna(oDr, "Codigo")) produto.Codigo = oDr["Codigo"].ToString();
=======
                    if (Coluna(oDr, "Destaque")) produto.Destaque = (bool)oDr["Destaque"];
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
                    if (Coluna(oDr, "Lancamento")) produto.Lancamento = (bool)oDr["Lancamento"];
                    if (Coluna(oDr, "Status")) produto.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "Manual")) produto.Manual = oDr["Manual"].ToString();
                    if (Coluna(oDr, "Video")) produto.Video = oDr["Video"].ToString();
                    if (Coluna(oDr, "Nome")) produto.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "Marca")) produto.Marca = oDr["Marca"].ToString();
                    if (Coluna(oDr, "Fornecedor")) produto.Fornecedor = oDr["Fornecedor"].ToString();
<<<<<<< HEAD
                    if (Coluna(oDr, "Cor")) produto.Cor = oDr["Cor"].ToString();
                    if (Coluna(oDr, "ImagemProduto")) produto.ImagemProduto = oDr["ImagemProduto"].ToString();
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
                    if (Coluna(oDr, "Detalhe")) produto.Detalhe = oDr["Detalhe"].ToString();
                    if (Coluna(oDr, "DataInclusao")) produto.DataInclusao = (DateTime)oDr["DataInclusao"];
                    produtos.Add(produto);
                }
            }
            catch (Exception e)
            {
                new Log(e);
            }
            finally
            {
                oDr = null;
                oComm = null;
                oConn.Close();
            }

            return produtos;
        }

        /// <summary>
        /// Consulta um registro da tabela Produto
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public Entity.Produto Consultar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            Entity.Produto produto = new Entity.Produto();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    if (Coluna(oDr, "IDProduto")) produto.IDProduto = (int)oDr["IDProduto"];
                    if (Coluna(oDr, "Loja_ID")) produto.Loja_ID = (int)oDr["Loja_ID"];
                    if (Coluna(oDr, "Marca_ID")) produto.Marca_ID = (int)oDr["Marca_ID"];
                    if (Coluna(oDr, "Fornecedor_ID")) produto.Fornecedor_ID = (int)oDr["Fornecedor_ID"];
<<<<<<< HEAD
                    if (Coluna(oDr, "Cor_ID")) produto.Cor_ID = (int)oDr["Cor_ID"];
                    if (Coluna(oDr, "Codigo")) produto.Codigo = oDr["Codigo"].ToString();
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
                    if (Coluna(oDr, "Destaque")) produto.Destaque = (bool)oDr["Destaque"];
                    if (Coluna(oDr, "Lancamento")) produto.Lancamento = (bool)oDr["Lancamento"];
                    if (Coluna(oDr, "Status")) produto.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "Manual")) produto.Manual = oDr["Manual"].ToString();
                    if (Coluna(oDr, "Video")) produto.Video = oDr["Video"].ToString();
                    if (Coluna(oDr, "Nome")) produto.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "Marca")) produto.Marca = oDr["Marca"].ToString();
                    if (Coluna(oDr, "Fornecedor")) produto.Fornecedor = oDr["Fornecedor"].ToString();
<<<<<<< HEAD
                    if (Coluna(oDr, "Cor")) produto.Cor = oDr["Cor"].ToString();
                    if (Coluna(oDr, "ImagemProduto")) produto.ImagemProduto = oDr["ImagemProduto"].ToString();
                    if (Coluna(oDr, "Detalhe")) produto.Detalhe = oDr["Detalhe"].ToString();
                    if (Coluna(oDr, "DataInclusao")) produto.DataInclusao = (DateTime)oDr["DataInclusao"];
                    produto.Dicionarios = new Data.Dicionario().Listar("SELECT Idioma_ID, Descricao, Valor FROM dbo.Dicionario WHERE Tabela='Produto' AND Id=" + oDr["IDProduto"].ToString());
                    produto.Caracteristicas = new Data.Produto.Caracteristica().Listar("SELECT IDCaracteristica, Produto_ID, Nome, Valor, Filtro FROM Caracteristica WHERE Produto_ID=" + oDr["IDProduto"].ToString());
                    produto.Especificacoes = new Data.Produto.Especificacao().Listar("SELECT IDEspecificacao, Produto_ID, Nome, Valor, Filtro FROM Especificacao WHERE Produto_ID=" + oDr["IDProduto"].ToString());
                    produto.Imagens = new Data.Produto.Imagem().Listar("SELECT IDProdutoImagem, Produto_ID, Arquivo, Ordem FROM ProdutoImagem WHERE Produto_ID=" + oDr["IDProduto"].ToString());
=======
                    if (Coluna(oDr, "Detalhe")) produto.Detalhe = oDr["Detalhe"].ToString();
                    if (Coluna(oDr, "DataInclusao")) produto.DataInclusao = (DateTime)oDr["DataInclusao"];
                    produto.Dicionarios = new Data.Dicionario().Listar("SELECT Idioma_ID, Descricao, Valor FROM dbo.Dicionario WHERE Tabela='Produto' AND Id=" + oDr["IDProduto"].ToString());
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
                }
            }
            catch (Exception e)
            {
                new Log(e);
            }
            finally
            {
                oDr = null;
                oComm = null;
                oConn.Close();
            }

            return produto;
        }
<<<<<<< HEAD

        /// <summary>
        /// Produto > Imagem
        /// </summary>
        public class Imagem : Generica
        {
            /// <summary>
            /// Lista os registros da tabela VitrineImagem
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public List<Entity.Produto.Imagem> Listar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                List<Entity.Produto.Imagem> imagens = new List<Entity.Produto.Imagem>();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        Entity.Produto.Imagem imagem = new Entity.Produto.Imagem();
                        if (Coluna(oDr, "IDProdutoImagem")) imagem.IDProdutoImagem = (int)oDr["IDProdutoImagem"];
                        if (Coluna(oDr, "Produto_ID")) imagem.Produto_ID = (int)oDr["Produto_ID"];
                        if (Coluna(oDr, "Arquivo")) imagem.Arquivo = (string)oDr["Arquivo"];
                        if (Coluna(oDr, "Ordem")) imagem.Ordem = (int)oDr["Ordem"];
                        imagens.Add(imagem);
                    }
                }
                catch (Exception e)
                {
                    new Log(e);
                }
                finally
                {
                    oDr = null;
                    oComm = null;
                    oConn.Close();
                }

                return imagens;
            }
        }

        /// <summary>
        /// Produto > Preço
        /// </summary>
        public class Preco : Generica
        {
            /// <summary>
            /// Lista os registros da tabela VitrinePreco
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public List<Entity.Produto.Preco> Listar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                List<Entity.Produto.Preco> precos = new List<Entity.Produto.Preco>();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        Entity.Produto.Preco preco = new Entity.Produto.Preco();
                        if (Coluna(oDr, "IDProdutoPreco")) preco.IDProdutoPreco = (int)oDr["IDProdutoPreco"];
                        if (Coluna(oDr, "Produto_ID")) preco.Produto_ID = (int)oDr["Produto_ID"];
                        if (Coluna(oDr, "TipoPessoa_ID")) preco.TipoPessoa_ID = (int)oDr["TipoPessoa_ID"];
                        if (Coluna(oDr, "TipoPessoa")) preco.TipoPessoa = oDr["TipoPessoa"].ToString();
                        if (Coluna(oDr, "Valor")) preco.Valor = (decimal)oDr["Valor"];
                        if (Coluna(oDr, "Promocao")) preco.Promocao = (decimal)oDr["Promocao"];
                        precos.Add(preco);
                    }
                }
                catch (Exception e)
                {
                    new Log(e);
                }
                finally
                {
                    oDr = null;
                    oComm = null;
                    oConn.Close();
                }

                return precos;
            }
        }

        /// <summary>
        /// Produto > Vitrine
        /// </summary>
        public class Vitrine : Generica
        {
            /// <summary>
            /// Lista os registros da tabela Vitrine
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public List<Entity.Produto.Vitrine> Listar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                List<Entity.Produto.Vitrine> vitrines = new List<Entity.Produto.Vitrine>();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        Entity.Produto.Vitrine vitrine = new Entity.Produto.Vitrine();
                        if (Coluna(oDr, "IDVitrine")) vitrine.IDVitrine = (int)oDr["IDVitrine"];
                        if (Coluna(oDr, "Produto_ID")) vitrine.Produto_ID = (int)oDr["Produto_ID"];
                        if (Coluna(oDr, "Tamanho_ID")) vitrine.Tamanho_ID = (int)oDr["Tamanho_ID"];
                        if (Coluna(oDr, "Tamanho")) vitrine.Tamanho = oDr["Tamanho"].ToString();
                        if (Coluna(oDr, "Peso")) vitrine.Peso = Convert.ToDecimal(oDr["Peso"]);
                        if (Coluna(oDr, "Altura")) vitrine.Altura = Convert.ToDecimal(oDr["Altura"]);
                        if (Coluna(oDr, "Largura")) vitrine.Largura = Convert.ToDecimal(oDr["Largura"]);
                        if (Coluna(oDr, "Profundidade")) vitrine.Profundidade = Convert.ToDecimal(oDr["Profundidade"]);
                        if (Coluna(oDr, "Estoque")) vitrine.Estoque = (int)oDr["Estoque"];
                        if (Coluna(oDr, "Status")) vitrine.Status = (bool)oDr["Status"];
                        vitrines.Add(vitrine);
                    }
                }
                catch (Exception e)
                {
                    new Log(e);
                }
                finally
                {
                    oDr = null;
                    oComm = null;
                    oConn.Close();
                }

                return vitrines;
            }

            /// <summary>
            /// Consulta um registro da tabela Vitrine
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public Entity.Produto.Vitrine Consultar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                Entity.Produto.Vitrine vitrine = new Entity.Produto.Vitrine();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        if (Coluna(oDr, "IDVitrine")) vitrine.IDVitrine = (int)oDr["IDVitrine"];
                        if (Coluna(oDr, "Produto_ID")) vitrine.Produto_ID = (int)oDr["Produto_ID"];
                        if (Coluna(oDr, "Tamanho_ID")) vitrine.Tamanho_ID = (int)oDr["Tamanho_ID"];
                        if (Coluna(oDr, "Tamanho")) vitrine.Tamanho = oDr["Tamanho"].ToString();
                        if (Coluna(oDr, "Peso")) vitrine.Peso = Convert.ToDecimal(oDr["Peso"]);
                        if (Coluna(oDr, "Altura")) vitrine.Altura = Convert.ToDecimal(oDr["Altura"]);
                        if (Coluna(oDr, "Largura")) vitrine.Largura = Convert.ToDecimal(oDr["Largura"]);
                        if (Coluna(oDr, "Profundidade")) vitrine.Profundidade = Convert.ToDecimal(oDr["Profundidade"]);
                        if (Coluna(oDr, "Estoque")) vitrine.Estoque = (int)oDr["Estoque"];
                        if (Coluna(oDr, "Status")) vitrine.Status = (bool)oDr["Status"];
                    }
                }
                catch (Exception e)
                {
                    new Log(e);
                }
                finally
                {
                    oDr = null;
                    oComm = null;
                    oConn.Close();
                }

                return vitrine;
            }
        }

        /// <summary>
        /// Produto > Caracteristica
        /// </summary>
        public class Caracteristica : Generica
        {
            /// <summary>
            /// Lista os registros da tabela Caracteristica
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public List<Entity.Produto.Caracteristica> Listar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                List<Entity.Produto.Caracteristica> caracteristicas = new List<Entity.Produto.Caracteristica>();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        Entity.Produto.Caracteristica caracteristica = new Entity.Produto.Caracteristica();
                        if (Coluna(oDr, "IDCaracteristica")) caracteristica.IDCaracteristica = (int)oDr["IDCaracteristica"];
                        if (Coluna(oDr, "Produto_ID")) caracteristica.Produto_ID = (int)oDr["Produto_ID"];
                        if (Coluna(oDr, "Nome")) caracteristica.Nome = oDr["Nome"].ToString();
                        if (Coluna(oDr, "Valor")) caracteristica.Valor = oDr["Valor"].ToString();
                        if (Coluna(oDr, "Filtro")) caracteristica.Filtro = (bool)oDr["Filtro"];
                        caracteristicas.Add(caracteristica);
                    }
                }
                catch (Exception e)
                {
                    new Log(e);
                }
                finally
                {
                    oDr = null;
                    oComm = null;
                    oConn.Close();
                }

                return caracteristicas;
            }

            /// <summary>
            /// Consulta um registro da tabela Caracteristica
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public Entity.Produto.Caracteristica Consultar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                Entity.Produto.Caracteristica caracteristica = new Entity.Produto.Caracteristica();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        if (Coluna(oDr, "IDCaracteristica")) caracteristica.IDCaracteristica = (int)oDr["IDCaracteristica"];
                        if (Coluna(oDr, "Produto_ID")) caracteristica.Produto_ID = (int)oDr["Produto_ID"];
                        if (Coluna(oDr, "Nome")) caracteristica.Nome = oDr["Nome"].ToString();
                        if (Coluna(oDr, "Valor")) caracteristica.Valor = oDr["Valor"].ToString();
                        if (Coluna(oDr, "Filtro")) caracteristica.Filtro = (bool)oDr["Filtro"];
                    }
                }
                catch (Exception e)
                {
                    new Log(e);
                }
                finally
                {
                    oDr = null;
                    oComm = null;
                    oConn.Close();
                }

                return caracteristica;
            }
        }

        /// <summary>
        /// Produto > Especificacao
        /// </summary>
        public class Especificacao : Generica
        {
            /// <summary>
            /// Lista os registros da tabela Especificacao
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public List<Entity.Produto.Especificacao> Listar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                List<Entity.Produto.Especificacao> especificacoes = new List<Entity.Produto.Especificacao>();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        Entity.Produto.Especificacao especificacao = new Entity.Produto.Especificacao();
                        if (Coluna(oDr, "IDEspecificacao")) especificacao.IDEspecificacao = (int)oDr["IDEspecificacao"];
                        if (Coluna(oDr, "Produto_ID")) especificacao.Produto_ID = (int)oDr["Produto_ID"];
                        if (Coluna(oDr, "Nome")) especificacao.Nome = oDr["Nome"].ToString();
                        if (Coluna(oDr, "Valor")) especificacao.Valor = oDr["Valor"].ToString();
                        if (Coluna(oDr, "Filtro")) especificacao.Filtro = (bool)oDr["Filtro"];
                        especificacoes.Add(especificacao);
                    }
                }
                catch (Exception e)
                {
                    new Log(e);
                }
                finally
                {
                    oDr = null;
                    oComm = null;
                    oConn.Close();
                }

                return especificacoes;
            }

            /// <summary>
            /// Consulta um registro da tabela Especificacao
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public Entity.Produto.Especificacao Consultar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                Entity.Produto.Especificacao especificacao = new Entity.Produto.Especificacao();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        if (Coluna(oDr, "IDEspecificacao")) especificacao.IDEspecificacao = (int)oDr["IDEspecificacao"];
                        if (Coluna(oDr, "Produto_ID")) especificacao.Produto_ID = (int)oDr["Produto_ID"];
                        if (Coluna(oDr, "Nome")) especificacao.Nome = oDr["Nome"].ToString();
                        if (Coluna(oDr, "Valor")) especificacao.Valor = oDr["Valor"].ToString();
                        if (Coluna(oDr, "Filtro")) especificacao.Filtro = (bool)oDr["Filtro"];
                    }
                }
                catch (Exception e)
                {
                    new Log(e);
                }
                finally
                {
                    oDr = null;
                    oComm = null;
                    oConn.Close();
                }

                return especificacao;
            }
        }
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
    }
}