using ProcessoSeletivoTotvs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario GetByLogin(string login);
        Usuario GetByLoginAndPassword(string login, string password);
    }
}
