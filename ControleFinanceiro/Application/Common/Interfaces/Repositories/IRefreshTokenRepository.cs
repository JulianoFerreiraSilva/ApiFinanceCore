using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Common.Interfaces.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task AdicionarTokenAsync(RefreshToken refreshToken);

        Task<RefreshToken?> BuscarPorTokenAsync(string token, CancellationToken cancellationToken);

        Task<bool> TentarRevogarTokenAsync(string tokenHash, CancellationToken cancellationToken);

        void AtualizaToken(RefreshToken refreshToken);
    }
}
