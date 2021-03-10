using ProcessoSeletivoTotvs.Application.Contracts;
using ProcessoSeletivoTotvs.Application.DTOs;
using ProcessoSeletivoTotvs.Application.Models.Usuarios;
using ProcessoSeletivoTotvs.Domain.Contracts.Services;
using ProcessoSeletivoTotvs.Domain.Entities;
using ProcessoSeletivoTotvs.Domain.Enums.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessoSeletivoTotvs.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioDomainService _usuarioDomainService;

        public UsuarioApplicationService(IUsuarioDomainService usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        public UsuarioDTO Create(UsuarioCadastroModel model)
        {
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = model.Nome,
                Email = model.Email,
                Senha = model.Senha,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                LastLogin = DateTime.Now,
                Perfis = new List<Perfil>
                {
                    new Perfil{
                        Perfis= Perfis.Usuario.ToString(),
                        Id = Guid.NewGuid(),
                        IdUsuario = Guid.NewGuid()
                    }
                }
            };

            _usuarioDomainService.Create(usuario);

            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Created = usuario.Created,
                Modified = usuario.Modified,
                LastLogin = usuario.LastLogin,
                Perfis = new List<Perfil>
                {
                    new Perfil{
                        Perfis= Perfis.Usuario.ToString(),
                        Id = Guid.NewGuid(),
                        IdUsuario = usuario.Id
                    }
                }
            };
        }     

        public UsuarioDTO GetAccess(UsuarioAcessoModel model)
        {
            var usuario = _usuarioDomainService.Get(model.Email, model.Senha);

            if (usuario == null)
                return null;

            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Created = usuario.Created,
                Modified = usuario.Modified,
                LastLogin = DateTime.Now
            };
        }

        public List<Usuario> GetAll()
        {
            return _usuarioDomainService.GetAll();
        }

        public void Dispose()
        {
            _usuarioDomainService.Dispose();
        }
    }
}
