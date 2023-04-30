using Magma3.NotaFiscal.Application.DTOs;
using MediatR;

namespace Magma3.NotaFiscal.Application.Queries.BuscarNotaFiscalPeloUId
{
    public class BuscarNotaFiscalPeloUIdQuery : IRequest<NotaFiscalViewModel>
    {
        public BuscarNotaFiscalPeloUIdQuery(Guid notaFiscalUId)
        {
            NotaFiscalUId = notaFiscalUId;
        }

        public Guid NotaFiscalUId { get; set; }
    }
}