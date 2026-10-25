using ControleFinanceiro.Application.Authentication.DTO;
using ControleFinanceiro.Application.Common.Interfaces.Authentication;
using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Application.Common.Interfaces.UnitOfWork;
using MediatR;

namespace ControleFinanceiro.Application.Authentication.Refresh
{
    public class RefreshHandler : IRequestHandler<RefreshRequest, TokenDto>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IRefreshTokenHasher _refreshTokenHasher;
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;

        public RefreshHandler(IRefreshTokenRepository refreshTokenRepository, 
            IIdentityService identityService, ITokenService tokenService, IUnitOfWork unitOfWork, IRefreshTokenHasher refreshTokenHasher)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _identityService = identityService;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _refreshTokenHasher = refreshTokenHasher;
        }

        public async Task<TokenDto> Handle(RefreshRequest request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrWhiteSpace(request.RefreshToken))
            {
                throw new UnauthorizedAccessException("Refresh token invalido.");
            }

            var refreshTokenHash = _refreshTokenHasher.CalcularHash(request.RefreshToken);
            var refreshToken = await _refreshTokenRepository.BuscarPorTokenAsync(refreshTokenHash, cancellationToken);

            if (refreshToken is null || !refreshToken.TokenValido())
            {
                throw new UnauthorizedAccessException("Refresh token invalido.");
            }

            var usuario = await _identityService.ObterPorIdAsync(refreshToken.UsuarioId);

            if(usuario is null)
            {
                throw new UnauthorizedAccessException("Refresh token invalido.");
            }

            refreshToken.RevogarToken();
            _refreshTokenRepository.AtualizaToken(refreshToken);

            var tokens = await _tokenService.GerarTokensAsync(usuario);
            await _unitOfWork.SalvaInsercoesAlteracoesAsync();

            return tokens;
        }
    }
}
