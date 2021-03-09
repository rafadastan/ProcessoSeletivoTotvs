using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Application.DTOs
{
    public class PerfilDTO
    {
        public Guid Id { get; set; }
        public string Perfis { get; set; }

        public PerfilDTO()
        {

        }

        public PerfilDTO(Guid id, string perfis)
        {
            Id = id;
            Perfis = perfis;
        }
    }
}
