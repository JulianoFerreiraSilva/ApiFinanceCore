using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Application.Common.Interfaces.UnitOfWork;
using MediatR;

namespace ControleFinanceiro.Application.Categorias.Command.Remover
{
    public class RemoverCategoriaHandler : IRequestHandler<RemoverCategoriaRequest, bool>
    {
        private readonly ICategoriaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoverCategoriaHandler(ICategoriaRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(RemoverCategoriaRequest request, CancellationToken cancellationToken)
        {
            var categoria = await _repository.ObterCategoriaPorIdAsync(request.Id);

            if (categoria == null) 
            {
                return false;
            }

            categoria.Ativa = false;
            categoria.DataAtualizacao = DateTime.UtcNow;

            _repository.RemoveCategoria(categoria);
            await _unitOfWork.SalvaInsercoesAlteracoesAsync(cancellationToken);

            return true;
        }
    }
}
