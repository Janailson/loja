using System;
using System.Collections.Generic;

namespace loja.Entity
{
    public class Loja
    {
        private int idloja;
        public int IDLoja
        {
            get { return idloja; }
            set { idloja = value; }
        }

        private string fantasia;
        public string Fantasia
        {
            get { return fantasia; }
            set { fantasia = value; }
        }

        private string razaosocial;
        public string RazaoSocial
        {
            get { return razaosocial; }
            set { razaosocial = value; }
        }

        private string cnpj;
        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }

        private string ie;
        public string Ie
        {
            get { return ie; }
            set { ie = value; }
        }

        private string telefone;
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string logo;
        public string Logo
        {
            get { return logo; }
            set { logo = value; }
        }

        private bool multiidioma;
        public bool Multiidioma
        {
            get { return multiidioma; }
            set { multiidioma = value; }
        }

        private string cor;
        public string Cor
        {
            get { return cor; }
            set { cor = value; }
        }

        private int parcela;
        public int Parcela
        {
            get { return parcela; }
            set { parcela = value; }
        }

        private decimal valorminimo;
        public decimal ValorMinimo
        {
            get { return valorminimo; }
            set { valorminimo = value; }
        }

        private string facebook;
        public string Facebook
        {
            get { return facebook; }
            set { facebook = value; }
        }

        private string twitter;
        public string Twitter
        {
            get { return twitter; }
            set { twitter = value; }
        }

        private string googleplus;
        public string GooglePlus
        {
            get { return googleplus; }
            set { googleplus = value; }
        }

        private string chat;
        public string Chat
        {
            get { return chat; }
            set { chat = value; }
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

        private List<Entity.Idioma> idiomas;
        public List<Entity.Idioma> Idiomas
        {
            get { return idiomas; }
            set { idiomas = value; }
        }
    }
}