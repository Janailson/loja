using System;

namespace loja.Entity
{
    public class Usuario
    {
        public int IDUsuario { get; set; }
        public int Perfil_ID { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Locked { get; set; }
        public DateTime DataInclusao { get; set; }

        public class Master : Usuario
        {

        }

        public class Loja : Usuario
        {
            public int Loja_ID { get; set; }
        }
    }
}