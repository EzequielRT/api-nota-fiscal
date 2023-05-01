using Microsoft.AspNetCore.Mvc;

namespace Magma3.NotaFiscal.Api.Controllers
{
    public abstract class ApiController : ControllerBase 
    {
        protected ActionResult ResponseApiOk(object? result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new 
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = ObterErros()
            });
        }

        protected ActionResult ResponseApiCreatedAtAction(string? actionName, object? routeValues, object? result = null)
        {
            if (OperacaoValida())
            {
                return CreatedAtAction(actionName, routeValues, new { success = true, data = result });
            }

            return BadRequest(new
            {
                success = false,
                errors = ObterErros()
            });
        }        

        protected ActionResult ResponseApiNotFound()
        {
            return NotFound(new
            {
                success = false,
                errors = ObterErros()
            });
        }

        protected bool OperacaoValida()
        {
            // minhas validações
            return true;
        }

        protected string ObterErros()
        {
            return "Ocorreu um erro!";
        }
    }
}