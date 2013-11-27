using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace loja.Data
{
    public class Perfil : Generica
    {
        public class Master : Perfil
        {
            /// <summary>
            /// Lista os registros da tabela Perfil
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public List<Entity.Perfil.Master> Listar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                List<Entity.Perfil.Master> perfis = new List<Entity.Perfil.Master>();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        Entity.Perfil.Master perfil = new Entity.Perfil.Master();
                        if (Coluna(oDr, "IDPerfil")) perfil.IDPerfil = (int)oDr["IDPerfil"];
                        if (Coluna(oDr, "Nome")) perfil.Nome = (string)oDr["Nome"];
                        if (Coluna(oDr, "Locked")) perfil.Locked = Convert.ToBoolean(oDr["Locked"]);
                        if (Coluna(oDr, "DataInclusao")) perfil.DataInclusao = (DateTime)oDr["DataInclusao"];
                        perfis.Add(perfil);
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

                return perfis;
            }

            /// <summary>
            /// Consulta um registro da tabela Perfil
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public Entity.Perfil.Master Consultar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                Entity.Perfil.Master perfil = new Entity.Perfil.Master();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        if (Coluna(oDr, "IDPerfil")) perfil.IDPerfil = (int)oDr["IDPerfil"];
                        if (Coluna(oDr, "Nome")) perfil.Nome = (string)oDr["Nome"];
                        if (Coluna(oDr, "Locked")) perfil.Locked = Convert.ToBoolean(oDr["Locked"]);
                        if (Coluna(oDr, "DataInclusao")) perfil.DataInclusao = (DateTime)oDr["DataInclusao"];
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

                return perfil;
            }

            public class Permissao : Generica
            {

            }
        }

        public class Loja : Perfil
        {
            /// <summary>
            /// Lista os registros da tabela Perfil
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public List<Entity.Perfil.Loja> Listar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                List<Entity.Perfil.Loja> perfis = new List<Entity.Perfil.Loja>();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        Entity.Perfil.Loja perfil = new Entity.Perfil.Loja();
                        if (Coluna(oDr, "IDPerfil")) perfil.IDPerfil = (int)oDr["IDPerfil"];
                        if (Coluna(oDr, "Loja_ID")) perfil.Loja_ID = (int)oDr["Loja_ID"];
                        if (Coluna(oDr, "Nome")) perfil.Nome = (string)oDr["Nome"];
                        if (Coluna(oDr, "Locked")) perfil.Locked = Convert.ToBoolean(oDr["Locked"]);
                        if (Coluna(oDr, "DataInclusao")) perfil.DataInclusao = (DateTime)oDr["DataInclusao"];
                        perfis.Add(perfil);
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

                return perfis;
            }

            /// <summary>
            /// Consulta um registro da tabela Perfil
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public Entity.Perfil.Loja Consultar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                Entity.Perfil.Loja perfil = new Entity.Perfil.Loja();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        if (Coluna(oDr, "IDPerfil")) perfil.IDPerfil = (int)oDr["IDPerfil"];
                        if (Coluna(oDr, "Loja_ID")) perfil.Loja_ID = (int)oDr["Loja_ID"];
                        if (Coluna(oDr, "Nome")) perfil.Nome = (string)oDr["Nome"];
                        if (Coluna(oDr, "Locked")) perfil.Locked = Convert.ToBoolean(oDr["Locked"]);
                        if (Coluna(oDr, "DataInclusao")) perfil.DataInclusao = (DateTime)oDr["DataInclusao"];
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

                return perfil;
            }

            public class Permissao : Generica
            {

            }
        }
    }
}