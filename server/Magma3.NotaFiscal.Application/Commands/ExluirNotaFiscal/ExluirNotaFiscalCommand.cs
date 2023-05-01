using MediatR;

namespace Magma3.NotaFiscal.Application.Commands.ExluirNotaFiscal
{
    public class ExluirNotaFiscalCommand : IRequest<bool>
    {
        public ExluirNotaFiscalCommand(Guid notaFiscalUId)
        {
            NotaFiscalUId = notaFiscalUId;
        }

        public Guid NotaFiscalUId { get; set; }
    }
}