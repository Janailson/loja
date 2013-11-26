using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace loja.Data
{
    public class Categoria : Generica
    {
        /// <summary>
        /// Lista os registros da tabela Categoria
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public List<Entity.Categoria> Listar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            List<Entity.Categoria> categorias = new List<Entity.Categoria>();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    Entity.Categoria categoria = new Entity.Categoria();
                    if (Coluna(oDr, "IDCategoria")) categoria.IDCategoria = (int)oDr["IDCategoria"];
                    if (Coluna(oDr, "Loja_ID")) categoria.Loja_ID = (int)oDr["Loja_ID"];
                    if (Coluna(oDr, "Nome")) categoria.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "parentId")) categoria.parentId = (int)oDr["parentId"];
<<<<<<< HEAD
                    if (Coluna(oDr, "Nivel")) categoria.Nivel = (int)oDr["Nivel"];
                    if (Coluna(oDr, "MinNivel")) categoria.MinNivel = (int)oDr["MinNivel"];
                    if (Coluna(oDr, "MaxNivel")) categoria.MaxNivel = (int)oDr["MaxNivel"];
                    if (Coluna(oDr, "Site")) categoria.Site = (bool)oDr["Site"];
                    if (Coluna(oDr, "Status")) categoria.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "DataInclusao")) categoria.DataInclusao = (DateTime)oDr["DataInclusao"];
                    if (Coluna(oDr, "Produtos")) categoria.Produtos = (int)oDr["Produtos"];
=======
                    if (Coluna(oDr, "Site")) categoria.Site = (bool)oDr["Site"];
                    if (Coluna(oDr, "Status")) categoria.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "DataInclusao")) categoria.DataInclusao = (DateTime)oDr["DataInclusao"];
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
                    categorias.Add(categoria);
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

            return categorias;
        }

        /// <summary>
        /// Consulta um registro da tabela Categoria
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public Entity.Categoria Consultar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            Entity.Categoria categoria = new Entity.Categoria();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    if (Coluna(oDr, "IDCategoria")) categoria.IDCategoria = (int)oDr["IDCategoria"];
                    if (Coluna(oDr, "Loja_ID")) categoria.Loja_ID = (int)oDr["Loja_ID"];
<<<<<<< HEAD
                    if (Coluna(oDr, "Nome")) categoria.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "parentId")) categoria.parentId = (int)oDr["parentId"];
                    if (Coluna(oDr, "Nivel")) categoria.Nivel = (int)oDr["Nivel"];
                    if (Coluna(oDr, "MinNivel")) categoria.MinNivel = (int)oDr["MinNivel"];
                    if (Coluna(oDr, "MaxNivel")) categoria.MaxNivel = (int)oDr["MaxNivel"];
                    if (Coluna(oDr, "Site")) categoria.Site = (bool)oDr["Site"];
                    if (Coluna(oDr, "Status")) categoria.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "DataInclusao")) categoria.DataInclusao = (DateTime)oDr["DataInclusao"];
                    if (Coluna(oDr, "Produtos")) categoria.Produtos = (int)oDr["Produtos"];
=======
                    if (Coluna(oDr, "parentId")) categoria.parentId = (int)oDr["parentId"];
                    if (Coluna(oDr, "Site")) categoria.Site = (bool)oDr["Site"];
                    if (Coluna(oDr, "Status")) categoria.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "DataInclusao")) categoria.DataInclusao = (DateTime)oDr["DataInclusao"];
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
                    categoria.Dicionarios = new Data.Dicionario().Listar("SELECT Idioma_ID, Descricao, Valor FROM dbo.Dicionario WHERE Tabela='Categoria' AND Id=" + oDr["IDCategoria"].ToString());
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

            return categoria;
        }
    }
}