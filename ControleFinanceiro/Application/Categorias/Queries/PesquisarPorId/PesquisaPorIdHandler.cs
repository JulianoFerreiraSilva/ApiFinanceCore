using AutoMapper;
using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using MediatR;

namespace ControleFinanceiro.Application.Categorias.Query.PesquisarPorId
{
    public class PesquisaPorIdHandler : IRequestHandler<PesquisaPorIdRequest, PesquisaPorIdRespose>
    {
        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;

        public PesquisaPorIdHandler(ICategoriaRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<PesquisaPorIdRespose?> Handle(PesquisaPorIdRequest request, CancellationToken cancellationToken)
        {
            var categoria = await _repository.ObterCategoriaPorIdAsync(request.Id);

            if(categoria is null)
            {
                return null;
            }

            return _mapper.Map<PesquisaPorIdRespose>(categoria);
        }
    }
}
