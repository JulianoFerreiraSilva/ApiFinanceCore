namespace ControleFinanceiro.Application.Common.Pagination
{
    public abstract class PaginationRequest
    {
        private const int TamanhoMaximoPagina = 100;

        private int _pagina = 1;
        private int _tamanhoPagina = 10;

        public int Pagina
        {
            get => _pagina;
            set => _pagina = value < 1 ? 1 : value;
        }

        public int TamanhoPagina
        {
            get => _tamanhoPagina;
            set
            {
                if(value < 1)
                {
                    _tamanhoPagina = 10;
                    return;
                }

                _tamanhoPagina = value > TamanhoMaximoPagina ?
                    TamanhoMaximoPagina : value;
            }
        }
    }
}
