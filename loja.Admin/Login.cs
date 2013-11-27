using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Admin
{
    public class Login
    {
        public class Master
        {
            #region SELECT

            public Entity.Usuario ConsultarUsuario(string Login, string Senha)
            {
                string Sql = "SELECT IDUsuario, Perfil_ID, Nome, Login, Senha, Locked FROM master.Usuario WHERE Login='" + Login + "' AND Senha='" + Senha + "'";
                return new Data.Usuario.Master().Consultar(Sql);
            }

            #endregion
        }

        public class Loja
        {
            #region SELECT

            public Entity.Usuario.Loja ConsultarUsuario(string Login, string Senha)
            {
                string Sql = "SELECT u.IDUsuario, p.Loja_ID, u.Perfil_ID, u.Nome, u.Login, u.Senha, u.Locked, u.DataInclusao FROM loja.Usuario u, loja.Perfil p WHERE p.IDPerfil=u.Perfil_ID AND u.Login='" + Login + "' AND u.Senha='" + Senha + "'";
                return new Data.Usuario.Loja().Consultar(Sql);
            }

            #endregion
        }
    }
}