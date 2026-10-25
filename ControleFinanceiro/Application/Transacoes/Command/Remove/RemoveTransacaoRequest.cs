using MediatR;

namespace ControleFinanceiro.Application.TransacaoApplication.Command.Remove
{
    public class RemoveTransacaoRequest : IRequest
    {
        public Guid Id { get; set; }
    }
}
