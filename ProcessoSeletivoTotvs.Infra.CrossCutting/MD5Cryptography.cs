using ProcessoSeletivoTotvs.Domain.Contracts.CrossCuttings.Cryptography;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ProcessoSeletivoTotvs.Infra.CrossCutting
{
    public class MD5Cryptography : IMD5Cryptoghaphy
    {
        public string Encrypt(string value)
        {
            var md5 = new MD5CryptoServiceProvider();

            //criptografar o valor recebido no método para MD5
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));

            //converter o conteudo da variavel hash em string
            var result = string.Empty;
            foreach (var item in hash)
            {
                result += item.ToString("X2"); //X2 -> hexadecimal
            }

            return result;
        }
    }
}
