using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infraestructure.Data.Configurations
{
    public class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Transacoes");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Descricao).HasMaxLength(250).IsRequired();
            builder.Property(t => t.Valor).HasPrecision(18, 2);
            builder.Property(t => t.DataTransacao).IsRequired();
            builder.Property(t => t.TipoTransacao).IsRequired();
            builder.Property(t => t.DataCriacao).IsRequired();
        }
    }
}
