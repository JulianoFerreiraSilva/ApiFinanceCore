using MediatR;

namespace ControleFinanceiro.Application.Categorias.Query.PesquisarPorId
{
    public class PesquisaPorIdRequest : IRequest<PesquisaPorIdRespose?>
    {
        public Guid Id { get; set; }
    }
}
