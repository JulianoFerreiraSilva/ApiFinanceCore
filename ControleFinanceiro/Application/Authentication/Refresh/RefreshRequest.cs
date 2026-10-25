using ControleFinanceiro.Application.Authentication.DTO;
using MediatR;

namespace ControleFinanceiro.Application.Authentication.Refresh
{
    public class RefreshRequest : IRequest<TokenDto>
    {
        public string RefreshToken { get; init; } = string.Empty;
    }
}
