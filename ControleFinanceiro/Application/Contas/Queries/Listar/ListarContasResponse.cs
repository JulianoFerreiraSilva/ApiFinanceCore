using ControleFinanceiro.Domain.Enums;

namespace ControleFinanceiro.Application.Contas.Queries.Listar
{
    public class ListarContasResponse
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public TipoConta TipoConta { get; set; }

        public decimal SaldoInicial { get; set; }

        public decimal SaldoAtual { get; set; }

        public bool Ativa { get; set; }
    }
}