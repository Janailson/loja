using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Business
{
    public class Marca
    {
        public List<Entity.Marca> ListarMarca(int IDCategoria)
        {
            string Sql = "p_Marcas " + IDCategoria;
            return new Data.Marca().Listar(Sql);
        }
    }
}