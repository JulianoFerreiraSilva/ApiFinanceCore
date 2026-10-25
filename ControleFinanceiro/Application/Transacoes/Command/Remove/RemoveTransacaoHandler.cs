using ControleFinanceiro.Application.Common.Exceptions;
using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Application.Common.Interfaces.UnitOfWork;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Enums;
using MediatR;

namespace ControleFinanceiro.Application.TransacaoApplication.Command.Remove
{
    public class RemoveTransacaoHandler : IRequestHandler<RemoveTransacaoRequest>
    {
        private readonly ITransacaoRepository _tRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContaRepository _cRepository;

        public RemoveTransacaoHandler(ITransacaoRepository tRepository, IUnitOfWork unitOfWork, IContaRepository cRepository)
        {
            _tRepository = tRepository;
            _unitOfWork = unitOfWork;
            _cRepository = cRepository;
        }

        public async Task Handle(RemoveTransacaoRequest request, CancellationToken cancellationToken)
        {
            var transacao = await _tRepository.ObterTransacaoPorIdAsync(request.Id, cancellationToken);

            if(transacao is null)
            {
                throw new NotFoundException("Transação ", request.Id);
            }

            var conta = await _cRepository.ObterContaPorIdAsync(transacao.ContaId, cancellationToken);

            if(conta is null)
            {
                throw new NotFoundException("Conta ", transacao.ContaId);
            }

            EstornaTransacao(conta, transacao);

            _tRepository.RemoveTransacao(transacao);
            await _unitOfWork.SalvaInsercoesAlteracoesAsync(cancellationToken);
        }

        private static void EstornaTransacao(Domain.Entities.Conta conta, Transacao transacao)
        {
            if (transacao.TipoTransacao == TipoTransacao.Receita)
                conta.SaldoAtual -= transacao.Valor;

            if(transacao.TipoTransacao == TipoTransacao.Despesa)
                conta.SaldoAtual += transacao.Valor;
        }
    }
}
