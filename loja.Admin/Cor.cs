using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Admin
{
    public class Cor
    {
        #region SELECT

        public List<Entity.Cor> ListarCor(int IDLoja)
        {
            string Sql = "SELECT IDCor, Loja_ID, dbo.f_Idioma(Cor.Loja_ID,'','Cor',Cor.IDCor,'Nome') as Nome, Status, DataInclusao FROM Cor WHERE Loja_ID=" + IDLoja;
            return new Data.Cor().Listar(Sql);
        }

        public Entity.Cor ConsultarCor(object IDCor)
        {
            string Sql = "SELECT IDCor, Loja_ID, Status, DataInclusao FROM Cor WHERE IDCor=" + IDCor;
            return new Data.Cor().Consultar(Sql);
        }

        #endregion

        #region INSERT, UPDATE, DELETE

        public Entity.Retorno InserirCor(Entity.Cor cor)
        {
            string Sql = "INSERT INTO Cor (Loja_ID,Status) VALUES ('" + cor.Loja_ID + "','" + cor.Status + "')";
            return new Data.Cor().Inserir(Sql);
        }

        public Entity.Retorno AlterarCor(Entity.Cor cor)
        {
            string Sql = "UPDATE Cor SET Status='" + cor.Status + "' WHERE IDCor=" + cor.IDCor;
            return new Data.Cor().Alterar(Sql);
        }

        public Entity.Retorno ExcluirCor(object IDCor)
        {
            string Sql = "DELETE FROM Cor WHERE IDCor=" + IDCor;
            return new Data.Cor().Alterar(Sql);
        }

        #endregion
    }
}