using Magma3.NotaFiscal.Application.DTOs;
using Magma3.NotaFiscal.Domain.Repositories;
using MediatR;

namespace Magma3.NotaFiscal.Application.Queries.BuscarNotaFiscalPeloUId
{
    public class BuscarNotaFiscalPeloUIdQueryHandler : IRequestHandler<BuscarNotaFiscalPeloUIdQuery, NotaFiscalViewModel>
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;

        public BuscarNotaFiscalPeloUIdQueryHandler(INotaFiscalRepository notaFiscalRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;
        }

        public async Task<NotaFiscalViewModel> Handle(BuscarNotaFiscalPeloUIdQuery request, CancellationToken cancellationToken)
        {
            var notaFiscal = await _notaFiscalRepository.BuscarNotaFiscalPeloUIdAsNoTrackingAsync(request.NotaFiscalUId, cancellationToken);

            if (notaFiscal == null) return null;

            var notasFiscaisViewModel = NotaFiscalViewModel.FromEntity(notaFiscal);

            return notasFiscaisViewModel;
        }
    }
}