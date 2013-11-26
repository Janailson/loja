namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class categoria : System.Web.UI.Page
    {
        public string style;

        protected void Page_Load(object sender, EventArgs e)
        {

            Entity.Categoria categoria = new Business.Categoria().ConsultarCategoria(Request["id"]);

            if (categoria.Nivel == categoria.MinNivel)
            {
                style = "categoria_nivel_1";
                placeHolder.Controls.Add(LoadControl("~/categoria_nivel_1.ascx"));
            }
            else if (categoria.Nivel == categoria.MaxNivel)
            {
                style = "categoria_nivel_2";
                placeHolder.Controls.Add(LoadControl("~/categoria_nivel_3.ascx"));
            }
            else
            {
                style = "categoria_nivel_2";
                placeHolder.Controls.Add(LoadControl("~/categoria_nivel_2.ascx"));
            }
        }
    }
}