using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infraestructure.Data.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("RefreshTokens");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Token).IsRequired().HasMaxLength(64);
            builder.HasIndex(r => r.Token).IsUnique();

            builder.Property(r => r.UsuarioId).IsRequired();
            builder.Property(r => r.Token).IsRequired();
            builder.Property(r => r.DataCriacao).IsRequired();
            builder.Property(r => r.DataExpiracao).IsRequired();
            builder.Property(r => r.DataRevogacao).IsRequired(false);
            builder.HasIndex(r => r.Token).IsUnique();
        }
    }
}
