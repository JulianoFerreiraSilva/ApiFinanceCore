using MediatR;

namespace ControleFinanceiro.Application.Categorias.Command.Registra
{
    public class RegistraCategoriaRequest : IRequest<RegistraCategoriaResponse>
    {
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
    }
}
