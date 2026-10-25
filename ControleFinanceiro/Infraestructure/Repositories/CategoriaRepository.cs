using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infraestructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _cont;

        public CategoriaRepository(AppDbContext context)
        {
            _cont = context;
        }

        public async Task AdicionaCategoria(Categoria categoria)
        {
            await _cont.Categorias.AddAsync(categoria);
        }

        public void AtualizaCategoria(Categoria categoria)
        {
            _cont.Categorias.Update(categoria);
        }

        public async Task<Categoria?> ObterCategoriaPorIdAsync(Guid id)
        {
           return await _cont.Categorias.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Categoria>> ObterTodasAsCategoriasAsync(CancellationToken cancellationToken)
        {
            return await _cont.Categorias.AsNoTracking().OrderBy(c => c.Nome).ToListAsync();
        }

        public void RemoveCategoria(Categoria categoria)
        {
            _cont.Categorias.Remove(categoria);
        }
    }
}

