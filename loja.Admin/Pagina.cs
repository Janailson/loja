using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Admin
{
    public class Pagina
    {
        public class Master
        {
            #region SELECT

            public List<Entity.Pagina> ListarPagina(int parentId)
            {
                string Sql = "SELECT IDPagina, Nome, Link, Icone, parentId, Ordem, Tipo FROM master.Pagina WHERE parentId=" + parentId + " ORDER BY Ordem ASC";
                return new Data.Pagina().Listar(Sql);
            }

            #endregion
        }

        public class Loja
        {
            #region SELECT

            public List<Entity.Pagina> ListarPagina(int parentId)
            {
                string Sql = "SELECT IDPagina, Nome, Link, Icone, parentId, Ordem, Tipo FROM loja.Pagina WHERE parentId=" + parentId + " ORDER BY Ordem ASC";
                return new Data.Pagina().Listar(Sql);
            }

            #endregion
        }
    }
}