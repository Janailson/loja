using System;

namespace loja.Entity
{
    public class Perfil
    {
        public int IDPerfil { get; set; }
        public string Nome { get; set; }
        public bool Locked { get; set; }
        public DateTime DataInclusao { get; set; }

        public class Master : Perfil
        {

        }

        public class Loja : Perfil
        {
            public int Loja_ID { get; set; }
        }
    }
}