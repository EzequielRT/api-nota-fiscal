using Magma3.NotaFiscal.Application.DTOs;
using Magma3.NotaFiscal.Application.Mediator.Message;

namespace Magma3.NotaFiscal.Application.Queries.BuscarNotaFiscalPeloUId
{
    public class BuscarNotaFiscalPeloUIdQuery : Command
    {
        public BuscarNotaFiscalPeloUIdQuery(Guid notaFiscalUId)
        {
            NotaFiscalUId = notaFiscalUId;
        }

        public Guid NotaFiscalUId { get; set; }

        public NotaFiscalViewModel NotaFiscal { get; private set; }

        public void SetNotaFiscal(NotaFiscalViewModel notaFiscal) => NotaFiscal = notaFiscal;
    }
}