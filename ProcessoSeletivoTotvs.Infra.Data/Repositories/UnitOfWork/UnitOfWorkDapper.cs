using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories.UnitOfWork;
using ProcessoSeletivoTotvs.Infra.Data.Contexts.DataDapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Infra.Data.Repositories.UnitOfWork
{
    public class UnitOfWorkDapper : IUnitOfWorkDapper
    {
        private readonly DbSession _session;

        public UnitOfWorkDapper(DbSession session)
        {
            _session = session;
        }

        public IUsuarioRepositoryDapper UsuarioRepositoryDapper
            => new UsuarioRepositoryDapper(_session);

        public IPerfilRepositoryDapper PerfilRepositoryDapper 
            => new PerfilRepositoryDapper(_session);

        public void BeginTransaction()
        {
            _session.Transaction = _session.Connection.BeginTransaction();
        }

        public void Commit()
        {
            _session.Transaction.Commit();
        }

        public void RollBack()
        {
            _session.Transaction.Rollback();
        }

        public void Dispose() => _session.Transaction?.Dispose();
    }
}
