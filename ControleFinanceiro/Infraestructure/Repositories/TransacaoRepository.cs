using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Enums;
using ControleFinanceiro.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infraestructure.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly AppDbContext _cont;

        public TransacaoRepository(AppDbContext context)
        {
            _cont = context;
        }
        public async Task AdicionaTransacaoAsync(Transacao transacao)
        {
            await _cont.Transacoes.AddAsync(transacao);
        }

        public void AtualizaTransacao(Transacao transacao)
        {
            _cont.Transacoes.Update(transacao);
        }

        public async Task<(List<Transacao> Dados, int TotalRegistros)> FiltrarTransacoesAsync(DateTime? dataInicio, DateTime? dataFinal, 
            Guid? contaId, Guid? categoriaId, TipoTransacao? tipoTransacao, int pagina, int tamanhoPagina, CancellationToken cancellationToken)
        {
            IQueryable<Transacao> query = _cont.Transacoes.AsNoTracking().Include(t => t.Conta).Include(t => t.Categoria);

            if(dataInicio.HasValue)
                query = query.Where(t => t.DataTransacao >= dataInicio.Value);

            if(dataFinal.HasValue)
                query = query.Where(t => t.DataTransacao <= dataFinal.Value);

            if(contaId.HasValue)
                query = query.Where(t => t.ContaId == contaId.Value);

            if(categoriaId.HasValue)
                query = query.Where(t => t.CategoriaId == categoriaId.Value);

            if(tipoTransacao.HasValue)
                query = query.Where(t => t.TipoTransacao == tipoTransacao.Value);

            var totalRegistros = await query.CountAsync(cancellationToken);

            var dados = await query.OrderByDescending(t => t.DataTransacao).
                Skip((pagina - 1) * tamanhoPagina).Take(tamanhoPagina).ToListAsync(cancellationToken);

            return (dados, totalRegistros);
        }

        public async Task<List<Transacao>> ObterTodasAsTransacoesAsync(CancellationToken cancellationToken)
        {
            var retorno = await _cont.Transacoes.AsNoTracking().Include(t => t.Conta).
                Include(t => t.Categoria).OrderByDescending(t => t.DataTransacao).
                ToListAsync(cancellationToken);
            return retorno;
                
        }

        public async Task<Transacao?> ObterTransacaoPorIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _cont.Transacoes.AsNoTracking().Include(t => t.Conta)
                .Include(t => t.Categoria).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Transacao>> ObterTransacoesDoMesAtualAsync(CancellationToken cancellationToken)
        {
            var agoraUtc = DateTime.UtcNow;

            var inicioMesUtc = new DateTime(agoraUtc.Year, agoraUtc.Month,1,0,0,0,DateTimeKind.Utc);

            var inicioProximoMesUtc = inicioMesUtc.AddMonths(1);

            return await _cont.Transacoes.AsNoTracking().Include(t => t.Conta).Include(t => t.Categoria)
                .Where(t => t.DataTransacao >= inicioMesUtc && t.DataTransacao < inicioProximoMesUtc).ToListAsync(cancellationToken);
        }

        public async Task<List<Transacao>> ObterTransacoesPorPeriodoAsync(DateTime? dataInicio, DateTime? dataFinal)
        {
            var query = _cont.Transacoes.AsNoTracking().Include(t => t.Categoria).
                Where(t => t.TipoTransacao == TipoTransacao.Despesa);
            if (dataInicio.HasValue)
            {
                query = query.Where(t => t.DataTransacao >= dataInicio.Value);
            }

            if (dataFinal.HasValue)
            {
                query = query.Where(t => t.DataTransacao <= dataFinal.Value);
            }

            return await query.ToListAsync();
        }

        public void RemoveTransacao(Transacao transacao)
        {
            _cont.Transacoes.Remove(transacao);
        }
    }
}
