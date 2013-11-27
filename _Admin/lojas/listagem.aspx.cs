namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class _Admin_lojas_listagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                MontarListagem();
        }

        private void MontarListagem()
        {
            List<Entity.Loja> lojas = new Admin.Loja().ListarLoja("");

            rptListagem.DataSource = lojas;
            rptListagem.DataBind();
        }

        public string Cnpj(object cnpj)
        {
            string c = cnpj.ToString();
            return c.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
        }

        public string Status(object status)
        {
            if (Convert.ToBoolean(status))
                return "<span class='label label-success arrowed'>Ativo</span>";
            else
                return "<span class='label label-important arrowed-in'>Inativo</span>";
        }

        protected void btnExcluir_ServerClick(object sender, EventArgs e)
        {

        }
    }
}