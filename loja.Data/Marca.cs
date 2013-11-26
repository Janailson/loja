using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace loja.Data
{
    public class Marca : Generica
    {
        /// <summary>
        /// Lista os registros da tabela Marca
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public List<Entity.Marca> Listar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            List<Entity.Marca> marcas = new List<Entity.Marca>();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    Entity.Marca marca = new Entity.Marca();
                    if (Coluna(oDr, "IDMarca")) marca.IDMarca = (int)oDr["IDMarca"];
                    if (Coluna(oDr, "Loja_ID")) marca.Loja_ID = (int)oDr["Loja_ID"];
                    if (Coluna(oDr, "Nome")) marca.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "Logo")) marca.Logo = oDr["Logo"].ToString();
                    if (Coluna(oDr, "Status")) marca.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "DataInclusao")) marca.DataInclusao = (DateTime)oDr["DataInclusao"];
<<<<<<< HEAD
                    if (Coluna(oDr, "Produtos")) marca.Produtos = (int)oDr["Produtos"];
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
                    marcas.Add(marca);
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

            return marcas;
        }

        /// <summary>
        /// Consulta um registro da tabela Marca
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public Entity.Marca Consultar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            Entity.Marca marca = new Entity.Marca();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    if (Coluna(oDr, "IDMarca")) marca.IDMarca = (int)oDr["IDMarca"];
                    if (Coluna(oDr, "Loja_ID")) marca.Loja_ID = (int)oDr["Loja_ID"];
                    if (Coluna(oDr, "Nome")) marca.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "Logo")) marca.Logo = oDr["Logo"].ToString();
                    if (Coluna(oDr, "Status")) marca.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "DataInclusao")) marca.DataInclusao = (DateTime)oDr["DataInclusao"];
<<<<<<< HEAD
                    if (Coluna(oDr, "Produtos")) marca.Produtos = (int)oDr["Produtos"];
=======
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

            return marca;
        }
    }
}