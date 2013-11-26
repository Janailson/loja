<<<<<<< HEAD
﻿
using System;
=======
﻿using System;
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
using System.Collections.Generic;

namespace loja.Entity
{
    public class Produto
    {
        private int idproduto;
        public int IDProduto
        {
            get { return idproduto; }
            set { idproduto = value; }
        }

        private int loja_id;
        public int Loja_ID
        {
            get { return loja_id; }
            set { loja_id = value; }
        }

        private int marca_id;
        public int Marca_ID
        {
            get { return marca_id; }
            set { marca_id = value; }
        }

        private int fornecedor_id;
        public int Fornecedor_ID
        {
            get { return fornecedor_id; }
            set { fornecedor_id = value; }
        }

<<<<<<< HEAD
        private int cor_id;
        public int Cor_ID
        {
            get { return cor_id; }
            set { cor_id = value; }
        }

        private string codigo;
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
        private bool destaque;
        public bool Destaque
        {
            get { return destaque; }
            set { destaque = value; }
        }

        private bool lancamento;
        public bool Lancamento
        {
            get { return lancamento; }
            set { lancamento = value; }
        }

        private bool status;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        private string manual;
        public string Manual
        {
            get { return manual; }
            set { manual = value; }
        }

        private string video;
        public string Video
        {
            get { return video; }
            set { video = value; }
        }

        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private string marca;
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        private string fornecedor;
        public string Fornecedor
        {
            get { return fornecedor; }
            set { fornecedor = value; }
        }

<<<<<<< HEAD
        private string cor;
        public string Cor
        {
            get { return cor; }
            set { cor = value; }
        }

        private string imagemproduto;
        public string ImagemProduto
        {
            get { return imagemproduto; }
            set { imagemproduto = value; }
        }

=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
        private string detalhe;
        public string Detalhe
        {
            get { return detalhe; }
            set { detalhe = value; }
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

        private List<Entity.Produto.Imagem> imagens;
        public List<Entity.Produto.Imagem> Imagens
        {
            get { return imagens; }
            set { imagens = value; }
        }

        private List<Entity.Produto.Preco> precos;
        public List<Entity.Produto.Preco> Precos
        {
            get { return precos; }
            set { precos = value; }
        }

        private List<Entity.Produto.Caracteristica> caracteristicas;
        public List<Entity.Produto.Caracteristica> Caracteristicas
        {
            get { return caracteristicas; }
            set { caracteristicas = value; }
        }

        private List<Entity.Produto.Especificacao> especificacoes;
        public List<Entity.Produto.Especificacao> Especificacoes
        {
            get { return especificacoes; }
            set { especificacoes = value; }
        }

        public class Imagem
        {
            private int idprodutoimagem;
            public int IDProdutoImagem
            {
                get { return idprodutoimagem; }
                set { idprodutoimagem = value; }
            }

            private int produto_id;
            public int Produto_ID
            {
                get { return produto_id; }
                set { produto_id = value; }
            }

            private string arquivo;
            public string Arquivo
            {
                get { return arquivo; }
                set { arquivo = value; }
            }

            private int ordem;
            public int Ordem
            {
                get { return ordem; }
                set { ordem = value; }
            }
        }

        public class Preco
        {
            private int idprodutopreco;
            public int IDProdutoPreco
            {
                get { return idprodutopreco; }
                set { idprodutopreco = value; }
            }

            private int produto_id;
            public int Produto_ID
            {
                get { return produto_id; }
                set { produto_id = value; }
            }

            private int tipopessoa_id;
            public int TipoPessoa_ID
            {
                get { return tipopessoa_id; }
                set { tipopessoa_id = value; }
            }

            private string tipopessoa;
            public string TipoPessoa
            {
                get { return tipopessoa; }
                set { tipopessoa = value; }
            }

            private decimal valor;
            public decimal Valor
            {
                get { return valor; }
                set { valor = value; }
            }

            private decimal promocao;
            public decimal Promocao
            {
                get { return promocao; }
                set { promocao = value; }
            }
        }

        public class Vitrine
        {
            private int idvitrine;
            public int IDVitrine
            {
                get { return idvitrine; }
                set { idvitrine = value; }
            }

            private int produto_id;
            public int Produto_ID
            {
                get { return produto_id; }
                set { produto_id = value; }
            }

            private int tamanho_id;
            public int Tamanho_ID
            {
                get { return tamanho_id; }
                set { tamanho_id = value; }
            }

            private string tamanho;
            public string Tamanho
            {
                get { return tamanho; }
                set { tamanho = value; }
            }

            private bool destaque;
            public bool Destaque
            {
                get { return destaque; }
                set { destaque = value; }
            }

            private decimal peso;
            public decimal Peso
            {
                get { return peso; }
                set { peso = value; }
            }

            private decimal altura;
            public decimal Altura
            {
                get { return altura; }
                set { altura = value; }
            }

            private decimal largura;
            public decimal Largura
            {
                get { return largura; }
                set { largura = value; }
            }

            private decimal profundidade;
            public decimal Profundidade
            {
                get { return profundidade; }
                set { profundidade = value; }
            }

            private int estoque;
            public int Estoque
            {
                get { return estoque; }
                set { estoque = value; }
            }

            private bool status;
            public bool Status
            {
                get { return status; }
                set { status = value; }
            }
        }

        public class Caracteristica
        {
            private int idcaracteristica;
            public int IDCaracteristica
            {
                get { return idcaracteristica; }
                set { idcaracteristica = value; }
            }

            private int produto_id;
            public int Produto_ID
            {
                get { return produto_id; }
                set { produto_id = value; }
            }

            private string nome;
            public string Nome
            {
                get { return nome; }
                set { nome = value; }
            }

            private string valor;
            public string Valor
            {
                get { return valor; }
                set { valor = value; }
            }

            private bool filtro;
            public bool Filtro
            {
                get { return filtro; }
                set { filtro = value; }
            }
        }

        public class Especificacao
        {
            private int idespecificacao;
            public int IDEspecificacao
            {
                get { return idespecificacao; }
                set { idespecificacao = value; }
            }

            private int produto_id;
            public int Produto_ID
            {
                get { return produto_id; }
                set { produto_id = value; }
            }

            private string nome;
            public string Nome
            {
                get { return nome; }
                set { nome = value; }
            }

            private string valor;
            public string Valor
            {
                get { return valor; }
                set { valor = value; }
            }

            private bool filtro;
            public bool Filtro
            {
                get { return filtro; }
                set { filtro = value; }
            }
        }
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
    }
}