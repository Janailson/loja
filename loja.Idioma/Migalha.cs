using System;

namespace loja.Idioma
{
    public class Migalha
    {
        private idioma Idioma;
        public string Dashboard;

        /// <summary>
        /// Master > Loja
        /// </summary>
        public class Loja : Migalha
        {
            public string Lojas;
            public string NovaLoja;

            /// <summary>
            /// Master > Loja > Usuário
            /// </summary>
            public class Usuario : Loja
            {
                public string Usuarios;
                public string NovoUsuario;

                public Usuario() { this.Idioma = idioma.Portugues; Definir(); }
                public Usuario(idioma Idioma) { this.Idioma = Idioma; Definir(); }

                private void Definir()
                {
                    switch (Idioma)
                    {
                        case idioma.Portugues:
                            this.Dashboard = "Dashboard";
                            this.Lojas = "Lojas";
                            this.NovaLoja = "Nova Loja";
                            this.Usuarios = "Usuários";
                            this.NovoUsuario = "Novo Usuário";
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Loja > Categoria
        /// </summary>
        public class Categoria : Migalha
        {
            public string Categorias;
            public string NovaCategoria;

            public Categoria() { this.Idioma = idioma.Portugues; Definir(); }
            public Categoria(idioma Idioma) { this.Idioma = Idioma; Definir(); }

            private void Definir()
            {
                switch (Idioma)
                {
                    case idioma.Portugues:
                        this.Dashboard = "Dashboard";
                        this.Categorias = "Categorias";
                        this.NovaCategoria = "Nova Categoria";
                        break;
                }
            }
        }

        /// <summary>
        /// Produto > Fornecedor
        /// </summary>
        public class Fornecedor : Migalha
        {
            public string Fornecedores;
            public string NovoFornecedor;

            public Fornecedor() { this.Idioma = idioma.Portugues; Definir(); }
            public Fornecedor(idioma Idioma) { this.Idioma = Idioma; Definir(); }

            private void Definir()
            {
                switch (Idioma)
                {
                    case idioma.Portugues:
                        this.Dashboard = "Dashboard";
                        this.Fornecedores = "Fornecedores";
                        this.NovoFornecedor = "Novo Fornecedor";
                        break;
                }
            }
        }

        /// <summary>
        /// Produto > Marca
        /// </summary>
        public class Marca : Migalha
        {
            public string Marcas;
            public string NovaMarca;

            public Marca() { this.Idioma = idioma.Portugues; Definir(); }
            public Marca(idioma Idioma) { this.Idioma = Idioma; Definir(); }

            private void Definir()
            {
                switch (Idioma)
                {
                    case idioma.Portugues:
                        this.Dashboard = "Dashboard";
                        this.Marcas = "Marcas";
                        this.NovaMarca = "Nova Marca";
                        break;
                }
            }
        }

        /// <summary>
        /// Produto > Cor
        /// </summary>
        public class Cor : Migalha
        {
            public string Cores;
            public string NovaCor;

            public Cor() { this.Idioma = idioma.Portugues; Definir(); }
            public Cor(idioma Idioma) { this.Idioma = Idioma; Definir(); }

            private void Definir()
            {
                switch (Idioma)
                {
                    case idioma.Portugues:
                        this.Dashboard = "Dashboard";
                        this.Cores = "Cores";
                        this.NovaCor = "Nova Cor";
                        break;
                }
            }
        }

        /// <summary>
        /// Produto > Tamanho
        /// </summary>
        public class Tamanho : Migalha
        {
            public string Tamanhos;
            public string NovoTamanho;

            public Tamanho() { this.Idioma = idioma.Portugues; Definir(); }
            public Tamanho(idioma Idioma) { this.Idioma = Idioma; Definir(); }

            private void Definir()
            {
                switch (Idioma)
                {
                    case idioma.Portugues:
                        this.Dashboard = "Dashboard";
                        this.Tamanhos = "Tamanhos";
                        this.NovoTamanho = "Novo Tamanho";
                        break;
                }
            }
        }

        /// <summary>
        /// Produto > Produto
        /// </summary>
        public class Produto : Migalha
        {
            public string Produtos;
            public string NovoProduto;

            public Produto() { this.Idioma = idioma.Portugues; Definir(); }
            public Produto(idioma Idioma) { this.Idioma = Idioma; Definir(); }

            private void Definir()
            {
                switch (Idioma)
                {
                    case idioma.Portugues:
                        this.Dashboard = "Dashboard";
                        this.Produtos = "Produtos";
                        this.NovoProduto = "Novo Produto";
                        break;
                }
            }
<<<<<<< HEAD

            public class Vitrine : Migalha
            {
                public string Vitrines;
                public string NovaVitrine;

                public Vitrine() { this.Idioma = idioma.Portugues; Definir(); }
                public Vitrine(idioma Idioma) { this.Idioma = Idioma; Definir(); }

                private void Definir()
                {
                    switch (Idioma)
                    {
                        case idioma.Portugues:
                            this.Dashboard = "Dashboard";
                            this.Vitrines = "Vitrines";
                            this.NovaVitrine = "Nova Vitrine";
                            break;
                    }
                }
            }

            public class Caracteristica : Migalha
            {
                public string Caracteristicas;
                public string NovaCaracteristica;

                public Caracteristica() { this.Idioma = idioma.Portugues; Definir(); }
                public Caracteristica(idioma Idioma) { this.Idioma = Idioma; Definir(); }

                private void Definir()
                {
                    switch (Idioma)
                    {
                        case idioma.Portugues:
                            this.Dashboard = "Dashboard";
                            this.Caracteristicas = "Características";
                            this.NovaCaracteristica = "Nova Característica";
                            break;
                    }
                }
            }

            public class Especificacao : Migalha
            {
                public string Especificacoes;
                public string NovaEspecificacao;

                public Especificacao() { this.Idioma = idioma.Portugues; Definir(); }
                public Especificacao(idioma Idioma) { this.Idioma = Idioma; Definir(); }

                private void Definir()
                {
                    switch (Idioma)
                    {
                        case idioma.Portugues:
                            this.Dashboard = "Dashboard";
                            this.Especificacoes = "Especificações";
                            this.NovaEspecificacao = "Nova Especificação";
                            break;
                    }
                }
            }
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
        }
    }
}