using Magma3.NotaFiscal.Application.DTOs;
using Magma3.NotaFiscal.Application.Mediator.Message;

namespace Magma3.NotaFiscal.Application.Queries.BuscarTodasNotasFiscais
{
    public class BuscarTodasNotasFiscaisQuery : Command
    {
        public List<NotaFiscalViewModel> NotasFiscais { get; private set; }

        public void SetNotasFiscais(List<NotaFiscalViewModel> notasFiscais) => NotasFiscais = notasFiscais;
    }
}