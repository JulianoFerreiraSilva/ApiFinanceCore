namespace ControleFinanceiro.Application.Common.Pagination
{
    public class PagedResult<T>
    {
        public IReadOnlyCollection<T> Itens { get; init; } = [];

        public int PaginaAtual { get; init; }

        public int TamanhoPagina { get; init; }

        public int TotalRegistros { get; init; }

        public int TotalPaginas => 
            TotalRegistros == 0 ? 0 : (int)Math.Ceiling(TotalRegistros / (double)TamanhoPagina);

        public bool TemPaginaAnterior => PaginaAtual > 1;

        public bool TemProximaPagina => PaginaAtual < TotalPaginas;
    }
}
