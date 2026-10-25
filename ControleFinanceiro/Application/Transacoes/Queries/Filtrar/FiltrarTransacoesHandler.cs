using AutoMapper;
using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Application.Common.Pagination;
using ControleFinanceiro.Application.Transacoes.DTO;
using MediatR;

namespace ControleFinanceiro.Application.TransacaoApplication.Queries.Filtrar
{
    public class FiltrarTransacoesHandler : IRequestHandler<FiltrarTransacoesRequest, PagedResult<TransacaoResumoDto>>
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IMapper _mapper; 

        public FiltrarTransacoesHandler(ITransacaoRepository transacaoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _transacaoRepository = transacaoRepository;
        }

        public async Task<PagedResult<TransacaoResumoDto>> Handle(FiltrarTransacoesRequest request, CancellationToken cancellationToken)
        {
            var resultado = await _transacaoRepository.FiltrarTransacoesAsync(
                request.DataInicio,
                request.DataFim,
                request.ContaId,
                request.CategoriaId,
                request.TipoTransacao,
                request.Pagina,
                request.TamanhoPagina,
                cancellationToken);

            var itens = _mapper.Map<List<TransacaoResumoDto>>(resultado.Dados);

            return new PagedResult<TransacaoResumoDto>
            { 
                Itens = itens,
                PaginaAtual = request.Pagina,
                TamanhoPagina = request.TamanhoPagina,
                TotalRegistros = resultado.TotalRegistros
            };
        }
    }
}