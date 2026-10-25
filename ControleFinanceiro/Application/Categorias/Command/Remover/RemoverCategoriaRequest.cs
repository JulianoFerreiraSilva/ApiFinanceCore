using MediatR;

namespace ControleFinanceiro.Application.Categorias.Command.Remover
{
    public class RemoverCategoriaRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
