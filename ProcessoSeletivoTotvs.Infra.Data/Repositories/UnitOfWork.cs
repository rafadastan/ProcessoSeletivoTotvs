using Microsoft.EntityFrameworkCore.Storage;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Infra.Data.Contexts;

namespace ProcessoSeletivoTotvs.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlContext sqlContext;
        private IDbContextTransaction transaction;

        public UnitOfWork(SqlContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public IUsuarioRepository UsuarioRepository
            => new UsuarioRepository(sqlContext);

        public IPerfilRepository PerfilRepository
            => new PerfilRepository(sqlContext);

        public void BeginTransaction()
        {
            transaction = sqlContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void RollBack()
        {
            transaction.Rollback();
        }

        public void Dispose()
        {
            sqlContext.Dispose();
        }
    }
}
