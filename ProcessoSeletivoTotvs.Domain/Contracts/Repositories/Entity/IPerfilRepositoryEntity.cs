using ProcessoSeletivoTotvs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Contracts.Repositories
{
    public interface IPerfilRepositoryEntity : IBaseRepositoryEntity<Perfil>
    {
        void Adicionar(Perfil entity); 
    }
}
