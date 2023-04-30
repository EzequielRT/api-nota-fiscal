using Magma3.NotaFiscal.Application.DTOs;
using MediatR;

namespace Magma3.NotaFiscal.Application.Queries.BuscarTodasNotasFiscais
{
    public class BuscarTodasNotasFiscaisQuery : IRequest<List<NotaFiscalViewModel>>
    {
    }
}