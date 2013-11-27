using System;

namespace loja.Idioma
{
    public class Categoria
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

        public Categoria() { this.Idioma = idioma.Portugues; Definir(); }
        public Categoria(idioma Idioma) { this.Idioma = Idioma; Definir(); }

        private void Definir()
        {
            switch (Idioma)
            {
                case idioma.Portugues:
                    // listagem
                    this.Novo = "nova categoria";
                    this.Excluir = "excluir selecionado(s)";
                    // registro
                    this.Geral = "Geral";
                    this.Nome = "Nome";
                    this.parentId = "Categoria";
                    this.Site = "Site";
                    this.Status = "Status";
                    // botão
                    this.Salvar = "salvar";
                    this.Cancelar = "cancelar";
                    break;
            }
        }
    }
}