using FluentValidation;

namespace ControleFinanceiro.Application.TransacaoApplication.Command.Registra
{
    public class RegistraTransacaoValidator : AbstractValidator<RegistraTransacaoRequest>
    {
        public RegistraTransacaoValidator()
        {
            RuleFor(t => t.Descricao).NotEmpty().WithMessage("A descrição é obrigatoria.").
                MaximumLength(150).WithMessage("A descrição não pode ultrapassar 150 caracteres.");

            RuleFor(t => t.Valor).
                GreaterThan(0).WithMessage("O valor deve ser maior que zero!");

            RuleFor(t => t.DataTransacao).
                NotEmpty().WithMessage("A data da transação é obrigatoria.");

            RuleFor(t => t.TipoTransacao).
                IsInEnum().WithMessage("Tipo de transação invalido.");

            RuleFor(t => t.ContaId).
                NotEmpty().WithMessage("A conta é obrigatoria.");

            RuleFor(t => t.CategoriaId).
                NotEmpty().WithMessage("A categoria é obrigatoria.");
        }
    }
}
