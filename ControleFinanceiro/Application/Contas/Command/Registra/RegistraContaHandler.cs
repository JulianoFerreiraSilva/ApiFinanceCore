using AutoMapper;
using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Application.Common.Interfaces.UnitOfWork;
using ControleFinanceiro.Domain.Entities;
using MediatR;

namespace ControleFinanceiro.Application.Contas.Command.Registra
{
    public class RegistraContaHandler : IRequestHandler<RegistraContaRequest, RegistraContaResponse>
    {
        private readonly IContaRepository _contaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegistraContaHandler(IContaRepository contaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _contaRepository = contaRepository;
            _unitOfWork = unitOfWork;
        }        

        public async Task<RegistraContaResponse> Handle(RegistraContaRequest request, CancellationToken cancellationToken)
        {
            var conta = new Conta
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome.Trim(),
                TipoConta = request.TipoConta,
                SaldoInicial = request.SaldoInicial,
                SaldoAtual = request.SaldoInicial,
                Ativa = true,
                DataCriacao = DateTime.UtcNow
            };

            await _contaRepository.AdicionaConta(conta);
            await _unitOfWork.SalvaInsercoesAlteracoesAsync(cancellationToken);

            return _mapper.Map<RegistraContaResponse>(conta);
        }
    }
}
