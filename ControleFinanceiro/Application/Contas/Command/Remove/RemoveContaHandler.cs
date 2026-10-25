using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Application.Common.Interfaces.UnitOfWork;
using MediatR;

namespace ControleFinanceiro.Application.Contas.Command.Remove
{
    public class RemoveContaHandler : IRequestHandler<RemoveContaRequest, bool>
    {
        private readonly IContaRepository _contaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveContaHandler(IContaRepository contaRepository, IUnitOfWork unitOfWork)
        {
            _contaRepository = contaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(RemoveContaRequest request, CancellationToken cancellationToken)
        {
            var conta = await _contaRepository.ObterContaPorIdAsync(request.Id, cancellationToken);
            if(conta == null)
            {
                return false;
            }

            conta.Ativa = false;
            conta.DataAtualizacao = DateTime.UtcNow;

            _contaRepository.AtualizaConta(conta);
            await _unitOfWork.SalvaInsercoesAlteracoesAsync(cancellationToken);

            return true;    
        }
    }
}
