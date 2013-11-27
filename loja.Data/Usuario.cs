using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace loja.Data
{
    public class Usuario
    {
        public class Master : Generica
        {
            /// <summary>
            /// Lista os registros da tabela Usuario
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public List<Entity.Usuario.Master> Listar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                List<Entity.Usuario.Master> usuarios = new List<Entity.Usuario.Master>();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        Entity.Usuario.Master usuario = new Entity.Usuario.Master();
                        if (Coluna(oDr, "IDUsuario")) usuario.IDUsuario = (int)oDr["IDUsuario"];
                        if (Coluna(oDr, "Perfil_ID")) usuario.Perfil_ID = (int)oDr["Perfil_ID"];
                        if (Coluna(oDr, "Nome")) usuario.Nome = (string)oDr["Nome"];
                        if (Coluna(oDr, "Login")) usuario.Login = (string)oDr["Login"];
                        if (Coluna(oDr, "Senha")) usuario.Senha = (string)oDr["Senha"];
                        if (Coluna(oDr, "Locked")) usuario.Locked = Convert.ToBoolean(oDr["Locked"]);
                        if (Coluna(oDr, "DataInclusao")) usuario.DataInclusao = (DateTime)oDr["DataInclusao"];
                        usuarios.Add(usuario);
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

                return usuarios;
            }

            /// <summary>
            /// Consulta um registro da tabela Usuario
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public Entity.Usuario.Master Consultar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                Entity.Usuario.Master usuario = new Entity.Usuario.Master();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        if (Coluna(oDr, "IDUsuario")) usuario.IDUsuario = (int)oDr["IDUsuario"];
                        if (Coluna(oDr, "Perfil_ID")) usuario.Perfil_ID = (int)oDr["Perfil_ID"];
                        if (Coluna(oDr, "Nome")) usuario.Nome = (string)oDr["Nome"];
                        if (Coluna(oDr, "Login")) usuario.Login = (string)oDr["Login"];
                        if (Coluna(oDr, "Senha")) usuario.Senha = (string)oDr["Senha"];
                        if (Coluna(oDr, "Locked")) usuario.Locked = Convert.ToBoolean(oDr["Locked"]);
                        if (Coluna(oDr, "DataInclusao")) usuario.DataInclusao = (DateTime)oDr["DataInclusao"];
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

                return usuario;
            }
        }

        public class Loja : Generica
        {
            /// <summary>
            /// Lista os registros da tabela Usuario
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public List<Entity.Usuario.Loja> Listar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                List<Entity.Usuario.Loja> usuarios = new List<Entity.Usuario.Loja>();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        Entity.Usuario.Loja usuario = new Entity.Usuario.Loja();
                        if (Coluna(oDr, "IDUsuario")) usuario.IDUsuario = (int)oDr["IDUsuario"];
                        if (Coluna(oDr, "Loja_ID")) usuario.Loja_ID = (int)oDr["Loja_ID"];
                        if (Coluna(oDr, "Perfil_ID")) usuario.Perfil_ID = (int)oDr["Perfil_ID"];
                        if (Coluna(oDr, "Nome")) usuario.Nome = (string)oDr["Nome"];
                        if (Coluna(oDr, "Login")) usuario.Login = (string)oDr["Login"];
                        if (Coluna(oDr, "Senha")) usuario.Senha = (string)oDr["Senha"];
                        if (Coluna(oDr, "Locked")) usuario.Locked = Convert.ToBoolean(oDr["Locked"]);
                        if (Coluna(oDr, "DataInclusao")) usuario.DataInclusao = (DateTime)oDr["DataInclusao"];
                        usuarios.Add(usuario);
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

                return usuarios;
            }

            /// <summary>
            /// Consulta um registro da tabela Usuario
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public Entity.Usuario.Loja Consultar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                Entity.Usuario.Loja usuario = new Entity.Usuario.Loja();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        if (Coluna(oDr, "IDUsuario")) usuario.IDUsuario = (int)oDr["IDUsuario"];
                        if (Coluna(oDr, "Loja_ID")) usuario.Loja_ID = (int)oDr["Loja_ID"];
                        if (Coluna(oDr, "Perfil_ID")) usuario.Perfil_ID = (int)oDr["Perfil_ID"];
                        if (Coluna(oDr, "Nome")) usuario.Nome = (string)oDr["Nome"];
                        if (Coluna(oDr, "Login")) usuario.Login = (string)oDr["Login"];
                        if (Coluna(oDr, "Senha")) usuario.Senha = (string)oDr["Senha"];
                        if (Coluna(oDr, "Locked")) usuario.Locked = Convert.ToBoolean(oDr["Locked"]);
                        if (Coluna(oDr, "DataInclusao")) usuario.DataInclusao = (DateTime)oDr["DataInclusao"];
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

                return usuario;
            }
        }
    }
}