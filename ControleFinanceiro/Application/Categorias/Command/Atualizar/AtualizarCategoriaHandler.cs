using ControleFinanceiro.Application.Common.Exceptions;
using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Application.Common.Interfaces.UnitOfWork;
using MediatR;

namespace ControleFinanceiro.Application.Categorias.Command.Atualizar
{
    public class AtualizarCategoriaHandler : IRequestHandler<AtualizarCategoriaRequest>
    {
        private readonly ICategoriaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarCategoriaHandler(ICategoriaRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AtualizarCategoriaRequest request, CancellationToken cancellationToken)
        { 
            var categoria = await _repository.ObterCategoriaPorIdAsync(request.Id);

            if (categoria == null)
            {
                throw new NotFoundException("Categoria", request.Id);
            }

            categoria.Nome = request.Nome;
            categoria.Descricao = request.Descricao;
            categoria.DataAtualizacao = DateTime.UtcNow;

            _repository.AtualizaCategoria(categoria);
            await _unitOfWork.SalvaInsercoesAlteracoesAsync(cancellationToken);

            return;
        }
    }
}
