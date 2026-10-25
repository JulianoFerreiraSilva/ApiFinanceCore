using ControleFinanceiro.Application.Common.Interfaces.UnitOfWork;
using ControleFinanceiro.Infraestructure.Data;

namespace ControleFinanceiro.Infraestructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _cont;

        public UnitOfWork(AppDbContext context)
        {
            _cont = context;
        }

        public async Task<int> SalvaInsercoesAlteracoesAsync(CancellationToken cancellationToken = default)
        {
            return await _cont.SaveChangesAsync(cancellationToken);
        }
    }
}