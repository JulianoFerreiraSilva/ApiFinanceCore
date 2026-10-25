namespace ControleFinanceiro.Application.DashboardApplication.Queries.Executivo
{
    public class UltimaTransacaoDashboardResponse
    {
        public string Descricao { get; set; } = string.Empty;

        public decimal Valor { get; set; }

        public DateTime DataTransacao { get; set; }

        public string TipoTransacao { get; set; } = string.Empty;

        public string NomeConta { get; set; } = string.Empty;

        public string NomeCategoria { get; set; } = string.Empty;
    }
}
