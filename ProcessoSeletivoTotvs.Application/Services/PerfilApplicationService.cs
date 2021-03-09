using ProcessoSeletivoTotvs.Application.Contracts;
using ProcessoSeletivoTotvs.Application.DTOs;
using ProcessoSeletivoTotvs.Application.Models.Perfil;
using ProcessoSeletivoTotvs.Domain.Contracts.Services;
using ProcessoSeletivoTotvs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Application.Services
{
    public class PerfilApplicationService : IPerfilApplicationService
    {
        private readonly IPerfilDomainService _perfilDomainService;

        public PerfilApplicationService(IPerfilDomainService perfilDomainService)
        {
            _perfilDomainService = perfilDomainService;
        }

        public PerfilDTO Create(PerfilCadastroModel model)
        {
            var perfil = new Perfil
            {
                Id = Guid.NewGuid(),
                Perfis = model.Perfil
            };

            _perfilDomainService.Create(perfil);

            return new PerfilDTO
            {
                Id = perfil.Id,
                Perfis = perfil.Perfis
            };

        }

        public List<Perfil> GetAll()
        {
            return _perfilDomainService.GetAll();
        }

    }
}
