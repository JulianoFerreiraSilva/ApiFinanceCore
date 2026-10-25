using AutoMapper;
using ControleFinanceiro.Application.Categorias.Query.Listar;
using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using MediatR;

namespace ControleFinanceiro.Application.Categorias.Listar;

public class ObterCategoriasHandler : IRequestHandler<ListarTodasAsTransacoesRequest, List<ListarCategoriasResponse>>
{
    private readonly ICategoriaRepository _repositorio;
    private readonly IMapper _mapper;

    public ObterCategoriasHandler(ICategoriaRepository repositorio, IMapper mapper)
    {
        _mapper = mapper;
        _repositorio = repositorio;
    }

    public async Task<List<ListarCategoriasResponse>> Handle(ListarTodasAsTransacoesRequest request,
        CancellationToken cancellationToken)
    {
        var categorias = await _repositorio.ObterTodasAsCategoriasAsync(cancellationToken);

        return _mapper.Map<List<ListarCategoriasResponse>>(categorias);
    }
}