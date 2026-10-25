using ControleFinanceiro.Application.Authentication.DTO;
using ControleFinanceiro.Application.Common.Interfaces.Authentication;
using ControleFinanceiro.Application.Common.Interfaces.UnitOfWork;
using MediatR;

namespace ControleFinanceiro.Application.Authentication.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, TokenDto>
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;

        public LoginHandler(IIdentityService identityService, ITokenService tokenService, IUnitOfWork unitOfWork)
        {
            _identityService = identityService;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
        }

        public async Task<TokenDto> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var usuario = await _identityService.AutenticarAsync(request.UserName, request.Password);

            if (usuario is null)
            {
                throw new UnauthorizedAccessException("Usuário ou senha inválidos!");
            }

            var tokens = await _tokenService.GerarTokensAsync(usuario);

            await _unitOfWork.SalvaInsercoesAlteracoesAsync();
            
            return tokens;
        }
    }
}
