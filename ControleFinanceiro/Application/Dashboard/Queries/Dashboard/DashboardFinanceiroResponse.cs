namespace ControleFinanceiro.Application.DashboardApplication.Queries.Dashboard
{
    public class DashboardFinanceiroResponse
    {
        public decimal SaldoAtualTotal { get; set; }
        public decimal TotalReceita { get; set; }
        public decimal TotalDespesa { get; set; }
        public int QuantidadeTransacoes { get; set; }
    }
}
