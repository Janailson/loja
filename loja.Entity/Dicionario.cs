using System;

namespace loja.Entity
{
    public class Dicionario
    {
        private int idioma_id;
        public int Idioma_ID
        {
            get { return idioma_id; }
            set { idioma_id = value; }
        }

        private string tabela;
        public string Tabela
        {
            get { return tabela; }
            set { tabela = value; }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string descricao;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        private string valor;
        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public Dicionario() { }

        public Dicionario(int Idioma_ID, string Tabela, int Id, string Descricao, string Valor)
        {
            this.Idioma_ID = Idioma_ID;
            this.Tabela = Tabela;
            this.Id = Id;
            this.Descricao = Descricao;
            this.Valor = Valor;
        }
    }
}