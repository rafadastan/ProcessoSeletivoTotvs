using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Application.DTOs
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime LastLogin { get; set; }

        public UsuarioDTO()
        {

        }

        public UsuarioDTO(Guid id, string nome, string email, DateTime created, DateTime modified, DateTime lastLogin)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Created = created;
            Modified = modified;
            LastLogin = lastLogin;
        }
    }
}
