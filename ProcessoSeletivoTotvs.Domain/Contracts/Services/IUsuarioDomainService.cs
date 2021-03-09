using ProcessoSeletivoTotvs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Contracts.Services
{
    public interface IUsuarioDomainService : IDisposable
    {
        List<Usuario> GetAll();
        Usuario Get(string email, string senha);
        Usuario GetByLogin(string email);
        void Create(Usuario entity);
    }
}
