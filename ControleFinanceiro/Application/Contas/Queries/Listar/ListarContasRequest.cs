using ControleFinanceiro.Application.Categorias.Query.Listar;
using ControleFinanceiro.Domain.Enums;
using MediatR;

namespace ControleFinanceiro.Application.Contas.Queries.Listar
{
    public class ListarContasRequest : IRequest<List<ListarContasResponse>>
    {       
    }
}
