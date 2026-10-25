namespace ControleFinanceiro.Domain.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public Guid UsuarioId { get; private set; }

        public string Token { get; private set; } = string.Empty;

        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;

        public DateTime DataExpiracao { get; private set; }

        public DateTime? DataRevogacao { get; private set; }

        public RefreshToken(Guid usuarioId, string token, DateTime dataExpiracao)
        {
            if(usuarioId == Guid.Empty)
                throw new ArgumentException("Usuário invalido!", nameof(usuarioId));

            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("Token invalido.", nameof(token));

            if (dataExpiracao <= DateTime.UtcNow)
                throw new ArgumentException("A data de expiração deve ser futura!", nameof(dataExpiracao));

            UsuarioId = usuarioId;
            Token = token;
            DataExpiracao = dataExpiracao;
        }

        public bool TokenExpirado()
        {
            return DataExpiracao <= DateTime.UtcNow;
        }

        public bool TokenRevogado()
        {
            return DataRevogacao.HasValue;
        }

        public bool TokenValido()
        {
            return !TokenExpirado() && !TokenRevogado();
        }

        public void RevogarToken()
        {
            DataRevogacao = DateTime.UtcNow;
        }
    }
}
