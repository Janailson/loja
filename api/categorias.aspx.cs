namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Newtonsoft.Json;

    public partial class api_categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string str_loja = Request["loja"];
            string str_id = Request["id"];

            if (str_loja == null || str_loja == String.Empty)
                throw new Exception("loja not found");

            if (str_id == null || str_id == String.Empty)
                throw new Exception("id not found");

            Root root = new Root();
            root.categorias = new List<Rest.Categoria>();

            int IDLoja = Convert.ToInt32(str_loja);
            int IDCategoria = Convert.ToInt32(str_id);

            new Business.Categoria().ListarCategoria(IDLoja, IDCategoria).ForEach(delegate(Entity.Categoria category)
            {
                Rest.Categoria categoria = new Rest.Categoria();
                categoria.id = category.IDCategoria;
                categoria.parentId = category.parentId;
                categoria.nome = category.Nome;
                categoria.total_produtos = category.Produtos;
                categoria.subcategorias = new List<Rest.Categoria>();
                root.categorias.Add(categoria);

                new Business.Categoria().ListarCategoria(IDLoja, category.IDCategoria).ForEach(delegate(Entity.Categoria subcategory)
                {
                    Rest.Categoria subcategoria = new Rest.Categoria();
                    subcategoria.id = subcategory.IDCategoria;
                    subcategoria.parentId = subcategory.parentId;
                    subcategoria.nome = subcategory.Nome;
                    subcategoria.total_produtos = subcategory.Produtos;
                    categoria.subcategorias.Add(subcategoria);
                });
            });

            string json = JsonConvert.SerializeObject(root);
            Response.Write(json);
        }

        public class Root
        {
            public List<Rest.Categoria> categorias { get; set; }
        }
    }
}