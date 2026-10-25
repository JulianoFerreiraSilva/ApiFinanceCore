using ControleFinanceiro.Application.Common.Pagination;
using ControleFinanceiro.Application.Transacoes.DTO;
using ControleFinanceiro.Domain.Enums;
using MediatR;

namespace ControleFinanceiro.Application.TransacaoApplication.Queries.Filtrar
{
    public class FiltrarTransacoesRequest : PaginationRequest, IRequest<PagedResult<TransacaoResumoDto>>
    {
        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public Guid? ContaId { get; set; }

        public Guid? CategoriaId { get; set; }

        public TipoTransacao? TipoTransacao { get; set; }
    }
}
