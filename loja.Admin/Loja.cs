using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Admin
{
    public class Loja
    {
        #region SELECT

        public List<Entity.Loja> ListarLoja(string Busca)
        {
            string Sql = "SELECT IDLoja, Fantasia, RazaoSocial, Cnpj, Ie, Telefone, Email, Logo, Multiidioma, Cor, Parcela, ValorMinimo, Facebook, Twitter, GooglePlus, Chat, Status, DataInclusao FROM Loja WHERE Fantasia LIKE '%" + Busca + "%' OR RazaoSocial LIKE '%" + Busca + "%'";
            return new Data.Loja().Listar(Sql);
        }

        public Entity.Loja ConsultarLoja(object IDLoja)
        {
            string Sql = "SELECT IDLoja, Fantasia, RazaoSocial, Cnpj, Ie, Telefone, Email, Logo, Multiidioma, Cor, Parcela, ValorMinimo, Facebook, Twitter, GooglePlus, Chat, Status, DataInclusao FROM Loja WHERE IDLoja=" + IDLoja;
            return new Data.Loja().Consultar(Sql);
        }

        #endregion

        #region INSERT, UPDATE, DELETE

        public Entity.Retorno InserirLoja(Entity.Loja loja)
        {
            string Sql = "INSERT INTO Loja (Fantasia,RazaoSocial,Cnpj,Ie,Telefone,Email,Logo,Multiidioma,Cor,Parcela,ValorMinimo,Facebook,Twitter,GooglePlus,Chat,Status) VALUES ('" + loja.Fantasia + "','" + loja.RazaoSocial + "','" + loja.Cnpj.Replace(".", "").Replace("/", "").Replace("-", "") + "','" + loja.Ie + "','" + loja.Telefone + "','" + loja.Email + "','" + loja.Logo + "','" + loja.Multiidioma + "','" + loja.Cor + "','" + loja.Parcela + "','" + loja.ValorMinimo.ToString().Replace(",", ".") + "','" + loja.Facebook + "','" + loja.Twitter + "','" + loja.GooglePlus + "','" + loja.Chat + "','" + loja.Status + "')";
            return new Data.Loja().Inserir(Sql);
        }

        public Entity.Retorno AlterarLoja(Entity.Loja loja)
        {
            string Sql = "UPDATE Loja SET Fantasia='" + loja.Fantasia + "', RazaoSocial='" + loja.RazaoSocial + "', Cnpj='" + loja.Cnpj.Replace(".", "").Replace("/", "").Replace("-", "") + "', Ie='" + loja.Ie + "', Telefone='" + loja.Telefone + "', Email='" + loja.Email + "', Multiidioma='" + loja.Multiidioma + "', Cor='" + loja.Cor + "', Parcela='" + loja.Parcela + "', ValorMinimo=" + loja.ValorMinimo.ToString().Replace(",", ".") + ", Facebook='" + loja.Facebook + "', Twitter='" + loja.Twitter + "', GooglePlus='" + loja.GooglePlus + "', Chat='" + loja.Chat + "', Status='" + loja.Status + "' WHERE IDLoja=" + loja.IDLoja;
            return new Data.Loja().Alterar(Sql);
        }

        public Entity.Retorno AlterarLogo(Entity.Loja loja)
        {
            string Sql = "UPDATE Loja SET Logo='" + loja.Logo + "' WHERE IDLoja=" + loja.IDLoja;
            return new Data.Loja().Alterar(Sql);
        }

        public Entity.Retorno ExcluirLoja(object IDLoja)
        {
            string Sql = "DELETE FROM Loja WHERE IDLoja=" + IDLoja;
            return new Data.Loja().Alterar(Sql);
        }

        #endregion

        public class Idioma
        {
            #region INSERT, UPDATE, DELETE

            public Entity.Retorno InserirIdioma(object IDLoja, object IDIdioma)
            {
                string Sql = "INSERT INTO Idioma (Loja_ID,Idioma_ID) VALUES (" + IDLoja + "," + IDIdioma + ")";
                return new Data.Loja.Idioma().Alterar(Sql);
            }

            public Entity.Retorno ExcluirIdioma(object IDLoja)
            {
                string Sql = "DELETE FROM Idioma WHERE Loja_ID=" + IDLoja;
                return new Data.Loja.Idioma().Alterar(Sql);
            }

            #endregion
        }
    }
}