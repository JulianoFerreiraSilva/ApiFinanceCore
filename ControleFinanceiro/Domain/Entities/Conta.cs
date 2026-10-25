using ControleFinanceiro.Domain.Enums;

namespace ControleFinanceiro.Domain.Entities;

public class Conta
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public TipoConta TipoConta { get; set; }

    public decimal SaldoInicial { get; set; }

    public decimal SaldoAtual { get; set; }

    public bool Ativa { get; set; } = true;

    public DateTime DataCriacao { get; set; }

    public DateTime? DataAtualizacao { get; set; }

    public virtual ICollection<Transacao>? Transacoes { get; set; }
}