using ControleFinanceiro.Domain.Enums;

namespace ControleFinanceiro.Application.TransacaoApplication.Queries.Listar
{
    public class ListarTodasAsTransacoesResponse
    {
        public Guid Id { get; init; }

        public string Descricao { get; init; } = string.Empty;

        public decimal Valor { get; init; }

        public DateTime DataTransacao { get; init; }

        public TipoTransacao TipoTransacao { get; init; }

        public Guid ContaId { get; init; }

        public string NomeConta { get; init; } = string.Empty;

        public Guid CategoriaId { get; init; }

        public string NomeCategoria { get; init; } = string.Empty;
    }
}
