using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739

namespace loja.Entity
{
    public class Marca
    {
        private int idmarca;
        public int IDMarca
        {
            get { return idmarca; }
            set { idmarca = value; }
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

        private string logo;
        public string Logo
        {
            get { return logo; }
            set { logo = value; }
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
<<<<<<< HEAD

        private int produtos;
        public int Produtos
        {
            get { return produtos; }
            set { produtos = value; }
        }
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
    }
}