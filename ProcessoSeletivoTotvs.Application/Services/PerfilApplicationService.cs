using ProcessoSeletivoTotvs.Application.Contracts;
using ProcessoSeletivoTotvs.Application.DTOs;
using ProcessoSeletivoTotvs.Application.Models.Perfil;
using ProcessoSeletivoTotvs.Domain.Contracts.Services;
using ProcessoSeletivoTotvs.Domain.Contracts.User;
using ProcessoSeletivoTotvs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Application.Services
{
    public class PerfilApplicationService : IPerfilApplicationService
    {
        private readonly IPerfilDomainService _perfilDomainService;
        private readonly IUsuarioDomainService _usuarioDomainService;
        private readonly IUser _user;

        public PerfilApplicationService(IPerfilDomainService perfilDomainService, IUsuarioDomainService usuarioDomainService, IUser user)
        {
            _perfilDomainService = perfilDomainService;
            _usuarioDomainService = usuarioDomainService;
            _user = user;
        }

        public PerfilDTO Create(PerfilCadastroModel model)
        {
            var usuario = _usuarioDomainService.GetByLogin(_user.Name);

            var perfil = new Perfil
            {
                Id = Guid.NewGuid(),
                Perfis = model.Perfil,
                IdUsuario = usuario.Id,
                Usuario = usuario
            };

            _perfilDomainService.Create(perfil);

            return new PerfilDTO
            {
                Id = perfil.Id,
                Perfis = perfil.Perfis,
                IdUsuario = Guid.NewGuid(),
                Usuario = perfil.Usuario
            };

        }

        public List<Perfil> GetAll()
        {
            return _perfilDomainService.GetAll();
        }

    }
}
