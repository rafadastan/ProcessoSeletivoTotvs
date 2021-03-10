using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Contracts.Repositories.UnitOfWork
{
    public interface IUnitOfWorkDapper : IDisposable
    {
        IUsuarioRepositoryDapper UsuarioRepositoryDapper { get; }
        IPerfilRepositoryDapper PerfilRepositoryDapper { get; }
        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}
