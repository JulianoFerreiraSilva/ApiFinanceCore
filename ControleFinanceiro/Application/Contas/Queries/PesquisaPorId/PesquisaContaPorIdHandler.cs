using AutoMapper;
using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using MediatR;

namespace ControleFinanceiro.Application.Contas.Queries.PesquisaPorId
{
    public class PesquisaContaPorIdHandler : IRequestHandler<PesquisaContaPorIdRequest, PesquisaContaPorIdResponse>
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMapper _mapper;

        public PesquisaContaPorIdHandler(IContaRepository contaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _contaRepository = contaRepository;
        }

        public async Task<PesquisaContaPorIdResponse?> Handle(PesquisaContaPorIdRequest request, CancellationToken cancellationToken)
        {
            var conta = await _contaRepository.ObterContaPorIdAsync(request.Id, cancellationToken);

            if (conta == null)
                return null;

            return _mapper.Map<PesquisaContaPorIdResponse>(conta);
        }
    }
}
