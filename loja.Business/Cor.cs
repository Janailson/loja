using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Business
{
    public class Cor
    {
        public List<Entity.Cor> ListarCor(int IDCategoria)
        {
            string Sql = "p_Cores " + IDCategoria;
            return new Data.Cor().Listar(Sql);
        }
    }
}