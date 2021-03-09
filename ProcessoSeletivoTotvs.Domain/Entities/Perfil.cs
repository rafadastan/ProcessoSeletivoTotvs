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
        public Usuario Usuario { get; set; }

        public Perfil()
        {

        }
        public Perfil(Guid id, string perfis, Usuario usuario)
        {
            Id = id;
            Perfis = perfis;
            Usuario = usuario;
        }
    }
}
