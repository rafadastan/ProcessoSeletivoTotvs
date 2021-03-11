using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Contracts.Repositories
{
    public interface IBaseRepositoryDapper<TEntity> 
        where TEntity : class
    {
        TEntity Get(Func<TEntity, bool> where);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Func<TEntity, bool> where);

        TEntity GetById(Guid id);
    }
}
