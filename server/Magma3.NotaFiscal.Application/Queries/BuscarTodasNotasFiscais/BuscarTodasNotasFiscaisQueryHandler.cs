using Magma3.NotaFiscal.Application.DTOs;
using Magma3.NotaFiscal.Domain.Entities;
using Magma3.NotaFiscal.Domain.Repositories;
using MediatR;

namespace Magma3.NotaFiscal.Application.Queries.BuscarTodasNotasFiscais
{
    public class BuscarTodasNotasFiscaisQueryHandler : IRequestHandler<BuscarTodasNotasFiscaisQuery, List<NotaFiscalViewModel>>
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;

        public BuscarTodasNotasFiscaisQueryHandler(INotaFiscalRepository notaFiscalRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;
        }

        public async Task<List<NotaFiscalViewModel>> Handle(BuscarTodasNotasFiscaisQuery request, CancellationToken cancellationToken)
        {
            var notasFiscais = await _notaFiscalRepository.BuscarTodasNotasFiscaisAsync(cancellationToken);

            var notasFiscaisViewModel = notasFiscais
                .Select(x => NotaFiscalViewModel.FromEntity(x))
                .ToList();

            return notasFiscaisViewModel;
        }
    }
}