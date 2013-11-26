using System;
using System.Web.UI.WebControls;

namespace loja.Util
{
    public class Estado
    {
        public Estado(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Add("");
            ddl.Items.Add(new ListItem("Acre", "AC"));
            ddl.Items.Add(new ListItem("Alagoas", "AL"));
            ddl.Items.Add(new ListItem("Amapá", "AP"));
            ddl.Items.Add(new ListItem("Amazonas", "AM"));
            ddl.Items.Add(new ListItem("Bahia", "BA"));
            ddl.Items.Add(new ListItem("Ceará", "CE"));
            ddl.Items.Add(new ListItem("Distrito Federal", "DF"));
            ddl.Items.Add(new ListItem("Espírito Santo", "ES"));
            ddl.Items.Add(new ListItem("Goiás", "GO"));
            ddl.Items.Add(new ListItem("Maranhão", "MA"));
            ddl.Items.Add(new ListItem("Mato Grosso", "MT"));
            ddl.Items.Add(new ListItem("Mato Grosso do Sul", "MS"));
            ddl.Items.Add(new ListItem("Minas Gerais", "MG"));
            ddl.Items.Add(new ListItem("Pará", "PA"));
            ddl.Items.Add(new ListItem("Paraíba", "PB"));
            ddl.Items.Add(new ListItem("Paraná", "PR"));
            ddl.Items.Add(new ListItem("Pernambuco", "PE"));
            ddl.Items.Add(new ListItem("Piauí", "PI"));
            ddl.Items.Add(new ListItem("Rio de Janeiro", "RJ"));
            ddl.Items.Add(new ListItem("Rio Grande do Norte", "RN"));
            ddl.Items.Add(new ListItem("Rio Grando do Sul", "RS"));
            ddl.Items.Add(new ListItem("Rondônia", "RO"));
            ddl.Items.Add(new ListItem("Rorâima", "RR"));
            ddl.Items.Add(new ListItem("Santa Catarina", "SC"));
            ddl.Items.Add(new ListItem("São Paulo", "SP"));
            ddl.Items.Add(new ListItem("Sergipe", "SE"));
            ddl.Items.Add(new ListItem("Tocantins", "TO"));
        }
    }
}