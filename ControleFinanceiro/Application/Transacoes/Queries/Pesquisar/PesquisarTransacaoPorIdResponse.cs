using ControleFinanceiro.Domain.Enums;

namespace ControleFinanceiro.Application.TransacaoApplication.Queries.Pesquisar
{
    public class PesquisarTransacaoPorIdResponse
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public decimal Valor { get; set; }

        public DateTime DataTransacao { get; set; }

        public TipoTransacao TipoTransacao { get; set; }

        public Guid ContaId { get; set; }

        public string NomeConta { get; set; } = string.Empty;

        public Guid CategoriaId { get; set; }

        public string NomeCategoria { get; set; } = string.Empty;

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}
