using AutoMapper;
using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Application.Transacoes.DTO;
using MediatR;

namespace ControleFinanceiro.Application.TransacaoApplication.Queries.Listar
{
    public class ListarTodasAsTransacoesHandler : IRequestHandler<ListasTodasAsTransacoesRequest, List<ListarTodasAsTransacoesResponse>>
    {

        private readonly ITransacaoRepository _tRepository;
        private readonly IMapper _mapper;

        public ListarTodasAsTransacoesHandler(ITransacaoRepository tRepository, IMapper mapper)
        {
            _mapper = mapper;
            _tRepository = tRepository;
        }

        public async Task<List<ListarTodasAsTransacoesResponse>> Handle(ListasTodasAsTransacoesRequest request, CancellationToken cancellationToken)
        {
            var transacoes = await _tRepository.ObterTodasAsTransacoesAsync(cancellationToken);
          
            return _mapper.Map<List<ListarTodasAsTransacoesResponse>>(transacoes);
        }
    }
}

