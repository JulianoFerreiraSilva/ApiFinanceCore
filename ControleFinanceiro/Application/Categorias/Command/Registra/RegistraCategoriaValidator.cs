using FluentValidation;

namespace ControleFinanceiro.Application.Categorias.Command.Registra
{
    public class RegistraCategoriaValidator : AbstractValidator<RegistraCategoriaRequest>
    {
        public RegistraCategoriaValidator()
        {
            RuleFor(c => c.Nome)
                .Must(c => !string.IsNullOrWhiteSpace(c))
                .WithMessage("O nome da categoria é obrigatorio")
                .MaximumLength(100);

            RuleFor(c => c.Descricao)
                .MaximumLength(250)
                .WithMessage("A descrição não pode ultrapassar 250 caracteres!!");
        }
    }
}
