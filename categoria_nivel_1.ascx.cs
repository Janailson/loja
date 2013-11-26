namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using System.Text;

    public partial class categoria_nivel_1 : Catalogo
    {
        public Entity.Categoria categoria;

        protected void Page_Load(object sender, EventArgs e)
        {
            categoria = new Business.Categoria().ConsultarCategoria(Request["id"]);
        }

        public override void Produtos()
        {
            // not applied
        }
    }
}