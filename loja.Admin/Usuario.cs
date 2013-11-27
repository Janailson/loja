using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Admin
{
    public class Usuario
    {
        public class Master
        {
            #region SELECT

            public List<Entity.Usuario.Master> ListarUsuario(string Busca)
            {
                string Sql = "SELECT IDUsuario, Perfil_ID, Nome, Login, Senha, Locked, DataInclusao FROM master.Usuario WHERE Nome LIKE '%" + Busca + "%'";
                return new Data.Usuario.Master().Listar(Sql);
            }

            public Entity.Usuario.Master ConsultarUsuario(object IDUsuario)
            {
                string Sql = "SELECT IDUsuario, Perfil_ID, Nome, Login, Senha, Locked, DataInclusao FROM master.Usuario WHERE IDUsuario=" + IDUsuario;
                return new Data.Usuario.Master().Consultar(Sql);
            }

            #endregion

            #region INSERT, UPDATE, DELETE

            public Entity.Retorno InserirUsuario(Entity.Usuario.Master usuario)
            {
                string Sql = "INSERT INTO master.Usuario (Perfil_ID,Nome,Login,Senha) VALUES ('" + usuario.Perfil_ID + "','" + usuario.Nome + "','" + usuario.Login + "','" + usuario.Senha + "')";
                return new Data.Usuario.Master().Inserir(Sql);
            }

            public Entity.Retorno AlterarUsuario(Entity.Usuario.Master usuario)
            {
                string Sql = "UPDATE master.Usuario SET Perfil=" + usuario.Perfil_ID + ", Nome='" + usuario.Nome + "', Login='" + usuario.Login + "', Senha='" + usuario.Senha + "' WHERE IDUsuario=" + usuario.IDUsuario;
                return new Data.Usuario.Master().Alterar(Sql);
            }

            public Entity.Retorno ExcluirUsuario(object IDUsuario)
            {
                string Sql = "DELETE FROM loja.Usuario WHERE IDUsuario=" + IDUsuario;
                return new Data.Usuario.Master().Alterar(Sql);
            }

            #endregion
        }

        public class Loja
        {
            #region SELECT

            public List<Entity.Usuario.Loja> ListarUsuario(object IDLoja)
            {
                string Sql = "SELECT IDUsuario, Perfil_ID, Nome, Login, Senha, Locked, DataInclusao FROM loja.Usuario WHERE Perfil_ID IN (SELECT IDPerfil FROM loja.Perfil WHERE Loja_ID=" + IDLoja + ")";
                return new Data.Usuario.Loja().Listar(Sql);
            }

            public Entity.Usuario.Loja ConsultarUsuario(object IDUsuario)
            {
                string Sql = "SELECT IDUsuario, Perfil_ID, Nome, Login, Senha, Locked, DataInclusao FROM loja.Usuario WHERE IDUsuario=" + IDUsuario;
                return new Data.Usuario.Loja().Consultar(Sql);
            }

            #endregion

            #region INSERT, UPDATE, DELETE

            public Entity.Retorno InserirUsuario(Entity.Usuario.Loja usuario)
            {
                string Sql = "INSERT INTO loja.Usuario (Perfil_ID,Nome,Login,Senha) VALUES ('" + usuario.Perfil_ID + "','" + usuario.Nome + "','" + usuario.Login + "','" + usuario.Senha + "')";
                return new Data.Usuario.Loja().Inserir(Sql);
            }

            public Entity.Retorno AlterarUsuario(Entity.Usuario.Loja usuario)
            {
                string Sql = "UPDATE loja.Usuario SET Perfil_ID=" + usuario.Perfil_ID + ", Nome='" + usuario.Nome + "', Login='" + usuario.Login + "', Senha='" + usuario.Senha + "' WHERE IDUsuario=" + usuario.IDUsuario;
                return new Data.Usuario.Loja().Alterar(Sql);
            }

            public Entity.Retorno ExcluirUsuario(object IDUsuario)
            {
                string Sql = "DELETE FROM loja.Usuario WHERE IDUsuario=" + IDUsuario;
                return new Data.Usuario.Loja().Alterar(Sql);
            }

            #endregion
        }
    }
}