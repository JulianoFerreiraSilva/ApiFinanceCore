using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infraestructure.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private AppDbContext _cont;
        public ContaRepository(AppDbContext context)
        {
            _cont = context;
        }
        public async Task AdicionaConta(Conta conta)
        {
            await _cont.Contas.AddAsync(conta);
        }

        public void AtualizaConta(Conta conta)
        {
            _cont.Contas.Update(conta);
        }

        public async Task<Conta?> ObterContaPorIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _cont.Contas.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Conta>> ObterTodasAsContasAsync(CancellationToken cancellationToken)
        {
            return await _cont.Contas.AsNoTracking().OrderBy(c => c.Nome).ToListAsync(cancellationToken);
        }

        public void RemoveConta(Conta conta)
        {
            _cont.Contas.Remove(conta);
        }
    }
}
