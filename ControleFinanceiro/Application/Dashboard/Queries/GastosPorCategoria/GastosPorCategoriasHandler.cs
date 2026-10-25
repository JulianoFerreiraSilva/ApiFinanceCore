using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using MediatR;

namespace ControleFinanceiro.Application.DashboardApplication.Queries.
    GastosPorCategoria
{
    public class GastosPorCategoriasHandler : IRequestHandler<GastosPorCategoriaRequest, List<GastosPorCategoriasResponse>>
    {
        private readonly ITransacaoRepository _tRepository;

        public GastosPorCategoriasHandler(ITransacaoRepository tRepository)
        {
            _tRepository = tRepository;
        }

        public async Task<List<GastosPorCategoriasResponse>> Handle(GastosPorCategoriaRequest request, CancellationToken cancellationToken)
        {
            var despesas = await _tRepository.ObterTransacoesPorPeriodoAsync(request.DataInicial, request.DataFinal);

            return despesas.GroupBy(t => t.Categoria.Nome).Select(g => new GastosPorCategoriasResponse
            {
                Categoria = g.Key,
                ValorTotal = g.Sum(t => t.Valor)
            }).OrderByDescending(v => v.ValorTotal).ToList();
        } 
    }
}
