using ControleFinanceiro.Application.Contas.Command.Atualiza;
using FluentValidation;

namespace ControleFinanceiro.Application.Contas.Command.Atualizar
{
    public class AtualizarContaValidator : AbstractValidator<AtualizaContaRequest>
    {
        public AtualizarContaValidator()
        {
            RuleFor(c => c.Nome)
                .Must(nome => !string.IsNullOrWhiteSpace(nome))
                .WithMessage("O nome da conta é obrigatório.")
                .MaximumLength(100)
                .WithMessage("O nome da conta deve ultrapassar 100 caracteres.");

            RuleFor(c => c.TipoConta)
                .IsInEnum()
                .WithMessage("O tipo da conta é inválido.");

            RuleFor(c => c.SaldoInicial)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O saldo inicial não pode ser negativo.");
        }
    }
}