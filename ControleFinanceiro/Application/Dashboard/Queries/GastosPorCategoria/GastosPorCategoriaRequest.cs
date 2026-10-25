using MediatR;

namespace ControleFinanceiro.Application.DashboardApplication.Queries.GastosPorCategoria
{
    public class GastosPorCategoriaRequest : IRequest<List<GastosPorCategoriasResponse>>
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
