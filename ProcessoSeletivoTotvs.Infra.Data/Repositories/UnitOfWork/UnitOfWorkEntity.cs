using Microsoft.EntityFrameworkCore.Storage;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Infra.Data.Contexts;

namespace ProcessoSeletivoTotvs.Infra.Data.Repositories
{
    public class UnitOfWorkEntity : IUnitOfWorkEntity
    {
        private readonly SqlContext sqlContext;
        private IDbContextTransaction transaction;

        public UnitOfWorkEntity(SqlContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public IUsuarioRepositoryEntity UsuarioRepositoryEntity 
            => new UsuarioRepositoryEntity(sqlContext);

        public IPerfilRepositoryEntity PerfilRepositoryEntity 
            => new PerfilRepositoryEntity(sqlContext);

   
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
