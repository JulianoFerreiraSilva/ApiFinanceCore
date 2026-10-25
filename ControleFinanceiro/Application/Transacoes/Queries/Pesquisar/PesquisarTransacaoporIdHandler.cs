using AutoMapper;
using ControleFinanceiro.Application.Common.Exceptions;
using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Application.Transacoes.DTO;
using MediatR;

namespace ControleFinanceiro.Application.TransacaoApplication.Queries.Pesquisar
{
    public class PesquisarTransacaoporIdHandler : IRequestHandler<PesquisarTransacoesPorIdRequest, TransacaoDetalheDto>
    {
        private readonly ITransacaoRepository _tRepository;
        private readonly IMapper _mapper;

        public PesquisarTransacaoporIdHandler(ITransacaoRepository tRepository, IMapper mapper)
        {
            _mapper = mapper;
            _tRepository = tRepository;
        }

        public async Task<TransacaoDetalheDto> Handle(PesquisarTransacoesPorIdRequest request, CancellationToken cancellationToken)
        {
            var transacao = await _tRepository.ObterTransacaoPorIdAsync(request.Id, cancellationToken);

            if(transacao is null)
            {
                throw new NotFoundException("Transação ", request.Id);
            }

            return _mapper.Map<TransacaoDetalheDto>(transacao);
        }
    }
}
