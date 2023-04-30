using Magma3.NotaFiscal.Application.Commands.RegistrarNotaFiscal;
using Magma3.NotaFiscal.Application.Queries.BuscarNotaFiscalPeloUId;
using Magma3.NotaFiscal.Application.Queries.BuscarTodasNotasFiscais;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Magma3.NotaFiscal.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotaFiscalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("notas-fiscais/registrar")]
        public async Task<ActionResult> RegistrarNotaFiscal([FromBody] RegistrarNotaFiscalCommand command, CancellationToken cancellationToken)
        {
            Guid? uId = await _mediator.Send(command, cancellationToken);

            if (uId == null)
                return BadRequest();

            return CreatedAtAction(nameof(BuscarNotaFiscalPeloUId), new { notaFiscalUId = uId }, command);
        }


        [HttpGet]
        [Route("notas-fiscais/buscar-todas")]
        public async Task<ActionResult> BuscarTodasNotasFiscais(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new BuscarTodasNotasFiscaisQuery(), cancellationToken));
        }

        [HttpGet]
        [Route("notas-fiscais/buscar-pelo-uid/{notaFiscalUId}")]
        public async Task<ActionResult> BuscarNotaFiscalPeloUId([FromRoute] Guid notaFiscalUId, CancellationToken cancellationToken)
        {
            var notaFiscal = await _mediator.Send(new BuscarNotaFiscalPeloUIdQuery(notaFiscalUId), cancellationToken);

            if (notaFiscal == null) return NotFound();

            return Ok(notaFiscal);
        }
    }
}