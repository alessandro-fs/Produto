﻿using Produto.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Produto.Infra.Data.EntityConfig
{
    public class SetorConfiguration : EntityTypeConfiguration<Setor>
    {
        public SetorConfiguration()
        {
            HasKey(c => c.SetorId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            HasRequired(c => c.Celula)
                 .WithMany()
                 .HasForeignKey(c => c.CelulaId);

            Property(c => c.UsuarioCadastro)
                .IsOptional()
                .HasMaxLength(50);

            Property(c => c.DataCadastro)
                .HasColumnType("datetime2")
                .IsOptional();

            Property(c => c.UsuarioAlteracao)
                .IsOptional()
                .HasMaxLength(50);

            Property(c => c.DataAlteracao)
                .HasColumnType("datetime2")
                .IsOptional();

            Property(c => c.Excluido)
                .IsOptional();
        }
    }
}
