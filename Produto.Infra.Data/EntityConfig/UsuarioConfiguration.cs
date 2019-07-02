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
                .IsOptional()
                .HasMaxLength(150);

            Property(c => c.Login)
                .IsOptional()
                .HasMaxLength(150);
            Property(c => c.Senha)
                .IsOptional()
                .HasMaxLength(500);

            Property(c => c.Email)
                .IsOptional()
                .HasMaxLength(150);

            Property(c => c.Telefone)
                .IsOptional()
                .HasMaxLength(15);

            Property(c => c.DataCadastro)
               .HasColumnType("datetime2")
               .IsOptional();

            Property(c => c.DataAlteracao)
               .HasColumnType("datetime2")
               .IsOptional();

            Property(c => c.FacebookAccessToken)
                .IsOptional()
                .HasMaxLength(250);

            Property(c => c.FacebookId)
               .IsOptional()
               .HasMaxLength(50);

        }
    }
}
