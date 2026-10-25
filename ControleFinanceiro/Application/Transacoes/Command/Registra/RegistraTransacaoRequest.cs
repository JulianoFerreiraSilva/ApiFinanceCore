using ControleFinanceiro.Domain.Enums;
using MediatR;

namespace ControleFinanceiro.Application.TransacaoApplication.Command.Registra
{
    public class RegistraTransacaoRequest : IRequest<RegistraTransacaoResponse>
    {
        public string Descricao { get; set; } = string.Empty;

        public decimal Valor { get; set; }

        public DateTime DataTransacao { get; set; }

        public TipoTransacao TipoTransacao { get; set; }

        public Guid ContaId { get; set; }

        public Guid CategoriaId { get; set; }
    }
}
