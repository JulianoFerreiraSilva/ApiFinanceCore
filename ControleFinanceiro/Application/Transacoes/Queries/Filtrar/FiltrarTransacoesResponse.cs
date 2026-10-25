namespace ControleFinanceiro.Application.TransacaoApplication.Queries.Filtrar
{
    public class FiltrarTransacoesResponse
    {
        public int TamanhoPagina { get; set; }

        public int TotalRegistros { get; set; }

        public int TotalPaginas { get; set; }

        public int Pagina {  get; set; }

        public List<FiltrarTransacoesItemResponse> Dados { get; set; } = new();
    }
}
