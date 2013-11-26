using System;
using System.Collections.Generic;

namespace loja.Rest
{
    public class Categoria
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int parentId { get; set; }
        public int total_produtos { get; set; }
        public List<Rest.Categoria> subcategorias { get; set; }
    }
}