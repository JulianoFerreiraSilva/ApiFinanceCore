using AutoMapper;
using ControleFinanceiro.Application.TransacaoApplication.Queries.Listar;
using ControleFinanceiro.Application.Transacoes.DTO;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Common.Mapping
{
    public class TransacaoProfile : Profile
    {
        public TransacaoProfile()
        {
            CreateMap<Transacao, TransacaoResumoDto>()
                .ForMember(trans => trans.ContaNome, opt => opt.MapFrom(src => src.Conta.Nome))
                .ForMember(trans => trans.CategoriaNome, opt => opt.MapFrom(src => src.Categoria.Nome));

            CreateMap<Transacao, TransacaoDetalheDto>()
                .ForMember(trans => trans.ContaNome, opt => opt.MapFrom(src => src.Conta.Nome))
                .ForMember(trans => trans.CategoriaNome, opt => opt.MapFrom(src => src.Categoria.Nome));

            CreateMap<Transacao, ListarTodasAsTransacoesResponse>()
                .ForMember( trans => trans.NomeConta, opt => opt.MapFrom(origem => origem.Conta.Nome))
                .ForMember( trans => trans.NomeCategoria, opt => opt.MapFrom(origem => origem.Categoria.Nome));
        }
    }
}
