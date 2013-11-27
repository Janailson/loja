using System;

namespace loja.Idioma
{
    public class Cor
    {
        private idioma Idioma;

        // listagem
        public string Novo;
        public string Excluir;
        // registro
        public string Geral;
        public string Nome;
        public string Status;
        // botão
        public string Salvar;
        public string Cancelar;

        public Cor() { this.Idioma = idioma.Portugues; Definir(); }
        public Cor(idioma Idioma) { this.Idioma = Idioma; Definir(); }

        private void Definir()
        {
            switch (Idioma)
            {
                case idioma.Portugues:
                    // listagem
                    this.Novo = "nova cor";
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