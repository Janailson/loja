using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Admin
{
    public class Idioma
    {
        #region SELECT

        public List<Entity.Idioma> ListarIdioma()
        {
            string Sql = "SELECT IDIdioma, Nome, Codigo FROM master.Idioma";
            return new Data.Idioma().Listar(Sql);
        }

        public Entity.Idioma ConsultarIdioma(object IDIdioma)
        {
            string Sql = "SELECT IDIdioma, Nome, Codigo FROM master.Idioma WHERE IDIdioma=" + IDIdioma;
            return new Data.Idioma().Consultar(Sql);
        }

        #endregion
    }
}