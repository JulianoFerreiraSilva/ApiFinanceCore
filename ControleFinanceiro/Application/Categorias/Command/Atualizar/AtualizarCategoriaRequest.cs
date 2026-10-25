using MediatR;

namespace ControleFinanceiro.Application.Categorias.Command.Atualizar
{
    public class AtualizarCategoriaRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public bool Ativa { get; set; }
    }
}
