using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Admin
{
    public class Dicionario
    {
        #region INSERT, UPDATE, DELETE

        public Entity.Retorno InserirDicionario(Entity.Dicionario dicionario)
        {
            string Sql = "INSERT INTO Dicionario (Idioma_ID,Tabela,Id,Descricao,Valor) VALUES ('" + dicionario.Idioma_ID + "','" + dicionario.Tabela + "','" + dicionario.Id + "','" + dicionario.Descricao + "','" + dicionario.Valor + "')";
            return new Data.Dicionario().Inserir(Sql);
        }

        public Entity.Retorno AlterarDicionario(Entity.Dicionario dicionario)
        {
            string Sql = "UPDATE Dicionario SET Valor='" + dicionario.Valor + "' WHERE Tabela='" + dicionario.Tabela + "' AND Id=" + dicionario.Id + " AND Descricao='" + dicionario.Descricao + "' AND Idioma_ID=" + dicionario.Idioma_ID;
            return new Data.Dicionario().Alterar(Sql);
        }

        public Entity.Retorno ExcluirDicionario(object IDDicionario)
        {
            string Sql = "DELETE FROM Dicionario WHERE IDDicionario=" + IDDicionario;
            return new Data.Dicionario().Alterar(Sql);
        }

        #endregion
    }
}