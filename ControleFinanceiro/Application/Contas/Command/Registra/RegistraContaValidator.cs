using FluentValidation;

namespace ControleFinanceiro.Application.Contas.Command.Registra
{
    public class RegistraContaValidator : AbstractValidator<RegistraContaRequest>
    {
        public RegistraContaValidator()
        {
            RuleFor(c => c.Nome)
                .Must(nome => !string.IsNullOrWhiteSpace(nome))
                .WithMessage("O nome da conta é obrigatorio!")
                .MaximumLength(100)
                .WithMessage("O nome da conta não pode ultrapasar 100 caracteres");

            RuleFor(t => t.TipoConta)
                .IsInEnum()
                .WithMessage("O tipo da conta é invalido");

            RuleFor(c => c.SaldoInicial)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O Saldo inicial não pode ser negativo!");
        }
    }
}
