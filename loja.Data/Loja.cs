using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace loja.Data
{
    public class Loja : Generica
    {
        /// <summary>
        /// Lista os registros da tabela Loja
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public List<Entity.Loja> Listar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            List<Entity.Loja> lojas = new List<Entity.Loja>();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    Entity.Loja loja = new Entity.Loja();
                    if (Coluna(oDr, "IDLoja")) loja.IDLoja = (int)oDr["IDLoja"];
                    if (Coluna(oDr, "Fantasia")) loja.Fantasia = oDr["Fantasia"].ToString();
                    if (Coluna(oDr, "RazaoSocial")) loja.RazaoSocial = oDr["RazaoSocial"].ToString();
                    if (Coluna(oDr, "Cnpj")) loja.Cnpj = oDr["Cnpj"].ToString();
                    if (Coluna(oDr, "Ie")) loja.Ie = oDr["Ie"].ToString();
                    if (Coluna(oDr, "Telefone")) loja.Telefone = oDr["Telefone"].ToString();
                    if (Coluna(oDr, "Email")) loja.Email = oDr["Email"].ToString();
                    if (Coluna(oDr, "Logo")) loja.Logo = oDr["Logo"].ToString();
                    if (Coluna(oDr, "Multiidioma")) loja.Multiidioma = (bool)oDr["Multiidioma"];
                    if (Coluna(oDr, "Cor")) loja.Cor = oDr["Cor"].ToString();
                    if (Coluna(oDr, "Parcela")) loja.Parcela = (int)oDr["Parcela"];
                    if (Coluna(oDr, "ValorMinimo")) loja.ValorMinimo = (decimal)oDr["ValorMinimo"];
                    if (Coluna(oDr, "Facebook")) loja.Facebook = oDr["Facebook"].ToString();
                    if (Coluna(oDr, "Twitter")) loja.Twitter = oDr["Twitter"].ToString();
                    if (Coluna(oDr, "GooglePlus")) loja.GooglePlus = oDr["GooglePlus"].ToString();
                    if (Coluna(oDr, "Chat")) loja.Chat = oDr["Chat"].ToString();
                    if (Coluna(oDr, "Status")) loja.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "DataInclusao")) loja.DataInclusao = (DateTime)oDr["DataInclusao"];
                    lojas.Add(loja);
                }
            }
            catch (Exception e)
            {
                new Log(e);
            }
            finally
            {
                oDr = null;
                oComm = null;
                oConn.Close();
            }

            return lojas;
        }

        /// <summary>
        /// Consulta um registro da tabela Loja
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public Entity.Loja Consultar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            Entity.Loja loja = new Entity.Loja();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    if (Coluna(oDr, "IDLoja")) loja.IDLoja = (int)oDr["IDLoja"];
                    if (Coluna(oDr, "Fantasia")) loja.Fantasia = oDr["Fantasia"].ToString();
                    if (Coluna(oDr, "RazaoSocial")) loja.RazaoSocial = oDr["RazaoSocial"].ToString();
                    if (Coluna(oDr, "Cnpj")) loja.Cnpj = oDr["Cnpj"].ToString();
                    if (Coluna(oDr, "Ie")) loja.Ie = oDr["Ie"].ToString();
                    if (Coluna(oDr, "Telefone")) loja.Telefone = oDr["Telefone"].ToString();
                    if (Coluna(oDr, "Email")) loja.Email = oDr["Email"].ToString();
                    if (Coluna(oDr, "Logo")) loja.Logo = oDr["Logo"].ToString();
                    if (Coluna(oDr, "Multiidioma")) loja.Multiidioma = (bool)oDr["Multiidioma"];
                    if (Coluna(oDr, "Cor")) loja.Cor = oDr["Cor"].ToString();
                    if (Coluna(oDr, "Parcela")) loja.Parcela = (int)oDr["Parcela"];
                    if (Coluna(oDr, "ValorMinimo")) loja.ValorMinimo = (decimal)oDr["ValorMinimo"];
                    if (Coluna(oDr, "Facebook")) loja.Facebook = oDr["Facebook"].ToString();
                    if (Coluna(oDr, "Twitter")) loja.Twitter = oDr["Twitter"].ToString();
                    if (Coluna(oDr, "GooglePlus")) loja.GooglePlus = oDr["GooglePlus"].ToString();
                    if (Coluna(oDr, "Chat")) loja.Chat = oDr["Chat"].ToString();
                    if (Coluna(oDr, "Status")) loja.Status = (bool)oDr["Status"];
                    if (Coluna(oDr, "DataInclusao")) loja.DataInclusao = (DateTime)oDr["DataInclusao"];
                    loja.Idiomas = new Data.Idioma().Listar("SELECT i1.IDIdioma, i1.Nome, i1.Codigo, i1.DataInclusao FROM master.Idioma i1 INNER JOIN loja.Idioma i2 ON i2.Idioma_ID=i1.IDIdioma WHERE i2.Loja_ID=" + loja.IDLoja + " ORDER BY Ordem ASC");
                }
            }
            catch (Exception e)
            {
                new Log(e);
            }
            finally
            {
                oDr = null;
                oComm = null;
                oConn.Close();
            }

            return loja;
        }

        public class Idioma : Generica
        {

        }
    }
}