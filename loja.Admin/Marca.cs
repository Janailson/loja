using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Admin
{
    public class Marca
    {
        #region SELECT

        public List<Entity.Marca> ListarMarca(int IDLoja)
        {
            string Sql = "SELECT IDMarca, Loja_ID, Nome, Logo, Status, DataInclusao FROM Marca WHERE Loja_ID=" + IDLoja;
            return new Data.Marca().Listar(Sql);
        }

        public Entity.Marca ConsultarMarca(object IDMarca)
        {
            string Sql = "SELECT IDMarca, Loja_ID, Nome, Logo, Status, DataInclusao FROM Marca WHERE IDMarca=" + IDMarca;
            return new Data.Marca().Consultar(Sql);
        }

        #endregion

        #region INSERT, UPDATE, DELETE

        public Entity.Retorno InserirMarca(Entity.Marca marca)
        {
            string Sql = "INSERT INTO Marca (Loja_ID,Nome,Logo,Status) VALUES ('" + marca.Loja_ID + "','" + marca.Nome + "','" + marca.Logo + "','" + marca.Status + "')";
            return new Data.Marca().Inserir(Sql);
        }

        public Entity.Retorno AlterarMarca(Entity.Marca marca)
        {
            string Sql = "UPDATE Marca SET Nome='" + marca.Nome + "', Status='" + marca.Status + "' WHERE IDMarca=" + marca.IDMarca;
            return new Data.Marca().Alterar(Sql);
        }

        public Entity.Retorno AlterarLogo(object IDMarca, string Campo, string Valor)
        {
            string Sql = "UPDATE Marca SET " + Campo + "='" + Valor + "' WHERE IDMarca=" + IDMarca;
            return new Data.Marca().Alterar(Sql);
        }

        public Entity.Retorno ExcluirMarca(object IDMarca)
        {
            string Sql = "DELETE FROM Marca WHERE IDMarca=" + IDMarca;
            return new Data.Marca().Alterar(Sql);
        }

        #endregion
    }
}