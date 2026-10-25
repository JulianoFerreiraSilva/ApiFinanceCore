using ControleFinanceiro.Domain.Enums;

namespace ControleFinanceiro.Application.TransacaoApplication.Command.Registra
{
    public class RegistraTransacaoResponse
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public decimal Valor { get; set; }

        public DateTime DataTransacao { get; set; }

        public TipoTransacao TipoTransacao { get; set; }

        public Guid ContaId { get; set; }

        public Guid CategoriaId { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
