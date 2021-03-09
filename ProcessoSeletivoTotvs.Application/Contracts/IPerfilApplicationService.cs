using ProcessoSeletivoTotvs.Application.DTOs;
using ProcessoSeletivoTotvs.Application.Models.Perfil;
using ProcessoSeletivoTotvs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Application.Contracts
{
    public interface IPerfilApplicationService
    {
        PerfilDTO Create(PerfilCadastroModel model);
        List<Perfil> GetAll();
    }
}
