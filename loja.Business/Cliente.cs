using System;
using System.Collections.Generic;
using System.Text;

namespace loja.Business
{
    public class Cliente
    {
        #region SELECT

        public Entity.Cliente ConsultarCliente(int IDLoja, string Email, string Senha)
        {
            string Sql = "SELECT IDCliente, Loja_ID, TipoPessoa_ID, Tipo, Nome, Sobrenome, RazaoSocial, Cpf, Cnpj, Rg, Ie, Sexo, Nascimento, Telefone1, Telefone2, Email, Senha, Cep, Endereco, Numero, Complemento, Bairro, Cidade, Estado, Referencia, News, DataInclusao FROM Cliente WHERE Loja_ID=" + IDLoja + " AND Email='" + Email + "' AND Senha='" + Senha + "'";
            return new Data.Cliente().Consultar(Sql);
        }

        #endregion

        #region INSERT, UPDATE, DELETE

        public Entity.Retorno InserirCliente(Entity.Cliente cliente)
        {
            string Sql = "INSERT INTO Cliente (Loja_ID,TipoPessoa_ID,Tipo,Nome,Sobrenome,RazaoSocial,Cpf,Cnpj,Rg,Ie,Sexo,Nascimento,Telefone1,Telefone2,Email,Senha,Cep,Endereco,Numero,Complemento,Bairro,Cidade,Estado,Referencia,News) VALUES ('" + cliente.Loja_ID + "','" + cliente.TipoPessoa_ID + "','" + cliente.Tipo + "','" + cliente.Nome + "','" + cliente.Sobrenome + "','" + cliente.RazaoSocial + "','" + cliente.Cpf + "','" + cliente.Cnpj + "','" + cliente.Rg + "','" + cliente.Ie + "','" + cliente.Sexo + "'," + (cliente.Nascimento != DateTime.MinValue ? "'" + cliente.Nascimento.ToString("yyyy-MM-dd") + "'" : "NULL") + ",'" + cliente.Telefone1 + "','" + cliente.Telefone2 + "','" + cliente.Email + "','" + cliente.Senha + "','" + cliente.Cep + "','" + cliente.Endereco + "','" + cliente.Numero + "','" + cliente.Complemento + "','" + cliente.Bairro + "','" + cliente.Cidade + "','" + cliente.Estado + "','" + cliente.Referencia + "','" + cliente.News + "')";
            return new Data.Cliente().Inserir(Sql);
        }

        public Entity.Retorno AlterarCliente(Entity.Cliente cliente)
        {
            string Sql = "UPDATE Cliente SET Nome='" + cliente.Nome + "', Sobrenome='" + cliente.Sobrenome + "', RazaoSocial='" + cliente.RazaoSocial + "', Telefone1='" + cliente.Telefone1 + "', Telefone2='" + cliente.Telefone2 + "', Cep='" + cliente.Cep + "', Endereco='" + cliente.Endereco + "', Numero='" + cliente.Numero + "', Complemento='" + cliente.Complemento + "', Bairro='" + cliente.Bairro + "', Cidade='" + cliente.Cidade + "', Estado='" + cliente.Estado + "', Referencia='" + cliente.Referencia + "', News='" + cliente.News + "' WHERE IDCliente=" + cliente.IDCliente;
            return new Data.Cliente().Alterar(Sql);
        }

        #endregion

        public class Entrega
        {
            #region INSERT, UPDATE, DELETE

            public Entity.Retorno InserirEntrega(Entity.Cliente.Entrega entrega)
            {
                string Sql = "INSERT INTO Entrega (Cliente_ID,Nome,Cep,Endereco,Numero,Complemento,Bairro,Cidade,Estado,Referencia) VALUES ('" + entrega.Cliente_ID + "','" + entrega.Nome + "','" + entrega.Cep + "','" + entrega.Endereco + "','" + entrega.Numero + "','" + entrega.Complemento + "','" + entrega.Bairro + "','" + entrega.Cidade + "','" + entrega.Estado + "','" + entrega.Referencia + "')";
                return new Data.Cliente.Entrega().Inserir(Sql);
            }

            public Entity.Retorno AlterarEntrega(Entity.Cliente.Entrega entrega)
            {
                string Sql = "UPDATE Entrega SET Nome='" + entrega.Nome + "', Cep='" + entrega.Cep + "', Endereco='" + entrega.Endereco + "', Numero='" + entrega.Numero + "', Complemento='" + entrega.Complemento + "', Bairro='" + entrega.Bairro + "', Cidade='" + entrega.Cidade + "', Estado='" + entrega.Estado + "', Referencia='" + entrega.Referencia + "' WHERE IDEntrega=" + entrega.IDEntrega;
                return new Data.Cliente.Entrega().Alterar(Sql);
            }

            public Entity.Retorno ExcluirEntrega(object IDEntrega)
            {
                string Sql = "DELETE FROM Entrega WHERE IDEntrega=" + IDEntrega;
                return new Data.Cliente.Entrega().Alterar(Sql);
            }

            #endregion
        }
    }
}