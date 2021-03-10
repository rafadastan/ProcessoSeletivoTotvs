using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Infra.Data.Contexts;

namespace ProcessoSeletivoTotvs.Infra.Data.Repositories
{
    public class BaseRepositoryEntity<TEntity> : IBaseRepositoryEntity<TEntity>
        where TEntity : class
    {
        private readonly SqlContext _sqlContext;

        public BaseRepositoryEntity(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public void Create(TEntity entity)
        {
            _sqlContext.Entry(entity).State = EntityState.Added;
            _sqlContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _sqlContext.Entry(entity).State = EntityState.Deleted;
            _sqlContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _sqlContext.Entry(entity).State = EntityState.Modified;
            _sqlContext.SaveChanges();
        }

        public void Dispose()
        {
            _sqlContext.Dispose();
        }        
    }
}
