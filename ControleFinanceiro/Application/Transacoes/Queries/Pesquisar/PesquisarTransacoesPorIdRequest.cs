using ControleFinanceiro.Application.Transacoes.DTO;
using MediatR;

namespace ControleFinanceiro.Application.TransacaoApplication.Queries.Pesquisar
{
    public class PesquisarTransacoesPorIdRequest : IRequest<TransacaoDetalheDto>
    {
        public Guid Id { get; set; }
    }
}
