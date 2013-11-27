using System;

namespace loja.Entity
{
    public class Pagina
    {
        public int IDPagina { get; set; }
        public string Nome { get; set; }
        public string Link { get; set; }
        public string Icone { get; set; }
        public int parentId { get; set; }
        public int Ordem { get; set; }
        public int Tipo { get; set; }

        public class Master : Pagina
        {

        }

        public class Loja : Pagina
        {

        }
    }
}