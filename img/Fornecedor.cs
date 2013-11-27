using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Admin
{
    public class Fornecedor
    {
        #region SELECT

        public List<Entity.Fornecedor> ListarFornecedor(int IDLoja)
        {
            string Sql = "SELECT IDFornecedor, Loja_ID, Nome, Status, DataInclusao FROM Fornecedor WHERE Loja_ID=" + IDLoja;
            return new Data.Fornecedor().Listar(Sql);
        }

        public Entity.Fornecedor ConsultarFornecedor(object IDFornecedor)
        {
            string Sql = "SELECT IDFornecedor, Loja_ID, Nome, Status, DataInclusao FROM Fornecedor WHERE IDFornecedor=" + IDFornecedor;
            return new Data.Fornecedor().Consultar(Sql);
        }

        #endregion

        #region INSERT, UPDATE, DELETE

        public Entity.Retorno InserirFornecedor(Entity.Fornecedor fornecedor)
        {
            string Sql = "INSERT INTO Fornecedor (Loja_ID,Nome,Status) VALUES ('" + fornecedor.Loja_ID + "','" + fornecedor.Nome + "','" + fornecedor.Status + "')";
            return new Data.Fornecedor().Inserir(Sql);
        }

        public Entity.Retorno AlterarFornecedor(Entity.Fornecedor fornecedor)
        {
            string Sql = "UPDATE Fornecedor SET Nome='" + fornecedor.Nome + "', Status='" + fornecedor.Status + "' WHERE IDFornecedor=" + fornecedor.IDFornecedor;
            return new Data.Fornecedor().Alterar(Sql);
        }

        public Entity.Retorno ExcluirFornecedor(object IDFornecedor)
        {
            string Sql = "DELETE FROM Fornecedor WHERE IDFornecedor=" + IDFornecedor;
            return new Data.Fornecedor().Alterar(Sql);
        }

        #endregion
    }
}