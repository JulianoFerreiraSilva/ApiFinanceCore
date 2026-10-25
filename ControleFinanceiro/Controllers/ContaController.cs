using ControleFinanceiro.Application.Contas.Command.Atualiza;
using ControleFinanceiro.Application.Contas.Command.Registra;
using ControleFinanceiro.Application.Contas.Command.Remove;
using ControleFinanceiro.Application.Contas.Queries.Listar;
using ControleFinanceiro.Application.Contas.Queries.PesquisaPorId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers
{
    [Route("api/contas")]
    [ApiController]
    public class ContaController : Controller
    {
        private readonly IMediator _mediator;

        public ContaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegistraConta([FromBody] RegistraContaRequest contaRequest)
        {
            var result = await _mediator.Send(contaRequest);

            return CreatedAtAction(nameof(RegistraConta), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> ListaContas()
        {
            return Ok(await _mediator.Send(new ListarContasRequest()));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizaConta([FromBody] AtualizaContaRequest request, Guid id)
        {
            request.Id = id;

            await _mediator.Send(request);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscaContaPorId(Guid id)
        {
            var resultado = await _mediator.Send(new PesquisaContaPorIdRequest {Id =id });

            if(resultado is null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveConta( Guid id)
        {
            var resposta = await _mediator.Send(new RemoveContaRequest
            {
                Id = id
            });

            return resposta ? NoContent() : NotFound();
        }
    }
}
