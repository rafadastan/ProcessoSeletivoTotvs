using ProcessoSeletivoTotvs.Domain.Contracts.Repositories;
using ProcessoSeletivoTotvs.Domain.Contracts.Services;
using ProcessoSeletivoTotvs.Domain.Entities;
using ProcessoSeletivoTotvs.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ProcessoSeletivoTotvs.Domain.Services
{
    public class PerfilDomainService : BaseDomainService<Perfil>, IPerfilDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PerfilDomainService(IUnitOfWork unitOfWork) 
            : base(unitOfWork.PerfilRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public Perfil Get(string perfil)
        {
            return _unitOfWork.PerfilRepository.Get(perfil);
        }

        public override void Create(Perfil entity)
        {
            if (_unitOfWork.PerfilRepository.Get(entity.Perfis) != null)
                throw new PreenchaPerfil("Preencha o perfil");

            base.Create(entity);
        }

        public override List<Perfil> GetAll()
        {
            return base.GetAll();
        }
    }
}
