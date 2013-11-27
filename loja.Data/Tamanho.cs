using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace loja.Data
{
    public class Tamanho : Generica
    {
        /// <summary>
        /// Lista os registros da tabela Tamanho
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public List<Entity.Tamanho> Listar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            List<Entity.Tamanho> tamanhos = new List<Entity.Tamanho>();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    Entity.Tamanho tamanho = new Entity.Tamanho();
                    if (Coluna(oDr, "IDTamanho")) tamanho.IDTamanho = (int)oDr["IDTamanho"];
                    if (Coluna(oDr, "Loja_ID")) tamanho.Loja_ID = (int)oDr["Loja_ID"];
                    if (Coluna(oDr, "Nome")) tamanho.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "Status")) tamanho.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "DataInclusao")) tamanho.DataInclusao = (DateTime)oDr["DataInclusao"];
                    tamanhos.Add(tamanho);
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

            return tamanhos;
        }

        /// <summary>
        /// Consulta um registro da tabela Tamanho
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public Entity.Tamanho Consultar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            Entity.Tamanho tamanho = new Entity.Tamanho();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    if (Coluna(oDr, "IDTamanho")) tamanho.IDTamanho = (int)oDr["IDTamanho"];
                    if (Coluna(oDr, "Loja_ID")) tamanho.Loja_ID = (int)oDr["Loja_ID"];
                    if (Coluna(oDr, "Nome")) tamanho.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "Status")) tamanho.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "DataInclusao")) tamanho.DataInclusao = (DateTime)oDr["DataInclusao"];
                    tamanho.Dicionarios = new Data.Dicionario().Listar("SELECT Idioma_ID, Descricao, Valor FROM dbo.Dicionario WHERE Tabela='Tamanho' AND Id=" + oDr["IDTamanho"].ToString());
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

            return tamanho;
        }
    }
}