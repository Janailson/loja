using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace loja.Data
{
    public class Idioma : Generica
    {
            /// <summary>
            /// Lista os registros da tabela Idioma
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public List<Entity.Idioma> Listar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                List<Entity.Idioma> idiomas = new List<Entity.Idioma>();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        Entity.Idioma idioma = new Entity.Idioma();
                        if (Coluna(oDr, "IDIdioma")) idioma.IDIdioma = (int)oDr["IDIdioma"];
                        if (Coluna(oDr, "Nome")) idioma.Nome = oDr["Nome"].ToString();
                        if (Coluna(oDr, "Codigo")) idioma.Codigo = oDr["Codigo"].ToString();
                        if (Coluna(oDr, "DataInclusao")) idioma.DataInclusao = (DateTime)oDr["DataInclusao"];
                        idiomas.Add(idioma);
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

                return idiomas;
            }

            /// <summary>
            /// Consulta um registro da tabela Idioma
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public Entity.Idioma Consultar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                Entity.Idioma idioma = new Entity.Idioma();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        if (Coluna(oDr, "IDIdioma")) idioma.IDIdioma = (int)oDr["IDIdioma"];
                        if (Coluna(oDr, "Nome")) idioma.Nome = oDr["Nome"].ToString();
                        if (Coluna(oDr, "Codigo")) idioma.Codigo = oDr["Codigo"].ToString();
                        if (Coluna(oDr, "DataInclusao")) idioma.DataInclusao = (DateTime)oDr["DataInclusao"];
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

                return idioma;
            }
    }
}