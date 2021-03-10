using ProcessoSeletivoTotvs.Domain.Enums.Perfil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Entities
{
    public class Perfil
    {
        [Key]
        public Guid Id { get; set; }
        public string Perfis { get; set; }
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public Perfil()
        {

        }
        public Perfil(Guid id, string perfis)
        {
            Id = id;
            Perfis = perfis;
        }
    }
}
