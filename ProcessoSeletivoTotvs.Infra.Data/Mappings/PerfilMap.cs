using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessoSeletivoTotvs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Infra.Data.Mappings
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            //nome da tabela
            builder.ToTable("Perfil");

            //chave primária
            builder.HasKey(u => u.Id);

            //mapeamento dos campos
            builder.Property(u => u.Id)
                .HasColumnName("Id");

            builder.Property(u => u.Perfis)
                .HasColumnName("Perfis")
                .HasMaxLength(150)
                .IsRequired();

            #region Relacionamentos

            builder.HasOne(f => f.Usuario) 
                .WithMany(e => e.Perfis) 
                .HasForeignKey(f => f.Id); 

            #endregion
        }
    }
}
