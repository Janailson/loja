using System;
using System.Collections.Generic;

namespace loja.Entity
{
    public class Categoria
    {
        private int idcategoria;
        public int IDCategoria
        {
            get { return idcategoria; }
            set { idcategoria = value; }
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

        private int parentid;
        public int parentId
        {
            get { return parentid; }
            set { parentid = value; }
        }

<<<<<<< HEAD
        private int nivel;
        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

        private int minnivel;
        public int MinNivel
        {
            get { return minnivel; }
            set { minnivel = value; }
        }

        private int maxnivel;
        public int MaxNivel
        {
            get { return maxnivel; }
            set { maxnivel = value; }
        }

=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
        private bool site;
        public bool Site
        {
            get { return site; }
            set { site = value; }
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

        private List<Entity.Dicionario> dicionarios;
        public List<Entity.Dicionario> Dicionarios
        {
            get { return dicionarios; }
            set { dicionarios = value; }
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