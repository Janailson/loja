using System;
using System.Collections.Generic;

namespace loja.Entity
{
    public class Tamanho
    {
        private int idtamanho;
        public int IDTamanho
        {
            get { return idtamanho; }
            set { idtamanho = value; }
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

        private List<Entity.Dicionario> dicionarios;
        public List<Entity.Dicionario> Dicionarios
        {
            get { return dicionarios; }
            set { dicionarios = value; }
        }
    }
}