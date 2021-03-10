using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Contracts.Repositories
{
    public interface IBaseRepositoryEntity<TEntity> : IDisposable
        where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        
    }
}
