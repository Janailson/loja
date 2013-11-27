using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace loja.Data
{
    public class Fornecedor : Generica
    {
        /// <summary>
        /// Lista os registros da tabela Fornecedor
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public List<Entity.Fornecedor> Listar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            List<Entity.Fornecedor> fornecedores = new List<Entity.Fornecedor>();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    Entity.Fornecedor fornecedor = new Entity.Fornecedor();
                    if (Coluna(oDr, "IDFornecedor")) fornecedor.IDFornecedor = (int)oDr["IDFornecedor"];
                    if (Coluna(oDr, "Loja_ID")) fornecedor.Loja_ID = (int)oDr["Loja_ID"];
                    if (Coluna(oDr, "Nome")) fornecedor.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "Status")) fornecedor.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "DataInclusao")) fornecedor.DataInclusao = (DateTime)oDr["DataInclusao"];
                    fornecedores.Add(fornecedor);
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

            return fornecedores;
        }

        /// <summary>
        /// Consulta um registro da tabela Fornecedor
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public Entity.Fornecedor Consultar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            Entity.Fornecedor fornecedor = new Entity.Fornecedor();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    if (Coluna(oDr, "IDFornecedor")) fornecedor.IDFornecedor = (int)oDr["IDFornecedor"];
                    if (Coluna(oDr, "Loja_ID")) fornecedor.Loja_ID = (int)oDr["Loja_ID"];
                    if (Coluna(oDr, "Nome")) fornecedor.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "Status")) fornecedor.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "DataInclusao")) fornecedor.DataInclusao = (DateTime)oDr["DataInclusao"];
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

            return fornecedor;
        }
    }
}