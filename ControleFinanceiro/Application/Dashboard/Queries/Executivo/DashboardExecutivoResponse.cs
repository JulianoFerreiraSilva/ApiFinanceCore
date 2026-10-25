using ControleFinanceiro.Application.DashboardApplication.Queries.GastosPorCategoria;

namespace ControleFinanceiro.Application.DashboardApplication.Queries.Executivo
{
    public class DashboardExecutivoResponse
    {
        public decimal SaldoAtualTotal { get; set; }

        public decimal ReceitasMes { get; set; }

        public decimal DespesasMes { get; set; }

        public decimal ResultadoMes { get; set; }

        public decimal MaiorReceita { get; set; }

        public decimal MaiorDespesa { get; set; }

        public int QuantidadeReceitas { get; set; }

        public int QuantidadeDespesas { get; set; }

        public List<UltimaTransacaoDashboardResponse> UltimasTransacoes { get; set; } = new();

        public List<GastosPorCategoriasResponse> GastosPorCatergoria { get; set; } = new();

    }
}
