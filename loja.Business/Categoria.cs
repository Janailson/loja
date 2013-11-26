using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Business
{
    public class Categoria
    {
        #region SELECT

        public List<Entity.Categoria> ListarCategoria(int IDLoja, int IDCategoria)
        {
            string Sql = "SELECT IDCategoria, dbo.f_Idioma(Categoria.Loja_ID,'','Categoria',Categoria.IDCategoria,'Nome') as Nome, parentId, Nivel, (SELECT MIN(Nivel) FROM Categoria WHERE Loja_ID=Categoria.Loja_ID) as MinNivel, (SELECT MAX(Nivel) FROM Categoria WHERE Loja_ID=Categoria.Loja_ID) as MaxNivel, (SELECT Total FROM dbo.f_ProdutosTotal(Categoria.Loja_ID,Categoria.IDCategoria,'False')) as Produtos FROM Categoria WHERE Loja_ID=" + IDLoja + " AND parentId=" + IDCategoria + " AND Site='True' AND Status='True'";
            return new Data.Categoria().Listar(Sql);
        }

        public Entity.Categoria ConsultarCategoria(object IDCategoria)
        {
            string Sql = "SELECT IDCategoria, dbo.f_Idioma(Categoria.Loja_ID,'','Categoria',Categoria.IDCategoria,'Nome') as Nome, parentId, Nivel, (SELECT MIN(Nivel) FROM Categoria WHERE Loja_ID=Categoria.Loja_ID) as MinNivel, (SELECT MAX(Nivel) FROM Categoria WHERE Loja_ID=Categoria.Loja_ID) as MaxNivel, (SELECT Total FROM dbo.f_ProdutosTotal(Categoria.Loja_ID,Categoria.IDCategoria,'False')) as Produtos FROM Categoria WHERE IDCategoria=" + IDCategoria;
            return new Data.Categoria().Consultar(Sql);
        }

        #endregion
    }
}