using AutoMapper;
using ControleFinanceiro.Application.Common.Interfaces.Repositories;
using ControleFinanceiro.Application.Common.Interfaces.UnitOfWork;
using ControleFinanceiro.Domain.Entities;
using MediatR;

namespace ControleFinanceiro.Application.Categorias.Command.Registra;

public class RegistraCategoriaHandler : IRequestHandler<RegistraCategoriaRequest, RegistraCategoriaResponse>
{
    private readonly ICategoriaRepository _categoriaRepositorio;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegistraCategoriaHandler(ICategoriaRepository categoriaRepositorio, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _categoriaRepositorio = categoriaRepositorio;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<RegistraCategoriaResponse> Handle(RegistraCategoriaRequest request, CancellationToken cancellationToken)
    {
        var categoria = new Categoria
        {
            Id = Guid.NewGuid(),
            Nome = request.Nome.Trim(),
            Descricao = request.Descricao,
            Ativa = true,
            DataCriacao = DateTime.UtcNow
        };

        await _categoriaRepositorio.AdicionaCategoria(categoria);

        await _unitOfWork.SalvaInsercoesAlteracoesAsync(cancellationToken);

        return _mapper.Map<RegistraCategoriaResponse>(categoria);
    }
}