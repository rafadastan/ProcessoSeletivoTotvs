using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoTotvs.Domain.Entities;
using ProcessoSeletivoTotvs.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Infra.Data.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) 
            : base(options)
        {
                
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfils { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());

            modelBuilder.Entity<Usuario>(entity =>
           {
               entity.HasIndex(u => u.Email).IsUnique();
           });
        }
    }
}
