using ControleFinanceiro.Application.Authentication.DTO;
using MediatR;

namespace ControleFinanceiro.Application.Authentication.Login
{
    public class LoginRequest : IRequest<TokenDto>
    {
        public string UserName { get; init; } = string.Empty;

        public string Password { get; init; } = string.Empty;
    }
}
