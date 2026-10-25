using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Enums;

namespace ControleFinanceiro.Application.Common.Interfaces.Repositories
{
    public interface ITransacaoRepository
    {
        Task<List<Transacao>> ObterTransacoesDoMesAtualAsync(CancellationToken cancellationToken);

        Task<List<Transacao>> ObterTransacoesPorPeriodoAsync(DateTime? dataInicio, DateTime? dataFinal);

        Task<Transacao?> ObterTransacaoPorIdAsync(Guid id, CancellationToken cancellationToken);

        Task<List<Transacao>> ObterTodasAsTransacoesAsync(CancellationToken cancellationToken);

        Task AdicionaTransacaoAsync(Transacao transacao);

        Task<(List<Transacao> Dados, int TotalRegistros)> FiltrarTransacoesAsync
            (
                DateTime? dataInicio,
                DateTime? dataFinal,
                Guid? contaId,
                Guid? categoriaId,
                TipoTransacao? tipoTransacao,
                int pagina,
                int tamanhoPagina,
                CancellationToken cancellationToken
            );

        void AtualizaTransacao(Transacao transacao);

        void RemoveTransacao(Transacao transacao);
    }
}
