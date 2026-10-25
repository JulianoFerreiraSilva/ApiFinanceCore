using ControleFinanceiro.Application.TransacaoApplication.Queries.Listar;
using ControleFinanceiro.Application.TransacaoApplication.Command.Registra;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ControleFinanceiro.Application.TransacaoApplication.Queries.Pesquisar;
using ControleFinanceiro.Application.TransacaoApplication.Command.Atualiza;
using ControleFinanceiro.Application.TransacaoApplication.Command.Remove;
using ControleFinanceiro.Application.TransacaoApplication.Queries.Filtrar;
using Microsoft.AspNetCore.Authorization;

namespace ControleFinanceiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListaTransacoes()
        {
            var result = await _mediator.Send(new ListasTodasAsTransacoesRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PesquisaTransacaoPorId(Guid id)
        {
            var result = await _mediator.Send(new PesquisarTransacoesPorIdRequest { Id = id });

            return Ok(result);
        }

        [HttpGet("filtrar")]
        public async Task<IActionResult> FiltrarTransacoes([FromQuery] FiltrarTransacoesRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
        
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> RegistraTransacao([FromBody] RegistraTransacaoRequest request)
        {
            var result = await _mediator.Send(request);

            return CreatedAtAction(nameof(RegistraTransacao), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizaTransacao(Guid id, [FromBody] AtualizaTransacaoRequest request)
        {
            request.Id = id;
            await _mediator.Send(request);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverTransacao(Guid id)
        {
            await _mediator.Send(new RemoveTransacaoRequest { Id = id });

            return NoContent();
        }
    }
}
