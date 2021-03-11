using ProcessoSeletivoTotvs.Application.Contracts;
using ProcessoSeletivoTotvs.Application.DTOs;
using ProcessoSeletivoTotvs.Application.Models.Usuarios;
using ProcessoSeletivoTotvs.Domain.Contracts.Services;
using ProcessoSeletivoTotvs.Domain.Contracts.User;
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
        private readonly IPerfilDomainService _perfilDomainService;
        private readonly IUser _user;


        public UsuarioApplicationService(IUsuarioDomainService usuarioDomainService, IPerfilDomainService perfilDomainService, IUser user)
        {
            _usuarioDomainService = usuarioDomainService;
            _perfilDomainService = perfilDomainService;
            _user = user;
        }

        public UsuarioDTO Create(UsuarioCadastroModel model)
        {
            var usuarioLogado = _usuarioDomainService.GetByLogin(_user.Name);

            if (usuarioLogado != null)
            {
                var perfil = _perfilDomainService.GetById(usuarioLogado.Id);
            }

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
                        Perfis = model.Perfis.FirstOrDefault(),
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
                        Perfis = model.Perfis.FirstOrDefault(),
                        Id = Guid.NewGuid(),
                        IdUsuario = Guid.NewGuid(), 
                        Usuario = usuario
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
            var usuarios = _usuarioDomainService.GetAll();

            return usuarios; 
        }

        public void Dispose()
        {
            _usuarioDomainService.Dispose();
        }
    }
}
