using Produto.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Produto.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(c => c.UsuarioId);

            Property(c => c.Login)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Senha)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(15);

        }
    }
}
