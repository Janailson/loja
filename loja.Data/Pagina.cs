using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace loja.Data
{
    public class Pagina : Generica
    {
        /// <summary>
        /// Lista os registros da tabela Pagina
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public List<Entity.Pagina> Listar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            List<Entity.Pagina> paginas = new List<Entity.Pagina>();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    Entity.Pagina pagina = new Entity.Pagina();
                    if (Coluna(oDr, "IDPagina")) pagina.IDPagina = (int)oDr["IDPagina"];
                    if (Coluna(oDr, "Nome")) pagina.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "Link")) pagina.Link = oDr["Link"].ToString();
                    if (Coluna(oDr, "Icone")) pagina.Icone = oDr["Icone"].ToString();
                    if (Coluna(oDr, "parentId")) pagina.parentId = (int)oDr["parentId"];
                    if (Coluna(oDr, "Ordem")) pagina.Ordem = (int)oDr["Ordem"];
                    if (Coluna(oDr, "Tipo")) pagina.Tipo = (int)oDr["Tipo"];
                    paginas.Add(pagina);
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

            return paginas;
        }

        /// <summary>
        /// Consulta um registro da tabela Pagina
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public Entity.Pagina Consultar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            Entity.Pagina pagina = new Entity.Pagina();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    if (Coluna(oDr, "IDPagina")) pagina.IDPagina = (int)oDr["IDPagina"];
                    if (Coluna(oDr, "Nome")) pagina.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "Link")) pagina.Link = oDr["Link"].ToString();
                    if (Coluna(oDr, "Icone")) pagina.Icone = oDr["Icone"].ToString();
                    if (Coluna(oDr, "parentId")) pagina.parentId = (int)oDr["parentId"];
                    if (Coluna(oDr, "Ordem")) pagina.Ordem = (int)oDr["Ordem"];
                    if (Coluna(oDr, "Tipo")) pagina.Tipo = (int)oDr["Tipo"];
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

            return pagina;
        }
    }
}