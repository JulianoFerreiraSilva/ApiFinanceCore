using MediatR;

namespace ControleFinanceiro.Application.Contas.Command.Remove
{
    public class RemoveContaRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
