using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Domain.Enums;
using MediatR;

namespace ControleFinanceiro.Application.DashboardApplication.Queries.Executivo
{
    public class DashboardExecutivoHandler : IRequestHandler<DashboardExecutivoRequest, DashboardExecutivoResponse>
    {
        private readonly IContaRepository _cRepository;
        private readonly ITransacaoRepository _tRepository;

        public DashboardExecutivoHandler(IContaRepository cRepository, ITransacaoRepository tRepository)
        {
            _cRepository = cRepository;
            _tRepository = tRepository;
        }

        public async Task<DashboardExecutivoResponse> Handle(DashboardExecutivoRequest request, CancellationToken cancellationToken)
        {
            var contas = await _cRepository.ObterTodasAsContasAsync(cancellationToken);
            var transacoesMes = await _tRepository.ObterTransacoesDoMesAtualAsync(cancellationToken);

            var receitas = transacoesMes.Where(t => t.TipoTransacao == TipoTransacao.Receita).ToList();
            var despesas = transacoesMes.Where(t => t.TipoTransacao == TipoTransacao.Despesa).ToList();

            var receitasMes = receitas.Sum(t => t.Valor);
            var despesasMes = despesas.Sum(t => t.Valor);

            return new DashboardExecutivoResponse
            {
                SaldoAtualTotal = contas.Sum(c => c.SaldoAtual),
                ReceitasMes = receitasMes,
                DespesasMes = despesasMes,
                ResultadoMes = receitasMes - despesasMes,
                MaiorReceita = receitas.Any() ? receitas.Max(t => t.Valor) : 0,
                MaiorDespesa = despesas.Any() ? despesas.Max(t => t.Valor) : 0,
                QuantidadeReceitas = receitas.Count,
                QuantidadeDespesas = despesas.Count,

                UltimasTransacoes = transacoesMes.OrderByDescending(t => t.DataTransacao).Take(5).
                Select(t => new UltimaTransacaoDashboardResponse
                {
                    Descricao = t.Descricao,
                    Valor = t.Valor,
                    DataTransacao = t.DataTransacao,
                    TipoTransacao = t.TipoTransacao.ToString(),
                    NomeConta = t.Conta.Nome,
                    NomeCategoria = t.Categoria.Nome
                }).ToList(),

                GastosPorCatergoria = despesas.GroupBy(t => t.Categoria.Nome).
                Select(g => new GastosPorCategoria.GastosPorCategoriasResponse 
                {
                    Categoria = g.Key,
                    ValorTotal = g.Sum(t => t.Valor),
                }).OrderByDescending(g => g.ValorTotal).ToList()
            };
        }
    }
}
