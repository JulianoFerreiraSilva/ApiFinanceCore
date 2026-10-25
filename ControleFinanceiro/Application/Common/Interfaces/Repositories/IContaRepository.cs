using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Common.Interfaces.Repositories
{
    public interface IContaRepository
    {
        Task<Conta?> ObterContaPorIdAsync(Guid id, CancellationToken cancellationToken);

        Task<List<Conta>> ObterTodasAsContasAsync(CancellationToken cancellationToken);

        Task AdicionaConta(Conta conta);

        void AtualizaConta(Conta conta);

        void RemoveConta(Conta conta);
    }
}
