using System;

namespace loja.Idioma
{
    /// <summary>
    /// Pasta 'lojas'
    /// </summary>
    public class Loja
    {
        private idioma Idioma;

        /// <summary>
        /// Pasta 'perfis'
        /// </summary>
        public class Perfil : Loja
        {
            // listagem
            public string Novo;
            public string Excluir;
            // registro
            public string Geral;
            public string Nome;
            // botão
            public string Salvar;
            public string Cancelar;

            public Perfil() { this.Idioma = idioma.Portugues; Definir(); }
            public Perfil(idioma Idioma) { this.Idioma = Idioma; Definir(); }

            private void Definir()
            {
                switch (Idioma)
                {
                    case idioma.Portugues:
                        // listagem
                        Novo = "novo perfil";
                        Excluir = "excluir selecionado(s)";
                        // registro
                        Geral = "Geral";
                        Nome = "Nome";
                        // botão
                        Salvar = "salvar";
                        Cancelar = "cancelar";
                        break;
                }
            }
        }

        /// <summary>
        /// Pasta 'usuarios'
        /// </summary>
        public class Usuario : Loja
        {
            // listagem
            public string Novo;
            public string Excluir;
            // registro
            public string Geral;
            public string Perfil;
            public string Nome;
            public string Login;
            public string Senha;
            // botão
            public string Salvar;
            public string Cancelar;

            public Usuario() { this.Idioma = idioma.Portugues; Definir(); }
            public Usuario(idioma Idioma) { this.Idioma = Idioma; Definir(); }

            private void Definir()
            {
                switch (Idioma)
                {
                    case idioma.Portugues:
                        // listagem
                        this.Novo = "novo usuário";
                        this.Excluir = "excluir selecionado(s)";
                        // registro
                        this.Geral = "Geral";
                        this.Perfil = "Perfil";
                        this.Nome = "Nome";
                        this.Login = "Login";
                        this.Senha = "Senha";
                        // botão
                        this.Salvar = "salvar";
                        this.Cancelar = "cancelar";
                        break;
                }
            }
        }
    }
}