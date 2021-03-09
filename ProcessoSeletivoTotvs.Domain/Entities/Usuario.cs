using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime LastLogin { get; set; }
        public List<Perfil> Perfis { get; set; }

        public Usuario(Guid id, string nome, string email, string senha, DateTime created, DateTime modified, DateTime lastLogin, List<Perfil> perfis)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Created = created;
            Modified = modified;
            LastLogin = lastLogin;
            Perfis = perfis;
        }

        public Usuario()
        {
        }
    }
}
