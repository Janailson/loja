namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using System.Text;
    using System.Configuration;

    public partial class _Admin_MasterPage : System.Web.UI.MasterPage
    {
        public Entity.Usuario objUsuario = new Entity.Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            // verifica se possui sessão ativa
            if (Session[Constante.ADMMaster] == null && Session[Constante.ADMLoja] == null)
                Response.Redirect("~/_Admin/login.aspx");

            // acesso master
            if (Session[Constante.ADMMaster] != null)
            {
                objUsuario = (Entity.Usuario)Session[Constante.ADMMaster];
                return;
            }

            // acesso loja
            if (Session[Constante.ADMLoja] != null)
            {
                objUsuario = (Entity.Usuario)Session[Constante.ADMLoja];
                return;
            }
        }

        public void montar_menu()
        {
            // MASTER
            if (Session[Constante.ADMMaster] != null)
            {
                Response.Write(new Menu().Master(0, ""));
                return;
            }

            // LOJA
            if (Session[Constante.ADMLoja] != null)
            {
                Response.Write(new Menu().Loja(0, ""));
                return;
            }
        }

        protected void lnkSair_Click(object sender, EventArgs e)
        {
            Response.Cookies["ADMUsuario"].Expires = DateTime.Now.AddDays(-30);
            Session.Abandon();
            Response.Redirect("~/_Admin/login.aspx");
        }
    }

    public class Menu
    {
        public string Master(int parentId, string Link)
        {
            StringBuilder sb = new StringBuilder();

            new Admin.Pagina.Master().ListarPagina(parentId).ForEach(delegate(Entity.Pagina pagina)
            {
                sb.Append("<li>\n");
                sb.Append("<a " + ((pagina.Tipo == 1) ? "href='#' class='dropdown-toggle'" : "href='" + ConfigurationManager.AppSettings["Url"] + "/_Admin/" + Link + pagina.Link + "'") + ">\n");
                sb.Append("<i class='icon-" + pagina.Icone + "'></i>\n");
                sb.Append("<span>" + pagina.Nome + "</span>\n");
                if (pagina.Tipo == 1) sb.Append("<b class='arrow icon-angle-down'></b>\n");
                sb.Append("</a>\n");

                if (pagina.Tipo == 1)
                {
                    sb.Append("<ul class='submenu'>\n");
                    sb.Append(Master(pagina.IDPagina, pagina.Link + "/"));
                    sb.Append("</ul>\n");
                }

                sb.Append("</li>\n");
            });

            return sb.ToString();
        }

        public string Loja(int parentId, string Link)
        {
            StringBuilder sb = new StringBuilder();

            new Admin.Pagina.Loja().ListarPagina(parentId).ForEach(delegate(Entity.Pagina pagina)
            {
                sb.Append("<li>\n");
                sb.Append("<a " + ((pagina.Tipo == 1) ? "href='#' class='dropdown-toggle'" : "href='" + ConfigurationManager.AppSettings["Url"] + "/_Admin/" + Link + pagina.Link + "'") + ">\n");
                sb.Append("<i class='icon-" + pagina.Icone + "'></i>\n");
                sb.Append("<span>" + pagina.Nome + "</span>\n");
                if (pagina.Tipo == 1) sb.Append("<b class='arrow icon-angle-down'></b>\n");
                sb.Append("</a>\n");

                if (pagina.Tipo == 1)
                {
                    sb.Append("<ul class='submenu'>\n");
                    sb.Append(Loja(pagina.IDPagina, pagina.Link + "/"));
                    sb.Append("</ul>\n");
                }

                sb.Append("</li>\n");
            });

            return sb.ToString();
        }
    }
}