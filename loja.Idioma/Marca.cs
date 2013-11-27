using System;

namespace loja.Idioma
{
    public class Marca
    {
        private idioma Idioma;

        // listagem
        public string Novo;
        public string Excluir;
        // registro
        public string Geral;
        public string Nome;
        public string Logo;
        public string Status;
        // botão
        public string Salvar;
        public string Cancelar;

        public Marca() { this.Idioma = idioma.Portugues; Definir(); }
        public Marca(idioma Idioma) { this.Idioma = Idioma; Definir(); }

        private void Definir()
        {
            switch (Idioma)
            {
                case idioma.Portugues:
                    // listagem
                    this.Novo = "nova marca";
                    this.Excluir = "excluir selecionado(s)";
                    // registro
                    this.Geral = "Geral";
                    this.Nome = "Nome";
                    this.Logo = "Logo";
                    this.Status = "Status";
                    // botão
                    this.Salvar = "salvar";
                    this.Cancelar = "cancelar";
                    break;
            }
        }
    }
}