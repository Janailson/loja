using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Admin
{
    public class TipoPessoa
    {
        #region SELECT

        public List<Entity.TipoPessoa> ListarTipoPessoa(int IDLoja)
        {
            string Sql = "SELECT IDTipoPessoa, Loja_ID, Nome, Status FROM loja.TipoPessoa WHERE Loja_ID=" + IDLoja;
            return new Data.TipoPessoa().Listar(Sql);
        }

        public Entity.TipoPessoa ConsultarTipoPessoa(object IDTipoPessoa)
        {
            string Sql = "SELECT IDTipoPessoa, Loja_ID, Nome, Status FROM loja.TipoPessoa WHERE IDTipoPessoa=" + IDTipoPessoa;
            return new Data.TipoPessoa().Consultar(Sql);
        }

        #endregion
    }
}