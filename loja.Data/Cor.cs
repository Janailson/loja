using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace loja.Data
{
    public class Cor : Generica
    {
        /// <summary>
        /// Lista os registros da tabela Cor
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public List<Entity.Cor> Listar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            List<Entity.Cor> cores = new List<Entity.Cor>();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    Entity.Cor cor = new Entity.Cor();
                    if (Coluna(oDr, "IDCor")) cor.IDCor = (int)oDr["IDCor"];
                    if (Coluna(oDr, "Loja_ID")) cor.Loja_ID = (int)oDr["Loja_ID"];
                    if (Coluna(oDr, "Nome")) cor.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "Status")) cor.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "DataInclusao")) cor.DataInclusao = (DateTime)oDr["DataInclusao"];
<<<<<<< HEAD
                    if (Coluna(oDr, "Produtos")) cor.Produtos = (int)oDr["Produtos"];
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
                    cores.Add(cor);
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

            return cores;
        }

        /// <summary>
        /// Consulta um registro da tabela Cor
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public Entity.Cor Consultar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            Entity.Cor cor = new Entity.Cor();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    if (Coluna(oDr, "IDCor")) cor.IDCor = (int)oDr["IDCor"];
                    if (Coluna(oDr, "Loja_ID")) cor.Loja_ID = (int)oDr["Loja_ID"];
                    if (Coluna(oDr, "Nome")) cor.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "Status")) cor.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "DataInclusao")) cor.DataInclusao = (DateTime)oDr["DataInclusao"];
<<<<<<< HEAD
                    if (Coluna(oDr, "Produtos")) cor.Produtos = (int)oDr["Produtos"];
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
                    cor.Dicionarios = new Data.Dicionario().Listar("SELECT Idioma_ID, Descricao, Valor FROM dbo.Dicionario WHERE Tabela='Cor' AND Id=" + oDr["IDCor"].ToString());
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

            return cor;
        }
    }
}