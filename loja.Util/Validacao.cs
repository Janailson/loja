using System;
using System.Collections.Generic;
using System.Text;

using System.Text.RegularExpressions;

public class Validacao
{
    /// <summary>
    /// Verifica se o endereço de e-mail é válido
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public bool Email(string email)
    {
        Regex regex = new Regex(@"^([a-z0-9_-][a-z0-9_.-]+@([a-z0-9_-]+\.)+[a-z]{2,4})$");
        return regex.IsMatch(email.ToLower());
    }

    /// <summary>
    /// Verifica se o CPF é válido
    /// </summary>
    /// <param name="cpf"></param>
    /// <returns></returns>
    public bool Cpf(string cpf)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digito;
        int soma;
        int resto;

        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
            return false;

        switch (cpf)
        {
            case "00000000000":
            case "11111111111":
            case "22222222222":
            case "33333333333":
            case "44444444444":
            case "55555555555":
            case "66666666666":
            case "77777777777":
            case "88888888888":
            case "99999999999":
                return false;
        }

        tempCpf = cpf.Substring(0, 9);
        soma = 0;
        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();

        tempCpf = tempCpf + digito;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cpf.EndsWith(digito);
    }

    /// <summary>
    /// Verifica se o CNPJ é válido
    /// </summary>
    /// <param name="cnpj"></param>
    /// <returns></returns>
    public bool Cnpj(string cnpj)
    {
        int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma;
        int resto;
        string digito;
        string tempCnpj;

        cnpj = cnpj.Trim();
        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

        if (cnpj.Length != 14)
            return false;

        tempCnpj = cnpj.Substring(0, 12);

        soma = 0;
        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();

        tempCnpj = tempCnpj + digito;
        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cnpj.EndsWith(digito);
    }

    /// <summary>
    /// Verifica se o arquivo é uma imagem
    /// </summary>
    /// <param name="imagem"></param>
    /// <returns></returns>
    public bool Imagem(string imagem)
    {
        Regex regex = new Regex(@"\.(png|gif|jpe?g)$");
        return regex.IsMatch(imagem.ToLower());
    }
}