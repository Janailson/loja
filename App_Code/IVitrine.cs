using System;

namespace loja
{
    public interface IVitrine
    {
        void Migalha(int IDCategoria);

        void Precos(int IDProduto);

        void Parcelamento(int IDProduto);
    }
}