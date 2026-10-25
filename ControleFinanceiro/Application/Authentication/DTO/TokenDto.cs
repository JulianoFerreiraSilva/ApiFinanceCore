namespace ControleFinanceiro.Application.Authentication.DTO
{
    public class TokenDto
    {
        public string AccessToken { get; init; } = string.Empty;

        public string RefreshToken { get; init; } = string.Empty;

        public DateTime ExpiresAt { get; init; }
    }
}
