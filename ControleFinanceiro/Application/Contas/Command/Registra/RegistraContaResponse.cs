using ControleFinanceiro.Domain.Enums;

namespace ControleFinanceiro.Application.Contas.Command.Registra
{
    public class RegistraContaResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public TipoConta TipoConta { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal SaldoAtual { get; set; }
    }
}
