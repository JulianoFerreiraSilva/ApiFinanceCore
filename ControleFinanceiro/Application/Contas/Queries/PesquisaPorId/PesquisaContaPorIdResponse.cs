using ControleFinanceiro.Domain.Enums;

namespace ControleFinanceiro.Application.Contas.Queries.PesquisaPorId
{
    public class PesquisaContaPorIdResponse
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public TipoConta TipoConta { get; set; }

        public decimal SaldoInicial { get; set; }

        public bool Ativa { get; set; }

        public DateTime DataCriacao { get; set;}

        public DateTime? DataAtualizacao { get; set; }
    }
}
