namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class categoria_nivel_3 : Catalogo
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            subcategoria = new Business.Categoria().ConsultarCategoria(Request["id"]);
            categoria = new Business.Categoria().ConsultarCategoria(subcategoria.parentId);
            pai = new Business.Categoria().ConsultarCategoria(categoria.parentId);

            Pagina = (Request["pagina"] == null) ? 1 : Convert.ToInt32(Request["pagina"]);
            Produtos();
        }

        public override void Produtos()
        {
            PagedDataSource pDs = new PagedDataSource();
            pDs.DataSource = new Business.Produto().ListarProduto(subcategoria.IDCategoria, false);
            pDs.PageSize = TotalPagina;
            pDs.CurrentPageIndex = (Pagina - 1);

            rptProduto.DataSource = pDs;
            rptProduto.DataBind();
        }
    }
}