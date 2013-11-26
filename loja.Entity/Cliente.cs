using System;
using System.Collections.Generic;

namespace loja.Entity
{
    public class Cliente
    {
        private int idcliente;
        public int IDCliente
        {
            get { return idcliente; }
            set { idcliente = value; }
        }

        private int loja_id;
        public int Loja_ID
        {
            get { return loja_id; }
            set { loja_id = value; }
        }

        private int tipopessoa_id;
        public int TipoPessoa_ID
        {
            get { return tipopessoa_id; }
            set { tipopessoa_id = value; }
        }

        private string tipo;
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private string sobrenome;
        public string Sobrenome
        {
            get { return sobrenome; }
            set { sobrenome = value; }
        }

        private string razaosocial;
        public string RazaoSocial
        {
            get { return razaosocial; }
            set { razaosocial = value; }
        }

        private string cpf;
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        private string cnpj;
        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }

        private string rg;
        public string Rg
        {
            get { return rg; }
            set { rg = value; }
        }

        private string ie;
        public string Ie
        {
            get { return ie; }
            set { ie = value; }
        }

        private string sexo;
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        private DateTime nascimento;
        public DateTime Nascimento
        {
            get { return nascimento; }
            set { nascimento = value; }
        }

        private string telefone1;
        public string Telefone1
        {
            get { return telefone1; }
            set { telefone1 = value; }
        }

        private string telefone2;
        public string Telefone2
        {
            get { return telefone2; }
            set { telefone2 = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        private string cep;
        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        private string endereco;
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        private string numero;
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private string complemento;
        public string Complemento
        {
            get { return complemento; }
            set { complemento = value; }
        }

        private string bairro;
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        private string cidade;
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        private string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private string referencia;
        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        private bool news;
        public bool News
        {
            get { return news; }
            set { news = value; }
        }

        private DateTime datainclusao;
        public DateTime DataInclusao
        {
            get { return datainclusao; }
            set { datainclusao = value; }
        }

        private List<Entity.Cliente.Entrega> entregas;
        public List<Entity.Cliente.Entrega> Entregas
        {
            get { return entregas; }
            set { entregas = value; }
        }

        public class Entrega
        {
            private int identrega;
            public int IDEntrega
            {
                get { return identrega; }
                set { identrega = value; }
            }

            private int cliente_id;
            public int Cliente_ID
            {
                get { return cliente_id; }
                set { cliente_id = value; }
            }

            private string nome;
            public string Nome
            {
                get { return nome; }
                set { nome = value; }
            }

            private string cep;
            public string Cep
            {
                get { return cep; }
                set { cep = value; }
            }

            private string endereco;
            public string Endereco
            {
                get { return endereco; }
                set { endereco = value; }
            }

            private string numero;
            public string Numero
            {
                get { return numero; }
                set { numero = value; }
            }

            private string complemento;
            public string Complemento
            {
                get { return complemento; }
                set { complemento = value; }
            }

            private string bairro;
            public string Bairro
            {
                get { return bairro; }
                set { bairro = value; }
            }

            private string cidade;
            public string Cidade
            {
                get { return cidade; }
                set { cidade = value; }
            }

            private string estado;
            public string Estado
            {
                get { return estado; }
                set { estado = value; }
            }

            private string referencia;
            public string Referencia
            {
                get { return referencia; }
                set { referencia = value; }
            }

            private DateTime datainclusao;
            public DateTime DataInclusao
            {
                get { return datainclusao; }
                set { datainclusao = value; }
            }
        }
    }
}