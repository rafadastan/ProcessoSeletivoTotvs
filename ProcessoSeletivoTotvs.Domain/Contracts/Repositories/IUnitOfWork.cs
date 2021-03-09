using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Contracts.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository UsuarioRepository { get; }
        IPerfilRepository PerfilRepository { get; }
        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}
