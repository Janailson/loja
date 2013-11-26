using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace loja.Data
{
    public class Cliente : Generica
    {
        /// <summary>
        /// Lista os registros da tabela Cliente
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public List<Entity.Cliente> Listar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            List<Entity.Cliente> clientes = new List<Entity.Cliente>();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    Entity.Cliente cliente = new Entity.Cliente();
                    if (Coluna(oDr, "IDCliente")) cliente.IDCliente = (int)oDr["IDCliente"];
                    if (Coluna(oDr, "Loja_ID")) cliente.Loja_ID = (int)oDr["Loja_ID"];
                    if (Coluna(oDr, "TipoPessoa_ID")) cliente.TipoPessoa_ID = (int)oDr["TipoPessoa_ID"];
                    if (Coluna(oDr, "Tipo")) cliente.Tipo = oDr["Tipo"].ToString();
                    if (Coluna(oDr, "Nome")) cliente.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "Sobrenome")) cliente.Sobrenome = oDr["Sobrenome"].ToString();
                    if (Coluna(oDr, "RazaoSocial")) cliente.RazaoSocial = oDr["RazaoSocial"].ToString();
                    if (Coluna(oDr, "Cpf")) cliente.Cpf = oDr["Cpf"].ToString();
                    if (Coluna(oDr, "Cnpj")) cliente.Cnpj = oDr["Cnpj"].ToString();
                    if (Coluna(oDr, "Rg")) cliente.Rg = oDr["Rg"].ToString();
                    if (Coluna(oDr, "Ie")) cliente.Ie = oDr["Ie"].ToString();
                    if (Coluna(oDr, "Sexo")) cliente.Sexo = oDr["Sexo"].ToString();
                    if (Coluna(oDr, "Nascimento")) cliente.Nascimento = (DateTime)oDr["Nascimento"];
                    if (Coluna(oDr, "Telefone1")) cliente.Telefone1 = oDr["Telefone1"].ToString();
                    if (Coluna(oDr, "Telefone2")) cliente.Telefone2 = oDr["Telefone2"].ToString();
                    if (Coluna(oDr, "Email")) cliente.Email = oDr["Email"].ToString();
                    if (Coluna(oDr, "Senha")) cliente.Senha = oDr["Senha"].ToString();
                    if (Coluna(oDr, "Cep")) cliente.Cep = oDr["Cep"].ToString();
                    if (Coluna(oDr, "Endereco")) cliente.Endereco = oDr["Endereco"].ToString();
                    if (Coluna(oDr, "Numero")) cliente.Numero = oDr["Numero"].ToString();
                    if (Coluna(oDr, "Complemento")) cliente.Complemento = oDr["Complemento"].ToString();
                    if (Coluna(oDr, "Bairro")) cliente.Bairro = oDr["Bairro"].ToString();
                    if (Coluna(oDr, "Cidade")) cliente.Cidade = oDr["Cidade"].ToString();
                    if (Coluna(oDr, "Estado")) cliente.Estado = oDr["Estado"].ToString();
                    if (Coluna(oDr, "Referencia")) cliente.Referencia = oDr["Referencia"].ToString();
                    if (Coluna(oDr, "News")) cliente.News = (bool)oDr["News"];
                    if (Coluna(oDr, "DataInclusao")) cliente.DataInclusao = (DateTime)oDr["DataInclusao"];
                    clientes.Add(cliente);
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

            return clientes;
        }

        /// <summary>
        /// Consulta um registro da tabela Cliente
        /// </summary>
        /// <param name="Sql">Síntaxe Sql</param>
        /// <returns></returns>
        public Entity.Cliente Consultar(string Sql)
        {
            SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
            SqlCommand oComm = new SqlCommand(Sql, oConn);

            SqlDataReader oDr;

            Entity.Cliente cliente = new Entity.Cliente();
            try
            {
                oConn.Open();
                oDr = oComm.ExecuteReader();

                while (oDr.Read())
                {
                    if (Coluna(oDr, "IDCliente")) cliente.IDCliente = (int)oDr["IDCliente"];
                    if (Coluna(oDr, "Loja_ID")) cliente.Loja_ID = (int)oDr["Loja_ID"];
                    if (Coluna(oDr, "TipoPessoa_ID")) cliente.TipoPessoa_ID = (int)oDr["TipoPessoa_ID"];
                    if (Coluna(oDr, "Tipo")) cliente.Tipo = oDr["Tipo"].ToString();
                    if (Coluna(oDr, "Nome")) cliente.Nome = oDr["Nome"].ToString();
                    if (Coluna(oDr, "Sobrenome")) cliente.Sobrenome = oDr["Sobrenome"].ToString();
                    if (Coluna(oDr, "RazaoSocial")) cliente.RazaoSocial = oDr["RazaoSocial"].ToString();
                    if (Coluna(oDr, "Cpf")) cliente.Cpf = oDr["Cpf"].ToString();
                    if (Coluna(oDr, "Cnpj")) cliente.Cnpj = oDr["Cnpj"].ToString();
                    if (Coluna(oDr, "Rg")) cliente.Rg = oDr["Rg"].ToString();
                    if (Coluna(oDr, "Ie")) cliente.Ie = oDr["Ie"].ToString();
                    if (Coluna(oDr, "Sexo")) cliente.Sexo = oDr["Sexo"].ToString();
                    if (Coluna(oDr, "Nascimento")) cliente.Nascimento = (DateTime)oDr["Nascimento"];
                    if (Coluna(oDr, "Telefone1")) cliente.Telefone1 = oDr["Telefone1"].ToString();
                    if (Coluna(oDr, "Telefone2")) cliente.Telefone2 = oDr["Telefone2"].ToString();
                    if (Coluna(oDr, "Email")) cliente.Email = oDr["Email"].ToString();
                    if (Coluna(oDr, "Senha")) cliente.Senha = oDr["Senha"].ToString();
                    if (Coluna(oDr, "Cep")) cliente.Cep = oDr["Cep"].ToString();
                    if (Coluna(oDr, "Endereco")) cliente.Endereco = oDr["Endereco"].ToString();
                    if (Coluna(oDr, "Numero")) cliente.Numero = oDr["Numero"].ToString();
                    if (Coluna(oDr, "Complemento")) cliente.Complemento = oDr["Complemento"].ToString();
                    if (Coluna(oDr, "Bairro")) cliente.Bairro = oDr["Bairro"].ToString();
                    if (Coluna(oDr, "Cidade")) cliente.Cidade = oDr["Cidade"].ToString();
                    if (Coluna(oDr, "Estado")) cliente.Estado = oDr["Estado"].ToString();
                    if (Coluna(oDr, "Referencia")) cliente.Referencia = oDr["Referencia"].ToString();
                    if (Coluna(oDr, "News")) cliente.News = (bool)oDr["News"];
                    if (Coluna(oDr, "DataInclusao")) cliente.DataInclusao = (DateTime)oDr["DataInclusao"];
                    cliente.Entregas = new Data.Cliente.Entrega().Listar("SELECT IDEntrega, Cliente_ID, Nome, Cep, Endereco, Numero, Complemento, Bairro, Cidade, Estado, Referencia, DataInclusao FROM Entrega WHERE Cliente_ID=" + cliente.IDCliente);
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

            return cliente;
        }

        public class Entrega : Generica
        {
            /// <summary>
            /// Lista os registros da tabela Entrega
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public List<Entity.Cliente.Entrega> Listar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                List<Entity.Cliente.Entrega> entregas = new List<Entity.Cliente.Entrega>();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        Entity.Cliente.Entrega entrega = new Entity.Cliente.Entrega();
                        if (Coluna(oDr, "IDEntrega")) entrega.IDEntrega = (int)oDr["IDEntrega"];
                        if (Coluna(oDr, "Cliente_ID")) entrega.Cliente_ID = (int)oDr["Cliente_ID"];
                        if (Coluna(oDr, "Nome")) entrega.Nome = oDr["Nome"].ToString();
                        if (Coluna(oDr, "Cep")) entrega.Cep = oDr["Cep"].ToString();
                        if (Coluna(oDr, "Endereco")) entrega.Endereco = oDr["Endereco"].ToString();
                        if (Coluna(oDr, "Numero")) entrega.Numero = oDr["Numero"].ToString();
                        if (Coluna(oDr, "Complemento")) entrega.Complemento = oDr["Complemento"].ToString();
                        if (Coluna(oDr, "Bairro")) entrega.Bairro = oDr["Bairro"].ToString();
                        if (Coluna(oDr, "Cidade")) entrega.Cidade = oDr["Cidade"].ToString();
                        if (Coluna(oDr, "Estado")) entrega.Estado = oDr["Estado"].ToString();
                        if (Coluna(oDr, "Referencia")) entrega.Referencia = oDr["Referencia"].ToString();
                        if (Coluna(oDr, "DataInclusao")) entrega.DataInclusao = (DateTime)oDr["DataInclusao"];
                        entregas.Add(entrega);
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

                return entregas;
            }

            /// <summary>
            /// Consulta um registro da tabela Entrega
            /// </summary>
            /// <param name="Sql">Síntaxe Sql</param>
            /// <returns></returns>
            public Entity.Cliente.Entrega Consultar(string Sql)
            {
                SqlConnection oConn = new SqlConnection(oConexao.ConexaoBancoDeDados);
                SqlCommand oComm = new SqlCommand(Sql, oConn);

                SqlDataReader oDr;

                Entity.Cliente.Entrega entrega = new Entity.Cliente.Entrega();
                try
                {
                    oConn.Open();
                    oDr = oComm.ExecuteReader();

                    while (oDr.Read())
                    {
                        if (Coluna(oDr, "IDEntrega")) entrega.IDEntrega = (int)oDr["IDEntrega"];
                        if (Coluna(oDr, "Cliente_ID")) entrega.Cliente_ID = (int)oDr["Cliente_ID"];
                        if (Coluna(oDr, "Nome")) entrega.Nome = oDr["Nome"].ToString();
                        if (Coluna(oDr, "Cep")) entrega.Cep = oDr["Cep"].ToString();
                        if (Coluna(oDr, "Endereco")) entrega.Endereco = oDr["Endereco"].ToString();
                        if (Coluna(oDr, "Numero")) entrega.Numero = oDr["Numero"].ToString();
                        if (Coluna(oDr, "Complemento")) entrega.Complemento = oDr["Complemento"].ToString();
                        if (Coluna(oDr, "Bairro")) entrega.Bairro = oDr["Bairro"].ToString();
                        if (Coluna(oDr, "Cidade")) entrega.Cidade = oDr["Cidade"].ToString();
                        if (Coluna(oDr, "Estado")) entrega.Estado = oDr["Estado"].ToString();
                        if (Coluna(oDr, "Referencia")) entrega.Referencia = oDr["Referencia"].ToString();
                        if (Coluna(oDr, "DataInclusao")) entrega.DataInclusao = (DateTime)oDr["DataInclusao"];
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

                return entrega;
            }
        }
    }
}