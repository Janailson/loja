using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;

public class Constante
{
<<<<<<< HEAD
    public const int IDLoja = 3;

    public const string ADMMaster = "ADMMaster";
    public const string ADMLoja = "ADMLoja";
    public const string ADMProduto = "ADMProduto";
    public const string SESSAO = "SESSAO";
=======
    public const string ADMMaster = "ADMMaster";
    public const string ADMLoja = "ADMLoja";
    public const string ADMProduto = "ADMProduto";
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739

    public void input_error(Panel pnl, Label lbl)
    {
        pnl.CssClass = "control-group";
        lbl.Visible = false;
        lbl.Text = "";
    }

    public void input_error(Panel pnl, Label lbl, String str)
    {
        pnl.CssClass = "control-group error";
        lbl.Visible = true;
        lbl.Text = str;
    }

    public void label_message(Panel p, Alert a, Label l, String str)
    {
        p.CssClass = "alert alert-" + a;
        p.Visible = true;
        l.Text = str;
    }
<<<<<<< HEAD

    public class Redirect
    {
        public const string MYACCOUNT = "minha-conta/meus-dados.aspx";
        public const string DELIVERY = "entrega.aspx";
        public const string ORDER = "pagamento.aspx";
    }
=======
>>>>>>> d4ef194a5565e4cead9b89585b7509b8ad988739
}