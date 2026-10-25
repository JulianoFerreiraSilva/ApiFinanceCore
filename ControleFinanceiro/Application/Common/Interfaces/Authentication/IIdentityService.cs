using ControleFinanceiro.Application.Authentication.DTO;

namespace ControleFinanceiro.Application.Common.Interfaces.Authentication
{
    public interface IIdentityService
    {
        Task<UsuarioTokenDto?> AutenticarAsync(string userName, string password);

        Task<UsuarioTokenDto?> ObterPorIdAsync(Guid usuarioId);
    }
}
