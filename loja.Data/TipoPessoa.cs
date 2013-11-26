using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace loja.Data
{
    public class TipoPessoa:Generica
    {
        /// <summary>
        /// Lista os registros da tabela TipoPessoa
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public List<Entity.TipoPessoa> Listar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            List<Entity.TipoPessoa> tipospessoa = new List<Entity.TipoPessoa>();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    Entity.TipoPessoa tipopessoa = new Entity.TipoPessoa();
                    if (Coluna(oDr, "IDTipoPessoa")) tipopessoa.IDTipoPessoa = (int)oDr["IDTipoPessoa"];
                    if (Coluna(oDr, "Loja_ID")) tipopessoa.Loja_ID = (int)oDr["Loja_ID"];
                    if (Coluna(oDr, "Nome")) tipopessoa.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "Status")) tipopessoa.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "DataInclusao")) tipopessoa.DataInclusao = (DateTime)oDr["DataInclusao"];
                    tipospessoa.Add(tipopessoa);
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

            return tipospessoa;
        }

        /// <summary>
        /// Consulta um registro da tabela TipoPessoa
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public Entity.TipoPessoa Consultar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            Entity.TipoPessoa tipopessoa = new Entity.TipoPessoa();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    if (Coluna(oDr, "IDTipoPessoa")) tipopessoa.IDTipoPessoa = (int)oDr["IDTipoPessoa"];
                    if (Coluna(oDr, "Loja_ID")) tipopessoa.Loja_ID = (int)oDr["Loja_ID"];
                    if (Coluna(oDr, "Nome")) tipopessoa.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "Status")) tipopessoa.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "DataInclusao")) tipopessoa.DataInclusao = (DateTime)oDr["DataInclusao"];
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

            return tipopessoa;
        }
    }
}