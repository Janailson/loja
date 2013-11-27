using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Admin
{
    public class Tamanho
    {
        #region SELECT

        public List<Entity.Tamanho> ListarTamanho(int IDLoja)
        {
            string Sql = "SELECT IDTamanho, Loja_ID, dbo.f_Idioma(Tamanho.Loja_ID,'','Tamanho',Tamanho.IDTamanho,'Nome') as Nome, Status, DataInclusao FROM Tamanho WHERE Loja_ID=" + IDLoja;
            return new Data.Tamanho().Listar(Sql);
        }

        public Entity.Tamanho ConsultarTamanho(object IDTamanho)
        {
            string Sql = "SELECT IDTamanho, Loja_ID, Status, DataInclusao FROM Tamanho WHERE IDTamanho=" + IDTamanho;
            return new Data.Tamanho().Consultar(Sql);
        }

        #endregion

        #region INSERT, UPDATE, DELETE

        public Entity.Retorno InserirTamanho(Entity.Tamanho tamanho)
        {
            string Sql = "INSERT INTO Tamanho (Loja_ID,Status) VALUES ('" + tamanho.Loja_ID + "','" + tamanho.Status + "')";
            return new Data.Tamanho().Inserir(Sql);
        }

        public Entity.Retorno AlterarTamanho(Entity.Tamanho tamanho)
        {
            string Sql = "UPDATE Tamanho SET Status='" + tamanho.Status + "' WHERE IDTamanho=" + tamanho.IDTamanho;
            return new Data.Tamanho().Alterar(Sql);
        }

        public Entity.Retorno ExcluirTamanho(object IDTamanho)
        {
            string Sql = "DELETE FROM Tamanho WHERE IDTamanho=" + IDTamanho;
            return new Data.Tamanho().Alterar(Sql);
        }

        #endregion
    }
}