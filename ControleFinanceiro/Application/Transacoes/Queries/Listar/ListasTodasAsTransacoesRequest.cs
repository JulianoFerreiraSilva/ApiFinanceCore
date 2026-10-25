using MediatR;

namespace ControleFinanceiro.Application.TransacaoApplication.Queries.Listar
{
    public class ListasTodasAsTransacoesRequest : IRequest<List<ListarTodasAsTransacoesResponse>>
    {
    }
}
