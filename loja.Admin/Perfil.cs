using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Admin
{
    public class Perfil
    {
        public class Master
        {
            #region SELECT

            public List<Entity.Perfil.Master> ListarPerfil()
            {
                string Sql = "SELECT IDPerfil, Nome, Locked, DataInclusao FROM master.Perfil";
                return new Data.Perfil.Master().Listar(Sql);
            }

            public Entity.Perfil ConsultarPerfil(object IDPerfil)
            {
                string Sql = "SELECT IDPerfil, Nome, Locked, DataInclusao FROM master.Perfil WHERE IDPerfil="+IDPerfil;
                return new Data.Perfil.Master().Consultar(Sql);
            }

            #endregion

            #region INSERT, UPDATE, DELETE

            public Entity.Retorno InserirPerfil(Entity.Perfil.Master perfil)
            {
                string Sql = "INSERT INTO master.Perfil (Nome) VALUES ('" + perfil.Nome + "')";
                return new Data.Loja().Inserir(Sql);
            }

            public Entity.Retorno AlterarPerfil(Entity.Perfil.Master perfil)
            {
                string Sql = "UPDATE master.Perfil SET Nome='"+perfil.Nome+"' WHERE IDPerfil=" + perfil.IDPerfil;
                return new Data.Perfil().Alterar(Sql);
            }

            public Entity.Retorno ExcluirPerfil(object IDPerfil)
            {
                string Sql = "DELETE FROM master.Perfil WHERE IDPerfil=" + IDPerfil;
                return new Data.Perfil().Alterar(Sql);
            }

            #endregion
        }

        public class Loja
        {
            #region SELECT

            public List<Entity.Perfil.Loja> ListarPerfil(int IDLoja)
            {
                string Sql = "SELECT IDPerfil, Loja_ID, Nome, Locked, DataInclusao FROM loja.Perfil WHERE Loja_ID=" + IDLoja;
                return new Data.Perfil.Loja().Listar(Sql);
            }

            public Entity.Perfil.Loja ConsultarPerfil(object IDPerfil)
            {
                string Sql = "SELECT IDPerfil, Loja_ID, Nome, Locked, DataInclusao FROM loja.Perfil WHERE IDPerfil=" + IDPerfil;
                return new Data.Perfil.Loja().Consultar(Sql);
            }

            #endregion

            #region INSERT, UPDATE, DELETE

            public Entity.Retorno InserirPerfil(Entity.Perfil.Loja perfil)
            {
                string Sql = "INSERT INTO loja.Perfil (Loja_ID,Nome) VALUES ('" + perfil.Loja_ID + "','" + perfil.Nome + "')";
                return new Data.Loja().Inserir(Sql);
            }

            public Entity.Retorno AlterarPerfil(Entity.Perfil.Loja perfil)
            {
                string Sql = "UPDATE loja.Perfil SET Nome='" + perfil.Nome + "' WHERE IDPerfil=" + perfil.IDPerfil;
                return new Data.Perfil().Alterar(Sql);
            }

            public Entity.Retorno ExcluirPerfil(object IDPerfil)
            {
                string Sql = "DELETE FROM loja.Perfil WHERE IDPerfil=" + IDPerfil;
                return new Data.Perfil().Alterar(Sql);
            }

            #endregion
        }
    }
}