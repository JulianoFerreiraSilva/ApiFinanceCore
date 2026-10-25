using ControleFinanceiro.Domain.Enums;

namespace ControleFinanceiro.Application.Transacoes.DTO
{
    public class TransacaoResumoDto
    {
        public Guid Id { get; init; }

        public string Descricao { get; init; } = string.Empty;

        public decimal Valor { get; init; }

        public DateTime DataTransacao { get; init; }

        public TipoTransacao TipoTransacao { get; init; }

        public string ContaNome { get; init; } = string.Empty;

        public string CategoriaNome { get; init; } = string.Empty;
    }
}
