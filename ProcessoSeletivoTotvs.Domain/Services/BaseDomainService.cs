using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Services
{
    public class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
        where TEntity : class
    {

        private readonly IBaseRepositoryEntity<TEntity> _baseRepositoryEntity;
        private readonly IBaseRepositoryDapper<TEntity> _baseRepositoryDapper;

        public BaseDomainService(IBaseRepositoryEntity<TEntity> baseRepositoryEntity,
            IBaseRepositoryDapper<TEntity> baseRepositoryDapper)
        {
            _baseRepositoryEntity = baseRepositoryEntity;
            _baseRepositoryDapper = baseRepositoryDapper;
        }

        public virtual void Create(TEntity entity)
        {
            _baseRepositoryEntity.Create(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _baseRepositoryEntity.Delete(entity);
        }

        public virtual List<TEntity> GetAll()
        {
            return _baseRepositoryDapper.GetAll();
        }

        public virtual TEntity GetById(Guid id)
        {
            return _baseRepositoryDapper.GetById(id);
        }

        public virtual void Update(TEntity entity)
        {
            _baseRepositoryEntity.Update(entity);
        }

        public virtual void Get(Func<TEntity, bool> where)
        {
            _baseRepositoryDapper.Get(where);
        }

        public void Dispose()
        {
            _baseRepositoryEntity.Dispose();
        }
    }
}
