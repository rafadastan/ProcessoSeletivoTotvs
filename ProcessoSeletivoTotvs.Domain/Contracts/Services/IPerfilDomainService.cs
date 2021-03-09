using ProcessoSeletivoTotvs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Contracts.Services
{
    public interface IPerfilDomainService : IDisposable
    {
        Perfil Get(string perfil);
        void Create(Perfil entity);
        List<Perfil> GetAll();
    }
}
