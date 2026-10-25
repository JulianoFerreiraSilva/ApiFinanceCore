using FluentValidation;

namespace ControleFinanceiro.Application.TransacaoApplication.Command.Atualiza
{
    public class AtualizaTransacaoValidator : AbstractValidator<AtualizaTransacaoRequest>
    {
        public AtualizaTransacaoValidator()
        {
            RuleFor(t => t.Id)
           .NotEmpty();

            RuleFor(t => t.Descricao)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(t => t.Valor)
                .GreaterThan(0);

            RuleFor(t => t.ContaId)
                .NotEmpty();

            RuleFor(t => t.CategoriaId)
                .NotEmpty();
        }
    }
}
