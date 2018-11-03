using Produto.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Produto.Infra.Data.EntityConfig
{
    public class UnidadeConfiguration : EntityTypeConfiguration<Unidade>
    {
        public UnidadeConfiguration()
        {
            HasKey(c => c.UnidadeId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
