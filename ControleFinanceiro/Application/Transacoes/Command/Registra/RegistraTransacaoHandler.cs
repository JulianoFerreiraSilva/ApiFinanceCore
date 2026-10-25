using ControleFinanceiro.Application.Common.Exceptions;
using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Application.Common.Interfaces.UnitOfWork;
using ControleFinanceiro.Domain.Enums;
using MediatR;

namespace ControleFinanceiro.Application.TransacaoApplication.Command.Registra
{
    public class RegistraTransacaoHandler : IRequestHandler<RegistraTransacaoRequest, RegistraTransacaoResponse>
    {
        private readonly ITransacaoRepository _TRepository;
        private readonly IContaRepository _CRepository;
        private readonly ICategoriaRepository _CatRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public RegistraTransacaoHandler(ITransacaoRepository tRepository, IContaRepository cRepository, ICategoriaRepository catRepository, IUnitOfWork unitOfWork)
        {
            _TRepository = tRepository;
            _CRepository = cRepository;
            _CatRepository = catRepository;
            _UnitOfWork = unitOfWork;
        }

        public async Task<RegistraTransacaoResponse> Handle(RegistraTransacaoRequest request, CancellationToken cancellationToken)
        {
            var conta = await _CRepository.ObterContaPorIdAsync(request.ContaId, cancellationToken);

            if(conta is null)
            {
                throw new NotFoundException("Conta ", request.ContaId);
            }

            var categoria = await _CatRepository.ObterCategoriaPorIdAsync(request.CategoriaId);

            if(categoria is null)
            {
                throw new NotFoundException("Categoria ", request.CategoriaId);
            }

            switch (request.TipoTransacao)
            {
                case TipoTransacao.Receita:
                    conta.SaldoAtual += request.Valor;
                    break;

                case TipoTransacao.Despesa:
                    conta.SaldoAtual -= request.Valor;
                    break;
            }

            var dataTansacaoUtc = request.DataTransacao.Kind switch
            {
                DateTimeKind.Utc => request.DataTransacao,
                DateTimeKind.Local => request.DataTransacao.ToUniversalTime(),
                DateTimeKind.Unspecified => DateTime.SpecifyKind(request.DataTransacao, DateTimeKind.Utc),

                _ => request.DataTransacao
            };

            var transacao = new Domain.Entities.Transacao
            {
                Id = Guid.NewGuid(),
                Descricao = request.Descricao,
                Valor = request.Valor,
                DataTransacao = dataTansacaoUtc,
                TipoTransacao = request.TipoTransacao,
                ContaId = request.ContaId,
                CategoriaId = request.CategoriaId,
                DataCriacao = DateTime.UtcNow  
            };

            await _TRepository.AdicionaTransacaoAsync(transacao);
            await _UnitOfWork.SalvaInsercoesAlteracoesAsync(cancellationToken);

            return new RegistraTransacaoResponse
            {
                Id = transacao.Id,
                Descricao = transacao.Descricao,
                Valor = transacao.Valor,
                DataTransacao = transacao.DataTransacao,
                TipoTransacao = transacao.TipoTransacao,
                ContaId = transacao.ContaId,
                CategoriaId = transacao.CategoriaId,
                DataCriacao = transacao.DataCriacao
            };
        }
    }
}
