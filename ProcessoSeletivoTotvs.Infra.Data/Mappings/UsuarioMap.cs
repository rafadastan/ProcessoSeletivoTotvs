using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessoSeletivoTotvs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //nome da tabela
            builder.ToTable("Usuario");

            //chave primária
            builder.HasKey(u => u.Id);

            //mapeamento dos campos
            builder.Property(u => u.Id)
                .HasColumnName("Id");

            builder.Property(u => u.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnName("Senha")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.Created)
                .HasColumnName("Created")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(u => u.Modified)
                .HasColumnName("Modified")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(u => u.LastLogin)
                .HasColumnName("LastLogin")
                .HasColumnType("date")
                .IsRequired();

        }
    }
}
