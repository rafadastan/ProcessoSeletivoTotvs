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

        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseDomainService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual void Create(TEntity entity)
        {
            _baseRepository.Create(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _baseRepository.Delete(entity);
        }

        public virtual List<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public virtual TEntity GetById(Guid id)
        {
            return _baseRepository.GetById(id);
        }

        public virtual void Update(TEntity entity)
        {
            _baseRepository.Update(entity);
        }

        public virtual void Get(TEntity entity)
        {
            _baseRepository.Get(entity);
        }

        public void Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}
