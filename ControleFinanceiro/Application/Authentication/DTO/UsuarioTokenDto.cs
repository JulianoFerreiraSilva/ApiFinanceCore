namespace ControleFinanceiro.Application.Authentication.DTO
{
    public class UsuarioTokenDto
    {
        public Guid Id { get; init; }

        public IReadOnlyCollection<string> Roles { get; init; } = [];
    }
}
