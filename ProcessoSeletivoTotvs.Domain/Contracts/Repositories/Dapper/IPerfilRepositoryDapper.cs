using ProcessoSeletivoTotvs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Contracts.Repositories
{
    public interface IPerfilRepositoryDapper : IBaseRepositoryDapper<Perfil>
    {
        Perfil Get(string perfil);
    }
}
