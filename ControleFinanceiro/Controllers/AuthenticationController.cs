using ControleFinanceiro.Application.Authentication.DTO;
using ControleFinanceiro.Application.Authentication.Login;
using ControleFinanceiro.Application.Authentication.Refresh;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginRequest request)
        {
            var resultado = await _mediator.Send(request);
            return Ok(resultado);
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<TokenDto>> Refresh(RefreshRequest request)
        {
            var resultado = await _mediator.Send(request);
            return Ok(resultado);
        }
    }
}
