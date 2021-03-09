using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Exceptions
{
    public class PreenchaPerfil : Exception
    {
        private readonly string perfil;

        public PreenchaPerfil(string perfil)
        {
            this.perfil = perfil;
        }

        public override string Message
            => $"O Email informado '{perfil}' já encontra-se cadastrado. Tente outro.";
    }
}
