using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Business
{
    public class Tamanhos
    {
        public List<Entity.Tamanho> ListarTamanho(int IDLoja, int IDCategoria)
        {
            string Sql = "p_Tamanhos " + IDLoja + "," + IDCategoria;
            return new Data.Tamanho().Listar(Sql);
        }
    }
}