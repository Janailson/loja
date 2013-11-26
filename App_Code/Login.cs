using System;
using System.Collections.Generic;
using System.Web;

namespace loja
{
    public abstract class Login : BaseShop, ILogin
    {
        public void toRedirect()
        {
            string q = Request["q"];
            switch (q)
            {
                case "myaccount":
                    Response.Redirect(Constante.Redirect.MYACCOUNT);
                    break;
                case "delivery":
                    Response.Redirect(Constante.Redirect.DELIVERY);
                    break;
                case "order":
                    Response.Redirect(Constante.Redirect.ORDER);
                    break;
                default:
                    Response.Redirect(Constante.Redirect.MYACCOUNT);
                    break;
            }
        }
    }
}