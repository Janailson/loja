using System;

namespace loja.Idioma
{
    public class Produto
    {
        private idioma Idioma;

        // listagem
        public string Novo;
        public string Excluir;
        // registro
        public string Geral;
        public string Nome;
        public string Marca;
        public string Fornecedor;
<<<<<<< HEAD
        public string Cor;
        public string Codigo;
        public string Categoria;
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
        public string Destaque;
        public string Lancamento;
        public string Status;
        public string Manual;
        public string Video;
        public string Detalhes;
<<<<<<< HEAD
        public string Vitrines;
=======
        public string Vitrine;
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
        public string Caracteristicas;
        public string Especificacoes;
        public string Comentarios;
        // botão
        public string Salvar;
        public string Cancelar;

        public Produto() { this.Idioma = idioma.Portugues; Definir(); }
        public Produto(idioma Idioma) { this.Idioma = Idioma; Definir(); }

        private void Definir()
        {
            switch (Idioma)
            {
                case idioma.Portugues:
                    // listagem
                    this.Novo = "novo produto";
                    this.Excluir = "excluir selecionado(s)";
                    // registro
                    this.Geral = "Geral";
                    this.Nome = "Nome";
                    this.Marca = "Marca";
                    this.Fornecedor = "Fornecedor";
<<<<<<< HEAD
                    this.Cor = "Cor";
                    this.Codigo = "Código";
                    this.Categoria = "Categoria";
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
                    this.Destaque = "Destaque";
                    this.Lancamento = "Lançamento";
                    this.Status = "Status";
                    this.Manual = "Manual";
                    this.Video = "Vídeo";
                    this.Detalhes = "Detalhes do Produto";
<<<<<<< HEAD
                    this.Vitrines = "Vitrine";
=======
                    this.Vitrine = "Vitrine";
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
                    this.Caracteristicas = "Características";
                    this.Especificacoes = "Especificações Técnicas";
                    this.Comentarios = "Comentários / Avaliações";
                    // botão
                    this.Salvar = "salvar";
                    this.Cancelar = "cancelar";
                    break;
            }
        }
<<<<<<< HEAD

        public class Vitrine
        {
            private idioma Idioma;

            // listagem
            public string Novo;
            public string Excluir;
            // registro
            public string Geral;
            public string Tamanho;
            public string Cor;
            public string Codigo;
            public string Peso;
            public string Altura;
            public string Largura;
            public string Profundidade;
            public string Estoque;
            public string Status;
            public string Precos;
            public string Valor;
            public string Promocao;
            public string Imagens;
            // botão
            public string Salvar;
            public string Cancelar;

            public Vitrine() { this.Idioma = idioma.Portugues; Definir(); }
            public Vitrine(idioma Idioma) { this.Idioma = Idioma; Definir(); }

            private void Definir()
            {
                switch (Idioma)
                {
                    case idioma.Portugues:
                        // listagem
                        this.Novo = "novo produto";
                        this.Excluir = "excluir selecionado(s)";
                        // registro
                        this.Geral = "Geral";
                        this.Tamanho = "Tamanho";
                        this.Cor = "Cor";
                        this.Codigo = "Código";
                        this.Peso = "Peso";
                        this.Altura = "Altura";
                        this.Largura = "Largura";
                        this.Profundidade = "Profundidade";
                        this.Estoque = "Estoque";
                        this.Status = "Status";
                        this.Precos = "Preços";
                        this.Valor = "Valor";
                        this.Promocao = "Promoção";
                        this.Imagens = "Imagens";
                        // botão
                        this.Salvar = "salvar";
                        this.Cancelar = "cancelar";
                        break;
                }
            }
        }

        public class Caracteristica
        {
            private idioma Idioma;

            // listagem
            public string Novo;
            public string Excluir;
            // registro
            public string Geral;
            public string Nome;
            public string Valor;
            public string Filtro;
            // botão
            public string Salvar;
            public string Cancelar;

            public Caracteristica() { this.Idioma = idioma.Portugues; Definir(); }
            public Caracteristica(idioma Idioma) { this.Idioma = Idioma; Definir(); }

            private void Definir()
            {
                switch (Idioma)
                {
                    case idioma.Portugues:
                        // listagem
                        this.Novo = "nova característica";
                        this.Excluir = "excluir selecionado(s)";
                        // registro
                        this.Geral = "Geral";
                        this.Nome = "Nome";
                        this.Valor = "Valor";
                        this.Filtro = "Filtro";
                        // botão
                        this.Salvar = "salvar";
                        this.Cancelar = "cancelar";
                        break;
                }
            }
        }

        public class Especificacao
        {
            private idioma Idioma;

            // listagem
            public string Novo;
            public string Excluir;
            // registro
            public string Geral;
            public string Nome;
            public string Valor;
            public string Filtro;
            // botão
            public string Salvar;
            public string Cancelar;

            public Especificacao() { this.Idioma = idioma.Portugues; Definir(); }
            public Especificacao(idioma Idioma) { this.Idioma = Idioma; Definir(); }

            private void Definir()
            {
                switch (Idioma)
                {
                    case idioma.Portugues:
                        // listagem
                        this.Novo = "nova especificação";
                        this.Excluir = "excluir selecionado(s)";
                        // registro
                        this.Geral = "Geral";
                        this.Nome = "Nome";
                        this.Valor = "Valor";
                        this.Filtro = "Filtro";
                        // botão
                        this.Salvar = "salvar";
                        this.Cancelar = "cancelar";
                        break;
                }
            }
        }
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
    }
}