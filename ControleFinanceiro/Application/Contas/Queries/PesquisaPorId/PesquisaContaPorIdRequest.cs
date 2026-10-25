using MediatR;

namespace ControleFinanceiro.Application.Contas.Queries.PesquisaPorId
{
    public class PesquisaContaPorIdRequest : IRequest<PesquisaContaPorIdResponse>
    {
        public Guid Id { get; set; }
    }
}
