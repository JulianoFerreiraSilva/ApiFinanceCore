using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infraestructure.Data.Configurations
{
    public class ContaConfiguration : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("Contas");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(150);
            builder.Property(c => c.SaldoAtual).HasPrecision(18, 2);
            builder.Property(c => c.SaldoInicial).HasPrecision(18, 2);
            builder.Property(c => c.Ativa).IsRequired();

            builder.HasMany(c => c.Transacoes).WithOne(t => t.Conta)
                .HasForeignKey(t => t.ContaId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
