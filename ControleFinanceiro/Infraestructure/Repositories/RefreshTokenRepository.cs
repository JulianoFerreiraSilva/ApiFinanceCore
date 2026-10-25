using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infraestructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly AppDbContext _cont;
        public RefreshTokenRepository(AppDbContext cont)
        {
            _cont = cont;
        }

        public async Task AdicionarTokenAsync(RefreshToken refreshToken)
        {
            await _cont.RefreshTokens.AddAsync(refreshToken);
        }

        public void AtualizaToken(RefreshToken refreshToken)
        {
            _cont.RefreshTokens.Update(refreshToken);
        }

        public async Task<bool> TentarRevogarTokenAsync(string tokenHash, CancellationToken cancellationToken)
        {
            var dataAtual = DateTime.UtcNow;

            var linhasAfetadas = await _cont.RefreshTokens.Where(r => r.Token == tokenHash && r.DataRevogacao == null
                                 && r.DataExpiracao > dataAtual).ExecuteUpdateAsync(setters => 
                                 setters.SetProperty(r => r.DataRevogacao, dataAtual), cancellationToken);

            return linhasAfetadas == 1;
        }

        public async Task<RefreshToken?> BuscarPorTokenAsync(string token, CancellationToken cancellationToken)
        {
            var tokenEncontrado = await _cont.RefreshTokens.FirstOrDefaultAsync(r => r.Token == token, cancellationToken);
            return tokenEncontrado;
        }
    }
}
