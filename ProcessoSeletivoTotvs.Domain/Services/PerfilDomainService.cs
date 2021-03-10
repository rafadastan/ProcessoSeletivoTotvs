using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Domain.Contracts.Repositories.UnitOfWork;
using ProcessoSeletivoTotvs.Domain.Contracts.Services;
using ProcessoSeletivoTotvs.Domain.Entities;
using ProcessoSeletivoTotvs.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ProcessoSeletivoTotvs.Domain.Services
{
    public class PerfilDomainService : BaseDomainService<Perfil>, IPerfilDomainService
    {
        private readonly IUnitOfWorkEntity _unitOfWorkEntity;
        private readonly IUnitOfWorkDapper _unitOfWorkDapper;

        public PerfilDomainService(IUnitOfWorkEntity unitOfWorkEntity, IUnitOfWorkDapper unitOfWorkDapper) 
            : base(unitOfWorkEntity.PerfilRepositoryEntity, unitOfWorkDapper.PerfilRepositoryDapper)
        {
            _unitOfWorkEntity = unitOfWorkEntity;
            _unitOfWorkDapper = unitOfWorkDapper;
        }

        public Perfil Get(string perfil)
        {
            return _unitOfWorkDapper.PerfilRepositoryDapper.Get(perfil);
        }

        public override void Create(Perfil entity)
        {
            if (_unitOfWorkDapper.PerfilRepositoryDapper.Get(entity.Perfis) != null)
                throw new PreenchaPerfil("Preencha o perfil");

            base.Create(entity);
        }

        public override List<Perfil> GetAll()
        {
            return base.GetAll();
        }
    }
}
