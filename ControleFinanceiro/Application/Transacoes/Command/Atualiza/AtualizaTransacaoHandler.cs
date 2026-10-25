using ControleFinanceiro.Domain.Enums;
using ControleFinanceiro.Domain.Entities;
using MediatR;
using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Application.Common.Interfaces.UnitOfWork;
using ControleFinanceiro.Application.Common.Exceptions;

namespace ControleFinanceiro.Application.TransacaoApplication.Command.Atualiza
{
    public class AtualizaTransacaoHandler : IRequestHandler<AtualizaTransacaoRequest>
    {
        private readonly ITransacaoRepository _tRepository;
        private readonly IContaRepository _cRepository;
        private readonly ICategoriaRepository _catRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AtualizaTransacaoHandler(ITransacaoRepository tRepository, IContaRepository cRepository, ICategoriaRepository catRepository, IUnitOfWork unitOfWork)
        {
            _tRepository = tRepository;
            _cRepository = cRepository;
            _catRepository = catRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AtualizaTransacaoRequest request, CancellationToken cancellationToken)
        {
            var transacao = await _tRepository.ObterTransacaoPorIdAsync(request.Id, cancellationToken);

            if (transacao is null)
                throw new NotFoundException("Transação ", request.Id);

            var conta = await _cRepository.ObterContaPorIdAsync(request.ContaId, cancellationToken);

            if (conta is null)
                throw new NotFoundException("Conta ", request.ContaId);

            var categoria = await _catRepository.ObterCategoriaPorIdAsync(request.CategoriaId);

            if (categoria is null)
                throw new NotFoundException("Categoria ", request.CategoriaId);

            EstornaTransacao(conta, transacao);

            transacao.Descricao = request.Descricao;
            transacao.Valor = request.Valor;
            transacao.DataTransacao = request.DataTransacao;
            transacao.TipoTransacao = request.TipoTransacao;
            transacao.ContaId = request.ContaId;
            transacao.CategoriaId = request.CategoriaId;
            transacao.DataAtualizacao = DateTime.UtcNow;

            AplicaTransacao(conta, transacao.TipoTransacao, transacao.Valor);

            _tRepository.AtualizaTransacao(transacao);

            await _unitOfWork.SalvaInsercoesAlteracoesAsync();
        }

        private static void EstornaTransacao(Conta conta, Transacao transacao)
        {
            if (transacao.TipoTransacao == TipoTransacao.Receita)
                conta.SaldoAtual -= transacao.Valor;

            if (transacao.TipoTransacao == TipoTransacao.Despesa)
                conta.SaldoAtual += transacao.Valor;
        }

        private static void AplicaTransacao(Conta conta, TipoTransacao tipoTransacao, decimal valor)
        {
            if (tipoTransacao == TipoTransacao.Receita)
                conta.SaldoAtual += valor;

            if (tipoTransacao == TipoTransacao.Despesa)
                conta.SaldoAtual -= valor;
        }

    }
}
