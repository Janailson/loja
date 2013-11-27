namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using System.Collections;

    public partial class _Admin_produto_produtos_editor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[Constante.ADMProduto] != null)
                {
                    ArrayList arr = new ArrayList();
                    arr = (ArrayList)Session[Constante.ADMProduto];

                    txtTexto.Value = arr[Convert.ToInt32(Request["n"])].ToString();
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string Texto = txtTexto.Value.Trim().Replace("'", "''").Replace("--", "");
            bool Validar = true;

            if (Validar)
            {
                ArrayList arr = new ArrayList();
                arr.Add("");
                arr.Add("");

                if (Session[Constante.ADMProduto] != null) arr = (ArrayList)Session[Constante.ADMProduto];

                arr[Convert.ToInt32(Request["n"])] = Texto;
                Session[Constante.ADMProduto] = arr;

                ClientScript.RegisterStartupScript(GetType(), "Redirect", "top.window.location=top.window.location.toString();", true);
            }
        }
    }
}