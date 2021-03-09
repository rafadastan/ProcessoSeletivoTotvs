using ProcessoSeletivoTotvs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Contracts.Repositories
{
    public interface IPerfilRepository : IBaseRepository<Perfil>
    {
        Perfil Get(string perfil);
    }
}
