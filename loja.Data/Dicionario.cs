using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace loja.Data
{
    public class Dicionario : Generica
    {
        /// <summary>
        /// Lista os registros da tabela Dicionario
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public List<Entity.Dicionario> Listar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            List<Entity.Dicionario> dicionarios = new List<Entity.Dicionario>();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    Entity.Dicionario dicionario = new Entity.Dicionario();
                    if (Coluna(oDr, "Idioma_ID")) dicionario.Idioma_ID = (int)oDr["Idioma_ID"];
                    if (Coluna(oDr, "Tabela")) dicionario.Tabela = oDr["Tabela"].ToString();
                    if (Coluna(oDr, "Id")) dicionario.Id = (int)oDr["Id"];
                    if (Coluna(oDr, "Descricao")) dicionario.Descricao = oDr["Descricao"].ToString();
                    if (Coluna(oDr, "Valor")) dicionario.Valor = oDr["Valor"].ToString();
                    dicionarios.Add(dicionario);
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

            return dicionarios;
        }

        /// <summary>
        /// Consulta um registro da tabela Dicionario
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public Entity.Dicionario Consultar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            Entity.Dicionario dicionario = new Entity.Dicionario();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    if (Coluna(oDr, "Idioma_ID")) dicionario.Idioma_ID = (int)oDr["Idioma_ID"];
                    if (Coluna(oDr, "Tabela")) dicionario.Tabela = oDr["Tabela"].ToString();
                    if (Coluna(oDr, "Id")) dicionario.Id = (int)oDr["Id"];
                    if (Coluna(oDr, "Descricao")) dicionario.Descricao = oDr["Descricao"].ToString();
                    if (Coluna(oDr, "Valor")) dicionario.Valor = oDr["Valor"].ToString();
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

            return dicionario;
        }
    }
}