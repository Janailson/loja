using System;

namespace loja.Entity
{
    public class Retorno
    {
        private bool status;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        private string erro;
        public string Erro
        {
            get { return erro; }
            set { erro = value; }
        }

        private int identity;
        public int Identity
        {
            get { return identity; }
            set { identity = value; }
        }
    }
}