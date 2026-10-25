using ControleFinanceiro.Application.Common.Exceptions;
using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Application.Common.Interfaces.UnitOfWork;
using MediatR;

namespace ControleFinanceiro.Application.Contas.Command.Atualiza
{
    public class AtualizaContaHandler : IRequestHandler<AtualizaContaRequest>
    {
        private readonly IContaRepository _contaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AtualizaContaHandler(IContaRepository contaRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _contaRepository = contaRepository;
        }

        public async Task Handle(AtualizaContaRequest request, CancellationToken cancellationToken)
        {
            var conta = await _contaRepository.ObterContaPorIdAsync(request.Id, cancellationToken);

            if(conta == null)
            {
                throw new NotFoundException("Conta", request.Id);
            }

            conta.Nome = request.Nome;
            conta.TipoConta = request.TipoConta;
            conta.SaldoAtual = request.SaldoAtual;
            conta.DataAtualizacao = DateTime.UtcNow;

            _contaRepository.AtualizaConta(conta);
            await _unitOfWork.SalvaInsercoesAlteracoesAsync(cancellationToken);

            return;
        }
    }
}
