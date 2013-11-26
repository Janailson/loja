using System;
using System.Collections.Generic;

namespace loja.Rest
{
    [Serializable]
    public class Produto
    {
        // produto
        public string nome_produto { get; set; }
        public string marca { get; set; }
        public string descricao { get; set; }
        public int lojaid { get; set; }
        public string fornecedor { get; set; }
        public string lancamento { get; set; }
        public string manual { get; set; }
        public string video { get; set; }
        // vitrine
        public int id { get; set; }
        public string tamanho { get; set; }
        public string cor { get; set; }
        public string destaque { get; set; }
        public decimal peso { get; set; }
        public decimal altura { get; set; }
        public decimal largura { get; set; }
        public decimal profundidade { get; set; }
        public int estoque { get; set; }
        public List<String> imagens { get; set; }
        public List<Preco> precos { get; set; }

        // preços -> vitrine
        public class Preco
        {
            public string tipo_pessoa { get; set; }
            public decimal valor { get; set; }
            public decimal promocao { get; set; }
        }
    }
}