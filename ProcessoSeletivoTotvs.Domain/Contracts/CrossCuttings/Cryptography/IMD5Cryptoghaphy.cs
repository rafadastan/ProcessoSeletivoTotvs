using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Contracts.CrossCuttings.Cryptography
{
    public interface IMD5Cryptoghaphy
    {
        string Encrypt(string value);
    }
}
