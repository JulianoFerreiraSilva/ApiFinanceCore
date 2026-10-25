using ControleFinanceiro.Application.Authentication.DTO;

namespace ControleFinanceiro.Application.Common.Interfaces.Authentication
{
    public interface ITokenService
    {
        Task<TokenDto> GerarTokensAsync(UsuarioTokenDto usuarioToken);
    }
}
