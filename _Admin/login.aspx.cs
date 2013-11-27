namespace loja
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class _Admin_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // placeholder
            txtUsuario.Attributes.Add("placeholder", Resources.login.Usuario);
            txtSenha.Attributes.Add("placeholder", Resources.login.Senha);

            // lembrar usuário
            if (!IsPostBack)
            {
                if (Request.Cookies["ADMUsuario"] != null)
                {
                    txtUsuario.Text = Request.Cookies["ADMUsuario"]["Usuario"];
                    txtSenha.Text = Request.Cookies["ADMUsuario"]["Senha"];
                    Login();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            Entity.Usuario usuario = new Entity.Usuario();

            string Usuario = txtUsuario.Text.Trim().Replace("'", "''").Replace("--", "");
            string Senha = txtSenha.Text.Trim().Replace("'", "''").Replace("--", "");

            // MASTER
            usuario = new Admin.Login.Master().ConsultarUsuario(Usuario, Senha);
            if (usuario.IDUsuario > 0)
            {
                Session[Constante.ADMMaster] = usuario;
                if (chkLembrar.Checked) montar_cookie();
                Response.Redirect("~/_Admin/Default.aspx");
                return;
            }

            // LOJA
            usuario = new Admin.Login.Loja().ConsultarUsuario(Usuario, Senha);
            if (usuario.IDUsuario > 0)
            {
                Session[Constante.ADMLoja] = usuario;
                if (chkLembrar.Checked) montar_cookie();
                Response.Redirect("~/_Admin/Default.aspx");
                return;
            }

            ClientScript.RegisterStartupScript(GetType(), "alerta", "alert('Usuário e/ou senha inválido.');", true);
        }

        private void montar_cookie()
        {
            HttpCookie oCookie = new HttpCookie("ADMUsuario");
            oCookie["Usuario"] = txtUsuario.Text;
            oCookie["Senha"] = txtSenha.Text;
            Response.Cookies.Set(oCookie);
            Response.Cookies["ADMUsuario"].Expires = DateTime.Now.AddYears(1);
        }
    }
}