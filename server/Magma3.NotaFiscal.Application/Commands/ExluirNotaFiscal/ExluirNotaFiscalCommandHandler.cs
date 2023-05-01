using Magma3.NotaFiscal.Infra.Data.UoW;
using MediatR;

namespace Magma3.NotaFiscal.Application.Commands.ExluirNotaFiscal
{
    public class ExluirNotaFiscalCommandHandler : IRequestHandler<ExluirNotaFiscalCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public ExluirNotaFiscalCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(ExluirNotaFiscalCommand request, CancellationToken cancellationToken)
        {
            var notaFiscal = await _uow.NotasFiscais.BuscarNotaFiscalPeloUIdAsync(request.NotaFiscalUId, cancellationToken);

            if (notaFiscal == null) return false;

            notaFiscal.Excluir();

            return await _uow.CompleteAsync();
        }
    }
}