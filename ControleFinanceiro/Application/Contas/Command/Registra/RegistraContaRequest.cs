using ControleFinanceiro.Domain.Enums;
using MediatR;

namespace ControleFinanceiro.Application.Contas.Command.Registra
{
    public class RegistraContaRequest : IRequest<RegistraContaResponse>
    {
        public string Nome { get; set; } = string .Empty;
        public TipoConta TipoConta { get; set; }
        public decimal SaldoInicial { get; set; }
    }
}
