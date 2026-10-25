using ControleFinanceiro.Application.Categorias.Command.Atualizar;
using ControleFinanceiro.Application.Categorias.Command.Registra;
using ControleFinanceiro.Application.Categorias.Command.Remover;
using ControleFinanceiro.Application.Categorias.Query.Listar;
using ControleFinanceiro.Application.Categorias.Query.PesquisarPorId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Registra([FromBody] RegistraCategoriaRequest request)
        {
            var resultado = await _mediator.Send(request);

            return CreatedAtAction(nameof(Registra), new {id = resultado.Id },resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ListarCategorias()
        {
            return Ok(await _mediator.Send(new ListarTodasAsTransacoesRequest()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            var resultado = await _mediator.Send(new PesquisaPorIdRequest
            {
                Id = id
            });

            if(resultado == null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCategoria(Guid id, AtualizarCategoriaRequest request)
        {
            request.Id = id;

            await _mediator.Send(request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategoria(Guid id)
        {
            var sucesso = await _mediator.Send(new RemoverCategoriaRequest
            {
                Id = id
            });
            return NoContent();
        }
    }
}
