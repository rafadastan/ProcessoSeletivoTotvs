using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Contracts.Repositories
{
    public interface IUnitOfWorkEntity : IDisposable
    {
        IUsuarioRepositoryEntity UsuarioRepositoryEntity { get; }
        IPerfilRepositoryEntity PerfilRepositoryEntity { get; }
        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}
