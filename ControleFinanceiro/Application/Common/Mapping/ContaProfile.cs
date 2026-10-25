using AutoMapper;
using ControleFinanceiro.Application.Contas.Command.Registra;
using ControleFinanceiro.Application.Contas.Queries.Listar;
using ControleFinanceiro.Application.Contas.Queries.PesquisaPorId;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Common.Mapping
{
    public class ContaProfile : Profile
    {
        public ContaProfile()
        {
            CreateMap<Conta, RegistraContaResponse>();
            CreateMap<Conta, PesquisaContaPorIdResponse>();
            CreateMap<Conta, ListarContasResponse>();
        }
    }
}
