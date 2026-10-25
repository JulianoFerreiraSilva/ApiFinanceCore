using ControleFinanceiro.Domain.Enums;

namespace ControleFinanceiro.Domain.Entities;

public class Transacao
{
    public Guid Id { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public decimal Valor { get; set; }

    public DateTime DataTransacao { get; set; }

    public TipoTransacao TipoTransacao { get; set; }

    public Guid ContaId { get; set; }

    public virtual Conta Conta { get; set; } = null!;

    public Guid CategoriaId { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public DateTime DataCriacao { get; set; }

    public DateTime? DataAtualizacao { get; set; }
}