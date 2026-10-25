using AutoMapper;
using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using MediatR;

namespace ControleFinanceiro.Application.Contas.Queries.Listar
{
    public class ListarContasHandler : IRequestHandler<ListarContasRequest, List<ListarContasResponse>>
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMapper _mapper;

        public ListarContasHandler(IContaRepository contaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _contaRepository = contaRepository;
        }

        public async Task<List<ListarContasResponse>> Handle(ListarContasRequest request,  CancellationToken cancellationToken)
        {
            var contas = await _contaRepository.ObterTodasAsContasAsync(cancellationToken);

            return _mapper.Map<List<ListarContasResponse>>(contas);
        }
    }
}