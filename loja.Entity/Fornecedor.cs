using System;
using System.Collections.Generic;

namespace loja.Entity
{
    public class Fornecedor
    {
        private int idfornecedor;
        public int IDFornecedor
        {
            get { return idfornecedor; }
            set { idfornecedor = value; }
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