namespace loja
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    public interface ICatalogo
    {
        // --
        void Migalha(int IDCategoria);

        void Menu(int IDCategoria);

        // --
        void Categorias(int parentId, bool Destaque);

        void Subcategorias(int parentId, bool Destaque);
    }
}