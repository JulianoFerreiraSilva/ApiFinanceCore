using ControleFinanceiro.Application.Common.Interfaces.Authentication;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace ControleFinanceiro.Infraestructure.Authentication
{
    public class RefreshTokenHasher : IRefreshTokenHasher
    {
        public string CalcularHash(string token)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(token);
            
            var bytes = Encoding.UTF8.GetBytes(token);
            var hash = SHA256.HashData(bytes);

            return Convert.ToHexString(hash);

        }
    }
}
