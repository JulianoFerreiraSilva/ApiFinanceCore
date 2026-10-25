using ControleFinanceiro.Application.DashboardApplication.Queries;
using ControleFinanceiro.Application.DashboardApplication.Queries.Dashboard;
using ControleFinanceiro.Application.DashboardApplication.Queries.Executivo;
using ControleFinanceiro.Application.DashboardApplication.Queries.GastosPorCategoria;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _iMediator;

        public DashboardController(IMediator iMediator)
        {
            _iMediator = iMediator;
        }

        [HttpGet("resumo")]
        public async Task<IActionResult> ResumoDashboard()
        {
            var result = await _iMediator.Send(new DashboardFinanceiroRequest());

            return Ok(result);
        }

        [HttpGet("gastos-por-categoria")]
        public async Task<IActionResult> GastosPorCategoria([FromQuery] GastosPorCategoriaRequest request)
        {
            var result = await _iMediator.Send(request);
            return Ok(result);
        }

        [HttpGet("executivo")]
        public async Task<IActionResult> DashboardExecutivo()
        {
            var result = await _iMediator.Send(new DashboardExecutivoRequest());

            return Ok(result);
        }
    }
}
