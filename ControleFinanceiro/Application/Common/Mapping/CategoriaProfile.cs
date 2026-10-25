using AutoMapper;
using ControleFinanceiro.Application.Categorias.Command.Registra;
using ControleFinanceiro.Application.Categorias.Query.Listar;
using ControleFinanceiro.Application.Categorias.Query.PesquisarPorId;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Common.Mapping
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, ListarCategoriasResponse>();
            CreateMap<Categoria, PesquisaPorIdRespose>();
            CreateMap<Categoria, RegistraCategoriaResponse>();
        }
    }
}
