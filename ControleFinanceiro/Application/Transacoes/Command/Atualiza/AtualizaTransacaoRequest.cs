using ControleFinanceiro.Domain.Enums;
using MediatR;

namespace ControleFinanceiro.Application.TransacaoApplication.Command.Atualiza
{
    public class AtualizaTransacaoRequest : IRequest
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public decimal Valor { get; set; }

        public DateTime DataTransacao { get; set; }

        public TipoTransacao TipoTransacao { get; set; }

        public Guid ContaId { get; set; }

        public Guid CategoriaId { get; set; }
    }
}
