using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Admin
{
    public class Categoria
    {
        #region SELECT

        public List<Entity.Categoria> ListarCategoria(int IDLoja, int parentId)
        {
            string Sql = "SELECT IDCategoria, Loja_ID, dbo.f_Idioma(" + IDLoja + ",'pt-BR','Categoria',Categoria.IDCategoria,'Nome') as Nome, parentId, Site, Status, DataInclusao FROM Categoria WHERE Loja_ID=" + IDLoja + " AND parentId=" + parentId;
            return new Data.Categoria().Listar(Sql);
        }

<<<<<<< HEAD
        public List<Entity.Categoria> ListarCategoria(int IDLoja)
        {
            string Sql = "SELECT IDCategoria, Loja_ID, dbo.f_Idioma(" + IDLoja + ",'pt-BR','Categoria',Categoria.IDCategoria,'Nome') as Nome, parentId, Site, Status, DataInclusao FROM Categoria WHERE Loja_ID=" + IDLoja;
            return new Data.Categoria().Listar(Sql);
        }

=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
        public Entity.Categoria ConsultarCategoria(object IDCategoria)
        {
            string Sql = "SELECT IDCategoria, Loja_ID, parentId, Site, Status, DataInclusao FROM Categoria WHERE IDCategoria=" + IDCategoria;
            return new Data.Categoria().Consultar(Sql);
        }

        #endregion

        #region INSERT, UPDATE, DELETE

        public Entity.Retorno InserirCategoria(Entity.Categoria categoria)
        {
            string Sql = "INSERT INTO Categoria (Loja_ID,parentId,Site,Status) VALUES ('" + categoria.Loja_ID + "','" + categoria.parentId + "','" + categoria.Site + "','" + categoria.Status + "')";
            return new Data.Categoria().Inserir(Sql);
        }

        public Entity.Retorno AlterarCategoria(Entity.Categoria categoria)
        {
            string Sql = "UPDATE Categoria SET Site='" + categoria.Site + "', Status='" + categoria.Status + "' WHERE IDCategoria=" + categoria.IDCategoria;
            return new Data.Categoria().Alterar(Sql);
        }

        public Entity.Retorno ExcluirCategoria(object IDCategoria)
        {
            string Sql = "DELETE FROM Categoria WHERE IDCategoria=" + IDCategoria;
            return new Data.Categoria().Alterar(Sql);
        }

        #endregion
    }
}