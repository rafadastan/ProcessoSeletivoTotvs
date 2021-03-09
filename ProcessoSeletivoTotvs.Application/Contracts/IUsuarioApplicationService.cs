using ProcessoSeletivoTotvs.Application.DTOs;
using ProcessoSeletivoTotvs.Application.Models.Usuarios;
using ProcessoSeletivoTotvs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Application.Contracts
{
    public interface IUsuarioApplicationService : IDisposable
    {
        UsuarioDTO Create(UsuarioCadastroModel model);
        UsuarioDTO GetAccess(UsuarioAcessoModel model);
        List<Usuario> GetAll();
    }
}
