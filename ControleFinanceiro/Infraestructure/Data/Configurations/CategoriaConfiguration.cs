using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infraestructure.Data.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Descricao).HasMaxLength(500);
            builder.Property(c => c.Ativa).IsRequired();
            builder.Property(c => c.DataCriacao).IsRequired();

            builder.HasMany(c => c.Transacoes).WithOne(t => t.Categoria)
                .HasForeignKey(t => t.CategoriaId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
