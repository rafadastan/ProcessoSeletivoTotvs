using ProcessoSeletivoTotvs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Application.DTOs
{
    public class PerfilDTO
    {
        public Guid Id { get; set; }
        public string Perfis { get; set; }
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public PerfilDTO()
        {

        }

        public PerfilDTO(Guid id, string perfis, Guid idUsuario, Usuario usuario)
        {
            Id = id;
            Perfis = perfis;
            IdUsuario = idUsuario;
            Usuario = usuario;
        }
    }
}
