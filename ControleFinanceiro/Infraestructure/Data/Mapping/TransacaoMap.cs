using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infraestructure.Data.Mapping;

public class TransacaoMap : IEntityTypeConfiguration<Transacao>
{
    public void Configure(EntityTypeBuilder<Transacao> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Descricao)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Valor)
            .HasPrecision(18, 2);

        builder.Property(t => t.TipoTransacao)
            .HasConversion<int>();

        builder.HasIndex(t => t.DataTransacao);

        builder.HasIndex(t => t.ContaId);

        builder.HasIndex(t => t.CategoriaId);
    }
}