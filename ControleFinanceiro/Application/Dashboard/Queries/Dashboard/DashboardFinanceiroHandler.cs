using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Domain.Enums;
using MediatR;

namespace ControleFinanceiro.Application.DashboardApplication.Queries.Dashboard
{
    public class DashboardFinanceiroHandler : IRequestHandler<DashboardFinanceiroRequest, DashboardFinanceiroResponse>
    {
        private readonly ITransacaoRepository _tRepository;
        private readonly IContaRepository _cRepository;

        public DashboardFinanceiroHandler(ITransacaoRepository tRepository, IContaRepository cRepository)
        {
            _tRepository = tRepository;
            _cRepository = cRepository;
        }

        public async Task<DashboardFinanceiroResponse> Handle(DashboardFinanceiroRequest request, CancellationToken cancellationToken)
        {
            var contas = await _cRepository.ObterTodasAsContasAsync(cancellationToken);
            var transacoes = await _tRepository.ObterTodasAsTransacoesAsync(cancellationToken);

            var totalReceita = transacoes.
                Where(t => t.TipoTransacao == TipoTransacao.Receita).Sum(t => t.Valor);

            var totalDespesa = transacoes.
                Where(t => t.TipoTransacao == TipoTransacao.Despesa).Sum(t => t.Valor);

            return new DashboardFinanceiroResponse
            {
                SaldoAtualTotal = contas.Sum(c => c.SaldoAtual),
                TotalReceita = totalReceita,
                TotalDespesa = totalDespesa,
                QuantidadeTransacoes = transacoes.Count
            };
        }
    }
}
