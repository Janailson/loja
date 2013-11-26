using System;

namespace loja.Entity
{
    public class TipoPessoa
    {
        private int idtipopessoa;
        public int IDTipoPessoa
        {
            get { return idtipopessoa; }
            set { idtipopessoa = value; }
        }

        private int loja_id;
        public int Loja_ID
        {
            get { return loja_id; }
            set { loja_id = value; }
        }

        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private bool status;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        private DateTime datainclusao;
        public DateTime DataInclusao
        {
            get { return datainclusao; }
            set { datainclusao = value; }
        }
    }
}