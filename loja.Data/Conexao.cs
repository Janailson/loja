using System;
using System.Configuration;

public class Conexao
{
    private string _ConexaoBancoDeDados = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
    public string ConexaoBancoDeDados
    {
        get { return _ConexaoBancoDeDados; }
        set { _ConexaoBancoDeDados = value; }
    }

    private string _ConexaoBancoDeDadosV = ConfigurationSettings.AppSettings["ConnectionStringV"].ToString();
    public string ConexaoBancoDeDadosV
    {
        get { return _ConexaoBancoDeDadosV; }
        set { _ConexaoBancoDeDadosV = value; }
    }
}