using System;

namespace loja.Idioma
{
    public class Fornecedor
    {
        private idioma Idioma;

        // listagem
        public string Novo;
        public string Excluir;
        // registro
        public string Geral;
        public string Nome;
        public string parentId;
        public string Site;
        public string Status;
        // botão
        public string Salvar;
        public string Cancelar;

        public Fornecedor() { this.Idioma = idioma.Portugues; Definir(); }
        public Fornecedor(idioma Idioma) { this.Idioma = Idioma; Definir(); }

        private void Definir()
        {
            switch (Idioma)
            {
                case idioma.Portugues:
                    // listagem
                    this.Novo = "novo fornecedor";
                    this.Excluir = "excluir selecionado(s)";
                    // registro
                    this.Geral = "Geral";
                    this.Nome = "Nome";
                    this.Status = "Status";
                    // botão
                    this.Salvar = "salvar";
                    this.Cancelar = "cancelar";
                    break;
            }
        }
    }
}