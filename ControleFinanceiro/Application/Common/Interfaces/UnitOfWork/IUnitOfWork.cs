namespace ControleFinanceiro.Application.Common.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SalvaInsercoesAlteracoesAsync(CancellationToken cancellationToken = default);
    }
}
