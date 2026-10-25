using MediatR;

namespace ControleFinanceiro.Application.Categorias.Query.Listar
{
    public class ListarTodasAsTransacoesRequest : IRequest<List<ListarCategoriasResponse>>
    {
    }
}
