

namespace ControleFinanceiro.Application.Common.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        Task<Domain.Entities.Categoria> ObterCategoriaPorIdAsync(Guid id);

        Task<List<Domain.Entities.Categoria>> ObterTodasAsCategoriasAsync(CancellationToken cancellationToken);

        Task AdicionaCategoria(Domain.Entities.Categoria categoria);

        void AtualizaCategoria(Domain.Entities.Categoria categoria);

        void RemoveCategoria(Domain.Entities.Categoria categoria);

    }
}
