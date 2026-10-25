using ControleFinanceiro.Application.Authentication.DTO;
using ControleFinanceiro.Application.Common.Interfaces.Authentication;
using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ControleFinanceiro.Infraestructure.Authentication
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwt;
        private readonly IRefreshTokenHasher _refreshtokenHasher;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public TokenService(IOptions<JwtSettings> jwt, IRefreshTokenRepository refreshToken, IRefreshTokenHasher refreshTokenHasher)
        {
            _jwt = jwt.Value;
            _refreshTokenRepository = refreshToken;
            _refreshtokenHasher = refreshTokenHasher;
        }

        private string GerarAccessToken(UsuarioTokenDto usuario, DateTime dataExpiracao)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, usuario.Id.ToString())
            };

            foreach (var role in usuario.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: dataExpiracao,
                signingCredentials: credenciais);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GerarRefreshToken()
        {
            var bytes = RandomNumberGenerator.GetBytes(32);

            return Convert.ToBase64String(bytes);
        }

        public async Task<TokenDto> GerarTokensAsync(UsuarioTokenDto usuario)
        {
            var dataExpiracaoAccessToken = DateTime.UtcNow.AddMinutes(_jwt.ExpirationMinutes);
            var accessToken = GerarAccessToken(usuario, dataExpiracaoAccessToken);
            var refreshToken = GerarRefreshToken();
            var refreshTokenHash = _refreshtokenHasher.CalcularHash(refreshToken);
            var dataExpiracaoRefreshToken = DateTime.UtcNow.AddDays(_jwt.RefreshTokenExpirationDays);

            var refreshTokenEntity = new RefreshToken(
                usuario.Id,
                refreshTokenHash,
                dataExpiracaoRefreshToken);

            await _refreshTokenRepository.AdicionarTokenAsync(refreshTokenEntity);

            return new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresAt = dataExpiracaoAccessToken
            };
        }
    }
}
