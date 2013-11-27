using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace loja.Data
{
    public class Generica
    {
        protected Conexao oConexao = new Conexao();
        private string ConnectionString;

        // CONSTRUTORES
        public Generica() { this.ConnectionString = oConexao.ConexaoBancoDeDados; }
        public Generica(string ConnectionString) { this.ConnectionString = ConnectionString; }

        /// <summary>
        /// Verifica se o campo está explícito na instrução Sql
        /// </summary>
        /// <param name="oDr">DataReader</param>
        /// <param name="Campo">Nome do Campo</param>
        /// <returns></returns>
        public bool Coluna(SqlDataReader oDr, string Campo)
        {
            for (int i = 0; i < oDr.FieldCount; i++)
            {
                string nome = oDr.GetName(i);
                if (oDr.GetName(i) == Campo)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Insere um novo registro
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public Entity.Retorno Inserir(string Sql)
        {
            SqlConnection oConn = new SqlConnection(ConnectionString);
            SqlCommand oComm = new SqlCommand(Sql + "; SELECT @@IDENTITY as 'Identity'", oConn);

            SqlDataReader oDr;

            Entity.Retorno retorno = new Entity.Retorno();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();
                oDr.Read();

                retorno.Status = true;
                retorno.Erro = "";
                retorno.Identity = Convert.ToInt32(oDr["Identity"]);
            }
            catch (Exception e)
            {
                new Log(e);
                retorno.Status = false;
                retorno.Erro = e.Message;
                retorno.Identity = 0;
            }
            finally
            {
                oDr = null;
                oComm = null;
                oConn.Close();
            }

            return retorno;
        }

        /// <summary>
        /// Altera ou remove um registro
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public Entity.Retorno Alterar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(ConnectionString);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            Entity.Retorno retorno = new Entity.Retorno();
            try
            {
                oConn.Open();
                oComm.ExecuteNonQuery();

                retorno.Status = true;
                retorno.Erro = "";
                retorno.Identity = 0;
            }
            catch (Exception e)
            {
                new Log(e);
                retorno.Status = false;
                retorno.Erro = e.Message;
                retorno.Identity = 0;
            }
            finally
            {
                oComm = null;
                oConn.Close();
            }

            return retorno;
        }
    }
}