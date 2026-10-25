namespace ControleFinanceiro.Application.Common.Interfaces.Authentication
{
    public interface IRefreshTokenHasher
    {
        string CalcularHash(string token);
    }
}
