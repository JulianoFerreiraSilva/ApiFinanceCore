using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infraestructure.Data.Mapping;

public class ContaMap : IEntityTypeConfiguration<Conta>
{
    public void Configure(EntityTypeBuilder<Conta> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.SaldoInicial)
            .HasPrecision(18,2);

        builder.Property(c => c.Ativa)
            .HasDefaultValue(true);

        builder.HasMany(c => c.Transacoes)
        .WithOne(c => c.Conta)
        .HasForeignKey(c => c.ContaId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
