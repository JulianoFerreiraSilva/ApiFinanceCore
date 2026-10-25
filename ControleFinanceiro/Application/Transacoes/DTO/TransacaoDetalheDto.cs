using ControleFinanceiro.Domain.Enums;

namespace ControleFinanceiro.Application.Transacoes.DTO;

public class TransacaoDetalheDto
{
    public Guid Id { get; init; }

    public string Descricao { get; init; } = string.Empty;

    public decimal Valor { get; init; }

    public DateTime DataTransacao { get; init; }

    public TipoTransacao TipoTransacao { get; init; }

    public Guid ContaId { get; init; }

    public string ContaNome { get; init; } = string.Empty;

    public Guid CategoriaId { get; init; }

    public string CategoriaNome { get; init; } = string.Empty;

    public DateTime DataCriacao { get; init; }

    public DateTime? DataAtualizacao { get; init; }
}