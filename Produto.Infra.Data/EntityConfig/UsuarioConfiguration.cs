using Produto.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Produto.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(c => c.UsuarioId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Sobrenome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Login)
                .IsRequired()
                .HasMaxLength(150);
            Property(c => c.Senha)
                .IsRequired()
                .HasMaxLength(500);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(15);

            Property(c => c.DataCadastro)
               .HasColumnType("datetime2")
               .IsOptional();

            Property(c => c.DataAlteracao)
               .HasColumnType("datetime2")
               .IsOptional();

        }
    }
}
