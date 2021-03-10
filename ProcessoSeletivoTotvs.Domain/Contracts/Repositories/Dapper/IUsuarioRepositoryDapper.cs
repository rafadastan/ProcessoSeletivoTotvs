using ProcessoSeletivoTotvs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Contracts.Repositories
{
    public interface IUsuarioRepositoryDapper : IBaseRepositoryDapper<Usuario>
    {
        Usuario GetByLogin(string email);
        Usuario GetByLoginAndPassword(string email, string password);
    }
}
